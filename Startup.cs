using Google.Cloud.Diagnostics.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;
using Serilog.Sinks.SystemConsole.Themes;

namespace aspapp2
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
//            Log.Logger = new LoggerConfiguration()
//                .MinimumLevel.Debug()
//                //.WriteTo.Console(new CompactJsonFormatter())
//                //.WriteTo.Console(new CompactJsonFormatter())
//                .WriteTo.Console()
//                .CreateLogger();
            //
            
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string projectId = "lloyd-test";
            string serviceName = "aspapp2";
            string version = "1.0";
            
            services.AddGoogleExceptionLogging(options =>
            {
                options.ProjectId = projectId;
                options.ServiceName = serviceName;
                options.Version = version;
            });
            
            services.AddGoogleTrace(options =>
            {
                options.ProjectId = projectId;
            });
            
            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            string projectId = "lloyd-test";
            loggerFactory.AddGoogle(projectId);
            app.UseGoogleExceptionLogging();
            app.UseGoogleTrace();
            
            //loggerFactory.AddSerilog();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
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
            });
        }
    }
}
