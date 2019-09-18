# primacontrolevendas
Prima-ControleVendas

Aplicação Web desenvolvida com:

- ASP.Net Core MVC 2
- JQuery/Bootstrap
- Entity Framework Core
- Banco de dados SQL Server

Para configurar uma conexão válida com o banco de dados em seu ambiente basta alterar o ítem Data->Prima->ConnectionString no arquivo appsettings.json com uma ConnectionString válida.

Para criar o database schema execute o seguinte comando na pasta Prima.ControleVendas.Web:

dotnet ef database update
