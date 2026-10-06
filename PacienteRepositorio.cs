namespace ClinicaSaaS;

public class RepositorioPaciente
{
    private readonly string _caminhoArquivo;

    public RepositorioPaciente(string caminhoArquivo)
    {
        _caminhoArquivo = caminhoArquivo;
    }

    public void SalvarPacientes(List<Paciente> listaPacientes)
    {
        using (StreamWriter escritor = new StreamWriter(_caminhoArquivo))
        {
            foreach (Paciente p in listaPacientes)
            {
                string linha = $"{p.Nome};{p.DataNascimento:yyyy-MM-dd};{p.Convenio};{p.Telefone}";
                escritor.WriteLine(linha);
            }
        }
    }

    public List<Paciente> CarregarPacientes()
    {
        List<Paciente> pacientes = [];

        if (!File.Exists(_caminhoArquivo))
        {
            return pacientes;
        }

        using (StreamReader leitor = new(_caminhoArquivo))
        {
            string? linha;

            while ((linha = leitor.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(linha)) continue;

                string[] campos = linha.Split(';');

                if (campos.Length >= 4)
                {
                    string nome = campos[0];
                    DateTime.TryParse(campos[1], out DateTime dataNascimento);
                    string convenio = campos[2];
                    string telefone = campos[3];

                    Paciente p = new Paciente(nome, dataNascimento, convenio, telefone);
                    pacientes.Add(p);
                }

            }
        }

        return pacientes;
    }


}