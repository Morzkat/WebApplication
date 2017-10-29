using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using BuyYourMovie.DataLayer;


namespace BuyYourMovie
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
            
            //singleton behavior
            services.AddSingleton<IConfiguration>(Configuration);

            services.AddCors(options =>
            {
                options.AddPolicy
                ("AllowAnyOrigin",
                    builder => builder
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin()
                   );
            });

            //Contexts
            services.AddDbContext<ActorsContext>(optActorsContext => optActorsContext.UseSqlServer(Configuration.GetConnectionString("localDB")));
            services.AddDbContext<MoviesContext>(optMoviesContext => optMoviesContext.UseSqlServer(Configuration.GetConnectionString("localDB")));
            services.AddDbContext<MovieAndActorsContext>(optMovieAndActorsContext => optMovieAndActorsContext.UseSqlServer(Configuration.GetConnectionString("localDB")));

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("AllowAnyOrigin");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
