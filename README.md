# Projeto Financeiro

Este é um projeto de gestão financeira desenvolvido em C#/.NET. A aplicação foi estruturada focando em boas práticas de engenharia de software, utilizando princípios de separação de responsabilidades, como **Domain-Driven Design (DDD)** e **Clean Architecture**.

## 🚀 Tecnologias Utilizadas

* **.NET (C#)** - Plataforma e linguagem principal de desenvolvimento.
* **xUnit / NUnit / MSTest** - Framework para testes unitários (verifique qual está sendo utilizado no projeto `financeiro.Tests`).
* **Moq** - (Provavelmente) Framework para criação de mocks nos testes de serviço.

## 🏗️ Estrutura do Projeto

A solução está dividida principalmente nas seguintes camadas:

* **`financeiro` (Projeto Principal)**
  * **Domain:** Contém as entidades principais do negócio, regras estritas do domínio e validações (ex: `Usuario`).
  * **Application:** Contém as regras de negócio da aplicação e orquestração de chamadas (ex: `CriarUsuario`, serviços e casos de uso).
  * **Infrastructure / API:** (Dependendo da evolução do projeto) Camadas de acesso a banco de dados, injeção de dependência e exposição dos endpoints.

* **`financeiro.Tests` (Projeto de Testes)**
  * **Tests/Domain:** Testes unitários para garantir que as regras das entidades de domínio estão corretas (ex: `UsuarioTest`).
  * **Tests/Application:** Testes unitários e de integração validando os serviços da aplicação, como a criação de usuários (ex: `UsuarioServiceTest`).

## ⚙️ Pré-requisitos

Para executar e contribuir com este projeto, certifique-se de ter os seguintes itens instalados no seu ambiente:

* [.NET SDK](https://dotnet.microsoft.com/download) (Recomendado a versão mais recente suportada pelo projeto, ex: .NET 6, 7 ou 8)
* [Visual Studio](https://visualstudio.microsoft.com/) ou [Visual Studio Code](https://code.visualstudio.com/)

## 🏃 Como Executar o Projeto

1. Clone o repositório para sua máquina local.
2. Navegue até a pasta raiz do projeto via terminal.
3. Restaure as dependências do pacote executando:
 ```dotnet restore```
4. Para compilar o projeto, execute:
 ```dotnet build```
5. Para rodar a bateria de testes unitários:
 ```dotnet test```
6. Para executar a aplicação principal:
 ```dotnet run --project financeiro```
 Ou ir ao diretório do projeto `financeiro` e executar:
 ```dotnet run```