// Entrada

    // Dados do Paciente

    Console.Write("Digite o nome do paciente: ");
    string? entradaNome = Console.ReadLine();
    string nomePaciente = string.IsNullOrWhiteSpace(entradaNome) 
                ? "Não informado" : entradaNome;

    Console.Write("Digite a data de nascimento do paciente: ");
    string? entradaDataNascimento = Console.ReadLine();
    DateTime dataNascimentoPaciente = DateTime.TryParse(entradaDataNascimento, out DateTime dataNascimentoConvertida) 
                ? dataNascimentoConvertida.Date 
                : new(2500, 1, 1);

    bool dataNascimentoValida = dataNascimentoPaciente.Year != 2500;

    DateTime dataAtual = DateTime.Today;
    int idadePaciente = dataNascimentoValida 
                ? dataAtual.Year - dataNascimentoPaciente.Year - (dataAtual.DayOfYear < dataNascimentoPaciente.DayOfYear ? 1 : 0) 
                : 0;

    Console.Write("Digite o convênio do paciente (Se não houver, tecle Enter): ");
    string? entradaConvenio = Console.ReadLine();
    bool possuiConvenio = !string.IsNullOrWhiteSpace(entradaConvenio);
    string nomeConvenio = possuiConvenio 
                ? entradaConvenio! 
                : "Particular";

    // Dados da Consulta

    Console.Write("Digite o valor da consulta: ");
    string? entradaValor = Console.ReadLine();
    decimal valorConsulta = decimal.TryParse(entradaValor, out decimal valorConvertido) 
                    ? valorConvertido 
                    : -1.00m;

    DateTime dataHoraConsulta = new(2026, 10, 15, 14, 0, 0);
    TimeSpan duracaoConsulta = TimeSpan.FromMinutes(45);
    DateTime dataHoraTermino = dataHoraConsulta.Add(duracaoConsulta);

// Processamento

    //Opções de valor da consulta para o terminal
    string opcoesValor = valorConsulta switch
    {
        < 0 => "Não informado",
        0.00m => "Gratuito (Retorno)",
        _ => valorConsulta.ToString("C")
    };

// Saída

    Console.WriteLine("=== SISTEMA CLÍNICA SAAS ===");
    Console.WriteLine($"Paciente: {nomePaciente}");
    Console.WriteLine($"Idade do Paciente: {(dataNascimentoValida ? $"{idadePaciente} anos" : "Não informado")}"); 
    Console.WriteLine($"Convênio: {nomeConvenio}");
    Console.WriteLine($"Valor da Consulta: {opcoesValor}");
    Console.WriteLine($"Data do Atendimento: {dataHoraConsulta:dd/MM/yyyy}");
    Console.WriteLine($"Horário: das {dataHoraConsulta:HH:mm} ás {dataHoraTermino:HH:mm} ({duracaoConsulta.TotalMinutes} min)");