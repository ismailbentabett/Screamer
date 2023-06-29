# Screamer

a "Special" social media platform for annoying twitter people who like to scream their pointless views on other people faces

# Screamer Project - Local Development Guide

This guide will walk you through the steps to run the Screamer project locally on your machine.

## Prerequisites (server)

Before running the project, ensure that you have the following prerequisites installed on your machine:

- .NET SDK 7.0 or later
- SQL Server (or SQL Server Express) with a new database created named 'Screamer'

## Getting Started

Follow the steps below to set up and run the Screamer project:

## Clone the repository to your local machine:
 ```shell
   git clone https://github.com/ismailbentabett/Screamer.git
 ```

 
## Build the project:



```shell
dotnet build
```

## Update the configuration settings:

Open the appsettings.json file located in the Screamer.WebApi project.

Update the following sections with your own values:
```bash
 "CloudinarySettings": {
  "CloudName": "YOUR_CLOUD_NAME",
  "ApiKey": "YOUR_API_KEY",
  "ApiSecret": "YOUR_API_SECRET"
},
"ConnectionStrings": {
  "ScreamerDbConnection": "YOUR_DATABASE_CONNECTION_STRING"
},
"EmailSettings": {
  "ApiKey": "YOUR_EMAIL_API_KEY",
  "FromAddress": "YOUR_EMAIL_ADDRESS",
  "FromName": "YOUR_EMAIL_NAME"
},
"JwtSettings": {
  "Key": "YOUR_JWT_SECRET_KEY",
  "Issuer": "YOUR_JWT_ISSUER",
  "Audience": "YOUR_JWT_AUDIENCE",
  "DurationInMinutes": YOUR_JWT_DURATION_IN_MINUTES
},
"Serilog": {
  "MinimumLevel": {
    "Default": "Information",
    "Override": {
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "WriteTo": [
    {
      "Name": "File",
      "Args": {
        "path": "./logs/log-.txt",
        "rollingInterval": "Day"
      }
    }
  ]
},
"Google": {
  "ClientId": "YOUR_GOOGLE_CLIENT_ID",
  "ClientSecret": "YOUR_GOOGLE_CLIENT_SECRET"
},
"Facebook": {
  "AppId": "YOUR_FACEBOOK_APP_ID",
  "AppSecret": "YOUR_FACEBOOK_APP_SECRET"
},
"Algolia": {
  "ApplicationId": "YOUR_ALGOLIA_APPLICATION_ID",
  "APIKey": "YOUR_ALGOLIA_API_KEY"
}

```

## Apply database migrations:

Open a terminal and navigate to the Screamer.Persistence directory:


```shell
cd Screamer.Persistence
```

 Run the following command to apply database migrations:

```shell
dotnet ef migrations add newInitialMigrations --project ../Screamer.Persistence.csproj --startup-project ../Screamer.WebApi.csproj
```
```shell
dotnet ef database update --project ../Screamer.Persistence.csproj --startup-project ../Screamer.WebApi.csproj
```

##Run the application:

Open a terminal and navigate to the Screamer.WebApi directory:


```shell
cd Screamer.WebApi
```
Run the following command to start the application:

```shell
dotnet watch run
```

Access the application:

Open a web browser and navigate to https://localhost:5001/swagger/index.html to access the Screamer application.
That's it! You have successfully set up and run the Screamer project locally on your machine. Enjoy!


## Prerequisites (client)
Before getting started, ensure that you have the following prerequisites installed on your machine:

- Node.js (version 18.16.1 or higher)
- Angular CLI (version 16 or higher)

## Navigate to the project directory:

```shell
cd Screamer.AngularUI
```

## Install project dependencies:

```shell
npm install --force
```
## Start the development server:

```shell
ng serve
```

Open your web browser and navigate to http://localhost:4200 to see the running application.

## TODOS : 
- [x]  Fix The Sign Up Going To Profile Isuue
- [x]  fix the edit avatar stuff
- [ ]  fix user not signing out after deleting db
- [x]  fix cover upload buttons
- [x]  fix the damn image upload change
- [x]  fix the navbar avatar showing
- [x]  add gender and date and country dtuff
- [ ]  fix pagination
- [x]  fix profile tabs colors
- [x]  refactor both profile settings and profile
- [ ]  Fix the typing issue
- [ ]  Fix the chat layout
- [x]  add send message or create room
- [x]  fix the empty spots
- [ ]  complete the settings stuff
- [ ]  add real time views change
- [ ]  add real time added posts
- [ ]  work on modals ui because they look blank
- [x]  add custom validation
- [ ]  fix google button style
- [ ]  oauth signin still have tons of issues and bugs
- [ ]  fix auth settings ui
- [ ]  fix “your profile” drop down on signin
- [x]  fix verify email button
- [ ]  fix the delete my account logic
- [ ]  add the deleting zith relationship button
- [x]  dockerize it
- [ ]  use [Home | ng-gallery (ngx-gallery.netlify.app)](https://ngx-gallery.netlify.app/#/) video upload cloudinary
- [x]  move sidebard to main app
- [ ]  fix dropdowns
- [x]  fixed editor
- [ ]  fix clicking away modal
- [ ]  creating post moodtype issue
- [ ]  recheck chat the query stuff seems fishy
- [ ]  add tags and mentions notifications
- [ ]  change password for social auth users
- [ ]  chat is a mess
- [ ]  maybe add video chat
- [x]  store and show notifications
- [ ]  fix the 404 server to client logic
