using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Pidgeon.Core.Mappings.Configuration;
using Pidgeon.Core.Services.Implementations;
using Pidgeon.Core.Services.Interfaces;
using Pidgeon.Data.DatabaseModel;
using Pidgeon.Data.Implementations;
using Pidgeon.Data.Interfaces;
using Pidgeon.Web.Hubs;
using System.Text;

namespace Pidgeon_Messenger
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public static string ConnectionString { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDefaultIdentity<IdentityUser>()
            .AddEntityFrameworkStores<PidgeonContext>()
            .AddDefaultTokenProviders();

            services.AddSignalR();

            services.AddAuthentication()
                .AddCookie()
                .AddJwtBearer(cfg =>
                {
                    cfg.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        ValidIssuer = Configuration["Tokens:Issuer"],
                        ValidAudience = Configuration["Tokens:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"]))
                    };
                });

            ConnectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<PidgeonContext>(options => options.UseSqlServer(ConnectionString));

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            IMapper mapper = MappingProfile.InitializeAutoMapper().CreateMapper();
            services.AddSingleton(mapper);

            services.AddTransient<IDatabaseContext, DatabaseContext>();

            ResolveRepositories(services);
            ResolveServices(services);
        }

        private void ResolveServices(IServiceCollection services)
        {
            services.AddTransient<IUserGroupService, UserGroupService>();
            services.AddTransient<IUserVsgroupService, UserVsgroupService>();
            services.AddTransient<IMessageService, MessageService>();
        }

        private void ResolveRepositories(IServiceCollection services)
        {
            services.AddTransient<IUserGroupRepository, UserGroupRepository>();
            services.AddTransient<IUserVsgroupRepository, UserVsgroupRepository>();
            services.AddTransient<IMessageRepository, MessageRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
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

            app.UseSignalR(options =>
            {
                options.MapHub<GroupHub>("/hub");
            });
        }
    }
}
