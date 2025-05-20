# 🚀 MotoGridAPI (.NET)

API REST desenvolvida para o projeto da **1ª Sprint do Challenge FIAP**.  
Este sistema em .NET permite o **gerenciamento de motos e pátios**, com funcionalidades completas de CRUD, integração com banco de dados Oracle, documentação via Swagger e boas práticas de desenvolvimento como uso de DTOs, validações e arquitetura em camadas.

✅ Projeto desenvolvido para atender 100% dos requisitos técnicos exigidos pela entrega da Sprint 1.

---

## 🎯 Objetivo da API

Oferecer uma solução backend robusta para:

- Cadastrar, atualizar, listar e excluir motos.
- Relacionar motos com pátios.
- Filtrar motos por **placa** ou **status**.
- Listar pátios por **cidade**.
- Validar entradas e fornecer respostas padronizadas.
- Documentar a API com Swagger UI (OpenAPI).

---

## 🔗 Rotas Disponíveis

### 🛵 Motos (`/api/motos`)

| Método | Rota                          | Descrição                                |
|--------|-------------------------------|------------------------------------------|
| GET    | `/api/motos`                  | Lista todas as motos                     |
| GET    | `/api/motos/{id}`             | Busca moto por ID                        |
| GET    | `/api/motos/placa/{placa}`    | Busca moto por placa                     |
| POST   | `/api/motos`                  | Cadastra uma nova moto                   |
| PUT    | `/api/motos/{id}`             | Atualiza uma moto existente              |
| DELETE | `/api/motos/{id}`             | Remove uma moto                          |

### 📦 Pátios (`/api/patios`)

| Método | Rota                              | Descrição                              |
|--------|-----------------------------------|----------------------------------------|
| GET    | `/api/patios`                     | Lista todos os pátios                  |
| GET    | `/api/patios/{id}`                | Busca pátio por ID                     |
| GET    | `/api/patios/cidade/{cidade}`     | Lista pátios por cidade                |
| POST   | `/api/patios`                     | Cadastra um novo pátio                 |
| PUT    | `/api/patios/{id}`                | Atualiza um pátio existente            |
| DELETE | `/api/patios/{id}`                | Remove um pátio                        |

---

## 🛠 Tecnologias Utilizadas

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- Oracle Database
- Swagger / OpenAPI
- AutoMapper
- DTOs para entrada e saída
- Validações com DataAnnotations
- Arquitetura em camadas (Domain, Application, Infrastructure)
- Git e GitHub para versionamento

---

## ▶️ Instruções para Executar

### Pré-requisitos:
- .NET 8 SDK instalado
- Banco de dados Oracle disponível
- IDE como Visual Studio ou VS Code

### Passos:

1. Clone o repositório:
   ```bash
   git clone https://github.com/seu-usuario/motogrid-api-dotnet.git
    ```

2. Configure a string de coexão no arquivo appsettings.json:
  ```json
    "ConnectionStrings": {
    "DefaultConnection": "User Id=USUARIO;Password=SENHA;Data Source=localhost:1521/XEPDB1"
    }
  ```

3. Execute as migrations e atualize o banco:
  ```bash
    dotnet ef database update
  ```

4. Rode o projeto:
  ```bash
  dotnet run
  ```
5. Acesse a documentação da API:
  - Swagger UI: http://localhost:5079/swagger

---

### 📦 Exemplos de Requisição

## POST /api/patios
  ```json
  {
    "nome": "Pátio Centro",
    "cidade": "São Paulo",
    "capacidade": 50
  }
  ```
## GET /api/patios/cidade/São Paulo
    Retorna todos os pátios localizados na cidade de São Paulo.

---

## POST /api/motos
```json
  {
  "placa": "XYZ1234",
  "modelo": "Honda CG",
  "status": "DISPONIVEL",
  "patioId": "GUID_DO_PATIO"
}
```
## GET /api/motos/placa/XYZ1234
      Retorna os dados da moto com a placa especificada.


---

### ❌ Tratamento de Erros
  A API possui um mecanismo centralizado de tratamento de exceções, retornando respostas padronizadas em JSON com timestamp, status, error, message e path.
  
## 🔸 Erro de Validação (HTTP 422)
  ```json
    {
       "status": 422,
       "error": "Erro de Validação",
      "messages": {
      "placa": "A placa é obrigatória",
      "nome": "O nome do pátio é obrigatório"
      }
    }
```

## 🔸 Entidade Não Encontrada (HTTP 404)
  ```json
    {
      "status": 404,
      "error": "Not Found",
      "message": "Pátio não encontrado"
    }
  ```

## 🔸 Status Inválido no Filtro (HTTP 400)
  ```json
    {
      "status": 400,
      "error": "Bad Request",
      "message": "ID do corpo e da URL não conferem"
    }
  ```

## 🔸 ID do PUT divergente (HTTP 400)
  ```json
  {
    "status": 400,
    "error": "Bad Request",
    "message": "ID do corpo e da URL não conferem"
  }
  ```

## 🔸 Erro Genérico (HTTP 500)
  ```json
  {
    "status": 500,
    "error": "Internal Server Error",
    "message": "Erro interno: ..."
  }
  ```

---

### ✅ Funcionalidades Extras

- 🔍 Filtros por placa e status para motos
- 🏙️ Filtro por cidade para pátios
- 📃 Documentação completa com Swagger
- 🛑 Validação de enums com mensagens claras
- 🔐 Verificação de consistência entre ID da rota e ID do corpo no PUT
- 💡 Padrão de projeto com uso de DTOs, AutoMapper e validações centralizadas
- 📂 Organização em camadas para melhor manutenção

---

### 👥 Alunos Participantes

  - Victor Hugo Carvalho Pereira — RM: 558550
  - Gabriel Gomes Mancera — RM: 555427
  - Juliana de Andrade Sousa — RM: 558834 
