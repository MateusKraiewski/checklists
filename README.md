# TransporteChecklistAPI

**TransporteChecklistAPI** é uma aplicação de backend desenvolvida em .NET 8 para gerenciar checklists de veículos. Esta API permite o controle de usuários, configurações de itens de checklist, e a execução de checklists de transporte com padrões definidos.

## **Requisitos**

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/sql-server)
- [Entity Framework Core](https://learn.microsoft.com/ef/core/)
- [Swagger](https://swagger.io/) para documentação interativa da API

## **Configuração do Projeto**

### **Clonando o Repositório**
```bash
git clone https://github.com/seu-repositorio/transporte-checklist-api.git
cd transporte-checklist-api

 -------------------------------------------
Instalação de Dependências
Certifique-se de restaurar os pacotes NuGet:

dotnet restore
 -------------------------------------------

Configuração da String de Conexão
Edite o arquivo appsettings.json na raiz do projeto TransporteChecklistAPI:
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=TransporteChecklistDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}

Substitua localhost pelo nome do servidor SQL, se necessário.
O parâmetro TrustServerCertificate=True é recomendado para ambientes de desenvolvimento.


 -------------------------------------------

Criação do Banco de Dados
Gere as migrações e aplique-as para criar o banco de dados:

dotnet ef migrations add InitialCreate --project TransporteChecklistAPI.Infra --startup-project TransporteChecklistAPI
dotnet ef database update --startup-project TransporteChecklistAPI


 -------------------------------------------

Estrutura do Projeto
TransporteChecklistAPI: Contém os controladores e configurações principais da API.
TransporteChecklistAPI.Application: Contém interfaces e comandos de aplicação.
TransporteChecklistAPI.Domain: Contém entidades e objetos de domínio.
TransporteChecklistAPI.Infra: Camada de acesso a dados e implementações de repositórios.


 -------------------------------------------

Padrões de Projeto Utilizados
Repository Pattern: Para abstrair o acesso aos dados.
CQRS (Command Query Responsibility Segregation): Utilizado para comandos como IniciarChecklistCommand.
Dependency Injection: Para inversão de controle e gerenciamento de dependências.


 -------------------------------------------

Funcionalidades
Checklists
POST /api/checklists/iniciar: Inicia um novo checklist com os itens configurados.
Body: IniciarChecklistCommand
GET /api/checklists: Lista todos os checklists registrados.
Itens Configurados
GET /api/itemconfigurado: Lista todos os itens configurados.
POST /api/itemconfigurado: Adiciona um novo item configurado.
Usuários
POST /api/usuarios: Registra um novo usuário.
GET /api/usuarios: Lista todos os usuários cadastrados.

 -------------------------------------------

Executando o Projeto
Para rodar o projeto em ambiente local:
dotnet run --project TransporteChecklistAPI
O Swagger estará disponível em:
https://localhost:7248  :  http://localhost:5298
