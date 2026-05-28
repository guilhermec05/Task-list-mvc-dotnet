# ✅ Task List — ASP.NET MVC (.NET Framework 4.7)

Uma aplicação web de gerenciamento de tarefas desenvolvida com **ASP.NET MVC** sobre o **.NET Framework 4.7**, aplicando boas práticas como inversão de dependência, mapeamento de objetos, acesso a dados via ORM e testes unitários.

---

## 📋 Sobre o Projeto

Este projeto é uma lista de tarefas (To-Do List) que permite criar, visualizar, editar e remover tarefas. A aplicação foi construída seguindo o padrão **MVC**, com camadas bem definidas, injeção de dependência via **Unity**, mapeamento entre entidades e DTOs com **AutoMapper**, persistência com **Entity Framework 6 + PostgreSQL** e autenticação/autorização com **OWIN**.

---

## 🚀 Funcionalidades

- 📝 Criar novas tarefas
- 📋 Listar todas as tarefas
- ✏️ Editar tarefas existentes
- 🗑️ Remover tarefas
- ✔️ Marcar tarefas como concluídas

---

## 🛠️ Tecnologias e Bibliotecas

| Tecnologia | Descrição |
|---|---|
| .NET Framework 4.7.2 | Plataforma base da aplicação |
| ASP.NET MVC 5 | Padrão arquitetural web (Model-View-Controller) |
| C# | Linguagem principal |
| Entity Framework 6 | ORM para acesso e mapeamento ao banco de dados |
| PostgreSQL + Npgsql + EntityFramework6.Npgsql | Banco de dados relacional e provider EF6 |
| AutoMapper | Mapeamento entre entidades de domínio e ViewModels |
| OWIN + Microsoft.Owin.Security.Cookies | Pipeline de autenticação e middleware HTTP |
| Unity + Unity.Mvc | Container de inversão de dependência (IoC/DI) |
| BCrypt-Net-Next | Hash de senhas |
| dotenv.net | Gerenciamento de variáveis de ambiente |
| xUnit | Framework de testes unitários |
| Bootstrap 5 + jQuery 3.7 | Frontend das views |

---

## 📁 Estrutura do Projeto

```
Task-list-mvc-dotnet/
│
├── task/                                  # Projeto principal ASP.NET MVC
│   │
│   ├── App_Start/                         # Inicialização da aplicação
│   │   ├── BundleConfig.cs
│   │   ├── FilterConfig.cs
│   │   ├── RouteConfig.cs
│   │   ├── Startup.cs                     # Configuração OWIN
│   │   ├── UnityConfig.cs                 # Registro de dependências no Unity
│   │   └── UnityMvcActivator.cs
│   │
│   ├── Configuration/                     # Configurações da aplicação
│   │   ├── AutoMapperConfig.cs            # Perfis do AutoMapper
│   │   └── DependecyConfiguration.cs      # Configuração de injeção de dependência
│   │
│   ├── Controllers/                       # Controladores MVC
│   │   ├── LoginController.cs
│   │   ├── TaskController.cs
│   │   └── UserController.cs
│   │
│   ├── Domain/                            # Camada de domínio
│   │   ├── Models/                        # Entidades de domínio
│   │   │   ├── Tasks.cs
│   │   │   ├── User.cs
│   │   │   └── enums/
│   │   │       └── StateTask.cs           # Enum de status da tarefa
│   │   │
│   │   └── ViewModels/                    # Modelos de apresentação
│   │       ├── LoginViewModel.cs
│   │       ├── SignUpViewModel.cs
│   │       ├── TaskListViewModel.cs
│   │       ├── TaskViewModel.cs
│   │       └── UserViewModel.cs
│   │
│   ├── Extensions/                        # Métodos de extensão
│   │   └── EnumExtensions.cs
│   │
│   ├── Infrastruct/                       # Infraestrutura de dados
│   │   ├── Data/
│   │   │   └── Context/
│   │   │       └── AppDbContext.cs        # DbContext do Entity Framework
│   │   │
│   │   └── Migration/
│   │       ├── Seeders/
│   │       │   └── UsersSeeds.cs          # Seed de dados iniciais
│   │       └── Tables/
│   │           ├── TaskMap.cs             # Mapeamento da tabela Tasks
│   │           └── UserMap.cs             # Mapeamento da tabela Users
│   │
│   ├── Mappers/                           # Perfis do AutoMapper
│   │   ├── TaskProfiller.cs
│   │   └── UserProfiler.cs
│   │
│   ├── Migrations/                        # Migrations do Entity Framework
│   │   ├── 202605131740218_InitialCreate.cs
│   │   ├── 202605181910545_update-task-table.cs
│   │   └── Configuration.cs
│   │
│   ├── Repositories/                      # Camada de acesso a dados
│   │   ├── RepositoryBase.cs
│   │   ├── TaskRepository.cs
│   │   ├── UnitOfWork.cs
│   │   ├── UserRepository.cs
│   │   └── Impl/                          # Interfaces dos repositórios
│   │       ├── ITaskRepository.cs
│   │       ├── IUnityOfWork.cs
│   │       └── IUserRepository.cs
│   │
│   ├── Resources/                         # Mensagens e recursos localizados
│   │   ├── Message.resx
│   │   ├── TaskMessages.resx
│   │   └── UserMessages.resx
│   │
│   ├── Services/                          # Camada de serviços (regras de negócio)
│   │   ├── AuthService.cs
│   │   ├── BaseService.cs
│   │   ├── TaskService.cs
│   │   ├── UserServices.cs
│   │   └── Impl/                          # Interfaces dos serviços
│   │       ├── IAuthService.cs
│   │       ├── ITaskService.cs
│   │       └── IUserServices.cs
│   │
│   ├── Shared/                            # Utilitários compartilhados
│   │   ├── Helpers/
│   │   │   └── Security/
│   │   │       └── CustomAuthorizeAttribute.cs
│   │   └── Util/
│   │       └── PasswordHandler.cs         # Utilitário de hash de senha (BCrypt)
│   │
│   ├── Views/                             # Views Razor (.cshtml)
│   │   ├── Login/
│   │   │   ├── Index.cshtml
│   │   │   └── SignUp.cshtml
│   │   ├── Shared/
│   │   │   ├── _Layout.cshtml
│   │   │   ├── _Menu.cshtml
│   │   │   └── Error.cshtml
│   │   ├── Task/
│   │   │   ├── Index.cshtml
│   │   │   ├── _AddTask.cshtml
│   │   │   └── _CardTask.cshtml
│   │   └── User/
│   │       └── Index.cshtml
│   │
│   ├── Content/                           # CSS (Bootstrap 5 + estilos customizados)
│   │   └── pages/
│   │       ├── Shared.css
│   │       ├── SingUp.css
│   │       └── Task.css
│   │
│   ├── Scripts/                           # JavaScript (Bootstrap 5 + jQuery 3.7)
│   │   └── Pages/
│   │       └── Tasks.js
│   │
│   ├── Global.asax                        # Ponto de entrada da aplicação
│   ├── Web.config                         # Configurações e connection string
│   └── packages.config                    # Pacotes NuGet
│
├── TestProject2/                          # Projeto de testes unitários (xUnit)
├── task.slnx                              # Arquivo de solução .NET
├── .gitignore
└── .gitattributes
```

