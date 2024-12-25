using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Business.DTOs;

namespace BlogApp.Business.Service.Interface
{
    public interface ICategoryService
    {
        Task<GetCategoryDto> Get(int id);

        Task<GetCategoryDto> CreateAsync(CreateCategoryDto dto);
        
        Task UpdateAsync(UpdateCategoryDto dto);
    

    }
}
