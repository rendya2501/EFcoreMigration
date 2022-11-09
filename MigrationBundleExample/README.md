# README

---

## プログラム参考

[Introduction to Migration Bundles - What can they do the migration scripts don't?](https://www.youtube.com/watch?v=mBxSONeKbPk)  

---

## bundle作成のスタートアップ

``` cs : × bundle作成出来ず
var services = new ServiceCollection();
services.AddDbContext<DatContext>(options => options.UseSqlServer(connectionString));
ServiceProvider serviceProvider = services.BuildServiceProvider();
_datContext = serviceProvider.GetService<DatContext>();
```

ASP.NET Core 2.2 アプリで dotnet ef コマンドを実行する場合は、 Program.cs に CreateWebHostBuilder メソッドが必要な模様

``` cs : ○ bundle作成できた
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
```

[デザイン時 DbContext 作成](https://learn.microsoft.com/ja-jp/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli)  
[dotnet ef migrations でエラーになった話](https://qiita.com/wukann/items/53462f4b21104ed75c31)  

---

## appsettings.jsonの読み取り

`dotnet add package Microsoft.Extensions.Configuration --version 6.*`  

``` json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=.;Initial Catalog=[db_name];Integrated Security=True"
  }
}
```

``` cs
using Microsoft.Extensions.Configuration;

class Program
{
    static void Main(string[] args)
    {
        var configuration = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json")
           .Build();
        string connectionString = configuration.GetConnectionString("DefaultConnection");
    }
}
```

[.NETのコンソールアプリでappsettings.jsonを使う (.NET6)](https://zenn.dev/higmasu/articles/b3dab3c7bea6db)  
