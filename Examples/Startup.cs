﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Examples
{
   public class ConnectionStrings
   {
      public string Default { get; set; }
   }

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
         services.AddControllers();
      }

      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
      {
         app.UseDeveloperExceptionPage()
            .UseHttpsRedirection()
            .UseRouting()
            .UseAuthorization()
            .UseEndpoints(endpoints => endpoints.MapControllers());
      }

      //public Startup(IWebHostEnvironment env)
      //{
      //   var builder = new ConfigurationBuilder()
      //       .SetBasePath(env.ContentRootPath)
      //       .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
      //       .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
      //       .AddEnvironmentVariables();
      //   Configuration = builder.Build();
      //}

      //string DefaultApiRoot => "localhost:8000/api";
      //string GetApiRoot(IConfigurationRoot config)
      //   => config.Lookup("ApiRoot").GetOrElse("localhost");

      //// This method gets called by the runtime. Use this method to add services to the container.
      //public void ConfigureServices(IServiceCollection services)
      //{
      //   services.AddMvc();
      //   services.AddLogging();

      //   // configuration
      //   services.AddOptions();
      //   services.Configure<ConnectionStrings>(Configuration.GetSection("ConnectionStrings"));

      //   services.AddLogging(loggingBuilder =>
      //   {
      //      loggingBuilder.AddConfiguration(Configuration.GetSection("Logging"));
      //      loggingBuilder.AddConsole();
      //      loggingBuilder.AddDebug();
      //   });

      //   // relevant for chapter 7
      //   // TODO will have to revisit this
      //   //var ctrlActivator = new ControllerActivator(Configuration);
      //   //services.AddSingleton<IControllerActivator>(ctrlActivator);
      //   //services.AddSingleton<ControllerActivator>(ctrlActivator);
      //   //ctrlActivator.loggerFactory = loggingBuilder; ???

      //   services.AddSwaggerGen();
      //   //services.ConfigureSwaggerGen(options =>
      //   //{
      //   //   options.SingleApiVersion(new Swashbuckle.Swagger.Model.Info
      //   //   {
      //   //      Version = "v1",
      //   //      Title = "Examples",
      //   //      Description = "Examples for Functional Programming in C#",
      //   //   });
      //   //   //options.IncludeXmlComments(pathToDoc);
      //   //   options.DescribeAllEnumsAsStrings();
      //   //});
      //}

      //// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      //public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)//, ControllerActivator ctrlActivator)
      //{                  
      //   //var routeBuilder = new RouteBuilder(app);
      //   //routeBuilder.MapRoute("echo", (context) =>
      //   //{
      //   //   var body = new StreamReader(context.Request.Body).ReadToEnd();

      //   //   // context.GetRouteData().Values
      //   //   return context.Response.WriteAsync(body);
      //   //});

      //   //app.UseRouter(routeBuilder.Build());

      //   var useCases = new UseCaseFactory(Configuration, loggerFactory);

      //   // demonstrates how you can just have all your logic live in functions;
      //   // but this fails to provide many niceties you get when using a Controller
      //   app.Map("/api/transferOn", a => a.Run(async ctx =>
      //   {
      //      BookTransfer transfer = await Parse<BookTransfer>(ctx.Request.Body);
      //      IActionResult result = useCases.PersistTransferOn()(transfer);
      //      await WriteResponse(ctx.Response, result);
      //   }));

      //   MvcOptions.EnableEndpointRouting = false;
      //   app.UseMvcWithDefaultRoute();

      //   app.UseSwagger();
      //   //app.UseSwaggerUi();
      //}

      //private Task WriteResponse(HttpResponse response, IActionResult result)
      //{
      //   throw new NotImplementedException();
      //}

      //private Task<T> Parse<T>(Object body)
      //{
      //   throw new NotImplementedException();
      //}
   }
}
