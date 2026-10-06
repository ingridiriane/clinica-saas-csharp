using ClinicaSaaS;

RepositorioPaciente repoPaciente = new("pacientes.csv");
RepositorioConsulta repoConsulta = new("consultas.csv");

List<Paciente> listaPacientes = repoPaciente.CarregarPacientes();
List<Consulta> listaConsultas = repoConsulta.CarregarConsultas(listaPacientes);

bool executando = true;

while (executando)
{
    string? opcaoMenu = ExibirMenuInicial();

    switch (opcaoMenu)
    {
        case "1":
            ProcessarNovaConsulta(listaConsultas, listaPacientes, repoConsulta);
            Limpeza();
            break;

        case "2":
            ProcessarNovoPaciente(listaPacientes, repoPaciente);
            Limpeza();
            break;

        case "3":
            ProcessarBusca(listaPacientes, listaConsultas);
            Limpeza();
            break;

        case "4":
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
    Console.WriteLine("1 - Nova Consulta\n2 - Novo Paciente\n3 - Busca\n4 - Informações da Clínica\n0 - Sair");

    Console.Write("Escolha uma opção: ");
    return Console.ReadLine();
}

static void Limpeza()
{
    Console.WriteLine("Pressione Enter para voltar ao menu...");
    Console.ReadLine();

    Console.Clear();
}

static void ProcessarNovoPaciente(List<Paciente> listaPacientes, RepositorioPaciente repoPaciente)
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

    Console.WriteLine($"Deseja cadastrar paciente {nome}? (S/N): ");
    string resposta = Console.ReadLine() ?? "";

    switch (resposta)
    {
        case "S":
            Paciente paciente;
            try
            {
                paciente = new Paciente(nome, dataNascimento, convenio, telefone);
                listaPacientes.Add(paciente);

                repoPaciente.SalvarPacientes(listaPacientes);

                Console.Clear();

                Console.WriteLine($"Paciente {paciente.Nome} cadastrado com sucesso!");
                Console.WriteLine($"Total de pacientes cadastrados: {listaPacientes.Count}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Erro ao cadastrar paciente: {ex.Message}");
                return;

            }
            break;
        case "N":
            Console.Clear();
            Console.WriteLine("Paciente não cadastrado");
            break;
        default:
            Console.Clear();
            Console.WriteLine("Entrada inválida");
            break;
    }
}

static void ProcessarNovaConsulta(List<Consulta> listaConsultas, List<Paciente> listaPacientes, RepositorioConsulta repoConsulta)
{
    //CONSULTA

    if (listaPacientes.Count == 0)
    {
        Console.WriteLine("Nenhum paciente cadastrado. Cadastre um paciente primeiro antes de registrar uma consulta.");
        return;
    }

    Console.WriteLine("Digite o nome do paciente que irá registrar consulta: ");
    string busca = Console.ReadLine() ?? "";

    if (string.IsNullOrWhiteSpace(busca))
    {
        Console.WriteLine("Entrada inválida. Digite um nome para buscar.");
        Limpeza();
        return;
    }

    Paciente? pacienteEncontrado = listaPacientes
        .FirstOrDefault(p => p.Nome.Contains(busca, StringComparison.OrdinalIgnoreCase));

    if (pacienteEncontrado == null)
    {
        Console.WriteLine($"Nenhum paciente encontrado com o termo {busca}");
        return;
    }

    Console.WriteLine($"Paciente Selecionado: {pacienteEncontrado.Nome}");
    Console.WriteLine("É o paciente correto? (S/N)");
    string resposta = Console.ReadLine() ?? "";

    if (resposta == "S")
    {
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

        Consulta consulta = new(pacienteEncontrado)
        {
            Duracao = duracao,
            Valor = valor,
            Status = status
        };

        listaConsultas.Add(consulta);

        repoConsulta.SalvarConsultas(listaConsultas);

        //EXIBIR RESULTADO DOS INPUTS
        Console.WriteLine("=== NOVO ATENDIMENTO ===");
        Console.WriteLine($"Paciente: {consulta.Paciente.Nome}");
        Console.WriteLine($"Idade: {consulta.Paciente.Idade}");
        Console.WriteLine($"Convênio: {consulta.Paciente.Convenio}");
        Console.WriteLine($"Telefone: {consulta.Paciente.Telefone ?? "Não informado"}");
        Console.WriteLine($"Horário: das {consulta.DataHora:HH:mm} às {consulta.DataHoraTermino:HH:mm}");
        Console.WriteLine($"Valor: {consulta.ValorFinal:C}");
        Console.WriteLine($"Status: {consulta.Status}");
        Console.WriteLine("\n=== INFORMAÇÕES ===");
        Console.WriteLine(consulta.Paciente.MensagemAcompanhante);
        Console.WriteLine(consulta.MensagemDesconto);
        Console.WriteLine($"Consultas realizadas durante a sessão: {listaConsultas.Count}");

    }
    else if (resposta == "N")
    {
        return;
    }
    else
    {
        Console.WriteLine("Entrada inválida");
        return;
    }

}

