using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Clinic.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Clinic.Models;

namespace Clinic
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            //Password Strength Setting
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 6;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;
            });


            //Setting the Account Login page
            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                options.LoginPath = "/Account/Login"; // If the LoginPath is not set here,
                                                      // ASP.NET Core will default to /Account/Login
                options.LogoutPath = "/Account/Logout"; // If the LogoutPath is not set here,
                                                        // ASP.NET Core will default to /Account/Logout
                options.AccessDeniedPath = "/Account/AccessDenied"; // If the AccessDeniedPath is
                                                                    // not set here, ASP.NET Core 
                                                                    // will default to 
                                                                    // /Account/AccessDenied
                options.SlidingExpiration = true;
            });


            services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultUI(UIFramework.Bootstrap4)
             .AddDefaultTokenProviders();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

           CreateRoles(serviceProvider).Wait();

        }

        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            //initializing custom roles   
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            string[] roleNames = { "Admin", "Doctor", "Patient","Assistant","Insurance" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    //create the roles and seed them to the database 
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            ApplicationUser admin = await UserManager.FindByEmailAsync("admin@admin.com");

            if (admin == null)
            {
                admin = new ApplicationUser()
                {
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com",
                    fname="admin",
                    lname="admin"
                };
       

                await UserManager.CreateAsync(admin, "Test@123");
            }
            await UserManager.AddToRoleAsync(admin, "Admin");



            ApplicationUser doctor = await UserManager.FindByEmailAsync("doctor@doctor.com");

            if (doctor == null)
            {
                doctor = new ApplicationUser()
                {
                    UserName = "doctor@doctor.com",
                    Email = "doctor@doctor.com",
                    fname = "doctor",
                    lname = "doctor"
                };
                await UserManager.CreateAsync(doctor, "Test@123");
            }
            await UserManager.AddToRoleAsync(doctor, "Doctor");



            ApplicationUser patient = await UserManager.FindByEmailAsync("patient@patient.com");

            if (patient == null)
            {
                patient = new ApplicationUser()
                {
                    UserName = "patient@patient.com",
                    Email = "patient@patient.com",
                    fname = "patient",
                    lname = "patient"
                };
                await UserManager.CreateAsync(patient, "Test@123");
            }
            await UserManager.AddToRoleAsync(patient, "Patient");



            ApplicationUser assistant = await UserManager.FindByEmailAsync("assistant@assistant.com");

            if (assistant == null)
            {
                assistant = new ApplicationUser()
                {
                    UserName = "assistant@assistant.com",
                    Email = "assistant@assistant.com",
                    fname = "assistant",
                    lname = "assistant"
                };
                await UserManager.CreateAsync(assistant, "Test@123");
            }
            await UserManager.AddToRoleAsync(assistant, "Assistant");



            ApplicationUser insurance = await UserManager.FindByEmailAsync("insurance@insurance.com");

            if (insurance == null)
            {
                insurance = new ApplicationUser()
                {
                    UserName = "insurance@insurance.com",
                    Email = "insurance@insurance.com",
                    fname = "insurance",
                    lname = "insurance"
                };
                await UserManager.CreateAsync(insurance, "Test@123");
            }
            await UserManager.AddToRoleAsync(insurance, "Insurance");









        }



    }
}
