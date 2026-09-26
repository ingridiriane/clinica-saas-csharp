namespace ClinicaSaaS;

public class Consulta
{
    public Paciente Paciente { get; set; }
    public DateTime DataHora { get; set; } = DateTime.Now;
    public DateTime DataHoraTermino => DataHora.AddMinutes(Duracao);
    public int Duracao { get; set; } = 45;
    public decimal Valor { get; set; }
    public decimal ValorFinal { get; set; }

    public Consulta(Paciente paciente)
    {
        Paciente = paciente ?? throw new ArgumentNullException(nameof(paciente), "A consulta exige um paciente válido.");
    }

}

