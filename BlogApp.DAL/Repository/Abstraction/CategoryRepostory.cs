using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.DAL.Context;
using BlogApp.DAL.Repository.Interface;
using BlogApp.Model.Entities;

namespace BlogApp.DAL.Repository.Abstraction
{
    public class CategoryRepostory:Repository<Category>,ICategoryRepositoy
    {
        private readonly BlogDbContext blogDbContext;

        public CategoryRepostory(BlogDbContext blogDbContext):base(blogDbContext)
        {
        }
    }
}
