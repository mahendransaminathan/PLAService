# PLAService
Cloned from GitHub

# Webservice
1. dotnet new webapi -o MyWebApiProject
2. dotnet build
3. dotnet run

# Run the following commands to connect to a Database from Asp.Net Back End
1. dotnet add package Microsoft.EntityFrameworkCore.SqlServer
2. dotnet add package Microsoft.EntityFrameworkCore.Design
3. dotnet add package Microsoft.EntityFrameworkCore.Tools

# Create the Database using the following two commands
1. dotnet ef migrations add InitialCreate
2. dotnet ef database update
# Run the following command when dotnet ef command is not recognised
dotnet tool install --global dotnet-ef --version 9.*

# Please update the Sql server name under appsettings.json file according as per your server name 
