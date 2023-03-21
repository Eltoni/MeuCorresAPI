using Microsoft.AspNetCore.Mvc;


namespace DevIO.Api.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection AddApiConfig(this IServiceCollection services)
        {
            services.AddControllers();

           


            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;

            });

            services.AddCors(options =>
            {
                options.AddPolicy("Development",
                    builder =>
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .DisallowCredentials()
                        .AllowAnyHeader());


                options.AddPolicy("Production",
                    builder =>
                        builder
                            .WithMethods("GET")
                            .WithOrigins("http://desenvolvedor.io")
                            .SetIsOriginAllowedToAllowWildcardSubdomains()
                            //.WithHeaders(HeaderNames.ContentType, "x-custom-header")
                            .AllowAnyHeader());
            });

            return services;
        }

        public static IApplicationBuilder UseApiConfig(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseCors("Development");
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
             
            }
            else
            {
                app.UseCors("Production"); // Usar apenas nas demos => Configuração Ideal: Production
                app.UseHsts();
                app.UseSwagger();
                 app.UseSwaggerUI();
            }


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStaticFiles();

           /// app.UseEndpoints(endpoints =>
            //{
              //  endpoints.MapControllers();
                //endpoints.MapHealthChecks("/api/hc", new HealthCheckOptions()
                //{
                  //  Predicate = _ => true,
                   // ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                //});
                //endpoints.MapHealthChecksUI(options =>
                //{
                  //  options.UIPath = "/api/hc-ui";
                   // options.ResourcesPath = "/api/hc-ui-resources";

                   // options.UseRelativeApiPath = false;
                   // options.UseRelativeResourcesPath = false;
                   // options.UseRelativeWebhookPath = false;
               // });

           // });

            return app;
        }
    }
}