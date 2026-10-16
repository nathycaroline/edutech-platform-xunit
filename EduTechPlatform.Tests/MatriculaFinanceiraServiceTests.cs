using EduTechPlatform.App.Services;
using Xunit;

namespace EduTechPlatform.Tests;

public class MatriculaFinanceiraServiceTests
{
    private readonly MatriculaFinanceiraService _service = new();

    [Theory]
    [InlineData(1000.0, 10, true, 500.0)]
    [InlineData(1000.0, 4, false, 900.0)]
    [InlineData(1000.0, 10, false, 1000.0)]
    public void CalcularValorMensalidade_DeveRetornarValorCorreto(
        double valorBase,
        int diaPagamento,
        bool eBolsista,
        double valorEsperado)
    {
        var resultado = _service.CalcularValorMensalidade(
            (decimal)valorBase,
            diaPagamento,
            eBolsista);

        Assert.Equal((decimal)valorEsperado, resultado);
    }

    [Theory]
    [InlineData(false, "APROVADO", true)]
    [InlineData(true, "APROVADO", false)]
    [InlineData(false, "REPROVADO", false)]
    public void PodeRealizarRematricula_DeveRetornarResultadoCorreto(
        bool possuiPendenciaFinanceira,
        string situacaoAcademica,
        bool resultadoEsperado)
    {
        var resultado = _service.PodeRealizarRematricula(
            possuiPendenciaFinanceira,
            situacaoAcademica);

        Assert.Equal(resultadoEsperado, resultado);
    }
}
