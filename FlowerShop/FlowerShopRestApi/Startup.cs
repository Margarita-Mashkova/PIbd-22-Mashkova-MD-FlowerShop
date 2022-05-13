using FlowerShopBusinessLogic.BusinessLogics;
using FlowerShopBusinessLogic.MailWorker;
using FlowerShopConracts.BindingModels;
using FlowerShopConracts.BusinessLogicsContracts;
using FlowerShopConracts.StoragesContracts;
using FlowerShopDatabaseImplement.Implements;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace FlowerShopRestApi
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
            services.AddTransient<IClientStorage, ClientStorage>();
            services.AddTransient<IOrderStorage, OrderStorage>();
            services.AddTransient<IFlowerStorage, FlowerStorage>();
            services.AddTransient<IStorehouseStorage, StorehouseStorage>();
            services.AddTransient<IComponentStorage, ComponentStorage>();
            services.AddTransient<IMessageInfoStorage, MessageInfoStorage>();
            services.AddTransient<IOrderLogic, OrderLogic>();
            services.AddTransient<IClientLogic, ClientLogic>();
            services.AddTransient<IFlowerLogic, FlowerLogic>();
            services.AddTransient<IStorehouseLogic, StorehouseLogic>();
            services.AddTransient<IComponentLogic, ComponentLogic>();            
            services.AddTransient<IMessageInfoLogic, MessageInfoLogic>();
            services.AddSingleton<AbstractMailWorker, MailKitWorker>();
            services.AddControllers().AddNewtonsoftJson();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "FlowerShopRestApi",
                    Version = "v1"
                });
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "FlowerShopRestApi v1"));
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            var mailSender = app.ApplicationServices.GetService<AbstractMailWorker>();
            mailSender.MailConfig(new MailConfigBindingModel
            {
                MailLogin = Configuration?.GetSection("MailLogin")?.Value.ToString(),
                MailPassword = Configuration?.GetSection("MailPassword")?.Value.ToString(),
                SmtpClientHost = Configuration?.GetSection("SmtpClientHost")?.Value.ToString(),
                SmtpClientPort = Convert.ToInt32(Configuration?.GetSection("SmtpClientPort")?.Value.ToString()),
                PopHost = Configuration?.GetSection("PopHost")?.Value.ToString(),
                PopPort = Convert.ToInt32(Configuration?.GetSection("PopPort")?.Value.ToString())
            });
        }
    }
}
