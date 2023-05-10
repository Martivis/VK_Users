# VK_Users

## Setup

You need _Docker_ or _Docker Desktop_ installed on your computer.
System is configured to work on both _Linux_ and _Windows_ platforms.

1. Pull this repository to your local storage.
2. Ensure that docker deamon is running. Open folder in terminal and type `docker-compose build` (with `sudo` on Linux).
   You can use `docker-compose up --build` instead
4. After build finishing, type `docker-compose up` (with `sudo` on Linux)

Starting up may take a time.  
When the system is running, you can access swagger on `http://localhost:10000/swagger`.
---
Authentication works with added users credentials. Authorization is only required for GetUser endpoint
