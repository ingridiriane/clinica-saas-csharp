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

decimal desconto = 0.0m;

DateTime dataHoraConsulta = new(2026, 10, 15, 14, 0, 0);
TimeSpan duracaoConsulta = TimeSpan.FromMinutes(45);
DateTime dataHoraTermino = dataHoraConsulta.Add(duracaoConsulta);

//Mensagens para saída
string mensagemEntradaInvalida = "Entrada inválida ou não informada";
string mensagemAcompanhante = "";

// Processamento

//Validar se o paciente precisa de acompanhante
if (idadePaciente < 0)
{
    mensagemAcompanhante = mensagemEntradaInvalida;
}
else if (idadePaciente < 12)
{
    mensagemAcompanhante = "Paciente infantil: obrigatório acompanhante\nEntregar kit de desenho na recepção";
}
else
{
    mensagemAcompanhante = "Paciente liberado para aguardar sozinho";
}

//Validar se a data de nascimento inserida pelo usuário é válida
if (!dataNascimentoValida)
{
    mensagemAcompanhante = mensagemEntradaInvalida;
}

//Validar se tem desconto
if (idadePaciente < 0)
{
    valorConsulta = -1.0m;
}
else if (idadePaciente < 5)
{
    valorConsulta = 0.0m;
    desconto = 1.0m;
}
else if (idadePaciente >= 60)
{
    desconto = 0.8m;
    valorConsulta = valorConsulta * desconto;
}

string opcoesValor = valorConsulta switch
{
    < 0 => "Não informado",
    0.00m => "Gratuito",
    _ => valorConsulta.ToString("C")
};

string opcoesDesconto = !dataNascimentoValida ? "Desconto não aplicável" : idadePaciente switch
{
    < 5 => $"Desconto de pediatria social: {desconto:P1}",
    >= 60 => $"Desconto para paciente idoso: {1.0m - desconto:P1}",
    _ => $"Desconto não aplicável"
};

// Saída

Console.WriteLine("=== SISTEMA CLÍNICA SAAS ===");
Console.WriteLine($"Paciente: {nomePaciente}");
Console.WriteLine($"Idade do Paciente: {(dataNascimentoValida ? $"{idadePaciente} anos" : "Não informado")}");
Console.WriteLine($"Convênio: {nomeConvenio}");
Console.WriteLine($"Valor da Consulta: {opcoesValor}");
Console.WriteLine($"Data do Atendimento: {dataHoraConsulta:dd/MM/yyyy}");
Console.WriteLine($"Horário: das {dataHoraConsulta:HH:mm} às {dataHoraTermino:HH:mm} ({duracaoConsulta.TotalMinutes} min)");

Console.WriteLine("=== Informações para o paciente ===");
Console.WriteLine(mensagemAcompanhante);
Console.WriteLine($"{opcoesDesconto}");
