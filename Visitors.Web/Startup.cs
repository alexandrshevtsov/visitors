using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Visitors.Data;
using Visitors.Services;
using Visitors.Services.Contracts;

namespace Visitors.Web
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
            //var connection = @"Server=(local);Initial Catalog=Testim;Persist Security Info=False;User ID=testim;Password=testim123;MultipleActiveResultSets=False;Connection Timeout=30;";
            services.AddDbContext<DbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));
            services.AddTransient<IDataContext, DataContext>();
            services.AddTransient(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddTransient<IVisitorService, VisitorService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
