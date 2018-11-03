# <<Sample title>>
This GitHub repository contains a code sample that demonstrate how to create angula application with SQL Server/Azure SQL Database.

## Contents

[About this sample](#about-this-sample)<br/>
[Before you begin](#before-you-begin)<br/>
[Run this sample](#run-this-sample)<br/>
[Sample details](#sample-details)<br/>
[Disclaimers](#disclaimers)<br/>
[Related links](#related-links)<br/>

<a name=about-this-sample></a>

## About this sample

- **Applies to:** SQL Server 2016 or higher, Azure SQL Database
- **Key features:** JSON
- **Programming Language:** C#, TypeScript, T-SQL
- **Authors:** Jovan Popovic

<a name=before-you-begin></a>

## Before you begin

To run this sample, you need the following prerequisites.
1. SQL Server 2016 or higher or Azure SQL Database
2. .Net Core 2.1 or .Net Framework 4.6 
3. NodeJS

<a name=run-this-sample></a>

## Run this sample

### Setup
1. Connect to your SQL Server/Azure Server and create a new database called HeroDb 
2. Execute [setup script](db/setup.sql) agains your database to create tables and populate data.

### Build and run
1. Go to the **src** folder and restore packages using Visual Studio, VSCode, or `dotnet restore` command line.
2. Restore npm packages using **npm install** command line. This command will download packages in **node_modules** folder.
3. Build the sample using Visual Studio, VSCode, or `dotnet build` command line.
3.1. If you don't have .Net core 2.1, change the version in .csproj file.
4. Change the connection string in appsetings.json file.
5. Run the sample using Visual Studio, VSCode, or `dotnet run` command line.

### Deploy the application

You cna deploy the application to Azure Web sites using the following button:
[![Deploy to Azure](http://azuredeploy.net/deploybutton.png)](https://azuredeploy.net/)

<a name=sample-details></a>

## Sample details

This sample application shows how to create REST API service is used as backend for AngularJS app.
Front-end code stored in wwwroot folder is modified johnpapa [Github sample project](https://github.com/johnpapa/angular2-tour-of-heroes).
ASP.NET Core Web API is used to implement REST Service called by Hero front-end app.
Service uses FOR JSON clause that is available in SQL Server 2016 and Azure SQL Database.

<a name=disclaimers></a>

## Disclaimers
The code included in this sample is not intended demonstrate some general guidance and architectural patterns for building single-page applications. 

<a name=related-links></a>

## Related Links

## Code of Conduct
This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

## License
These samples and templates are all licensed under the MIT license. See the [license.txt](license.txt) file in the root.

## Questions
Email questions to: sqlserversamples@microsoft.com.
