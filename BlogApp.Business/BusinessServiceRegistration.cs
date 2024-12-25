using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Business.DTOs;
using BlogApp.Business.Service.Common;
using BlogApp.Business.Service.Interface;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace BlogApp.Business
{
    public static class BusinessServiceRegistration
    {
        public static void AddBusinessService(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddAutoMapper(typeof(BusinessServiceRegistration));
            services.AddControllers().AddFluentValidation(x=>x.RegisterValidatorsFromAssemblyContaining<CreateCategoryValidator>());
        }
    }
}
