# CSharp-WPF-.NET_Five-ExampleApplication

# C# - WPF - .NET 5 - How to build a Simple Example Application in WPF System based on .NET 5 and how to use MVVM and Mediator Design Patterns in this application. [Year of Development: 2021]

About the application technologies and operation:

### Technologies:

- Programming Language: C#
- FrontEnd Side: Windows Presentation Foundation (WPF) - .NET 5
- BackEnd Side: .NET 5
- Other used modul:
  - Microsoft.EntityFrameworkCore (v5.0.3)
  - Microsoft.EntityFrameworkCore.Design (v5.0.3)
  - Microsoft.EntityFrameworkCore.SqlServer (v5.0.3)
  - Microsoft.Extensions.Configuration (v5.0.0)
  - Microsoft.Extensions.Configuration.Abstractions (v5.0.0)
  - Microsoft.Extensions.Configuration.FileExtensions (v5.0.0)
  - Microsoft.Extensions.Configuration.Json (v5.0.0)
  - Microsoft.Extensions.DependencyInjection (v5.0.1)
  - Microsoft.Extensions.Hosting (v5.0.0)
  - NLog.Extensions.Logging (v1.7.2)
  - MediatR (v9.0.0)
  - Newtonsoft.Json (v10.0.1)

### BackEnd Application solution structure:

- **Application.DataAccessLayer**:
  - Includes the DataBase Contexts _(Write and Read Contexts)_.
  - Includes every DataBase Entities.
  - Includes DesignTimeDbContextFactory for generating database tables at Design-Time.
  - Includes Extensions for DataBase Context _(you can see more information about this in: ParkingAppDbContextExtension.InitDatabase method)_.
  - Includes generated Database Migrations.
- **Application.Core**:
  - This project includes all elements that can be used by any point in the application.
  - This project does not include any business logic.
  - Includes the General Global Error Handling constants and models for the Client Application.
  - Includes Command and Query interfaces for MediatR.
  - Includes a Global Export Abstraction and a JSON Export Service that implements this abstraction.
  - Includes the types for environment.
  - Includes static datasets _(for example: environment variables)_.
- **Application.BusinessLogicLayer**:
  - This project includes the Business Logic.
  - The business logic can be divided into modules.
  - The module folders contain the following: Commands- Querys with Handlers, Dtos, Services with Interfaces and Request- Response Models for Client Application Commands.
  - Includes the Command and Query abstractions for MediatR.
- **Application.Client**:
  - This is the User Interface Layer.
  - Includes the HostBuilder configurations.
  - Includes IoC DI Registers, with separate configuration files _(for example: DataBase configurations, MediatR configurations, Scoped and Singleton services , etc.)_.
  - Includes each extension for the IoC DI _(for example: Hosts, etc.)_.
  - Includes configuration settings for NLog.
  - Includes the ASPNETCORE_ENVIRONMENT environment variable configuration.
  - Includes starting the DataBase Migration when starting the application.
  - Includes Client-Side Global Error Handling.
    - The unhandled errors appear in an error window.
    - The text that appears depends on whether the application is running in a developer or other environment.
  - Includes the RelayCommandAsync class that implements the ICommand interface.
  - Includes the ViewModelBase class that implements the INotifyPropertyChange interface.
  - Includes the Windows, Views, View Models and Commands that used by the client application.
  - Includes the Services that used by the client application.

### Installation/ Configuration:

1. Restore necessary Packages on the selected project, run the following command in **Package Manager Console**

   ```
   Update-Package -reinstall
   ```

2. If you want to use **Code First Migrations** through the **Package Manager Console**, you must first set the **ASPNETCORE_ENVIRONMENT Environment Variable**, so run the following command in **Package Manager Console**:

   ```
   $env:ASPNETCORE_ENVIRONMENT='Development'
   ```

3. If you want to **Update** the **Database** trough the **Package Manager Console**, run the following command in the **Package Manager Console** _(However, this is not necessary, because when the Application starts than the application runs all Migrations.)_:

   ```
   Update-Database -verbose
   ```

### About the application:

This application demonstrates how to build a simple example application in **WPF System** based on **.NET 5** and how to use **MVVM** and **Mediator Design Patterns** in this application and further how to use a **.NET 5 IoC DI Container** in **WPF System**.

The application implements the following business logics:

- The application stores data from a parking garage system.
  - The system stores the arrival and departure times.
  - The system stores the parking passes. There are two types of parking passes:
    - License Plate based (1 car).
    - Card based (1 card - up to several cars).
  - In case of a key partner, it is possible to give a percentage discount.
  - Multiple payment options: Daily, Weekly, Monthly.
- Based on the data stored in the database, the user can perform the following operations in the client application:
  - Based on the license plate or card number entered in the input field, the itemized parking list is displayed.
  - The user can export the list to JSON format, which will be saved in the root directory of the application.

You can find the data included in the application in the data migration files.

#### The application shows the following:

- How to use **Model-View-ViewModel (MVVM)** in a **WPF Application**.
- How to build an application using **CQRS** and **Mediator Pattern** and how to use it.
- How to use the **MediatR Nuget Package** to use the **Mediator Pattern**.
- How to build and use **Command** and **Query** Handlers.
- How to using **HostBuilder**, **Dependency Injection** and **ServiceProvider** with **.NET 5 - WPF Application**.
- How to configurate the **HostConfiguration**, **AppConfiguration**, **Services** and **Logging** in the **HostBuilder**.
- How to use **IoC Container** in a **.NET 5 - WPF Application**.
- How to separate **IoC Container Configurations** in a **.NET 5 - WPF Application**.
- How to use the **NLog.Extensions.Logging Nuget Package** to implement and use the **NLog** to **Log** into a **File** and **DataBase**.
- How to use the **ASPNETCORE_ENVIRONMENT** **Environment variable**
- How to use **Entity Framework Core** and how to separate **Entity Configurations** in **Entities**.
- How to create **Extensions** to the **DataBase Context**.
- How to create **Custom Database Seeds**, that run when the application start.
- How to create a **Write**- and **Readonly Database Context** that corresponding to the **CQRS Pattern** and how to implement this.
- How to create a **Generic DesignTimeDbContextFactory** for generating database tables at **Design-Time**.
- How to easily manage the **Handled** and **Unhandled exceptions** in a **.NET 5 - WPF Application**.