---

## ⚙️ Pré-requisitos

- [Visual Studio 2019 ou superior](https://visualstudio.microsoft.com/) com suporte a **.NET Framework 4.7**
- [PostgreSQL](https://www.postgresql.org/download/) instalado e em execução
- [NuGet](https://www.nuget.org/) para restauração dos pacotes

---

## ▶️ Como Executar

**1. Clone o repositório**

```bash
git clone https://github.com/guilhermec05/Task-list-mvc-dotnet.git
```

**2. Abra a solução no Visual Studio**

Abra o arquivo `task.slnx` no Visual Studio.

**3. Restaure os pacotes NuGet**

```
Tools → NuGet Package Manager → Restore NuGet Packages
```


**5. Execute as migrations do Entity Framework**

No **Package Manager Console** (Tools → NuGet Package Manager → Package Manager Console):

```powershell
Update-Database
```

**6. Execute o projeto**

Pressione `F5` no Visual Studio.

---

## 🧪 Executando os Testes

Os testes unitários estão no projeto `TestProject2` usando **xUnit**.

Via Visual Studio:
```
Test → Run All Tests  (Ctrl + R, A)
```

---

## 📐 Arquitetura e Padrões

### Fluxo da aplicação

```
Requisição HTTP
      │
      ▼
  Controller  ──►  Service (regra de negócio)  ──►  Repository  ──►  EF6 + PostgreSQL
      │                         │
      │                   AutoMapper
      │                         │
      ▼                         ▼
    View  ◄──────────────  ViewModel / DTO
```

### Inversão de Dependência — Unity

O container **Unity** é configurado em `UnityConfig.cs` e `DependecyConfiguration.cs`, injetando automaticamente as dependências nos controllers.

```csharp
container.RegisterType<ITaskRepository, TaskRepository>();
container.RegisterType<ITaskService, TaskService>();
container.RegisterType<IAuthService, AuthService>();
```

### Mapeamento de Objetos — AutoMapper

Perfis definidos em `Mappers/` mapeiam as entidades de domínio para ViewModels e vice-versa.

```csharp
// TaskProfiller.cs
CreateMap<Tasks, TaskViewModel>();
CreateMap<TaskViewModel, Tasks>();
```

### Unit of Work + Repository Pattern

O padrão **Unit of Work** (`UnitOfWork.cs`) coordena as operações dos repositórios, garantindo consistência nas transações com o banco.

### Segurança

- Senhas armazenadas com hash via **BCrypt** (`PasswordHandler.cs`)
- Autorização customizada via `CustomAuthorizeAttribute.cs`
- Autenticação por cookies gerenciada pelo **OWIN**

---

## 🤝 Contribuindo

Contribuições são bem-vindas!

1. Faça um fork do projeto
2. Crie uma branch para sua feature (`git checkout -b feature/minha-feature`)
3. Commit suas mudanças (`git commit -m 'feat: minha nova feature'`)
4. Push para a branch (`git push origin feature/minha-feature`)
5. Abra um Pull Request

---

## 👤 Autor

**Guilherme C.**
- GitHub: [@guilhermec05](https://github.com/guilhermec05)

---

## 📄 Licença

Este projeto está sob a licença MIT. Consulte o arquivo `LICENSE` para mais detalhes.
