# Boostart.NET
ASP.NET Core RESTful API Project Template for CRUD applications

---
### Key Features
* Essential Database Operations (CRUD) in `BaseDataService` & `BaseController`. 
* Dependency Injections
* Swagger configured
* Automatic Request Logging (NLog)

---
### HOW TO: Run this demo
* Clone this repos
  ```bash
  git clone https://github.com/DerekJi/Boostart.NET.git
  ```
* Check ConnectionString in [Database.Mssql/appsettings.Development.json](Database.Mssql/appsettings.Development.json) and update it as your own database. It's recommended to create a fresh new database for the demo;
* Run command to build up the demo database with sample tables
  ```bash
  dotnet ef database update
  ```
* Check ConnectionString in [WebAPI/appsettings.Development.json](WebAPI/appsettings.Development.json) and update it as your own database. It should be same as the one defined in [Database.Mssql/appsettings.Development.json](Database.Mssql/appsettings.Development.json);
* Launch from *dotnet cli* or *Visual Studio 2019* (or higher version);
* You should be able to see the Swagger index page by visiting https://localhost:44340/swagger

---
### HOW TO: Add New Controller(s)

With Boostart.NET, you could have a new fully functional controller providing CRUD endpoints within 5 minutes.

Now, let's suppose we are going to setup a new set of endpoints for the new table: *Departments*.

Here are all the things you have to do:
* Step #1. Define the database entity under [Database.Entity/Entities](Database.Entity/Entities). It looks like:
  ```c#
  public class Department: BaseEntity
  {
      [MaxLength(255)]
      public string DepartmentName{ get; set; }

      [MaxLength(255)]
      public string Address { get; set; }
  }
  ```
  > NOTE: 
  > * the new entity MUST inherit from *BaseEntity* 
* Step #2. Run any `dotnet ef` command you'd like to update the database;
* Step #3. Create the new data service class and interface
  ```c#
  /// IDepartmentsDataService.cs
  public interface IUsersDataService : IBaseDataService<User>
  {
  }

  /// DepartmentsDataService.cs
  public class DepartmentsDataService : BaseDataService<Department>, IDepartmentsDataService
  {
      public DepartmentsDataService(
          IHttpContextAccessor httpContextAccessor,
          IBaseRepository<User> repos
          ) : base(httpContextAccessor, repos)
      {
      }
  }
  ```
* Step #4. Create the controller
  ```c#
  [Route("api/[controller]")]
  [ApiController]
  public class DepartmentsController : BaseController<Department>
  {
      public DepartmentsController(
          ILogger<ILogActionFilter> logger, 
          IDepartmentsDataService dataService)
          : base(logger, dataService)
      {
      }

  }
  ```
* Done!

As you can see, what you did is just create
* new entity from BaseEntity
* new data service from BaseDataService
* new controller from BaseController

That's it!

You don't have to do too many copy & pastes, so you could just focus on the relationships between the entities and business logic.

Enjoy! :)