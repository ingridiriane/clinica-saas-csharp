// Entrada

    // Dados do Paciente

    Console.Write("Digite o nome do paciente: ");
    string? entradaNome = Console.ReadLine();
    string nomePaciente = string.IsNullOrWhiteSpace(entradaNome) ? "Não informado" : entradaNome;

    Console.Write("Digite a idade do paciente: ");
    string? entradaIdade = Console.ReadLine();
    int idadePaciente = int.TryParse(entradaIdade, out int idadeConvertida) ? idadeConvertida : -1;

    Console.Write("Digite o convênio do paciente (Se não houver, tecle Enter): ");
    string? entradaConvenio = Console.ReadLine();
    bool possuiConvenio = !string.IsNullOrWhiteSpace(entradaConvenio);
    string nomeConvenio = possuiConvenio ? entradaConvenio! : "Particular";

    // Dados da Consulta

    Console.Write("Digite o valor da consulta: ");
    string? entradaValor = Console.ReadLine();
    decimal valorConsulta = decimal.TryParse(entradaValor, out decimal valorConvertido) ? valorConvertido : -1.00m;

    DateTime dataHoraConsulta = new(2026, 10, 15, 14, 0, 0);
    TimeSpan duracaoConsulta = TimeSpan.FromMinutes(45);
    DateTime dataHoraTermino = dataHoraConsulta.Add(duracaoConsulta);


// Saída

    Console.WriteLine("=== SISTEMA CLÍNICA SAAS ===");
    Console.WriteLine($"Paciente: {nomePaciente}");
    Console.WriteLine($"Idade do Paciente: {(idadePaciente == -1 ? "Não informado" : $"{idadePaciente} anos")}"); 
    Console.WriteLine($"Convênio: {nomeConvenio}");
    Console.WriteLine($"Valor da Consulta: {(valorConsulta == -1.00m ? "Não informado" : $"{valorConsulta:C}")}");
    Console.WriteLine($"Data do Atendimento: {dataHoraConsulta:dd/MM/yyyy}");
    Console.WriteLine($"Horário: das {dataHoraConsulta:HH:mm} ás {dataHoraTermino:HH:mm} ({duracaoConsulta.TotalMinutes} min)");