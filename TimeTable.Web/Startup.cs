﻿///Fájl neve: Startup.cs
///Dátum: 2018. 04. 25.

namespace TimeTableDesigner.Web
{
    using EroniX.Core;
    using EroniX.Core.Audit;
    using EroniX.Core.Config;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System.Linq;
    using TimeTableDesigner.DataAccess.DataContext;
    using TimeTableDesigner.DataAccess.Repository;
    using TimeTableDesigner.DataAccess.UnitOfWork;
    using TimeTableDesigner.Logic.Services;
    using TimeTableDesigner.Shared.Access;
    using TimeTableDesigner.Shared.Access.Repository;
    using TimeTableDesigner.Shared.Access.Service;
    using TimeTableDesigner.Shared.Access.UnitOfWork;
    using TimeTableDesigner.Shared.Helper.Converter.StringToList;
    using TimeTableDesigner.Shared.Helper.Web;
    using TimeTableDesigner.Web.Data;
    using TimeTableDesigner.Web.Models;
    using TimeTableDesigner.Web.Services;

    /// <summary>
    /// A Startup osztály
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// A konstruktor, ami létrehoz egy Startup objektumok
        /// </summary>
        /// <param name="configuration">A konfiguráció</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// A "Configuration" adattag (GETTER)
        /// </summary>
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// A szolgáltatások konfigurációért felelős függvény
        /// </summary>
        /// <param name="services">A szolgáltatások</param>
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
        /// <summary>
        /// A konfigurációért felelős függvény
        /// </summary>
        /// <param name="app">Az applikáció</param>
        /// <param name="env">A környezet</param>
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
