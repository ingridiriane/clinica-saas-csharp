namespace ClinicaSaaS;

public class Paciente
{
    public string Nome {get; set;} = string.Empty;
    public DateTime DataNascimento {get;set;}
    public string Convenio {get;set;} = "Particular";
    public bool DataNascimentoValida {get;set;} = false;
    public string Telefone {get;set;} = string.Empty;
    public int Idade => CalcularIdade(DataNascimento);

    private static int CalcularIdade(DateTime DataNascimento)
    {
        var hoje = DateTime.Today;
        var idade = hoje.Year - DataNascimento.Year;

        if (DataNascimento.Date > hoje.AddYears(-idade))
        {
            idade--;
        }
        return idade < 0 ? -1 : idade;
    }
}