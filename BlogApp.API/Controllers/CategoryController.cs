using System;
using AutoMapper;
using BlogApp.API.DTOs.Category;
using BlogApp.Business.DTOs;
using BlogApp.Business.Exception;
using BlogApp.Business.Service.Interface;
using BlogApp.DAL.Context;
using BlogApp.Model.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly BlogDbContext dbContext;
        private readonly IMapper mapper;
        ICategoryService categoryService;

        public CategoryController(BlogDbContext dbContext, IMapper mapper, ICategoryService categoryService)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.categoryService = categoryService;
        }

        /*[HttpPost]
        public IActionResult Create(CreateCategoryDtos create)
        {
            var category = mapper.Map<Category>(create);
            dbContext.Add(category);
            dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }*/

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] CreateCategoryDto dto)
        {
            try
            {
                return Ok(await categoryService.CreateAsync(dto));
            }
            catch (CategoryNameException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }

        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(categoryService.Get(id));
            }
            catch (ExceptionForId ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest("duzgun islemir");
            }
        }



        /*public IActionResult Get(int id)
        {
            var category = dbContext.categories.FirstOrDefault(c => c.Id == id);
            if (category == null) return StatusCode(StatusCodes.Status404NotFound);
            return StatusCode(StatusCodes.Status200OK, category);

        }*/

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryDto dto)
        {

            try 
            {
                await categoryService.UpdateAsync(dto);
                return Ok();

            }
            catch(CategoryException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (CategoryNameException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

        /*        public IActionResult Update(UpdateCategoryDtos update)
                {
                    var category = dbContext.categories.AsNoTracking().FirstOrDefault(x => x.Id == update.Id);
                    if (category == null) return StatusCode(StatusCodes.Status404NotFound);
                    mapper.Map<Category>(update);
                    dbContext.Update(category);
                    dbContext.SaveChanges();
                    return StatusCode(StatusCodes.Status202Accepted, category);
                }*/

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = dbContext.categories.FirstOrDefault(x => x.Id == id);
            if (category == null) return StatusCode(StatusCodes.Status404NotFound);
            dbContext.categories.Remove(category);
            dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status200OK);
        }

    }
}