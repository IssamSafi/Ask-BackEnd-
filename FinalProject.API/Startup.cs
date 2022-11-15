using FinalProject.core.Common;
using FinalProject.core.Data;
using FinalProject.core.Repository;
using FinalProject.core.Service;
using FinalProject.infra.Common;
using FinalProject.infra.Repository;
using FinalProject.infra.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.API
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



            services.AddAuthentication(opt => {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"))
        };
       });




            services.AddScoped<IDbContext, DbContext>();

            services.AddScoped<IJWTRepository, JWTRepository>();
            services.AddScoped<IJWTService, JWTService>();


            services.AddScoped<IRepository<Categoryf>, CategoryRepository>();
            services.AddScoped<IService<Categoryf>, CategoryService>();
            services.AddScoped<IRepository<Homef>, HomeRepository>();
            services.AddScoped<IService<Homef>, HomeService>();
            services.AddScoped<IRepository<Userf>, UserRepository>();
            services.AddScoped<IService<Userf>, UserService>();
            services.AddScoped<IRepository<Contactusf>, ContactUsRepository>();
            services.AddScoped<IService<Contactusf>, ContactusService>();
            services.AddScoped<IRepository<Aboutusf>, AboutUsRepository>();
            services.AddScoped<IService<Aboutusf>, AboutusService>();
            services.AddScoped<IRepository<Testimonialf>, TestmonialRepository>();
            services.AddScoped<IService<Testimonialf>, TestmonialService>();
            services.AddScoped<IRepository<Asking>, AskingRepository>();
            services.AddScoped<IService<Asking>, AskingService>();
            services.AddScoped<IRepository<CommonQuestion>, CommonQuestionRepository>();
            services.AddScoped<IService<CommonQuestion>, CommonQuestionService>();



            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

    
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
