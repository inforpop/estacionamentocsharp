public class EstacionamentoService
{
    private readonly DataContext _context;

    public EstacionamentoService(DataContext context)
    {
        _context = context;
    }

    public void RegistrarEntrada(Veiculo veiculo, int vagaId)
    {
        var vaga = _context.Vagas.FirstOrDefault(v => v.Id == vagaId);
        if (vaga == null || vaga.Ocupada)
            throw new Exception("Vaga inválida ou ocupada");

        var estacionamento = new Estacionamento
        {
            VeiculoId = veiculo.Id,
            VagaId = vaga.Id,
            DataEntrada = DateTime.Now
        };

        vaga.Ocupada = true;
        _context.Estacionamentos.Add(estacionamento);
        _context.SaveChanges();
    }

    public void RegistrarSaida(int estacionamentoId)
    {
        var estacionamento = _context.Estacionamentos.FirstOrDefault(e => e.Id == estacionamentoId);
        if (estacionamento == null || estacionamento.DataSaida != null)
            throw new Exception("Estacionamento inválido ou já encerrado");

        estacionamento.DataSaida = DateTime.Now;
        estacionamento.Valor = CalcularTarifa(estacionamento);

        var vaga = _context.Vagas.FirstOrDefault(v => v.Id == estacionamento.VagaId);
        if (vaga != null)
        {
            vaga.Ocupada = false;
        }

        _context.SaveChanges();
    }

    private decimal CalcularTarifa(Estacionamento estacionamento)
    {
        var tempoEstacionado = (estacionamento.DataSaida - estacionamento.DataEntrada)?.TotalHours ?? 0;
        return (decimal)tempoEstacionado * 5; // Exemplo de tarifa: R$ 5 por hora
    }
}
