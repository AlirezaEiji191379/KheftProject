dotnet ef migrations add "init" -p KheftProject -o ./Core/DataAccess/Migrations --startup-project KheftProject 
dotnet ef migrations remove -p KheftProject --startup-project KheftProject 
dotnet ef database update -p KheftProject --startup-project KheftProject