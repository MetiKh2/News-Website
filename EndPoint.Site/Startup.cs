using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyCms.Application.Interfaces;
using MyCms.Application.Services.Category.Command.AddCategory;
using MyCms.Application.Services.Category.Command.DeleteCategory;
using MyCms.Application.Services.Category.Query.GetCategories;
using MyCms.Application.Services.News.Command.AddNews;
using MyCms.Application.Services.News.Query.GetDetailNewsForAdmin;
using MyCms.Application.Services.News.Query.GetNews;
using MyCms.Application.Services.Roles.Query.GetRoles;
using MyCms.Application.Services.User.Command.AddNewUser;
using MyCms.Application.Services.User.Command.ChangeUserStatus;
using MyCms.Application.Services.User.Command.EditUser;
using MyCms.Application.Services.User.Command.RemoveUser;
using MyCms.Application.Services.User.Query.GetUsers;
using MyCms.Application.Services.User.Query.GetUsersInRole;
using MyCms.Application.Services.User.Query.UserLogin;
using MyCms.Common.Roles;
using MyCms.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyCms.Application.Services.News.Command.DeleteNews;
using MyCms.Application.Services.News.Command.EditNews;
using MyCms.Application.Services.News.Query.GetNewsForSite;
using MyCms.Application.Services.News.Query.GetDetailNewsForSite;
using MyCms.Application.Services.News.Query.GetTopNews;
using MyCms.Application.Services.News.Query.GetOneTopNews;
using MyCms.Application.Services.News.Command.ChangeStatusNews;
using MyCms.Application.Services.News.Command.ShowNewsInSlider;
using MyCms.Application.Services.News.Query.GetNewsInSlider;
using MyCms.Application.Services.News.Query.GetNewsByCategory;
using MyCms.Application.Services.News.Command.ShowInNews;
using MyCms.Application.Services.News.Query.GetNewsInNews;
using MyCms.Application.Services.News.Query.GetNewsOfDay;
using MyCms.Application.Services.News.Command.AddLike;
using MyCms.Application.Services.News.Command.AddDisLike;
using MyCms.Application.Services.News.Query.GetPopularNews;

namespace EndPoint.Site
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
            services.AddAuthorization(options =>
            {
                options.AddPolicy(UserRoles.Admin, policy => policy.RequireRole(UserRoles.Admin));
                options.AddPolicy(UserRoles.Customer, policy => policy.RequireRole(UserRoles.Customer));
                options.AddPolicy(UserRoles.Operator, policy => policy.RequireRole(UserRoles.Operator));
            });



            services.AddAuthentication(options =>
            {
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options =>
            {
                options.LoginPath = new PathString("/Authentication/signIn");
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5.0);
            });



            services.AddScoped<IDatabaseContext, DatabaseContext>(); 
            services.AddScoped<IGetRolesService, GetRolesService>();
            services.AddScoped<IAddNewUserService, AddNewUserService>();
            services.AddScoped<IGetUsersService, GetUsersService>();
            services.AddScoped<IGetUsersInRoleService, GetUsersInRoleService>();
            services.AddScoped<IEditUserService, EditUserService>();
            services.AddScoped<IRemoveUserService, RemoveUserService>();
            services.AddScoped<IChangeUserStatusService, ChangeUserStatusService>();
            services.AddScoped<IAddCategoryService, AddCategoryService>();
            services.AddScoped<IGetCategoriesService, GetCategoriesService>();
            services.AddScoped<IDeleteCategoryService, DeleteCategoryService>();
            services.AddScoped<IUserLoginService, UserLoginService>();
            services.AddScoped<IAddNewsService, AddNewsService>();
            services.AddScoped<IGetNewsService, GetNewsService>();
            services.AddScoped<IDeleteNewsService, DeleteNewsService>(); 
            services.AddScoped<IEditNewsService, EditNewsService>(); 
            services.AddScoped<IGetDetailNewsForAdminService, GetDetailNewsForAdminService>();
            services.AddScoped<IGetTopNewsService, GetTopNewsService>(); 
            services.AddScoped<IGetDetailNewsForSiteService, GetDetailNewsForSiteService>();
            services.AddScoped<IGetNewsForSiteService, GetNewsForSiteService>();
            services.AddScoped<IChangeStatusNewsService, ChangeStatusNewsService>();
            services.AddScoped<IGetOneTopNewsService, GetOneTopNewsService>(); 
            services.AddScoped<IShowNewsInSliderService, ShowNewsInSliderService>(); 
            services.AddScoped<IGetNewsInSliderService, GetNewsInSliderService>();
            services.AddScoped<IGetNewsByCategoryService, GetNewsByCategoryService>();
            services.AddScoped<IShowInNewsService, ShowInNewsService>(); 
            services.AddScoped<IGetNewsInNewsService, GetNewsInNewsService>(); 
            services.AddScoped<IGetNewsOfDayService, GetNewsOfDayService>();
            services.AddScoped<IAddLikeService, AddLikeService>(); 
            services.AddScoped<IAddDisLikeService, AddDisLikeService>();
            services.AddScoped<IGetPopularNewsService, GetPopularNewsService>();

            string ConnectionString = "Data Source=.;Initial Catalog=MyCmsDB;Integrated Security=True;";
            services.AddEntityFrameworkSqlServer().AddDbContext<DatabaseContext>(option => option.UseSqlServer(ConnectionString));
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
