## Technical questions\*\*

- How long did you spend on the coding test? What would you add to your solution if you had more time? If you didn't spend much time on the coding test then use this as an opportunity to explain what you would add.
  I spent more than 4 hours on the coding tests. I had initial few errors that needed to be resolved, to progress.
  The list of few errors I tried resolving,

  1. The database connectivity
     The Nuget package used System.Configuration to get the database connection string is does not work well with .NET Core. I have achieved database connectivity using Microsoft.Extensions.Configuration. I have made these changes in ClientRepository.cs class. Since I was not allowed to change UserDataAccess.cs the change is not implemented there.
  2. Connecting to the WCF service to calculate the user credit.
     I have updated this WCF service to a make HttpClient calls, but getting error that the host does not exists.

  List of changes that are implemented,

  1. Dependency injection.
  2. Refactoring the code based on clean architecture which implements SOLID principles.
  3. ClientRepository class connecting to db to fetch client information.
  4. Changed WCF class to HttpClient, the code is failing with error host does not exists.
  5. xUnit testcase to check adding new user.

  If i had more time, I would have added better test cases in the xUnit and finishing the complete implementation

- What was the most useful feature that was added to the latest version of C#? Please include a snippet of code that shows how you've used it.
  The useful feature of latest C# is global using. This includes adding using of packages and namespaces in the csproj file which will be then applicable to all the complied files in the project.
  LegacyApp.csproj

<ItemGroup>
	<Using Include="System" />
	<Using Include="System.Threading.Tasks"/>
	<Using Include="System.Net.Http"/>
	<Using Include="LegacyApp.Contracts"/>
	<Using Include="LegacyApp.Models"/>
	<Using Include="LegacyApp.Validators"/>
	<Using Include="System.ComponentModel.DataAnnotations"/>
	<Using Include="System.Data"/>
	<Using Include="System.Data.SqlClient"/>
</ItemGroup>

- How would you track down a performance issue in production? Have you ever had to do this?
  Review application logs for any error messages or exceptions that might be related to the performance issue.
  Creating monitoring dashboards to track key metrics like CPU and memory usage, server response time.
  Identifying database queries/ stored procedures that are taking more time and optimizing them.

- How would you track down an issue with this in production, assuming this api would be deployed as an app service in Azure.
  Use application insigths in Azure to track or identify errors.
