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
- [ ] **Módulo 2: Fluxo & Validação Contínua**  
  Interface CLI resiliente e validação iterativa de entradas de dados.
- [ ] **Módulo 3: Modelagem de Domínio**  
  Entidades (`Paciente`, `Consulta`, `Especialidade`), Enums e encapsulamento.
- [ ] **Módulo 4: Manipulação de Dados & LINQ**  
  Coleções em memória, consultas com LINQ e serialização em JSON.
- [ ] **Módulo 5: Suíte de Testes Unitários**  
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