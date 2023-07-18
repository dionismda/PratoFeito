[![build and test](https://github.com/dionismda/PratoFeito/actions/workflows/build-and-test.yml/badge.svg?branch=main)](https://github.com/dionismda/PratoFeito/actions/workflows/build-and-test.yml)

# PratoFeito

O PratoFeito é um clone simplificado do iFood, criado com o objetivo de oferecer uma plataforma simples e fácil de usar para pedir comida online. Este projeto é uma ótima oportunidade para aprender e praticar habilidades de programação, além de ser um bom ponto de partida para projetos maiores. Ele foi elaborado seguindo a elaboração feita pelo [Lucas Gertel](https://github.com/lgertel) durante suas [lives](https://www.youtube.com/watch?v=6BfJb7RPW-o&list=PLs-l5bSgIMhBDOtatiLQXeNarcdeaekZI&index=10) onde ele desenvolveu a mesma aplicação mas em kotlyn e usando outras abordagens você pode ver a estrutura proposta para o projeto no seguinte [link](https://miro.com/app/board/uXjVMR2I6DI=/).

# Tecnologias usadas

* [ASP.NET 6](https://learn.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-6.0)
* [Entity Framework Core 7](https://learn.microsoft.com/pt-br/ef/core/)
* [MediatR](https://github.com/jbogard/MediatR)
* [AutoMapper](https://automapper.org/)
* [FluentValidation](https://fluentvalidation.net/)
* [Postgres](https://www.postgresql.org/)
* [Docker](https://www.docker.com/)
* [Dapper](https://github.com/DapperLib/Dapper)

# Visão geral dos contextos

## Customer
O contexto "customer" do PratoFeito é responsável por gerenciar as funcionalidades relacionadas aos clientes. Algumas das suas principais funcionalidades podem incluir:

1. Cadastro de clientes: o contexto permite o cadastro de novos clientes, com informações basicas como nome, sobrenome e limite de valor do pedido.
2. Gerenciamento de contas: o contexto permite que os clientes gerenciem suas contas, alterando informações de perfil, como nome, sobrenome e limite de valor do pedido.
3. Histórico de pedidos: o contexto mantém um histórico de todos os pedidos feitos por um cliente, permitindo que ele visualize o status de cada um deles.

## Order

## Restaurant

## Courier

# Como executar o projeto
Para executar o PratoFeito, siga as instruções abaixo:

## Foto do projeto no miro 
[![image info](./.readmeFiles/ProjetoMiro.png)](https://miro.com/app/board/uXjVMR2I6DI=/)

# Licença
O PratoFeito é distribuído sob a licença MIT. Para mais informações, consulte o arquivo LICENSE neste repositório.
Espero que isso ajude! Se você tiver mais dúvidas, sinta-se à vontade para perguntar.