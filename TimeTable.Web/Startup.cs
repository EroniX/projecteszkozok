using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using EroniX.Core;
using EroniX.Core.Audit;
using EroniX.Core.Config;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TimeTableDesigner.DataAccess.DataContext;
using TimeTableDesigner.Shared.Access.Repository;
using TimeTableDesigner.Web.Data;
using TimeTableDesigner.Web.Models;
using TimeTableDesigner.Web.Services;
using TimeTableDesigner.DataAccess.Repository;
using TimeTableDesigner.DataAccess.UnitOfWork;
using TimeTableDesigner.Logic.Services;
using TimeTableDesigner.Shared.Access;
using TimeTableDesigner.Shared.Access.Service;
using TimeTableDesigner.Shared.Access.UnitOfWork;
using TimeTableDesigner.Shared.Entity.Domain;
using TimeTableDesigner.Shared.Helper.Converter.StringToList;
using TimeTableDesigner.Shared.Helper.Web;

namespace TimeTableDesigner.Web
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
            services.AddDbContext<SecurityContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<SecurityContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            // Context
            services.AddTransient<ITimeTableAppContextProvider, TimeTableAppContextProvider>();
            services.AddTransient<IAppContextProvider>(c => new TimeTableAppContextProvider());

            // Logging
            services.AddTransient<ILogger, NLogLogger>();

            // Config
            services.AddTransient<IConfig>(c => Config.Create(Configuration.AsEnumerable()));

            // Repositories
            services.AddTransient<IScheduleRepository>(r => new ScheduleRepository(new ScheduleContext(
                new WebHtmlReader(),
                new HtmlTableToListConverter(new NLogLogger(new TimeTableAppContextProvider())),
                new HtmlDropDownToListConverter(new NLogLogger(new TimeTableAppContextProvider())),
                Config.Create(Configuration.AsEnumerable())
            )));
            services.AddTransient<ICourseRepository, CourseRepository>();
            services.AddTransient<ITimeTableRepository, TimeTableRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            // Unit of Work
            services.AddTransient<ITimeTableUnitOfWork, TimeTableUnitOfWork>();
            services.AddTransient<ITimeTableUnitOfWorkFactory>(s => new TimeTableUnitOfWorkFactory("name=DefaultConnection"));

            // Services
            services.AddTransient<ITimeTableService, TimeTableService>();
            services.AddTransient<IWebDataService, WebDataService>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
