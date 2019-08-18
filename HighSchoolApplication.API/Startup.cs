using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HighSchoolApplication.API.Models;
using HighSchoolApplication.API.Models.Profiles;
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
using Serilog;
using Swashbuckle.AspNetCore.Swagger;

namespace HighSchoolApplication.API
{
    public class Startup
    {
        public string Secret = "secretKey";
        public static string ConnectionString { get; private set; } 
        public Startup(IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.Authority = "http://localhost";
                options.Audience = "http://localhost";
                options.TokenValidationParameters.ValidateLifetime = true;
                options.TokenValidationParameters.ClockSkew = TimeSpan.FromMinutes(0);
                options.TokenValidationParameters.IssuerSigningKey = Secret.ToSymmetricSecurityKey();
            });

            services.AddDbContext<Infrastructure.Models.HighSchoolContext>(options => options.UseSqlServer(Configuration.GetConnectionString("connectionString")));

            services.AddTransient<IRepository<Roles>, EFRepository<Roles>>();
            services.AddTransient<IRolesRepository, RolesRepository>();

            services.AddTransient<IMapper<Absents, AbsentsModel>, AbsentsMapper>();
            services.AddTransient<IMapper<Address, AddressModel>, AddressMapper>();
            services.AddTransient<IMapper<Class, ClassModel>, ClassMapper>();
            services.AddTransient<IMapper<Diary, DiaryModel>, DiaryMapper>();
            services.AddTransient<IMapper<DocumentCategory, DocumentCategoryModel>, DocumentCategoryMapper>();
            services.AddTransient<IMapper<Documents, DocumentsModel>, DocumentsMapper>();
            services.AddTransient<IMapper<FinalExams, FinalExamsModel>, FinalExamsMapper>();
            services.AddTransient<IMapper<Finances, FinancesModel>, FinancesMapper>();
            services.AddTransient<IMapper<Lesson, LessonModel>, LessonMapper>();
            services.AddTransient<IMapper<Roles, RolesModel>, RolesMapper>();
            services.AddTransient<IMapper<School, SchoolModel>, SchoolMapper>();
            services.AddTransient<IMapper<SubjectPoints, SubjectPointsModel>, SubjectPointsMapper>();
            services.AddTransient<IMapper<Subjects, SubjectModel>, SubjectsMapper>();
            services.AddTransient<IMapper<UsersClass,UsersClassModel>, UsersClassMapper>();
            services.AddTransient<IMapper<Users, UsersModel>, UsersMapper>();
            services.AddTransient<IMapper<UsersStatus, UsersStatusModel>, UsersStatusMapper>();
            services.AddTransient<IMapper<UsersSubjectPoints, UsersSubjectPointsModel>, UserSubjectPointsMapper>();
            services.AddTransient<ListMapper<Roles, RolesModel>, RolesListMapper>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", x =>
                {
                    x.RequireClaim("ClaimTypes.Role Enum get values from DB", "Admin");
                });
            });

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
            app.UseMvc();

            ConnectionString = Configuration["ConnectionStrings:connectionString"];
        }
    }
}
