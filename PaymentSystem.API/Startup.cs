using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PaymentSystem.Domain.IRepositories;
using PaymentSystem.Domain.IServices;
using PaymentSystem.Persistence.MockRepositories;
using PaymentSystem.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using AutoMapper;
using PaymentSystem.Services.Mapping;
using PaymentSystem.Persistence;
using PaymentSystem.Persistence.Repositories;
using Newtonsoft.Json.Serialization;

namespace PaymentSystem.API
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
            services.AddControllers();

            services.AddMvc()
            .AddJsonOptions(
                options => options.JsonSerializerOptions.IgnoreNullValues = true
            );

            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IAccountService,AccountService>();
            services.AddScoped<IPaymentService, PaymentService>();

            //If you want to test with hardcoded data uncomment this line then comment the nextline
            //services.AddScoped<IUnitOfWork,MockUnitOfWork>();
            services.AddScoped<IUnitOfWork,UnitOfWork>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new PaymentSystemProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddDbContext<PaymentSystemContext>();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
