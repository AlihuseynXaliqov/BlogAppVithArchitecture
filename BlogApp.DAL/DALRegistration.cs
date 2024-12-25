using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.DAL.Repository.Abstraction;
using BlogApp.DAL.Repository.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace BlogApp.DAL
{
    public static class DALRegistration
    {
        public static void AddDALService(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepositoy,CategoryRepostory>();
        }
    }
}
