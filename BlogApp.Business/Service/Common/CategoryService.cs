using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BlogApp.Business.DTOs;
using BlogApp.Business.Exception;
using BlogApp.Business.Service.Interface;
using BlogApp.DAL.Repository.Interface;
using BlogApp.Model.Entities;

namespace BlogApp.Business.Service.Common
{
    public class CategoryService : ICategoryService
    {
        readonly ICategoryRepositoy repository;
        private readonly IMapper mapper;

        public CategoryService(ICategoryRepositoy repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<GetCategoryDto> CreateAsync(CreateCategoryDto dto)
        {
            if (await repository.IsExsist(x => x.Name == dto.Name))
            {
                throw new CategoryNameException("Hal hazirda bu categoriya movcuddur");
            }

            var category = mapper.Map<Category>(dto);
            var newCategory = await repository.CreateAsync(category);
            await repository.SaveChangeAsync();

            return mapper.Map<GetCategoryDto>(newCategory);
        }

        public async Task<GetCategoryDto> Get(int id)
        {
            if (id <= 0)
            {
                throw new ExceptionForId();
            }
            var category = mapper.Map<GetCategoryDto>(repository.GetById(id));

            return category;
        }

        public async Task UpdateAsync(UpdateCategoryDto dto)
        {
            var category = await Get(dto.Id);
            if (await repository.IsExsist(x=>x.Name==dto.Name))  throw new CategoryException();
            category= mapper.Map<GetCategoryDto>(category);
             repository.Update(mapper.Map<Category>(category));
            await repository.SaveChangeAsync();
        }

    }
}
