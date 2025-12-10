# OpenIddict Admin

Painel administrativo **open-source**, usando **OpenIddict + ASP.NET Core Identity**, pronto para integração com projetos .NET.

![Dashboard Preview](docs/dashboard-preview.gif)
> Painel Blazor WebAssembly com menu lateral, listagem de usuários, roles e claims.

---

## 🚀 Funcionalidades

- ✅ Gerenciamento completo de **usuários** (CRUD, reset de senha, bloqueio)  
- ✅ Gerenciamento de **roles** e atribuição de usuários  
- ✅ Gerenciamento de **claims** por usuário ou role  
- ⚙️ Gerenciamento de **clients e scopes** OpenIddict (em desenvolvimento)  
- 🔒 Autenticação via OpenIddict (Password + Refresh Token)  
- 📊 Dashboard SPA moderno com Blazor WebAssembly  
- 📝 Logs de auditoria para ações administrativas (planejado)

---

## 🛠 Stack Tecnológico

| Camada | Tecnologia |
|--------|------------|
| Backend | ASP.NET Core 10 WebAPI |
| Identity | ASP.NET Core Identity |
| OAuth/OIDC | OpenIddict |
| Frontend | Blazor WebAssembly |
| Banco de dados | SQL Server / PostgreSQL / MySQL / SQLite |

---

## 📂 Estrutura do Projeto

```
OpenIddict.Admin/
├─ src/
│  ├─ Seoldor.OpenIddict.Admin.API/           # Backend WebAPI
│  ├─ Seoldor.OpenIddict.Admin.UI/            # Frontend SPA (Blazor)
│  ├─ Seoldor.OpenIddict.Admin.Core/          # DTOs, interfaces e serviços
│  └─ Seoldor.OpenIddict.Admin.Infrastructure/# EF Core, Identity, OpenIddict
├─ tests/                              # Testes unitários
├─ docs/                               # Imagens, diagramas, GIFs
└─ README.md
```

---

## 📈 Arquitetura do Sistema

```
Frontend (Blazor SPA)
 ├─ Login / Dashboard / Users / Roles / Claims
 │
 │ HTTP Requests
 ▼
Backend (ASP.NET Core WebAPI)
 ├─ Controllers (Users, Roles, Claims, Clients, Scopes)
 ├─ Services e DTOs
 ├─ Identity + OpenIddict
 │
 │ EF Core (multi-banco)
 ▼
Banco de Dados
 ├─ SQL Server / PostgreSQL / MySQL / SQLite
 ├─ AspNetUsers / AspNetRoles / AspNetUserClaims
 ├─ OpenIddictApplications / OpenIddictScopes / OpenIddictTokens
```

![Architecture Diagram](docs/architecture-diagram.png)

---

## ⚡ Configuração Multi-Banco

No `appsettings.json`, configure o banco e a connection string:

```json
{
  "Database": {
    "Provider": "PostgreSQL"  // SqlServer | PostgreSQL | MySQL | SQLite
  },
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=OpenIddictAdmin;Username=postgres;Password=YourPassword;"
  }
}
```

### Exemplos por banco

- **SQL Server**
```json
"Provider": "SqlServer",
"DefaultConnection": "Server=localhost;Database=OpenIddictAdmin;User Id=sa;Password=YourPassword;"
```

- **PostgreSQL**
```json
"Provider": "PostgreSQL",
"DefaultConnection": "Host=localhost;Database=OpenIddictAdmin;Username=postgres;Password=YourPassword;"
```

- **MySQL**
```json
"Provider": "MySQL",
"DefaultConnection": "Server=localhost;Database=OpenIddictAdmin;User=root;Password=YourPassword;"
```

- **SQLite**
```json
"Provider": "SQLite",
"DefaultConnection": "Data Source=OpenIddictAdmin.db"
```

---

## ⚡ Primeiros Passos

1. **Clone o repositório**

```bash
git clone https://github.com/seu-usuario/OpenIddict.Admin.git
cd OpenIddict.Admin
```

2. **Instale os pacotes EF Core do seu banco escolhido**

```bash
# SQL Server
dotnet add package Microsoft.EntityFrameworkCore.SqlServer

# PostgreSQL
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL

# MySQL
dotnet add package Pomelo.EntityFrameworkCore.MySql

# SQLite
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
```

3. **Atualize o banco de dados**

```bash
cd src/OpenIddict.Admin.API
dotnet ef database update
```

4. **Rode a API**

```bash
dotnet run
```

5. **Rode o frontend Blazor**

```bash
cd src/OpenIddict.Admin.UI
dotnet run
```

6. **Acesse o painel**

```
https://localhost:5001
```

---

## 📄 Licença

MIT License – livre para uso e modificação, mantendo a atribuição.

---

## 📢 Próximos Passos do Projeto

- Integração completa de **Clients e Scopes** OpenIddict  
- Autenticação de **admin via JWT/refresh token**  
- **Paginação, filtros e modais** no frontend  
- Implementar **logs e auditoria detalhada**  
- Criar **template de contribuição** para a comunidade
