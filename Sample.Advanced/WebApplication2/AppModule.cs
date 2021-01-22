using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Volo.Abp;
using Volo.Abp.AspNetCore;
using Volo.Abp.AspNetCore.ExceptionHandling;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;
using WebApplication2.Localization.ErrorCode;
using WebApplication2.Localization.Exception;

namespace WebApplication2
{
    [DependsOn(typeof(AbpAspNetCoreMvcModule))]
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
                    baseNamespace: nameof(WebApplication2), 
                    baseFolder:"Localization");
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<ExceptionResource>("zh-Hans")
                    .AddVirtualJson("/Localization/Exception/Resources");
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

            app.UseRouting();

            app.UseConfiguredEndpoints();
        }
    }
}
