## Criando o Projeto

* ```dotnet new sln --name solution-name```
* ```dotnet new webapi -o solution-name.template-project --no-https true```
* ```dotnet sln solution-name.sln add ./solution-name.template-project/solution-name.template-project.csproj```
* ```dotnet new gitignore```
* ```dotnet add package Microsoft.AspNetCore.Mvc.Versioning```

## Executando o Projeto

* ```dotnet run --project solution-name.template-project```