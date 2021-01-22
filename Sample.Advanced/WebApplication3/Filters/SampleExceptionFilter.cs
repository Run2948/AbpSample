using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Serilog;
using Serilog.Extensions.Logging;
using Volo.Abp.AspNetCore.ExceptionHandling;
using Volo.Abp.AspNetCore.Mvc.ExceptionHandling;
using Volo.Abp.Json;

namespace WebApplication3.Filters
{
    public class SampleExceptionFilter : AbpExceptionFilter
    {
        public SampleExceptionFilter(IExceptionToErrorInfoConverter errorInfoConverter, 
            IHttpExceptionStatusCodeFinder statusCodeFinder, 
            IJsonSerializer jsonSerializer, 
            IOptions<AbpExceptionHandlingOptions> exceptionHandlingOptions,
            ILogger<AbpExceptionFilter> logger) 
            : base(errorInfoConverter, statusCodeFinder, jsonSerializer, exceptionHandlingOptions)
        {
            Logger = logger;
        }
    }
}
