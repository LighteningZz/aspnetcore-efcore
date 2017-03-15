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
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="1.1.1" />
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer.Design" Version="1.1.1" />
<DotNetCliToolReference Include="Microsoft.EntityFrameworkCore.Tools.Dotnet" Version="1.0.0" > 
```
**จะได้ประมาณนี้**  
---------------------------------
![aspnetcore install efcore](/img/aspnetcore-install-efcore.jpg)  
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