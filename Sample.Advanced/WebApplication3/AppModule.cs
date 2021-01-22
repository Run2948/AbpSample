using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using Volo.Abp;
using Volo.Abp.AspNetCore.ExceptionHandling;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.ExceptionHandling;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;
using WebApplication3.Filters;
using WebApplication3.Localization.ErrorCode;

namespace WebApplication3
{
    [DependsOn(typeof(AbpAspNetCoreMvcModule),
        typeof(AbpAspNetCoreSerilogModule))]
    public class AppModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            ConfigureLocaliztion();
            ConfigureExceptionLocalization();
        }

        public void ConfigureLocaliztion()
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AppModule>(
                    baseNamespace: nameof(WebApplication3), 
                    baseFolder:"Localization");
            });

        }

        public void ConfigureExceptionLocalization()
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<ErrorCodeResource>("zh-Hans")
                    .AddVirtualJson("/Localization/ErrorCode/Resources");
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("Sample", typeof(ErrorCodeResource));
            });

            Configure<AbpExceptionHttpStatusCodeOptions>(options =>
            {
                options.Map(SampleErrorCodes.ThisIsABusinessException, HttpStatusCode.BadRequest);
                options.Map(SampleErrorCodes.CustomExceptionMessage, HttpStatusCode.InternalServerError);
            });

        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            
            app.UseAbpSerilogEnrichers();
            app.UseConfiguredEndpoints();
        }
    }
}
