# Angular Architecture

![Angular Diagram](https://raw.githubusercontent.com/rpanchevski/SedcLottery/master/Img/Angular.png "Angular Diagram")

## Components

Angular application are built of components. Components are the basic building blocks of Angular. They contain business logic and are connected with the Templates where the UI is shown. As we learned in the ASP.NET classes, we can use Models Views and Controllers to create and manage applications. In Angular, the model and controller logic is in these components. 

## Templates

Templates are basically HTML views that Angular manages. Almost all of the HTML syntax is valid here except a few exceptions such as

## Directives

Directives are custom HTML elements and attributes that are used to extend the capabilities of the HTML view. With directives we can manipulate the dom, hide and add elements dynamically. Some directives we used for the application:

* [routerLink] - Attribute Directive
* *ngFor - Structural Directive

## Services

As we talked about, it is not a good practice to leave business logic in the controller. The same principle is true here, there shouldn't be any business logic inside a component. That is why we create Services that are modules that contain business logic and can be injected in any component so the service methods can be used. 