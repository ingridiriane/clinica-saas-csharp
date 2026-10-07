namespace ClinicaSaaS.Infrastructure;

using ClinicaSaaS.Domain;

public class RepositorioConsulta
{
    private readonly string _caminhoArquivo;

    public RepositorioConsulta(string caminhoArquivo)
    {
        _caminhoArquivo = caminhoArquivo;
    }

    public void SalvarConsultas(List<Consulta> listaConsultas)
    {
        using StreamWriter escritor = new(_caminhoArquivo);
        {
            foreach (Consulta c in listaConsultas)
            {
                string linha = $"{c.Paciente.Nome};{c.DataHora:yyyy-MM-dd};{c.Duracao};{c.Valor};{c.Status}";
                escritor.WriteLine(linha);
            }
        }
    }

    public List<Consulta> CarregarConsultas(List<Paciente> listaPacientes)
    {
        List<Consulta> consultas = [];

        if (!File.Exists(_caminhoArquivo))
        {
            return consultas;
        }

        using StreamReader leitor = new(_caminhoArquivo);
        {
            string? linha;
            while ((linha = leitor.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(linha)) continue;

                string[] campos = linha.Split(';');

                if (campos.Length >= 5)
                {
                    string nomePaciente = campos[0];

                    Paciente? pacienteEncontrado = listaPacientes
                        .FirstOrDefault(p => p.Nome.Equals(nomePaciente, StringComparison.OrdinalIgnoreCase));

                    if (pacienteEncontrado is null)
                    {
                        continue;
                    }

                    DateTime.TryParse(campos[1], out DateTime dataHora);
                    int.TryParse(campos[2], out int duracao);
                    decimal.TryParse(campos[3], out decimal valor);
                    Enum.TryParse(campos[4], out StatusConsulta status);

                    Consulta c = new(pacienteEncontrado)
                    {
                        DataHora = dataHora,
                        Duracao = duracao,
                        Valor = valor,
                        Status = status
                    };

                    consultas.Add(c);
                }
            }

        }

        return consultas;
    }
}