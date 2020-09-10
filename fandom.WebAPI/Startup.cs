using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using fandom.Model.Models;
using fandom.Model.Requests;
using fandom.WebAPI.Database;
using fandom.WebAPI.Security;
using fandom.WebAPI.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace fandom.WebAPI
{
    public class Startup
    {

        public class AuthOperationFilter : IOperationFilter
        {
            public void Apply(OpenApiOperation operation, OperationFilterContext context)
            {
                var isAuthorized = context.MethodInfo.DeclaringType.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any() ||
                                   context.MethodInfo.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any();
                if (!isAuthorized) return;
                operation.Responses.TryAdd("401", new OpenApiResponse { Description = "Unauthorized" });
                operation.Responses.TryAdd("403", new OpenApiResponse { Description = "Forbidden" });
                var basicSecurityScheme = new OpenApiSecurityScheme()
                {
                    Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "basic" },
                };
                operation.Security.Add(new OpenApiSecurityRequirement()
                {
                    [basicSecurityScheme] = new string[] { }
                });
            }
        }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppCtx>(it => it.UseSqlServer(Configuration.GetConnectionString("SqlString")));

            services.AddAuthentication("BasicAuthentication")
              .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
                c.AddSecurityDefinition("basic",
                    new OpenApiSecurityScheme()
                    {
                        Name = "Authorization",
                        Type = SecuritySchemeType.Http,
                        Scheme = "basic",
                        In = ParameterLocation.Header,
                        Description = "Basic authentication header"
                    });
                c.OperationFilter<AuthOperationFilter>();
            });
            


            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<ICharacterService, CharacterService>();

            services.AddScoped<IEpisodeService, EpisodeService>();
            services.AddScoped<ISeasonService, SeasonService>();
            services.AddScoped<IFamilyService, FamilyService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IPostService, PostService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();


            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });


          //  app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
