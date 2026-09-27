# ClinicaSaaS

Projeto de estudo em C# e .NET voltado para o aprendizado prático de integridade de dados, regras de negócio e programação defensiva. 

> **Aviso:** Este repositório tem fins estritamente acadêmicos e de autoestudo, sem qualquer propósito comercial ou de uso em produção.

---

## Stack Técnica & Conceitos Aplicados

* **Linguagem:** C# (.NET 8)
* **Paradigma:** Orientação a Objetos (POO) — Encapsulamento, Associação de Classes e Enums
* **Arquitetura & Design:** Clean Code, Single Responsibility Principle (SRP) e Padrão Repository (em progresso)
* **Práticas de Engenharia:** Defensive Programming, Null Safety, Validações Nativas em Construtores e Tratamento de Exceções (`try/catch`)
* **Testes:** xUnit (planejado)

---

## Roadmap de Estudos

- [x] **Módulo 1: Fundação & Parsing Defensivo**  
  Tratamento estrito de tipos primitivos e prevenção de falhas de runtime (`TryParse`, sentinelas).
- [x] **Módulo 2: Fluxo, Decisão & Ciclo Contínuo**  
  Interface CLI navegável (`switch`), regras de negócio condicionais (`if/else`) e execução contínua da aplicação (`while`).
- [x] **Módulo 3: Métodos & Modularização (Clean Code)**  
  Isolamento de responsabilidades (SRP), métodos auxiliares reutilizáveis e código limpo.
- [x] **Módulo 4: Modelagem de Domínio & POO**  
  Criação de entidades (`Paciente`, `Consulta`), encapsulamento de estado, regras de negócio financeiras/etárias, construtores defensivos com `try/catch` e uso do Enum `StatusConsulta`.
- [ ] **Módulo 5: Coleções em Memória, LINQ & Persistência**  
  Manipulação de listas dinâmicas (`List<T>`), consultas com LINQ, persistência em arquivo local e Padrão Repository.
- [ ] **Módulo 6: Arquitetura de Solução Multi-Projetos em .NET**  
  Estruturação em Monorepo (`/src/backend`, `/src/frontend`) e divisão em camadas (Domínio, Infraestrutura, Apresentação).
- [ ] **Módulo 7: Banco de Dados Relacional & EF Core**  
  Modelagem SQL, ORM com Entity Framework Core e controle de schema via Migrations.
- [ ] **Módulo 8: Transformação para Web API RESTful (.NET 8)**  
  Controllers, DTOs, Injeção de Dependência, Swagger e Middlewares para tratamento global de erros.
- [ ] **Módulo 9: Interface Web SPA (React ou Angular)**  
  Desenvolvimento do front-end reativo e integração com a Web API.
- [ ] **Módulo 10: Containerização & DevOps Básico (Docker)**  
  Criação de `Dockerfile` e orquestração de ambiente completo via `Docker Compose`.
- [ ] **Módulo 11: Segurança e Autenticação (JWT)**  
  Proteção de endpoints e dados de saúde com tokens JWT.
- [ ] **Módulo 12: Estratégia de QA, Casos de Teste & Automação**  
  Planos de teste, BDD/Gherkin, testes unitários com xUnit, testes de integração, testes E2E com Playwright, testes de carga com K6 e CI/CD via GitHub Actions.

---

## Como Executar

### Pré-requisitos
* [.NET SDK 8.0+](https://dotnet.microsoft.com/download)

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