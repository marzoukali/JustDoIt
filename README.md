# JustDoIt
Simple online TODO list.

# Technologies:
- .NET5 (Including EF, AspCore APIs) For backend (FluentValidations, MediatR, Moq, FluentAssertions).
- ReactJs with Typescript for frontend.

# File System Hierarchy:
- client: This folder contains all client side code which should run using nodejs.
- server: This folder contains all backend code which should run using iisexpress or even cmd.


# Architecture Style:
- I decided to seperate the project to client-side (ReactJs) and server-side (APIs) so there shouldn't be a coupling between the UI and the business logic.
- In Backend I decided to build the APIs using Clean Architecture ( With the help of CQRS + Mediator ) so you will find the Domain layer which includes all the domain entities and contract, then the application layer which encapsulates all the handlers (Each handler is triggered by even a command or query and passed to a validation layer before the excuation to validate the business rules). Also because the project is simple i didn't have any domain services but i created a repository layer to encapsulate all the database operations and also to make it easier for testing to mock and setup the needed objects. 
- In the APIs i used the REST specifications as needed.
- The backend was more towards type grouping but the client side was more towards features grouping.

# Functional concerns:
- In the authentication, i am using jwt to authenticate user. So in the login endpoint user can request token and using this token he/she can call the todos apis.
- The token is jwt and include some basic claims.
- I decided to sign the token using Key `TokenKey` which you can find in the configs `appsettings.Development.json` instead of using certificate (Beacsuse the project scope but in reallife that should be certitifcate)
- I decided to store the configs in appsettings.Development.json and this shouldn't pushed to the repo in reallife and i may use .net secret store to store all the secrets and use patterns to replace the keys in the pipeline.
- Take a look to the got logs for more info (I used numbers in git commits as representing for jira tickets)

# Testing:
- I made some unit tests for backend and in real life we should cover all the business logic backend and frontend.

# How to setup
- App should run without any issue on IIS or IIS Express
- Make sure to run with VisualStudio 2017 or from command line (.NET Core Runtime should be installed)
- Once the app run, it seed admin user and role to use it as admin (Can be changed from configurations)


# Setup the backend with VisualStudio:
- Make sure to have Visual Studio that supports .Net Core.
- Make sure that the .Net 5 runtime installed.
- Open the solution from `server\src` folder.
- Make sure to mark web > TIS.Todo.Api as Startup project
- Restore Nuget Packages
- Run the tests from  `server\src\tests` using Microsoft Testing Framework.
- Run with IISExpress or IIS
- Note: If you wish you can use dotnet core command line commands to run the project. Also you can use VS Code.
- After run the project make sure that you see the swagger documentation.

# Setup the clientside (React App):
- Use VSCode or any preffered editor to open `client\src\tis-todo`
- Make sure that you have nodejs and npm installed.
-  `npm install`
- from the terminal run: `npm start`

Note: If you faced any issue related to the datepicket just run the below two lines in order:
- `npm i --save react-datepicker`
- `npm i --save-dev @types/react-datepicker`

# Important:
- Make sure that the backend APIs URL is set correctly at the config: `client\src\tis-todo\.env.development`
- Also make sure at the backend side that you included the frontend origins in the config file`server\src\web\TIS.Todo.Api\appsettings.Development.json` in key: `CorsOrigins`