static void ProcessarBusca(List<Paciente> listaPacientes, List<Consulta> listaConsultas)
{
    Console.WriteLine("=== CONSULTAS E RELATÓRIOS ===");
    Console.WriteLine("1 - Listar todos os pacientes\n2 - Filtrar consultas por status\n3 - Relatório\nEscolha uma opção: ");
    string? opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":

            if (listaPacientes.Count == 0)
            {
                Console.WriteLine("Nenhum paciente cadastrado");
                return;
            }

            List<Paciente> pacientesOrdenados = [.. listaPacientes.OrderBy(p => p.Nome)];

            Console.WriteLine($"Pacientes cadastrados ({pacientesOrdenados.Count})");
            foreach (Paciente p in pacientesOrdenados)
            {
                Console.WriteLine($"Nome {p.Nome} | Idade: {p.Idade} | Convênio: {p.Convenio} | Telefone: {p.Telefone}");
            }
            break;

        case "2":

            if (listaConsultas.Count == 0)
            {
                Console.WriteLine("Nenhuma consulta cadastrada");
                return;
            }

            StatusConsulta status = LerStatusConsulta();

            List<Consulta> consultasFiltradas = [.. listaConsultas.Where(c => c.Status == status)];

            Console.WriteLine($"Consultas Filtradas com status {status} ({consultasFiltradas.Count})");

            if (consultasFiltradas.Count == 0)
            {
                Console.WriteLine($"Nenhuma consulta encontrada com o status {status}");
                return;
            }

            foreach (Consulta c in consultasFiltradas)
            {
                Console.WriteLine($"Paciente: {c.Paciente.Nome} | Horário: {c.DataHora:HH:mm} | Valor: {c.ValorFinal:C}");
            }
            break;
        
        case "3":

            if (listaConsultas.Count == 0)
            {
                Console.WriteLine("Nenhuma consulta cadastrada");
                return;
            }

            var concluidas = listaConsultas
                .Where(c => c.Status == StatusConsulta.Concluida)
                .ToList();

            var canceladas = listaConsultas
                .Where(c => c.Status == StatusConsulta.Cancelada)
                .ToList();

            Console.WriteLine("=== RELATÓRIO ===");

            if (concluidas.Count > 0)
            {
                decimal soma = concluidas.Sum(c => c.ValorFinal);
                decimal media = concluidas.Average(c => c.ValorFinal);
                decimal max = concluidas.Max(c => c.ValorFinal);
           
                Console.WriteLine("\nDetalhes sobre Consultas Concluídas\n");
                Console.WriteLine($"Valor total das consultas concluídas: {soma:C}");
                Console.WriteLine($"Média do valor das consultas concluídas: {media:C}");
                Console.WriteLine($"Valor máximo de consulta: {max:C}");
            }
            else
            {
                Console.WriteLine("\nDetalhes sobre Consultas Concluídas\n");
                Console.WriteLine("Nennhuma consulta concluída registrada");
            }

            if (canceladas.Count > 0)
            {
                int Qcanceladas = canceladas.Count;
                Console.WriteLine("Detalhes sobre Consultas Canceladas\n");
                Console.WriteLine($"Quantidade de consultdas canceladas: {Qcanceladas}");
            }
            else
            {
                Console.WriteLine("Detalhes sobre Consultas Canceladas\n");
                Console.WriteLine("Nenhuma consulta cancelada registrada");
            }

            break;

        default:
            Console.WriteLine("Entrada inválida");
             break;
    }

}

static StatusConsulta LerStatusConsulta()
{
    Console.WriteLine("1 - Agendada\n2 - Confirmada\n3 - Em Atendimento\n4 - Concluída\n5 - Cancelada\nEscolha o estado da Consulta: ");
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
