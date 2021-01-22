using System;
using Microsoft.Extensions.FileProviders;
using Volo.Abp.DependencyInjection;
using Volo.Abp.VirtualFileSystem;

namespace ConsoleApp1
{
    public class SampleService : ITransientDependency
    {
        private readonly IVirtualFileProvider _virtualFileProvider;

        public SampleService(IVirtualFileProvider virtualFileProvider)
        {
            _virtualFileProvider = virtualFileProvider;
        }

        public void Test()
        {
            var file = _virtualFileProvider
                .GetFileInfo("/MyResources/Hello.txt");

            if (file.Exists)
            {
                var fileContent = file.ReadAsString();
                Console.WriteLine(fileContent);
            }
            else
            {
                Console.WriteLine("文件不存在");
            }
            
                
        }
    }
}
