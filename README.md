# ControleNotas

O **ControleNotas** é uma aplicação ASP.NET Core para gerenciar alunos, disciplinas, professores e notas. Ele utiliza o Entity Framework Core com MySQL para persistência de dados e segue uma arquitetura baseada em repositórios e serviços.

## Funcionalidades

- **Alunos**:
  - Adicionar, atualizar, deletar e listar alunos.
  - Buscar alunos por ID, nome ou matrícula.

- **Disciplinas**:
  - Adicionar, atualizar, deletar e listar disciplinas.
  - Buscar disciplinas por ID ou nome.

- **Notas**:
  - Adicionar, atualizar, deletar e listar notas.
  - Buscar notas por ID ou aluno.

- **Professores**:
  - Adicionar, atualizar, deletar e listar professores.
  - Buscar professores por ID, nome ou disciplina.

## Tecnologias Utilizadas

- **ASP.NET Core 8.0**
- **Entity Framework Core 8.0**
- **MySQL** (via `Pomelo.EntityFrameworkCore.MySql`)
- **Swagger** para documentação da API
- **Dependency Injection** para gerenciar repositórios e serviços

## Estrutura do Projeto

O projeto segue uma estrutura organizada em camadas:

- **Controllers**: Controladores que expõem endpoints REST.
- **Services**: Camada de lógica de negócios.
- **Repositories**: Camada de acesso a dados.
- **Models**: Representação das entidades do banco de dados.
- **DTOs**: Objetos de transferência de dados para entrada e saída.
- **Context**: Configuração do Entity Framework Core.

## Configuração

### Pré-requisitos

- .NET 8.0 SDK
- MySQL Server

### Configuração do Banco de Dados

1. Atualize a string de conexão no arquivo `appsettings.Development.json`:
   ```json
   "ConnectionStrings": {
       "DefaultConnection": "Server=127.0.0.1;=controlenotasdb;User=SeuUser;Password=SuaSenha;SslMode=none;"
   }
   ```

2. Execute as migrações para criar o banco de dados:
   ```bash
   dotnet ef database update
   ```

### Executando o Projeto

1. Restaure as dependências:
   ```bash
   dotnet restore
   ```

2. Execute o projeto:
   ```bash
   dotnet run
   ```

3. Acesse a documentação Swagger em:
   ```
   https://localhost:7010/swagger
   ```

## Endpoints

### Alunos

- `GET /api/aluno` - Lista todos os alunos.
- `GET /api/aluno/{id}` - Busca um aluno por ID.
- `GET /api/aluno/matricula/{matricula}` - Busca um aluno pela matrícula.
- `GET /api/aluno/nome/{nome}` - Busca alunos pelo nome.
- `POST /api/aluno` - Adiciona um novo aluno.
- `PUT /api/aluno/{id}` - Atualiza um aluno existente.
- `DELETE /api/aluno/{id}` - Remove um aluno.

### Disciplinas

- `GET /api/disciplina` - Lista todas as disciplinas.
- `GET /api/disciplina/{id}` - Busca uma disciplina por ID.
- `GET /api/disciplina/nome/{nome}` - Busca disciplinas pelo nome.
- `POST /api/disciplina` - Adiciona uma nova disciplina.
- `PUT /api/disciplina/{id}` - Atualiza uma disciplina existente.
- `DELETE /api/disciplina/{id}` - Remove uma disciplina.

### Notas

- `GET /api/nota` - Lista todas as notas.
- `GET /api/nota/{id}` - Busca uma nota por ID.
- `GET /api/nota/aluno/{alunoId}` - Busca notas pelo ID do aluno.
- `POST /api/nota` - Adiciona uma nova nota.
- `PUT /api/nota/{id}` - Atualiza uma nota existente.
- `DELETE /api/nota/{id}` - Remove uma nota.

### Professores

- `GET /api/professor` - Lista todos os professores.
- `GET /api/professor/{id}` - Busca um professor por ID.
- `GET /api/professor/disciplina/{disciplinaId}` - Busca professores pelo ID da disciplina.
- `GET /api/professor/nome/{nome}` - Busca professores pelo nome.
- `POST /api/professor` - Adiciona um novo professor.
- `PUT /api/professor/{id}` - Atualiza um professor existente.
- `DELETE /api/professor/{id}` - Remove um professor.

## Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues ou enviar pull requests.

## Licença

Este projeto está licenciado sob a [MIT License](LICENSE).