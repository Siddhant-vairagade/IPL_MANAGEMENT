using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using IPL_BALayer.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPL_DALayer.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace IPL_WEBapi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }



        public IConfiguration Configuration { get; }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<IPLdbContext>();
            services.AddTransient(typeof(IGeneric<>), typeof(GenericService<>));



            //postman
            //cors

            services.AddCors(c => c.AddDefaultPolicy(p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));










            //jwt authentication

            /*services.AddAuthentication(Opt =>
            {
                Opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                Opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                Opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).
               AddJwtBearer(Opt =>
               {
               Opt.SaveToken = true;
               Opt.RequireHttpsMetadata = false;
               Opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
               {
               ValidateIssuer = true,
               ValidateAudience = true,
               ValidAudience = Configuration["jwt:ValidAudience"],
               ValidIssuer = Configuration["jwt:ValidAudience"],
               IssuerSigningKey = new
               SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["jwt:sec"]))
               };
            });*/








            // swagger config

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Welcome To IPL Management System",
                });

                /*c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "jwt",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    BearerFormat = "JWT",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                    new OpenApiSecurityScheme
                    {
                        Reference=new OpenApiReference
                        {
                            Type=ReferenceType.SecurityScheme,
                            Id="Bearer"
                        }
                    },
                    new String[]{}
                }

                 });*/

            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "IPL Management System"));
            app.UseCors();
            app.UseRouting();
            /*app.UseAuthentication();*/
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
