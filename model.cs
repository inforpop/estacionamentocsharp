// Classe Veiculo
public class Veiculo
{
    public int Id { get; set; }
    public string Placa { get; set; }
    public string Modelo { get; set; }
    public string Cor { get; set; }
}

// Classe Vaga
public class Vaga
{
    public int Id { get; set; }
    public string Numero { get; set; }
    public bool Ocupada { get; set; }
}

// Classe Estacionamento
public class Estacionamento
{
    public int Id { get; set; }
    public int VeiculoId { get; set; }
    public int VagaId { get; set; }
    public DateTime DataEntrada { get; set; }
    public DateTime? DataSaida { get; set; }
    public decimal? Valor { get; set; }
}
