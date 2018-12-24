using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace UniversalForm.EF
{
    public class ContextFactory : IDesignTimeDbContextFactory<EFDBContext>
    {
        public EFDBContext CreateDbContext(string[] args)
        {
            //从web项目目录下的appsetting下面读取数据库连接配置
            Directory.SetCurrentDirectory("..");//设置当前路径为当前解决方案的路径
            string appSettingBasePath = Directory.GetCurrentDirectory() + "/WebApi";//改成你的appsettings.json所在的项目名称
            var configBuilder = new ConfigurationBuilder().SetBasePath(appSettingBasePath)
                .AddJsonFile("appsettings.json")
                .Build();
            var optionsBuilder = new DbContextOptionsBuilder<EFDBContext>();

            optionsBuilder.UseSqlServer(configBuilder.GetConnectionString("SQLServer"));
            return new EFDBContext(optionsBuilder.Options);
        }
    }
}
