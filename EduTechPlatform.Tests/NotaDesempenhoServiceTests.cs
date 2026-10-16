using EduTechPlatform.App.Services;
using Xunit;

namespace EduTechPlatform.Tests;

public class NotaDesempenhoServiceTests
{
    private readonly NotaDesempenhoService _service = new();

    [Theory]
    [InlineData(7.0, 7.0, 7.0, 7.0)]
    [InlineData(10.0, 10.0, 5.0, 8.0)]
    public void CalcularMediaPonderada_DeveRetornarMediaCorreta(
        double nota1,
        double nota2,
        double notaProjeto,
        double mediaEsperada)
    {
        var resultado = _service.CalcularMediaPonderada(
            (decimal)nota1,
            (decimal)nota2,
            (decimal)notaProjeto);

        Assert.Equal((decimal)mediaEsperada, resultado);
    }

    [Theory]
    [InlineData(8.5, "APROVADO")]
    [InlineData(6.0, "RECUPERACAO")]
    [InlineData(4.2, "REPROVADO")]
    public void ObterSituacaoAcademica_DeveRetornarSituacaoCorreta(
        double media,
        string situacaoEsperada)
    {
        var resultado =
            _service.ObterSituacaoAcademica((decimal)media);

        Assert.Equal(situacaoEsperada, resultado);
    }
}
