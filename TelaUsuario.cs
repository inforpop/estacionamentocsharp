public partial class FormEntrada : Form
{
    private readonly EstacionamentoService _service;

    public FormEntrada(EstacionamentoService service)
    {
        InitializeComponent();
        _service = service;
    }

    private void btnRegistrarEntrada_Click(object sender, EventArgs e)
    {
        var veiculo = new Veiculo
        {
            Placa = txtPlaca.Text,
            Modelo = txtModelo.Text,
            Cor = txtCor.Text
        };

        int vagaId = int.Parse(txtVagaId.Text);
        _service.RegistrarEntrada(veiculo, vagaId);

        MessageBox.Show("Entrada registrada com sucesso!");
    }
}
