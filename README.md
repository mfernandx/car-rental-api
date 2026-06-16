# 🚗 Car Rental API

API REST desenvolvida com **ASP.NET Core**, **Entity Framework Core** e **Oracle Database** para gerenciamento de uma locadora de carros.

O projeto permite o cadastro de veículos e o registro de locações com cálculo automático do valor final, incluindo descontos conforme a quantidade de dias alugados.

---

## 📌 Funcionalidades

### 🚘 Gerenciamento de carros

- Cadastrar um novo carro
- Listar todos os carros cadastrados
- Buscar um carro por ID
- Atualizar informações de um carro
- Remover um carro do sistema

### 📅 Locação de carros

- Registrar uma locação informando:
  - Carro escolhido
  - Data de início
  - Data de término
- Calcular automaticamente:
  - Quantidade de dias
  - Subtotal da locação
  - Desconto aplicado
  - Valor final

---

## 🛠️ Tecnologias utilizadas

- ASP.NET Core Web API
- C#
- Entity Framework Core
- Oracle Database
- Scalar / OpenAPI
- REST API

---

## 🗂️ Estrutura do projeto

```
LocadoraDeCarrosAPI
│
├── Controllers
│   ├── CarController.cs
│   └── RentalController.cs
│
├── Models
│   ├── Car.cs
│   └── Rental.cs
│
├── Data
│   └── AppDbContext.cs
│
├── Migrations
│
└── Program.cs
```

---

## 🚀 Como executar o projeto

### 1. Clone o repositório

```bash
git clone https://github.com/mfernandx/car-rental-api.git
```

### 2. Entre na pasta do projeto

```bash
cd car-rental-api
```

### 3. Configure a conexão com o Oracle

Altere a *Connection String* no arquivo:

```
appsettings.json
```

Exemplo:

```json
{
  "ConnectionStrings": {
    "OracleConnection": "User Id=usuario;Password=senha;Data Source=localhost:1521/XEPDB1"
  }
}
```

---

### 4. Instale as dependências

```bash
dotnet restore
```

---

### 5. Execute as migrations

```bash
dotnet ef database update
```

---

### 6. Inicie a aplicação

```bash
dotnet run
```

A API estará disponível em:

```
https://localhost:xxxx
```

O Scalar estará disponível em:

```
https://localhost:7248/scalar/v1
```

---

## 🔗 Endpoints

### Carros

| Método | Endpoint | Descrição |
|---|---|---|
| POST | `/api/cars` | Cadastrar um carro |
| GET | `/api/cars` | Listar todos os carros |
| GET | `/api/cars/{id}` | Buscar carro por ID |
| PUT | `/api/cars/{id}` | Atualizar carro |
| DELETE | `/api/cars/{id}` | Remover carro |

---

### Locação

| Método | Endpoint | Descrição |
|---|---|---|
| POST | `/api/rental/calcular` | Registrar locação e calcular valor final |

---

## 💰 Regras de negócio da locação

O valor da locação é calculado com base no número de dias:

- Até 2 dias: sem desconto
- De 3 a 6 dias: **5% de desconto**
- A partir de 7 dias: **10% de desconto**

Fórmula utilizada:

```csharp
dias = dataFim - dataInicio
subtotal = dias * valorDiaria

se dias >= 7:
    desconto = 10%

se dias >= 3:
    desconto = 5%
```

---

## 📄 Exemplo de requisição de locação

### Request

```json
{
  "carId": 1,
  "startDate": "2025-04-25",
  "endDate": "2025-04-30"
}
```

### Response

```json
{
  "carro": {
    "modelo": "Civic",
    "marca": "Honda"
  },
  "periodo": {
    "dataInicio": "25/04/2025",
    "dataFim": "30/04/2025",
    "dias": 5
  },
  "valorDiaria": 150.00,
  "subtotal": 750.00,
  "descontoAplicado": 5,
  "valorFinal": 712.50
}
```

---

## 👨‍💻 Autor

Desenvolvido por Maria Fernanda Santos Mendes.
