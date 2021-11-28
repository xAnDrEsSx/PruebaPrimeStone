using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Test.Domain.Administration.Context;


namespace Test.Domain.Administration
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
            //services.AddControllersWithViews();
            services.AddSingleton<ILoggerManager, LoggerManager>();
            services.AddDbContext<TestContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Database")));
        }

    }
}
