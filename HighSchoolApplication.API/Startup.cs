using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DinkToPdf;
using DinkToPdf.Contracts;
using HighSchoolApplication.API.Models;
using HighSchoolApplication.API.Utils;
using HighSchoolApplication.Data;
using HighSchoolApplication.Infrastructure;
using HighSchoolApplication.Infrastructure.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Swashbuckle.AspNetCore.Swagger;

namespace HighSchoolApplication.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddAutoMapper(typeof(Startup));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(cfg =>
            {
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = Configuration["Tokens:Key"].ToSymmetricSecurityKey(),
                    ValidIssuer = Configuration["Tokens:Issuer"],
                    ValidAudience = Configuration["Tokens:Issuer"],
                };
            });
            services.AddAuthorization(options => options.AddPolicy("Admin", policy => policy.RequireClaim("Role", "Administrator")));

            services.Configure<IISOptions>(options =>
            {
                options.ForwardClientCertificate = false;
            });
            services.AddDbContext<HighSchoolContext>(options => options.UseSqlServer(Configuration.GetConnectionString("connectionString")));

            services.AddTransient<IRepository<Roles>, EFRepository<Roles>>();
            services.AddTransient<IRepository<Users>, EFRepository<Users>>();
            services.AddTransient<IRepository<Finances>, EFRepository<Finances>>();
            services.AddTransient<IRepository<Subjects>, EFRepository<Subjects>>();
            services.AddTransient<IRepository<Absents>, EFRepository<Absents>>();
            services.AddTransient<IRepository<Address>, EFRepository<Address>>();
            services.AddTransient<IRepository<Class>, EFRepository<Class>>();
            services.AddTransient<IRepository<Diary>, EFRepository<Diary>>();
            services.AddTransient<IRepository<DocumentCategory>, EFRepository<DocumentCategory>>();
            services.AddTransient<IRepository<Documents>, EFRepository<Documents>>();
            services.AddTransient<IRepository<FinalExams>, EFRepository<FinalExams>>();
            services.AddTransient<IRepository<Lesson>, EFRepository<Lesson>>();
            services.AddTransient<IRepository<UsersClass>, EFRepository<UsersClass>>();
            services.AddTransient<IRepository<School>,EFRepository<School>>();

            services.AddTransient<IRolesRepository, RolesRepository>();
            services.AddTransient<IUsersRepository, UsersRepository>();
            services.AddTransient<IFinancesRepository, FinancesRepository>();
            services.AddTransient<IClassesRepository, ClassesRepository>();
            services.AddTransient<IDocumentsRepository, DocumentsRepository>();
            services.AddTransient<ISubjectsRepository, SubjectsRepository>();
            services.AddTransient<IDiaryRepository, DiaryRepository>();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var context = new CustomAssemblyLoadContext();
            context.LoadUnmanagedLibrary(Path.Combine(Directory.GetCurrentDirectory(), "wkhtmltox\\libwkhtmltox.dll"));

            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "HighSchool API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[]{} }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "api-doc";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseMiddleware<ErrorHandling.CustomExceptionMiddleware>();
            app.UseHttpsRedirection();
            loggerFactory.AddSerilog();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
