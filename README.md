# EduTechPlatform

## Visão geral

A EduTechPlatform é uma plataforma educacional desenvolvida em C# com .NET 10. Seu objetivo é centralizar regras de negócio relacionadas ao desempenho acadêmico, à frequência dos alunos e à gestão financeira de matrículas.

O projeto faz parte da atividade acadêmica da disciplina Garantia da Qualidade de Software, do curso de Gestão e Qualidade de Software, ministrada pelo professor Daniel Henrique Matos de Paiva.

## Objetivos

- Calcular médias ponderadas e identificar a situação acadêmica dos alunos.
- Calcular o percentual de presença e verificar a frequência mínima.
- Calcular mensalidades conforme bolsas e descontos por pontualidade.
- Verificar a elegibilidade para rematrícula.
- Aplicar testes unitários para validar as regras de negócio.

## Tecnologias utilizadas

- C#
- .NET 10
- xUnit
- Git e GitHub

## Requisitos do ambiente

Para executar o projeto, é necessário ter:

- .NET 10 SDK instalado.
- Git instalado.
- Um terminal compatível com os comandos do .NET CLI.

Para verificar a instalação do SDK, execute:

```bash
dotnet --version
```

## Serviços da aplicação

### NotaDesempenhoService

Responsável pelas regras de desempenho acadêmico.

**CalcularMediaPonderada(decimal nota1, decimal nota2, decimal notaProjeto)**

Calcula a média ponderada utilizando os seguintes pesos:

- Nota 1: peso 3.
- Nota 2: peso 3.
- Nota do projeto: peso 4.

Fórmula:

`((nota1 * 3) + (nota2 * 3) + (notaProjeto * 4)) / 10`

**ObterSituacaoAcademica(decimal mediaFinal)**

Retorna a situação acadêmica conforme a média final:

- Média maior ou igual a 7,0: `APROVADO`.
- Média entre 5,0 e abaixo de 7,0: `RECUPERACAO`.
- Média abaixo de 5,0: `REPROVADO`.

### FrequenciaService

Responsável pelo cálculo da frequência dos alunos.

**CalcularPorcentagemPresenca(int aulasTotais, int faltas)**

Calcula o percentual de presença com base no total de aulas e no número de faltas.

**AprovadoPorFrequencia(int aulasTotais, int faltas)**

Verifica se o aluno possui pelo menos 75% de presença. Retorna `true` quando o requisito é atendido e `false` caso contrário.

### MatriculaFinanceiraService

Responsável pelas regras financeiras de mensalidade e rematrícula.

**CalcularValorMensalidade(decimal valorBase, int diaPagamento, bool eBolsista)**

Aplica as seguintes regras:

- Bolsista: desconto de 50%, independentemente do dia do pagamento.
- Não bolsista com pagamento até o dia 5: desconto de 10%.
- Não bolsista com pagamento após o dia 5: valor integral.

**PodeRealizarRematricula(bool possuiPendenciaFinanceira, string situacaoAcademica)**

Permite a rematrícula somente quando não há pendência financeira e a situação acadêmica não é `REPROVADO`.

## Testes unitários

Os testes são implementados com xUnit para verificar as regras de negócio dos três serviços.

### Testes parametrizados

O atributo `[Theory]` permite executar um mesmo método de teste com diferentes conjuntos de dados.

O atributo `[InlineData]` fornece os valores de entrada e os resultados esperados para cada cenário.

Os testes contemplam:

- Cálculo da média ponderada e situação acadêmica.
- Cálculo do percentual de presença e aprovação por frequência.
- Cálculo da mensalidade e elegibilidade para rematrícula.

Os cenários incluem resultados positivos, negativos e diferentes condições de negócio. A execução dos testes permite identificar falhas nas regras implementadas.

## Como executar o projeto

Clone o repositório:

```bash
git clone https://github.com/nathycaroline/edutech-platform-xunit.git
cd edutech-platform-xunit
```

Restaure as dependências:

```bash
dotnet restore
```

Compile a solução:

```bash
dotnet build
```

Execute os testes unitários:

```bash
dotnet test
```

**Observação:** os comandos de compilação e teste dependem de os projetos da aplicação e de testes estarem adicionados à solução.

## Estrutura esperada do projeto

```text
EduTechPlatform/
├── EduTechPlatform.slnx
├── .gitignore
├── LICENSE
├── README.md
├── EduTechPlatform.App/
│   ├── EduTechPlatform.App.csproj
│   ├── Program.cs
│   ├── NotaDesempenhoService.cs
│   ├── FrequenciaService.cs
│   └── MatriculaFinanceiraService.cs
└── EduTechPlatform.Tests/
    ├── EduTechPlatform.Tests.csproj
    ├── NotaDesempenhoServiceTests.cs
    ├── FrequenciaServiceTests.cs
    └── MatriculaFinanceiraServiceTests.cs
```

A estrutura acima representa a organização planejada. Os arquivos de serviços e testes serão adicionados conforme o trabalho dos desenvolvedores responsáveis por essas etapas.

## Responsabilidades da equipe

- **Desenvolvedor 1 — Backend/Core:** criação da solução e implementação das regras de negócio.
- **Desenvolvedor 2 — QA/Testes:** desenvolvimento e execução dos testes unitários.
- **Desenvolvedor 3 — Documentação/DevOps:** configuração do repositório, versionamento, licença, `.gitignore` e documentação técnica.

## Licença

Este projeto está licenciado sob a licença MIT. Consulte o arquivo [LICENSE](LICENSE) para obter os termos completos.
