namespace ClinicaSaaS;

public class Paciente
{
    public string Nome { get; set; } = string.Empty;
    public DateTime DataNascimento { get; set; }
    public string Convenio { get; set; } = "Particular";
    public bool DataNascimentoValida { get; set; } = false;
    public string Telefone { get; set; } = string.Empty;
    public int Idade => CalcularIdade(DataNascimento);
    public string MensagemAcompanhante => ObterMensagemAcompanhante();
    public static int CalcularIdade(DateTime DataNascimento)
    {
        var hoje = DateTime.Today;
        var idade = hoje.Year - DataNascimento.Year;

        if (DataNascimento.Date > hoje.AddYears(-idade))
        {
            idade--;
        }
        return idade < 0 ? -1 : idade;
    }

    private string ObterMensagemAcompanhante()
    {
        if (Idade < 12)
        {
            return "Paciente infantil: obrigatório acompanhante.\nEntregar kit de desenho na recepção";
        }
        else if (Idade >= 60)
        {
            return "Paciente idoso: obrigatório acompanhante";
        }
        else
        {
            return "Paciente liberado para aguardar na recepção";
        }
    }
    public Paciente(string nome, DateTime dataNascimento, string convenio = "Particular", string telefone = "")
    {

        if (string.IsNullOrWhiteSpace(nome))
        {
            throw new ArgumentException("O nome do paciente é de preenchimento obrigatório");
        }

        if (dataNascimento.Date > DateTime.Today)
        {
            throw new ArgumentException("A data é inválida, pois é maior que a data atual");
        }

        if (dataNascimento.Year < 1900)
        {
            throw new ArgumentException("A data é inválida");
        }        
        
        Nome = nome;
        DataNascimento = dataNascimento;
        Convenio = convenio;
        Telefone = telefone;
        DataNascimentoValida = true;
    }
}