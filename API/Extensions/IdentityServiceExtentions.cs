using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using API.Entities.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace API.Extensions
{
    public static class IdentityServiceExtentions
    {
          public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
        {

            //  services.AddDbContext<AppIdentityDbContext>(options =>
            // options.UseSqlServer(config.GetConnectionString("IdentityConnection")           
            // ));

            var builder = services.AddIdentityCore<AppUser>();
            builder = new IdentityBuilder(builder.UserType, typeof(AppRole), builder.Services);
           

           
            builder.AddEntityFrameworkStores<ApplicationDbConext>();
            builder.AddSignInManager<SignInManager<AppUser>>();
            builder.AddRoleValidator<RoleValidator<AppRole>>();
            builder.AddRoleManager<RoleManager<AppRole>>();
             builder.AddEntityFrameworkStores<ApplicationDbConext>();

            // services.AddAuthentication();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Token:Key"])),
                        ValidIssuer = config["Token:Issuer"],
                        ValidateIssuer = true,
                        ValidateAudience = false
                    };
                });
            
             services.AddAuthorization(opt =>
                 
            {
                opt.AddPolicy("ApplicationRole", policy => policy.RequireRole("Applicant", "Admin"));
                opt.AddPolicy("CanAccessApplicantDataRole", policy => policy.RequireRole("Applicant", "Admin", "DSW Regional-Head", "Social-Worker", "Adoption-Staff", "Committee-Member", "Adoption-Head"));
                opt.AddPolicy("ApplicationApprovalRole", policy => policy.RequireRole("DSW-Regional-Head", "Fostercare-Head", "Committee-Member", "Admin"));
                opt.AddPolicy("ApplicationApprovalTrack", policy => policy.RequireRole("DSW-Regional-Head", "Fostercare-Head", "Committee-Member", "Applicant", "Admin"));
                opt.AddPolicy("ApplicationDocumentUpload", policy => policy.RequireRole("DSW-Regional-Head", "Admin", "Applicant", "Admin"));
                opt.AddPolicy("ChildDataRole", policy => policy.RequireRole("Admin", "DSW-Regional-Head", "Social-Worker", "Adoption-Staff", "Committee-Member", "Adoption-Head"));
                opt.AddPolicy("Childapproval", policy => policy.RequireRole("Fostercare-Head", "Committee-Member", "Admin"));
                opt.AddPolicy("DoMatching", policy => policy.RequireRole("Committee-Member", "DSW-Regional-Head", "Admin"));
                opt.AddPolicy("ViewDoMatching", policy => policy.RequireRole("Fostercare-Head", "Committee-Member", "Admin"));
                opt.AddPolicy("SystemManager", policy => policy.RequireRole("Admin"));
            });

            return services;

            // services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //     .AddJwtBearer(options =>
            //     {
            //         options.TokenValidationParameters = new TokenValidationParameters
            //         {
            //             ValidateIssuerSigningKey = true,
            //             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Token:Key"])),
            //             ValidIssuer = config["Token:Issuer"],
            //             ValidateIssuer = true,
            //             ValidateAudience = false
            //         };
            //     });

            
        }
        
    }
}