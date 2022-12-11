
# Docker environment for development

We use docker compose to ease development process by providing, all 3 stores required for Demo run during learning.

- *Sql Server* to store data

To setup the database for the project, you need to use the [Seed](../Domain/DbContextExentions.cs) project.

## Pre-requisite

You need have docker installed on your machine. We recommand for Windows the use of [Docker desktop](https://hub.docker.com/editions/community/docker-ce-desktop-windows)

Minimum recommanded versions:

- docker engine : 20.10.13
- docker compose : v2.3.3
- docker desktop (if used): 4.6.1

## Create & destroy environment

From the currenct directory `docker`.

To create the environment :

`docker compose up -d --build --always-recreate-deps --force-recreate -V --remove-orphans` 

To destroy the environment :

`docker compose rm -s -f -v`

Scripts `start.sh` and `terminate.sh` run the two commands above.

### Post install

The F# `post-install.fsx` script can be run after the environment creation, to setup what's left. As of now, the creation of the ECapexDb in SQL Server is handled by this script. The script can be run multiple times with no issue.

To run this script :

`dotnet fsi post-install.fsx`

## Environment description

### SQL Server

- Address : localhost:1434
- User: sa
- Password: Pa$$word
