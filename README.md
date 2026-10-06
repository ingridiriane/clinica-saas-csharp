# ClinicaSaaS

Projeto de estudo em C# e .NET voltado para o aprendizado prático de integridade de dados, regras de negócio e programação defensiva. 

> **Aviso:** Este repositório tem fins estritamente acadêmicos e de autoestudo, sem qualquer propósito comercial ou de uso em produção.

---

## Stack Técnica & Conceitos Aplicados

* **Linguagem:** C# (.NET 8)[cite: 9]
* **Paradigma:** Orientação a Objetos (POO) — Encapsulamento, Associação de Classes e Enums[cite: 9]
* **Persistência Local:** Leitura e gravação automática em arquivos CSV (`StreamWriter` e `StreamReader`)[cite: 8]
* **Arquitetura & Design:** Clean Code, Single Responsibility Principle (SRP) e Padrão Repository (`RepositorioPaciente` e `RepositorioConsulta`)[cite: 7, 8, 9]
* **Práticas de Engenharia:** Defensive Programming, Null Safety, Validações Nativas em Construtores e Tratamento de Exceções (`try/catch`)[cite: 9]
* **Testes:** xUnit, Mocks e FluentAssertions (planejado)[cite: 8, 9]

---

## Contexto Atual do Projeto & Armazenamento Local

O projeto concluiu com êxito a **FASE 1 (CLI, Lógica & Modelagem de Domínio)**[cite: 8]. 

A aplicação evoluiu de um sistema volátil baseado apenas em memória RAM para uma arquitetura com **persistência em arquivos locais (CSV)** e isolamento completo da camada de dados através do **Padrão Repository**[cite: 7, 8]. 

> 📁 **Aviso de Armazenamento Local:** Ao executar a aplicação, o sistema criará e manipulará automaticamente os arquivos `pacientes.csv` e `consultas.csv` no diretório local da execução. Isso garante que todos os pacientes cadastrados e consultas agendadas permaneçam salvos na máquina do operador mesmo após o encerramento do programa.

O arquivo `Program.cs` atua estritamente no controle do fluxo da CLI e na exibição dos menus, enquanto todas as operações de I/O, parsing e gravação são delegadas aos seus respectivos repositórios[cite: 7, 8].

---

## Roadmap de Estudos

- [x] **Módulo 1: Fundação & Parsing Defensivo**  
  Tratamento estrito de tipos primitivos e prevenção de falhas de runtime (`TryParse`, sentinelas)[cite: 8, 9].
- [x] **Módulo 2: Fluxo, Decisão & Ciclo Contínuo**  
  Interface CLI navegável (`switch`), regras de negócio condicionais (`if/else`) e execução contínua da aplicação (`while`)[cite: 8, 9].
- [x] **Módulo 3: Métodos & Modularização (Clean Code)**  
  Isolamento de responsabilidades (SRP), métodos auxiliares reutilizáveis e código limpo[cite: 8, 9].
- [x] **Módulo 4: Modelagem de Domínio & POO**  
  Criação de entidades (`Paciente`, `Consulta`), encapsulamento de estado, regras de negócio financeiras/etárias, construtores defensivos com `try/catch` e uso do Enum `StatusConsulta`[cite: 8, 9].
- [x] **Módulo 5: Coleções em Memória, LINQ & Persistência**  
  Manipulação de listas dinâmicas (`List<T>`), relatórios dinâmicos com LINQ (`Sum`, `Average`, `Max`, `Count`), persistência em arquivos CSV e isolamento arquitetural com o Padrão Repository[cite: 7, 8, 9].
- [ ] **Módulo 6: Arquitetura de Solução Multi-Projetos em .NET**  
  CLI do .NET (`dotnet new sln`), estruturação em Monorepo (`/src/backend`, `/src/frontend`) e divisão em camadas (Domínio, Infraestrutura, Apresentação)[cite: 8, 9].
- [ ] **Módulo 7: Banco de Dados Relacional & EF Core**  
  Modelagem SQL, ORM com Entity Framework Core e controle de schema via Migrations[cite: 8, 9].
- [ ] **Módulo 8: Transformação para Web API RESTful (.NET 8)**  
  Controllers, DTOs, Injeção de Dependência, Swagger e Middlewares para tratamento global de erros (Problem Details RFC 7807)[cite: 8, 9].
- [ ] **Módulo 9: Interface Web SPA (React ou Angular)**  
  Desenvolvimento de front-end reativo, formulários, dashboards e integração com Web API[cite: 8, 9].
- [ ] **Módulo 10: Containerização & DevOps Básico (Docker)**  
  Containerização do backend e banco de dados via `Dockerfile` e orquestração do ambiente completo via `Docker Compose`[cite: 8, 9].
- [ ] **Módulo 10B: Deploy & Cloud Infrastructure (Microsoft Azure)**  
  Hospedagem PaaS (Azure App Service / Azure SQL), imagens no Azure Container Registry (ACR) e deploy automatizado via GitHub Actions[cite: 8].
- [ ] **Módulo 11: Segurança e Autenticação (JWT)**  
  Autenticação com JWT para proteção de dados médicos e controle de acesso por perfil de operador[cite: 8, 9].
- [ ] **Módulo 12: Estratégia de QA, Casos de Teste & Automação**  
  Planos de teste, BDD/Gherkin, testes unitários com xUnit/Mocks/FluentAssertions, testes de integração, testes E2E com Playwright/Selenium, testes de carga com K6/Locust e CI/CD via GitHub Actions[cite: 8, 9].

---

## Como Executar

### Pré-requisitos
* [.NET SDK 8.0+](https://dotnet.microsoft.com/download)[cite: 9]

### Execução

```bash
# Clonar o repositório
git clone [https://github.com/ingridiriane/clinica-saas-csharp.git](https://github.com/ingridiriane/clinica-saas-csharp.git)

# Entrar no diretório
cd clinica-saas-csharp

# Executar a aplicação
dotnet run

# Executar testes unitários (futuro)
dotnet test