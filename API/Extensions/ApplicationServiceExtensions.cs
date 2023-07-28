using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Data.Identity.Interfaces;
using API.Data.Repositories;
using API.Errors;
using API.Helpers;
using API.Interfaces;
using API.Security.Identity.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {


            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

           
             services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IChildInterface, ChildRepository>();
            services.AddScoped<IUnitOfWorkInterface, UnitOfWork>();

            // services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            // services.AddAutoMapper(typeof(MappingProfiles));
            services.Configure<ApiBehaviorOptions>(options =>
               {
                   options.InvalidModelStateResponseFactory = actionContext =>
                   {
                       var errors = actionContext.ModelState
                           .Where(e => e.Value.Errors.Count > 0)
                           .SelectMany(x => x.Value.Errors)
                           .Select(x => x.ErrorMessage).ToArray();

                       var errorResponse = new ApiValidationErrorResponse
                       {
                           Errors = errors
                       };

                       return new BadRequestObjectResult(errorResponse);
                   };
               });

            return services;
        }
    }
}