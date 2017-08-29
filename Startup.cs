using aspapp2.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Prometheus;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

namespace aspapp2
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .Enrich.FromLogContext()
                .WriteTo.Console(
                    outputTemplate: "RID={RequestId} {Message:lj}{NewLine}{Exception}",
                    standardErrorFromLevel: LogEventLevel.Warning,
                    theme: ConsoleTheme.None)
                .CreateLogger();
            
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
            
            var metricServer = new MetricServer(port: 1234);
            metricServer.Start();
            
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
//            string projectId = "lloyd-test";
//            string serviceName = "aspapp2";
//            string version = "1.0";
//            
//            services.AddGoogleExceptionLogging(options =>
//            {
//                options.ProjectId = projectId;
//                options.ServiceName = serviceName;
//                options.Version = version;
//            });
//            
//            services.AddGoogleTrace(options =>
//            {
//                options.ProjectId = projectId;
//            });
//            
            // Add framework services.
            services.AddMvc(x =>
            {
                x.Filters.Add(typeof(ExceptionFilter));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //string projectId = "lloyd-test";
            //loggerFactory.AddConsole();
            //loggerFactory.AddGoogle(projectId);
            //app.UseGoogleExceptionLogging();
            //app.UseGoogleTrace();
            
            loggerFactory.AddSerilog();

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
