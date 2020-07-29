# TESTE DTI - JOGO DA VELHA

## Author: Christian Alexsander da Silva Santos

## API

- C# .NET Core
- EntityFramework
- SQLite

## Frontend

- React
- Typescript

### To run

#### Start backend

Na pasta root do projeto entre com:

    $ cd .\API.HashGame\API.HashGame

Caso não exista e a pasta `Migrations`, rode:

    $ dotnet ef migrations add inital

Caso o arquivo `\API.HashGame\API.HashGameHashGame.db`:

    $ dotnet ef database update

Se não, ainda dentro de `.\API.HashGame\API.HashGame`:

    $ dotnet build

    $ dotnet run

#### Start frontend

Na pasta root do projeto entre com:

    $ cd .\Frontend.HashGame\

    $ npm install

ou

    $ yarn install

então

    $ npm run start

ou

    $ yarn start
