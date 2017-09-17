using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace OktaWebAPI
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
           
            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                
                c.SwaggerDoc("v1", 
                    new Swashbuckle.AspNetCore.Swagger.Info
                    { Title = "Okta API", Version = "v1", Description="Web Api ( core2) to consume okta API for major Okta workflows", 
                        Contact = new Swashbuckle.AspNetCore.Swagger.Contact { Name="Rakesh Agarwal", Email= "rakesh.agarwal@capgemini.com", Url= "www.capgemini.com" } });
                        });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger(c => c.PreSerializeFilters.Add((swagger, httpReq) => swagger.Host = httpReq.Host.Value));
            app.UseSwaggerUI(t => {
                t.SwaggerEndpoint("/swagger/v1/swagger.json", "This is Okta web api endPoints");
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
