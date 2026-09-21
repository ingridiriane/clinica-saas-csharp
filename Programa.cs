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

    int idadePaciente = dataNascimentoValida
                ? CalcularIdade(dataNascimentoPaciente)
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

    string mensagemAcompanhante = ObterMensagemAcompanhante(idadePaciente, dataNascimentoValida);

    valorConsulta = CalcularValorConsulta(valorConsulta, idadePaciente, dataNascimentoValida);
    string opcoesDesconto = ObterMensagemDesconto(idadePaciente, dataNascimentoValida);

    string opcoesValor = valorConsulta switch
    {
        < 0 => "Não informado",
        0.00m => "Gratuito",
        _ => valorConsulta.ToString("C")
    };

    Console.WriteLine("\n\n=== Novo Atendimento ===");
    Console.WriteLine($"Paciente: {nomePaciente}");
    Console.WriteLine($"Idade do Paciente: {(dataNascimentoValida ? $"{idadePaciente} anos" : "Não informado")}");
    Console.WriteLine($"Convênio: {nomeConvenio}");
    Console.WriteLine($"Valor da Consulta: {opcoesValor}");
    Console.WriteLine($"Data do Atendimento: {dataHoraConsulta:dd/MM/yyyy}");
    Console.WriteLine($"Horário: das {dataHoraConsulta:HH:mm} às {dataHoraTermino:HH:mm} ({duracaoConsulta.TotalMinutes} min)");
    Console.WriteLine("\n=== Informações para o paciente ===");
    Console.WriteLine(mensagemAcompanhante);
    Console.WriteLine($"{opcoesDesconto}");
}

static int CalcularIdade(DateTime dataNascimento)
{
    DateTime dataAtual = DateTime.Today;
    int idade = dataAtual.Year - dataNascimento.Year;

    if (dataAtual.DayOfYear < dataNascimento.DayOfYear)
    {
        idade--;
    }

    return idade;
}

static string ObterMensagemAcompanhante(int idade, bool dataValida)
{
    if (!dataValida)
    {
        return "Entrada inválida";
    }

    if (idade < 12)
    {
         return "Paciente infantil: obrigatório acompanhante\nEntregar kit de desenho na recepção";
    }

    return "Paciente liberado para aguardar sozinho";
}

static decimal CalcularValorConsulta(decimal valorOriginal, int idade, bool dataValida)
{
    if (!dataValida || valorOriginal < 0)
    {
        return valorOriginal;
    }
    else if (idade < 5)
    {
        return 0.0m;
    }
    else if (idade >= 60)
    {
        return valorOriginal *  0.8m;
    }

    return valorOriginal;
}

static string ObterMensagemDesconto(int idade, bool dataValida)
{
    if (!dataValida)
    {
        return "Desconto não aplicável";
    }

    if (idade < 5)
    {
        return "Desconto de pediatria social: 100,0%";
    }

    if (idade >= 60)
    {
        return "Desconto para paciente idoso: 20,0%";
    }

    return "Desconto não aplicável";
}