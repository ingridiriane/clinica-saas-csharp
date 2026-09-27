namespace ClinicaSaaS;

public class Consulta(Paciente paciente)
{
    public Paciente Paciente { get; set; } = paciente ?? throw new ArgumentNullException(nameof(paciente), "A consulta exige um paciente válido.");
    public DateTime DataHora { get; set; } = DateTime.Now;
    public DateTime DataHoraTermino => DataHora.AddMinutes(Duracao);
    public int Duracao { get; set; } = 45;
    public decimal Valor { get; set; }
    public decimal ValorFinal => CalcularValor();
    public decimal Desconto => CalcularDesconto();
    public string MensagemDesconto => ObterMensagemDesconto();
    public StatusConsulta Status {get; set;} = StatusConsulta.Agendada;

    private decimal CalcularDesconto()
    {
        if (Paciente.Idade < 5)
        {
            return 1.0m;
        }
        else if (Paciente.Idade >= 60)
        {
            return 0.2m;
        }
        else
        {
            return 0.0m;
        }
    }

        private decimal CalcularValor()
    {
        if (Paciente.Idade < 5)
        {
            return Valor * Desconto;
        }
        else if (Paciente.Idade >= 60)
        {
            return Valor * (1 - Desconto);
        }
        else
        {
            return Valor;
        }
    }

    private string ObterMensagemDesconto()
    {
        if (Paciente.Idade < 5)
        {
            return $"Pediatria social: {Desconto:P0} de desconto";
        }
        else if (Paciente.Idade >= 60)
        {
            return $"Paciente idoso: {Desconto:P0} de desconto";
        }
        else
        {
            return $"Paciente: {Desconto:P0} de desconto";
        }
    }
}

