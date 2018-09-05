# Dependency Injection and Inversion Of Control

## Inversion of Control ( IoC )

Inversion of Control is a design principle in which we delegate responsibility and control and with that create a more modular and decoupled software architecture.

## Dependency Injection ( DI )

Dependency Injection is a technique which is used to implement Inversion of Control in our software solution. The technique works by having an object require an instance of another object instead of creating the instance itself. This basically means that instead of building instances of our dependencies inside our classes and modules ( Services, repositories, controllers, etc. ), we delegate the problem of instantiating by requiring an already made instance of whatever we need as a parameter.

##### An example of an implementation without DI

This implementation is not using any IoC techniques. As you can see the service methods and the controller actions need to make multiple instances of the objects they need (dependencies). If there were multiple dependencies there would have been even more instances in every method and action.
![Example without DI](https://raw.githubusercontent.com/rpanchevski/SedcLottery/master/Img/withoutDi.png "No DI Example")

##### An example of an implementation using Constructor DI

In this example we are using Constructor Dependency Injection technique. This allows us to create one instance of the dependencies that our methods in the service would need and one instance of the dependencies that our controller actions would need. This instance is created in the service or controller constructor and is kept in a private field so anyone in the current class can access it. So when an instance of the service or controller is created, instances of the dependencies are created as well and our methods or actions can use that one instance instead of making instances by themselves.
![Example using Constructor DI](https://raw.githubusercontent.com/rpanchevski/SedcLottery/master/Img/diWithoutContainer.png "Constructor DI Example")

##### An example of an implementation using IoC Container

In this example we are using a Inversion of Control container, so we can use the Dependency Injection technique even more efficiently and have an even more decoupled code. Here we have a IoC container configuration that has an initialize method and register dependencies method. The register dependencies method basically resolves which interface is bound to which class implementation. With this configuration, by asking for the interface the container builds us an instance of the class required and also resolve all dependencies ( new up all the classes we need ). The configuration is placed in the App_Start folder. The IoC container is initialized with the initialize method in the Global.asax file. This means that it is initialized on the start of our application. Now when our classes or modules want a dependency resolved they just ask for an interface of the implementation they need ( in the constructor ) and the IoC container will automatically create an instance of the dependency we need and resolve every other dependency if there are any and give the dependency to that class or module. 
![Example using IoC Container ](https://raw.githubusercontent.com/rpanchevski/SedcLottery/master/Img/diWithContainer.png "IoC Container Example")

###### * The examples have implementation only for the purpose of showing how DI and IoC work. They are not fully implemented and don't have any business logic. 

