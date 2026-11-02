# API de Gerenciamento de Tarefas
API RESTful desenvolvida em C# com ASP.NET Core e Entity Framework Core para o gerenciamento de tarefas.

## Endpoints da API

- **GET `/api/tasks`**: Listagem de todas as tarefas.
- **POST `/api/tasks`**: Criação de uma nova tarefa.
- **GET `/api/tasks/{id}`**: Busca de uma tarefa específica por ID.
- **DELETE `/api/tasks/{id}`**: Remoção de uma tarefa por ID.
- **PATCH `/api/tasks/{id}/status`**: Atualização do status de uma tarefa.

## Como Executar o Projeto

### Pré-requisitos
- **.NET SDK** instalado. (Esse projeto foi criado e testado na versão 8.0). 
- **SQL Server** em execução.

### Passos

1. **Clonar o Repositório:**
```bash
https://github.com/allysson-nn/todo-api.git
```

2. **Configurar a Connection String:**
Insira a string de conexão do SQL Server no arquivo `appsettings.json` ou utilize o User Secrets do .NET para maior segurança.

3. **Aplicar as Migrations no Banco de Dados:**
```bash
dotnet ef database update
```
4. **Executar a Aplicação:**
```bash
dotnet run
```

## Tecnologias Utilizadas no Projeto
- **C#** / **.NET**
- **ASP.NET Core**
- **Entity Framework Core**
- **SQL Server**
