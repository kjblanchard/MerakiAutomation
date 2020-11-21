using System;
using System.Collections.Generic;
using MerakiAutomation.Client.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MerakiAutomation.Client.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Rewrite;

namespace MerakiAutomation.Client
{
    public struct AuthorizationPolicyStrings
    {
        public const string MerakiViewGroups = "MerakiView";
        public const string MerakiAdminGroups = "MerakiAdmin";
    }
    

    public class Startup
    {
        #region Configuration

        /// <summary>
        /// Used throughout the app to reference the authorization policies.  This is created in startup.cs
        /// </summary>
        private readonly string _dbUri = "https://localhost:5001/";

        private readonly string _groupString = "groups";


        //List of Azure Ad groups for each Authorization Policy, this is propagated in the startup method
        private readonly List<string> _merakiViewGroups = new List<string>();
        private readonly List<string> _merakiAdminGroups = new List<string>();


        /// <summary>
        /// List of all of the azure ad groups to their guids, for use when making the list of policies
        /// </summary>
        private struct AzureAdGroupStrings
        {
            public static readonly string MerakiAdmin = "26a8b9f9-3c96-4a81-9ba4-60060ae9e05e";
            public static readonly string MerakiView = "fbc91cc1-aec0-4666-8dfe-5790f97d4f67";
            public static readonly string GlobalAdmin = "99b9ef59-6fed-40ba-b7f5-23e8412e6d95";
        }

        #endregion

        public Startup(IConfiguration configuration)
        {
            InitializeGroups();
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddControllersWithViews(options => { });

            //singletons
            services.AddSingleton<WeatherForecastService>();

            //http clients
            services.AddHttpClient<IEmployeeService, EmployeeService>(client =>
                client.BaseAddress = new Uri(_dbUri));
            services.AddHttpClient<IMerakiOrganizationQuery, MerakiOrganizationQuery>();


            services.AddAuthentication(AzureADDefaults.AuthenticationScheme)
                .AddAzureAD(options => Configuration.Bind("AzureAd", options));


            services.AddAuthorization(options =>
            {
                options.AddPolicy(AuthorizationPolicyStrings.MerakiViewGroups,
                    p => { p.RequireClaim(_groupString, _merakiViewGroups); });
                options.AddPolicy(AuthorizationPolicyStrings.MerakiAdminGroups,
                    p => { p.RequireClaim(_groupString, _merakiAdminGroups); });
            });
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            RewriteOptions rewrite = new RewriteOptions().AddRedirect("AzureAD/Account/SignedOut", "/");
            app.UseRewriter(rewrite);

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication(); // UseAuthentication must come before UseAuthorization
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }

        #region Methods

        /// <summary>
        /// Used to initialize all of the different authorization Policies for use in the webpage
        /// </summary>
        private void InitializeGroups()
        {
            AddMerakiViewGroups();
            AddMerakiAdminGroups();
        }

        private void AddMerakiViewGroups()
        {
            _merakiViewGroups.Add(AzureAdGroupStrings.MerakiAdmin);
            _merakiViewGroups.Add(AzureAdGroupStrings.GlobalAdmin);
            _merakiViewGroups.Add(AzureAdGroupStrings.MerakiView);
        }

        private void AddMerakiAdminGroups()
        {
            _merakiAdminGroups.Add(AzureAdGroupStrings.MerakiAdmin);
            _merakiAdminGroups.Add(AzureAdGroupStrings.GlobalAdmin);
        }

        #endregion
    }
}