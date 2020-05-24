# ContactsManagerApi

This is a contacts management API and is composed of the follwing entities :
- Users
- Persons
- Employment Status
- Contacts
- Enterprises
- Offices
- Addresses

A user is a person.
A person has an employment status.
Many persons can have many contacts.
An enterprise has one main office and 0 or n other ones.
Persons and Offices have an address.
A person works on one or many enterprises.

It has been written in .NET CORE to demonstrate my skills and implements the following concepts and tools :

- REST
- Dependency Injection
- Authentication (JWT) and Authorization
- Password encryption
- Entity Framework Core
- Dapper
- Swagger
- Repository design pattern
- Use of DTOs and mappers
- Exception handling
