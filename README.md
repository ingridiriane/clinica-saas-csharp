# ClinicaSaaS

Projeto de estudo em C# e .NET voltado para o aprendizado prático de integridade de dados, regras de negócio e programação defensiva. 

> **Aviso:** Este repositório tem fins estritamente acadêmicos e de autoestudo, sem qualquer propósito comercial ou de uso em produção.

---

## Stack Técnica

* **Linguagem:** C# (.NET 8)
* **Paradigma:** Orientação a Objetos (POO)
* **Testes:** xUnit
* **Conceitos:** Defensive Programming, Null Safety, Clean Code

---

## Roadmap de Estudos

- [x] **Módulo 1: Fundação & Parsing Defensivo**  
  Tratamento estrito de tipos primitivos e prevenção de falhas de runtime (`TryParse`, sentinelas).
- [x] **Módulo 2: Fluxo, Decisão & Ciclo Contínuo**  
  Interface CLI navegável (`switch`), regras de negócio condicionais (`if/else`) e execução contínua da aplicação (`while`).
- [x] **Módulo 3: Métodos & Modularização**  
  Isolamento de responsabilidades (SRP), métodos auxiliares reutilizáveis e código limpo (*Clean Code*).
- [ ] **Módulo 4: Modelagem de Domínio & POO**  
  Criação de entidades (`Paciente`, `Consulta`), encapsulamento de propriedades e uso de Enums.
- [ ] **Módulo 5: Manipulação de Dados & LINQ**  
  Coleções em memória, consultas com LINQ e serialização em JSON.
- [ ] **Módulo 6: Suíte de Testes Unitários**  
  Cobertura automatizada de validações e regras de negócio com xUnit.

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

# Executar testes unitários
dotnet test