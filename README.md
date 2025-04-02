# 💳 PicPay Simplificado - Challenge

<img src="https://img.shields.io/badge/.NET-8-512BD4?logo=dotnet" alt=".NET 8"> <img src="https://img.shields.io/badge/Architecture-Clean%20Architecture-blueviolet" alt="Clean Architecture"> <img src="https://img.shields.io/badge/Database-SQL%20Server-CC2927?logo=microsoft-sql-server" alt="SQL Server">

## 📌 Índice

- [Tecnologias](#-tecnologias--princípios)
- [Execução](#-como-executar)
- [Endpoints](#-principais-endpoints)
- [Testes](#-testes)

## 🔧 Tecnologias & Princípios

### Backend
- **.NET 8** com Minimal APIs
- **Entity Framework Core** (Code First)
- **Docker** (Container SQL Server)

### Padrões
- Clean Architecture
- Repository Pattern + Unit of Work
- Validações com FluentValidation

### Segurança / Auditoria
- BCrypt para hashing de senhas
- Tratamento de erros
  - Middleware global
  - Respostas padronizadas (Problem Details)
  - Serilog para registrar logs

### Testes
- xUnit
- Moq
- AutoFixture
- Bogus

## 🚀 Como Executar

### Pré-requisitos
- [Docker Desktop](https://www.docker.com/products/docker-desktop/) instalado
- [.NET 8](https://dotnet.microsoft.com/download/dotnet/8.0) instalado
- IDE de sua preferência (Visual Studio 2022 ou VS Code com extensão C#)

### Passo a Passo

1. Clone o repositório:
    ```bash
    git clone https://github.com/lorranmendes/challenge-picpay-simplificado.git
    cd challenge-picpay-simplificado
    ```

2. Suba o banco de dados no Docker:
    ```bash
    docker-compose up
    ```

3. Aplique as migrations:
   ```bash
    dotnet ef database update --project PicPaySimplificado.Infrastructure --startup-project PicPaySimplificado.API
    ```
   
4. Rode a aplicação.

## 📊 Endpoints
![image](https://github.com/user-attachments/assets/d6447868-f14a-45bb-80a9-3d6f56f27754)

Criar usuario:
```http
POST /users
{
  "name": "Fulano Silva",
  "email": "fulano@email.com",
  "password": "Senha123@",
  "document": "123.456.789-09",
  "userType": 1
}
```

Transferência:
```http
POST /transfers
{
  "payerId": 1,
  "payeeId": 2,
  "amount": 50
}
```

## 🧪 Testes
Execute os testes com:
  ```bash
  dotnet test
  ```
![image](https://github.com/user-attachments/assets/d2b9fc94-1f4e-4b7c-b824-2b5550b4248d)


   
<div align="center"> <p>Desenvolvido por <a href="https://github.com/lorranmendes">Lorran Mendes</a></p> <a href="https://www.linkedin.com/in/lorran-mendes-2b9287221/"> <img src="https://img.shields.io/badge/LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white"> </a> </div>
