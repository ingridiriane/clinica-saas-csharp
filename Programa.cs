using ClinicaSaaS;

bool executando = true;

while (executando)
{
    string? opcaoMenu = ExibirMenuInicial();

    switch (opcaoMenu)
    {
        case "1":
            ProcessarNovoAtendimento();
            Limpeza();

            break;

        case "2":
            ExibirInformacoesClinica();
            Limpeza();

            break;

        case "0":
            Console.WriteLine("Sistema encerrado pelo operador.");
            executando = false;

            break;

        default:
            Console.WriteLine("Opção inválida");
            Limpeza();

            break;
    }

}

static void ExibirInformacoesClinica()
{
    Console.WriteLine("=== Informações da Clínica ===");
    Console.WriteLine("Endereço: R. Ficitica, 99 - Bairro tal");
    Console.WriteLine("Horários de atendimento:\nSegunda à Sexta - 09h às 20h\nSábado - 09h às 12h\nDomingo e Feriados - Encerrado");
}

static string? ExibirMenuInicial()
{
    Console.WriteLine("=== SISTEMA CLÍNICA SAAS ===");
    Console.WriteLine("1 - Novo Atendimento\n2 - Informações da Clínica\n0 - Sair");

    Console.Write("Escolha uma opção: ");
    return Console.ReadLine();
}

static void Limpeza()
{
    Console.WriteLine("Pressione Enter para voltar ao menu...");
    Console.ReadLine();

    Console.Clear();
}

static void ProcessarNovoAtendimento()
{
    //PACIENTE
    Console.WriteLine("Digite o nome do paciente: ");
    string nome = Console.ReadLine() ?? "";

    try
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("O nome é de preenchimento obrigatório");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"Erro de cadastro: {ex.Message}");
        return;
    }

    Console.WriteLine("Digite a data de nascimento do paciente (dd/mm/aaaa): ");
    if (!DateTime.TryParse(Console.ReadLine(), out DateTime dataNascimento))
    {
        Console.WriteLine("Data em formato inválido");
        return;
    }

    Console.WriteLine("Digite o convênio do paciente (Aperte Enter se for particular): ");
    string? convenioInput = Console.ReadLine();
    string convenio = string.IsNullOrWhiteSpace(convenioInput) ? "Particular" : convenioInput;

    Console.WriteLine("Digite o número do paciente (opcional): ");
    string? telefone = Console.ReadLine() ?? "";

    Paciente paciente;
    try
    {
        paciente = new Paciente(nome, dataNascimento, convenio, telefone);
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"Erro ao cadastrar paciente: {ex.Message}");
        return;
        
    }

    //CONSULTA
    Console.WriteLine("Digite a duração da consulta: ");
    string durancaoInput = Console.ReadLine() ?? "0";
    int duracao = int.TryParse(durancaoInput, out int minutos)
        ? minutos
        : 0;

    Console.WriteLine("Digite o valor da consulta: ");
    if (!decimal.TryParse(Console.ReadLine(), out decimal valor))
    {
        Console.WriteLine("Valor informado não é válido.");
        return;
    }

    StatusConsulta status = LerStatusConsulta();

    Consulta consulta = new Consulta(paciente)
    {
        Duracao = duracao,
        Valor = valor,
        Status = status
    };

    //EXIBIR RESULTADO DOS INPUTS
    Console.WriteLine("=== NOVO ATENDIMENTO ===");
    Console.WriteLine($"Paciente: {consulta.Paciente.Nome}");
    Console.WriteLine($"Idade: {consulta.Paciente.Idade}");
    Console.WriteLine($"Convênio: {consulta.Paciente.Convenio}");
    Console.WriteLine($"Telefone: {consulta.Paciente.Telefone ?? "Não informado"}");
    Console.WriteLine($"Horário: das {consulta.DataHora:HH:mm} às {consulta.DataHoraTermino:HH:mm}");
    Console.WriteLine($"Valor: {consulta.Valor:C}");
    Console.WriteLine($"Status: {consulta.Status}");
    Console.WriteLine("\n=== INFORMAÇÕES ===");
    Console.WriteLine(consulta.Paciente.MensagemAcompanhante);
    Console.WriteLine(consulta.MensagemDesconto);
    
}

static StatusConsulta LerStatusConsulta()
{
    Console.WriteLine("1 - Agendada\n2 - Confirmada\n3 - Em Atendimentoo\n4 - Concluída\n5 - Cancelada\nEscolha o estado da Consulta: ");
    string? status = Console.ReadLine();

    return status switch
    {
        "1" => StatusConsulta.Agendada,
        "2" => StatusConsulta.Confirmada,
        "3" => StatusConsulta.EmAtendimento,
        "4" => StatusConsulta.Concluida,
        "5" => StatusConsulta.Cancelada,
        _ => StatusConsulta.Agendada //em caso de entrada inválida, assume status padrão

    };
}