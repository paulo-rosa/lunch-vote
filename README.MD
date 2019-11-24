# LunchVote Application
WebAPI (.NET Core 2.2) + Angular 6 Application to voting for lunch location.

### Prerequisites (For Windows)
- ASP .NET Core 2.2
- Visual Studio 2017
- Node (https://nodejs.org/en/download/)


### Running API
- Open The .sln file with visual studio 2017;
- Right Click On Solution and "Restore NuGet Packages";
- In visual studio menu, select "Tools > NuGet Package Manager > Package Manager Console";
- Set the default project to "LunchVote.API" ;
- Hit ctrl+f5, or just f5 (debug);
- If everything is ok, local database will be created and the swagger documentation page will appear;

### Running Angular
- With PowerShell (or another desired command line tool), navigate to "LunchVote.Web\ClientApp" folder;
- Type "npm install" to download the dependencies;
- With all the dependencies resolved and API running, type "ng serve --open";
- Angular app will open

### About the solution
- The following libraries/approaches are present in this projects:
	* Entity Framework Core, with code first approach;
	* AutoMapper, with profiles approach;
	* IHostedService to runs a Task and finish the election;
	* Repositories to access DataBase objects;
	* Services to Fulfill the business requirements and abstract the repository functionalities;
	* Swagger to document the API methods;
	* Async methods in the whole communication chain;
	* Angular 6 with reactive forms.

### About the application
- This project provides an environment that a team can access to vote which restaurant will be the selected for the next lunch;
- The User will select the professional and the correspondent restaurant;
- A professional can vote only once a day;
- The election is open from 00:00 AM to 11:59 AM. 
- At 00:00 AM the system will run the task that gives the selected restaurant for the day;
- From 00:00 PM to 11:59 PM, the system will return the daily election results and show up on the client.

## Authors
* **Paulo Rosa**


