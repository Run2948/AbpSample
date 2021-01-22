using System;
using Sample.Novel.EntityFrameworkCore.Tests;
using Volo.Abp.Modularity;

namespace Sample.Novel.Application.Tests
{
    [DependsOn(typeof(NovelApplicationModule),
        typeof(NovelEntityFrameworkCoreTestModule))]
    public class NovelApplicationTestModule : AbpModule
    {
    }
}
