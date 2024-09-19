# Customer Management API & Frontend

Este projeto é uma aplicação de gerenciamento de clientes que consiste em uma API desenvolvida em **.NET 8** com **MongoDB** no backend e um frontend construído em **Angular** com **Tailwind CSS**. O projeto também inclui testes de integração para validar o correto funcionamento da API.

## Índice

1. [Clonando o Repositório](#clonando-o-repositório)
2. [Configurando o Backend (.NET + MongoDB)](#configurando-o-backend-net--mongodb)
3. [Configurando o Frontend (Angular + Tailwind)](#configurando-o-frontend-angular--tailwind)
4. [Executando os Testes de Integração](#executando-os-testes-de-integração)
5. [Sobre a API](#sobre-a-api)
6. [Funcionamento dos Testes de Integração](#funcionamento-dos-testes-de-integração)

---

## Clonando o Repositório

Para clonar este projeto e ter tudo em sua máquina local, execute os seguintes comandos no terminal:


Certifique-se de ter o .NET 8 SDK, MongoDB e Node.js instalados no seu sistema.

Configurando o Backend (.NET + MongoDB)
1. Instalar Dependências do Backend
Navegue até o diretório da API e instale as dependências do projeto .NET:

bash
Copiar código
cd Customer-api/backend
dotnet restore
2. Configurar o MongoDB
Certifique-se de ter o MongoDB rodando localmente ou em um serviço remoto.
Altere o arquivo appsettings.json para apontar para seu servidor MongoDB. Exemplo de configuração:
json
Copiar código
{
  "MongoDBSettings": {
    "ConnectionString": "mongodb://localhost:27017",
    "DatabaseName": "CustomerDb"
  }
}
3. Executar a API
Agora que as dependências estão instaladas e o MongoDB está configurado, você pode rodar a API:

bash
Copiar código
dotnet run
A API estará rodando por padrão no endereço: https://localhost:5001.

Configurando o Frontend (Angular + Tailwind)
1. Instalar Dependências do Frontend
No diretório raiz do projeto, vá até o diretório do frontend e instale as dependências do projeto Angular:

bash
Copiar código
cd frontend
npm install
2. Executar o Frontend
Após instalar as dependências, execute o comando abaixo para rodar o servidor de desenvolvimento do Angular:

bash
Copiar código
npm start
O frontend estará acessível em http://localhost:4200.

3. Tailwind CSS
Tailwind já está configurado no projeto e será aplicado automaticamente ao rodar o servidor Angular. Não é necessária configuração extra.

Executando os Testes de Integração
Os testes de integração garantem que os endpoints da API estejam funcionando corretamente.

1. Como Funciona o Teste de Integração
Os testes de integração utilizam um ambiente simulado para garantir que as operações CRUD (Create, Read, Update, Delete) de clientes funcionem conforme esperado.

Os testes são executados utilizando o xUnit no projeto .NET, validando se as operações na API estão corretas e se a comunicação com o MongoDB ocorre de maneira apropriada.

2. Executando os Testes
Para rodar os testes de integração, você deve navegar até o diretório backend e utilizar o comando abaixo:

bash
Copiar código
dotnet test
Isso vai executar todos os testes incluídos no projeto. Caso todos os testes passem, o resultado será exibido no terminal.

Sobre a API
A API de gerenciamento de clientes permite realizar operações CRUD básicas sobre os clientes da aplicação.

Endpoints
GET /api/customers: Retorna todos os clientes.
GET /api/customers/{id}: Retorna um cliente específico pelo seu ID.
POST /api/customers: Cria um novo cliente.
PUT /api/customers/{id}: Atualiza um cliente existente.
DELETE /api/customers/{id}: Deleta um cliente específico pelo ID.
Exemplo de Requisição POST:
json
Copiar código
{
  "firstName": "John",
  "lastName": "Doe",
  "email": "johndoe@example.com",
  "phone": "+1234567890"
}
Funcionamento dos Testes de Integração
Os testes de integração simulam requisições HTTP aos endpoints da API e verificam o comportamento esperado em cada uma das operações CRUD. Eles validam, por exemplo:

Se o cliente é criado corretamente.
Se as informações de um cliente existente são retornadas corretamente.
Se um cliente pode ser atualizado.
Se um cliente pode ser deletado.
Esses testes são importantes para garantir que a API funcione como esperado, mesmo após alterações no código.

Escrevendo Novos Testes
Você pode adicionar mais testes ao projeto adicionando novos métodos ao arquivo de testes de integração localizado em Tests/IntegrationTests/CustomerIntegrationTests.cs.

Executando Testes Específicos
Se você quiser rodar apenas um conjunto específico de testes, pode especificar o nome da classe ou do método ao rodar o comando dotnet test.

bash
Copiar código
dotnet test --filter "CustomerIntegrationTests"
Contribuições
Contribuições são bem-vindas! Se encontrar algum bug ou quiser adicionar novas funcionalidades, fique à vontade para abrir uma issue ou enviar um pull request.

Licença
Este projeto está sob a licença MIT. Para mais detalhes, veja o arquivo LICENSE.
