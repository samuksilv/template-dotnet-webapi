using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace template.API {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.AddMvc ().SetCompatibilityVersion (CompatibilityVersion.Version_2_2);

            // services.AddEntityFrameworkNpgsql ()
            //     .AddDbContextPool<Context> (opt =>
            //         opt.UseNpgsql (
            //             Configuration.GetConnectionString ("conPostgree"),
            //             o => {
            //                 o.MaxBatchSize (int.MaxValue);
            //                 o.MigrationsAssembly ("EmailServices.Infra");
            //                 //typeof (Context).GetTypeInfo ().Assembly.GetName ().FullName
            //             }
            //         ).UseLazyLoadingProxies ()
            //     );

            services.AddCors (opt =>
                opt.AddPolicy ("AllowAnyOrigin", policy => {
                    policy.AllowAnyHeader ().AllowAnyMethod ().AllowAnyOrigin ();
                }));

            services.Configure<GzipCompressionProviderOptions> (options => {
                options.Level = CompressionLevel.Optimal;
            });

            services.AddResponseCompression (Options => {
                Options.Providers.Add<GzipCompressionProvider> ();
                Options.EnableForHttps = true;
            });

            services.AddLogging (logging => {
                logging.AddConsole ();
                logging.AddDebug ();
            });

            services.AddSwaggerGen (c => {
                c.SwaggerDoc (
                    "v1",
                    new Info {
                        Title = "template API ",
                            Version = "v1"
                    });
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine (AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments (xmlPath);
                // c.ResolveConflictingActions(apiDescription=> apiDescription.First());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            } else {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts ();
            }

            app.UseCors ();
            app.UseSwagger ();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI (c => {
                c.SwaggerEndpoint ("/swagger/v1/swagger.json", "v1");
            });

            app.UseResponseCompression ();
            app.UseHttpsRedirection ();
            app.UseMvc ();
        }
    }
}