# SedcLottery

This is project for Expert C# Topics

## Project goal

This course will cover full stack development, using all the technologies that were previously learned on the Academy, on a more advanced level. The goal of this course is to prepare all the students for developing end to end software solution, implementing advance software architecture, using software development patterns and deploying it to the cloud.

## Technologies we are going to use

* ASP.NET WebApi / C#
* MS SQL Server / Entity Framework
* Angular / Typescript
* Azure  Databases / Azure SDK

###Structure of the architecture:

Structure of the architecture:

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
*Lottery.Web.Tests
A Unit Test project where unit tests should be written ( Might stay empty throughout the course, depending on time )

## Course Classes

What we covered so far:

### Class 1

* Talked about the goal of the subject
* Talked about the specification of the Lottery Project
* Discussed and created a UML diagram for the project structure
* Created an empty project
* Discussed about creating a repository on github, commiting and pishing our code

### Class 2

* Talked about and created the project architecture base
* Installed entity framework
* Created data models (classes) with entity framework in mind
* Created an entity framework context
* Created a seed method and configurations for code first aproach
* Discussed and created a generic repository class for the data models