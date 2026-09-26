namespace ClinicaSaaS;

public class Paciente
{
    public string Nome {get; set;} = string.Empty;
    public DateTime DataNascimento {get;set;}
    public string Convenio {get;set;} = "Particular";
    public bool DataNascimentoValida {get;set;} = false;
    public string Telefone {get;set;} = string.Empty;
}