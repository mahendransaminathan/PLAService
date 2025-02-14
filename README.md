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

# Please update the Sql server name under appsettings.json file according to your server name 

# Install the following package to run the unit test 
1. dotnet add package NUnit
2. dotnet add package Moq
3. dotnet add package NUnit3TestAdapter
4. dotnet add package Microsoft.NET.Test.Sdk

#Run the Unit test using InMemory DB - Install the following package
1. dotnet add package Microsoft.EntityFrameworkCore.InMemory
