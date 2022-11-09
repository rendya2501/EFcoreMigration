using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MigrationBundleExample.Context;

class Program
{
    private static DatContext? _datContext;
    private const string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=BundleDB2;Integrated Security=True";

    static void Main(string[] args)
    {
        // × bundle作成出来ず
        //var services = new ServiceCollection();
        //services.AddDbContext<DatContext>(options => options.UseSqlServer(connectionString));
        //ServiceProvider serviceProvider = services.BuildServiceProvider();
        //_datContext = serviceProvider.GetService<DatContext>();

        
        // ○ bundle作成できた
        // ASP.NET Core 2.2 アプリで dotnet ef コマンドを実行する場合は、 Program.cs に CreateWebHostBuilder メソッドが必要な模様
        // https://qiita.com/wukann/items/53462f4b21104ed75c31
        using IHost host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services
                    .AddDbContext<DatContext>(options =>
                    {
                        var appsettings = hostContext.Configuration.GetConnectionString("DefaultConnection");
                        options.UseSqlServer(appsettings ?? connectionString);
                    });
            })
            .Build();
    }
}



