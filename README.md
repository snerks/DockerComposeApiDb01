# DockerComposeApiDb01
Docker Compose sample, with ASP.NET Core 3.1 Web API and SQL Server

Based on an excellent video series by Les Jackson (@binarythistle)

[Video](https://www.youtube.com/watch?v=4V7CwC_4oss)

[@binarythistle](https://github.com/binarythistle)

An ASP.NET Core 3.1 Web API uses EF Core Migrations to seed/read a SQL Server database.

Separate Docker Containers are used for:
* ASP.NET Core 3.1 Web API 
* SQL Server database

Docker Compose is used to orchestrate the Containers.

*Compatible with Docker Toolbox*
