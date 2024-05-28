# API de Agenda de Tarefas

Esta é uma API simples para gerenciar uma agenda de tarefas, construída com ASP.NET Core e Entity Framework Core. A API permite criar, ler, atualizar e excluir tarefas. Além disso, oferece endpoints para filtrar tarefas por título, data e status.

## Endpoints

### Tarefas

#### Criar uma nova Tarefa

- **URL:** `/api/Tarefa`
- **Método HTTP:** `POST`
- **Descrição:** Cria uma nova tarefa.
- **Corpo da Requisição:**
    ```json
    {
      "titulo": "String",
      "descricao": "String",
      "data": "DateTime",
      "status": "Pendente" | "EmProgresso" | "Concluida"
    }
    ```
- **Resposta de Sucesso:**
    ```json
    {
      "id": 1,
      "titulo": "String",
      "descricao": "String",
      "data": "DateTime",
      "status": "Pendente" | "EmProgresso" | "Concluida"
    }
    ```

#### Obter todas as Tarefas

- **URL:** `/api/Tarefa`
- **Método HTTP:** `GET`
- **Descrição:** Retorna uma lista de todas as tarefas.
- **Resposta de Sucesso:**
    ```json
    [
      {
        "id": 1,
        "titulo": "String",
        "descricao": "String",
        "data": "DateTime",
        "status": "Pendente" | "EmProgresso" | "Concluida"
      },
      ...
    ]
    ```

#### Obter uma Tarefa por ID

- **URL:** `/api/Tarefa/{id}`
- **Método HTTP:** `GET`
- **Descrição:** Retorna uma tarefa específica pelo ID.
- **Parâmetro de URL:** `id` (int) - O ID da tarefa.
- **Resposta de Sucesso:**
    ```json
    {
      "id": 1,
      "titulo": "String",
      "descricao": "String",
      "data": "DateTime",
      "status": "Pendente" | "EmProgresso" | "Concluida"
    }
    ```

#### Atualizar uma Tarefa

- **URL:** `/api/Tarefa/{id}`
- **Método HTTP:** `PUT`
- **Descrição:** Atualiza uma tarefa específica pelo ID.
- **Parâmetro de URL:** `id` (int) - O ID da tarefa.
- **Corpo da Requisição:**
    ```json
    {
      "id": 1,
      "titulo": "String",
      "descricao": "String",
      "data": "DateTime",
      "status": "Pendente" | "EmProgresso" | "Concluida"
    }
    ```
- **Resposta de Sucesso:** `204 No Content`

#### Excluir uma Tarefa

- **URL:** `/api/Tarefa/{id}`
- **Método HTTP:** `DELETE`
- **Descrição:** Exclui uma tarefa específica pelo ID.
- **Parâmetro de URL:** `id` (int) - O ID da tarefa.
- **Resposta de Sucesso:** `204 No Content`

### Filtros de Tarefas

#### Obter Tarefas por Título

- **URL:** `/api/Tarefa/Titulo/{titulo}`
- **Método

#Criação e Aplicação das Migrações
**Criar a primeira migração:**
```
dotnet ef migrations add InitialCreate
```
#Atualizar o banco de dados:
```
dotnet ef database update
```
#Executando a Aplicação
**Para executar a aplicação, use o comando:**

```
dotnet run
```
#Tecnologias Utilizadas
-ASP.NET Core
-Entity Framework Core
-PostgreSQL

#Estrutura do Projeto
-Controllers
--TarefaController.cs: Controlador para gerenciar operações CRUD para tarefas.
-Context
--AppDbContext.cs: Contexto do Entity Framework Core.
-Models
--Tarefa.cs: Modelo da entidade Tarefa.

#Contribuições
Sinta-se à vontade para contribuir com este projeto. Faça um fork do repositório, crie um branch para suas alterações e envie um pull request.


