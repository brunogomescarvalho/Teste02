using domain.model;

namespace tests;

public class ChamadoTest
{
    [Test]
    public void QuandoBuscarChamado_Entao_DeveraCalcularDiasEmAberto()
    {
        Chamado chamado = new Chamado(1, "Teste", "Chamado de Teste", null!, DateTime.Now.AddDays(-10));
        chamado.CalcularDiasEmAberto();
        Assert.That(chamado.DiasEmAberto, Is.EqualTo(10));
    }
}