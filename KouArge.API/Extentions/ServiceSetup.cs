using FluentValidation.AspNetCore;
using KouArge.API.Filters;
using KouArge.Core.Models;
using KouArge.Repository;
using KouArge.Service.Mapping;
using KouArge.Service.Validations;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;

namespace KouArge.API.Modules
{
    public static class ServiceSetup
    {
        public static IServiceCollection RegisterService(this IServiceCollection services)
        {

            services.AddControllers(options => options.Filters.Add(new ValidateFilterAttribute()))
            .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<DepartmentDtoValidator>());

            //services.AddControllers(options => options.Filters.Add(new CustomAuthorizationFilter()));

            services.AddControllers(options =>
            {
                options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
            });

            services.AddAutoMapper(typeof(MapProfile));

            //services.AddScoped(typeof(NotFoundFilter<>));

            services.AddIdentity<AppUser, AppRole>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<AppIdentityDbContext>().AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
              {
                  options.Password.RequireDigit = true;
                  options.Password.RequireLowercase = true;
                  options.Password.RequiredLength = 8;
                  options.Password.RequireNonAlphanumeric = true;
                  options.Password.RequireUppercase = true;

                  options.Lockout.MaxFailedAccessAttempts = 5;
                  options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(60);
                  options.Lockout.AllowedForNewUsers = true;

                  options.User.RequireUniqueEmail = true;
                  options.User.AllowedUserNameCharacters = null;
                  options.SignIn.RequireConfirmedEmail = false;
                  options.SignIn.RequireConfirmedPhoneNumber = false;
              });

            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });
                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                 {{
                        new OpenApiSecurityScheme
                            {
                         Reference = new OpenApiReference
                             {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                     }
                  },
            new string[]{}} });
            });

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen();

            return services;

        }
    }
}
