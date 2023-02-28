using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace NumiClient
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
            services
                .AddControllersWithViews();

            services
                .AddAuthorization()
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Security/Auth/login";
                });

            //services
            //    .AddControllersWithViews(options =>
            //    {
            //        options.Filters.Add<DbContextFilter>();
            //        options.Filters.Add<DbContextErrorFilter>();
            //    })
            //.AddFluentValidation();
            //services.Configure<DbConfiguration>(Configuration.GetSection("DbConfiguration"));
            //
            //services.AddSingleton<IDbConfiguration>(x => x.GetRequiredService<IOptions<DbConfiguration>>().Value);
            //services.AddSingleton<DbContextManager>();
            //services.AddSingleton<IDbContextManager<IDbContext>>(x => x.GetRequiredService<DbContextManager>());
            //services.AddSingleton<IDbContextAccessor>(x => x.GetRequiredService<DbContextManager>());
            //
            ////Repos
            //services.AddSingleton<IUserRepository, UserRepository>();
            //
            ////Service
            //services.AddSingleton<IUserService, UserService>();

            //services.AddTransient<IValidator<LoginRequest>, LoginRequestValidator>();
            //services.AddTransient<IValidator<RegisterRequest>, RegisterRequestValidator>();

            //NOTE : In case we need to handle validation elsewhere
            //services.Configure<ApiBehaviorOptions>(x => x.SuppressModelStateInvalidFilter = true);
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
        }
    }
}
