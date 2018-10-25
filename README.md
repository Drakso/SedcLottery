# SedcLottery

This is a project for Expert C# Topics

## Project goal

This course will cover full stack development, using all the technologies that were previously learned on the Academy, on a more advanced level. The goal of this course is to prepare all the students for developing end to end software solution, implementing advance software architecture, using software development patterns and deploying it to the cloud.

## Technologies we are going to use

* ASP.NET WebApi / C#
* MS SQL Server / Entity Framework
* Angular / Typescript
* Azure  Databases / Azure SDK

### Structure of the architecture:

* Lottery.Data.Model
A class library project where we keep all the data models used for communication with the DB and the entity framework context
* Lottery.Data
A class library project where we keep the logic for accessing and manipulating the database
* Lottery.Service
A class library project where we keep the most of the business logic of our application
* Lottery.Mapper
A class library project where we have a generic mapper that will map from data models to view models
* Lottery.View.Model
A class library project where we have all the view models needed in the webapi application
* Lottery.Web
A WebApi ASP.NET application that is exposed to the outside
* Lottery.Web.Tests
A Unit Test project where unit tests should be written ( Might stay empty throughout the course, depending on time )

## Course Classes

What we covered so far:

### Class 1

* Talked about the goal of the subject
* Talked about the specification of the Lottery Project
* Discussed and created a UML diagram for the project structure
* Created an empty project
* Discussed about creating a repository on github, committing and pushing our code

### Class 2

* Talked about and created the project architecture base
* Installed entity framework
* Created data models (classes) with entity framework in mind
* Created an entity framework context
* Created a seed method and configurations for code first approach
* Discussed and created a generic repository class for the data models

### Class 3
* Discussed about architecture and view models
* Created view models
* Created Service class and interface
* Talked about [Inversion Of Control (IoC) and Dependency Injection (DI)](https://github.com/rpanchevski/SedcLottery/blob/master/DependencyInjection.md "Explanation document for Dependency Injection and Inversion of Control")
* Implemented controller and service logic without DI
* Changed controller and service with constructor DI
* Talked about IoC Containers
* Installed AutoFac container and implemented AutoFac configuration
* Changed controller and service with AutoFac Container DI

### Class 4
* Created another service with dependency injection and unit of work
* Discussed unit of work pattern
* Implemented the services and controllers to work end to end
* Added connection string and enabled auto migrations
* Installed swagger to test endpoints
* Tested the api end to end with swagger

### Class 5
* Explained the mapper that we implemented in detail
* Added show winners endpoint
* Finished the implementation of the backend
* Tested both endpoints and backend with swagger
* Started an Angular project
* Talked about [Angular](https://github.com/rpanchevski/SedcLottery/blob/master/Angular.md "Explanation about Angular architecture") and single page applications

### Class 6
* Explained angular architecture
* Created winners-list component
* Set-up routing
* Finished the whole end-point
* Tested with swager
* Talked about git branching models

### Class 7
* Created the submit-code component
* Finished the second end-point
* Tested with swager
* Go through the application end to end with break-points
* Go through the mapper with break-points

### Class 8
* Talk about deployment
* Talk about Azure and IIS
* Deploy ASP.NET on IIS
* Deploy Angular application
* Demo on Azure deployment

### Class 9
* Finishing deployment
* Talk about asp.net Core
* Talk about the console service for per-day and final raffle
* Begin developing the console service

### Class 10
* Developing the console service for per-day and final raffle
* Talked about the infrastructure and business logic
* Students try to implement business logic independently

### Class 11
* Implementing full solution for console service
* Debugging the console service to understand how it works
* Implement scheduling with windows task scheduler
* Introduction to docker

### Class 12
* Implement scheduling with cron
* Talk about docker containers and images
* Deploy the console service with docker locally

### Class 13
* Talk about docker and azure deployment
* Deploy the console service with docker to azure
* Talk about the benefits of deploying to azure and using docker
* Discussion about Async/Await

### Class 14
* Finish azure deployment
* Create another console application for processing excel files
* Deploy excel console on azure
* Create option for excel file to be uploaded on azure

### Class 15
* Finish with excel files stored on Azure
* Discussion about unit tests
* Discussion about testing