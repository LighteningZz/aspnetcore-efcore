# EntityFramework Core คือ object relational mapper (ORM)
EF Core ทำให้เราทำงานกับฐานข้อมูลได้ง่ายขึ้นโดยที่เราไม่ต้องเขียน SQL  
ตัว EF Core นั้นสามารถทำงานได้กับฐานข้อมูลหลายเจ้า  
โดยสามารถดูข้อมูลการเข้าไปที่ลิงค์ข้างล่าง  
Git Hub - [EntityFramework](https://github.com/aspnet/EntityFramework)  
# มาเริ่มกันเลยดีกว่า  
แก้ไฟล์ .csproj ของโปรเจคของเรา  
เพิ่ม PackageReference และ DotNetCliToolReference ให้กับตัวโปรเจคของเรา  
อ้างอิง  
    - [Nuget EFCore SqlServer](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer)  
    - [Nuget EFCore SqlServer Design](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer.Design)   
    - [Nuget EFCore Tools Dotnet](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools.DotNet)   
```xml
<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="1.1.1" />
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="1.1.1" />
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer.Design" Version="1.1.1" />
<DotNetCliToolReference Include="Microsoft.EntityFrameworkCore.Tools.Dotnet" Version="1.0.0" /> 
``` 
**แล้วอย่าลืมสั่ง dotnet restore**
---------------------------------
```cmd
$ dotnet restore
D:\Projects\NetCore\aspnetcore-efcore\aspnetcore-efcore>dotnet restore
  Restoring packages for D:\Projects\NetCore\aspnetcore-efcore\aspnetcore-efcore\aspnetcore-efcore.csproj...
  Restoring packages for D:\Projects\NetCore\aspnetcore-efcore\aspnetcore-efcore\aspnetcore-efcore.csproj...
  Restoring packages for D:\Projects\NetCore\aspnetcore-efcore\aspnetcore-efcore\aspnetcore-efcore.csproj...
  Restore completed in 1.11 sec for D:\Projects\NetCore\aspnetcore-efcore\aspnetcore-efcore\aspnetcore-efcore.csproj.
  Restore completed in 1.15 sec for D:\Projects\NetCore\aspnetcore-efcore\aspnetcore-efcore\aspnetcore-efcore.csproj.
  Writing lock file to disk. Path: D:\Projects\NetCore\aspnetcore-efcore\aspnetcore-efcore\obj\project.assets.json
  Restore completed in 1.56 sec for D:\Projects\NetCore\aspnetcore-efcore\aspnetcore-efcore\aspnetcore-efcore.csproj.

  NuGet Config files used:
      C:\Users\skyerox\AppData\Roaming\NuGet\NuGet.Config
      C:\Program Files (x86)\NuGet\Config\Microsoft.VisualStudio.Offline.config

  Feeds used:
      https://api.nuget.org/v3/index.json
      C:\Program Files (x86)\Microsoft SDKs\NuGetPackages\
```
# การ Generate Object ของ EF Core
**เรามาดูกันก่อนว่ามีอะไรมั้ง**
--------------------------------- 
```cmd
$ dotnet ef -h
Usage: dotnet ef [options] [command]

Options:
  --version        Show version information
  -h|--help        Show help information
  -v|--verbose     Show verbose output.
  --no-color       Don't colorize output.
  --prefix-output  Prefix output with level.

Commands:
  database    Commands to manage the database.
  dbcontext   Commands to manage DbContext types.
  migrations  Commands to manage migrations.

Use "dotnet ef [command] --help" for more information about a command.
```
**ใน Project นี้เราจะใช้ dbcontext** 
--------------------------------- 
```cmd
$ dotnet ef dbcontext --help
Usage: dotnet ef dbcontext [options] [command]

Options:
  -h|--help        Show help information
  -v|--verbose     Show verbose output.
  --no-color       Don't colorize output.
  --prefix-output  Prefix output with level.

Commands:
  info      Gets information about a DbContext type.
  list      Lists available DbContext types.
  scaffold  Scaffolds a DbContext and entity types for a database.

Use "dbcontext [command] --help" for more information about a command.
```
**การ Generate Database Object เราจะใช้ Scaffold** 
--------------------------------- 
```cmd
$ dotnet ef dbcontext scaffold --help
Usage: dotnet ef dbcontext scaffold [arguments] [options]

Arguments:
  <CONNECTION>  The connection string to the database.
  <PROVIDER>    The provider to use. (E.g. Microsoft.EntityFrameworkCore.SqlServer)

Options:
  -d|--data-annotations                  Use attributes to configure the model (where possible). If omitted, only the fluent API is used.
  -c|--context <NAME>                    The name of the DbContext.
  -f|--force                             Overwrite existing files.
  -o|--output-dir <PATH>                 The directory to put files in. Paths are relative to the project directory.
  --schema <SCHEMA_NAME>...              The schemas of tables to generate entity types for.
  -t|--table <TABLE_NAME>...             The tables to generate entity types for.
  --json                                 Show JSON output.
  -p|--project <PROJECT>                 The project to use.
  -s|--startup-project <PROJECT>         The startup project to use.
  --framework <FRAMEWORK>                The target framework.
  --configuration <CONFIGURATION>        The configuration to use.
  --msbuildprojectextensionspath <PATH>  The MSBuild project extensions path. Defaults to "obj".
  -e|--environment <NAME>                The environment to use. Defaults to "Development".
  -h|--help                              Show help information
  -v|--verbose                           Show verbose output.
  --no-color                             Don't colorize output.
  --prefix-output                        Prefix output with level.
```
 **Scaffold ต้องการ Arguments 2 ตัวคือ** 
---------------------------------    
  - Connection String 
  - Database Provider  ซึ่งในที่นี้เราจะใช้ SqlServer  
--------------------------------- 
**ตัวอย่างคำสั่งที่เราใช้ในการสร้าง Database Object** 
---------------------------------  
```cmd
$ dotnet ef dbcontext scaffold "Server=.\SQLEXPRESS2014;Database=aspnetcore-efcore;User Id=sa;Password=1;" "Microsoft.EntityFrameworkCore.SqlServer" -o Models/Database -c Db -d
```