# EduTechPlatform

Plataforma educacional desenvolvida em C# com .NET 10, com foco em regras de negócio acadêmicas, controle de frequência, gestão financeira e garantia da qualidade por meio de testes unitários com xUnit.

## Sobre o projeto

A EduTechPlatform foi desenvolvida como atividade acadêmica da disciplina de Garantia da Qualidade de Software, do curso de Gestão e Qualidade de Software.

O objetivo é implementar e validar regras de negócio relacionadas à vida acadêmica dos alunos, utilizando testes automatizados para verificar os resultados esperados e identificar possíveis falhas.

## Objetivos

- Calcular médias ponderadas e definir a situação acadêmica dos alunos.
- Calcular a porcentagem de presença e verificar a frequência mínima.
- Calcular mensalidades com bolsas e descontos por pontualidade.
- Validar as condições para realização da rematrícula.
- Aplicar testes unitários para aumentar a confiabilidade das regras de negócio.

## Tecnologias utilizadas

- **C#** — linguagem de programação.
- **.NET 10** — plataforma de desenvolvimento.
- **xUnit** — framework de testes unitários.
- **Git** — controle de versão.
- **GitHub** — hospedagem do código e colaboração entre os desenvolvedores.

## Estrutura do repositório

```text
edutech-platform-xunit/
├── EduTechPlatform.slnx
├── .gitignore
├── LICENSE
├── README.md
├── EduTechPlatform.App/
│   ├── EduTechPlatform.App.csproj
│   ├── Program.cs
│   └── Services/
│       ├── NotaDesempenhoService.cs
│       ├── FrequenciaService.cs
│       └── MatriculaFinanceiraService.cs
└── EduTechPlatform.Tests/
    ├── EduTechPlatform.Tests.csproj
    ├── NotaDesempenhoServiceTests.cs
    ├── FrequenciaServiceTests.cs
    ├── MatriculaFinanceiraServiceTests.cs
    └── UnitTest1.cs
```

A solução está organizada em dois projetos principais:

- **EduTechPlatform.App:** contém a aplicação e os serviços responsáveis pelas regras de negócio.
- **EduTechPlatform.Tests:** contém os testes unitários responsáveis por validar o comportamento dos serviços.

O arquivo `UnitTest1.cs` também aparece no repositório e pode ser mantido ou removido após verificar se ainda é necessário.

## Regras de negócio

### 1. NotaDesempenhoService

Responsável pelo cálculo da média ponderada e pela classificação acadêmica.

**Cálculo da média ponderada**

A média utiliza três notas com pesos diferentes:

- Nota 1: peso 3.
- Nota 2: peso 3.
- Nota do projeto: peso 4.

Fórmula:

```text
((nota1 * 3) + (nota2 * 3) + (notaProjeto * 4)) / 10
```

**Situação acadêmica**

| Média final | Resultado |
|---|---|
| Maior ou igual a 7,0 | APROVADO |
| Maior ou igual a 5,0 e menor que 7,0 | RECUPERACAO |
| Menor que 5,0 | REPROVADO |

**Testes implementados**

- Verificação do cálculo da média ponderada.
- Verificação da classificação acadêmica para aprovação, recuperação e reprovação.

### 2. FrequenciaService

Responsável pelo cálculo do percentual de presença e pela verificação da frequência mínima.

**Cálculo da presença**

```text
((aulasTotais - faltas) / (double)aulasTotais) * 100
```

**Regra de frequência**

- Presença igual ou superior a 75%: aprovado por frequência.
- Presença inferior a 75%: não aprovado por frequência.

**Testes implementados**

- Cálculo correto do percentual de presença.
- Validação de aprovação com 75% de presença.
- Validação de reprovação por frequência abaixo do limite.

### 3. MatriculaFinanceiraService

Responsável pelo cálculo da mensalidade e pela validação da elegibilidade para rematrícula.

**Cálculo da mensalidade**

- Aluno bolsista: desconto de 50%, independentemente do dia do pagamento.
- Aluno não bolsista que paga até o dia 5: desconto de 10%.
- Aluno não bolsista que paga após o dia 5: pagamento do valor integral.

**Condições para rematrícula**

A rematrícula pode ser realizada quando o aluno não possui pendência financeira e sua situação acadêmica é diferente de `REPROVADO`.

**Testes implementados**

- Cálculo da mensalidade para bolsistas.
- Aplicação do desconto por pontualidade.
- Verificação do valor integral após o prazo.
- Validação da rematrícula com e sem pendência financeira.
- Bloqueio da rematrícula para alunos reprovados.

## Testes unitários com xUnit

O projeto utiliza o xUnit para verificar se os serviços apresentam os resultados esperados em diferentes cenários.

Os principais atributos utilizados são:

- **`[Theory]`**: permite executar um mesmo método de teste com diferentes conjuntos de dados.
- **`[InlineData]`**: fornece os valores de entrada e os resultados esperados para cada execução.

Essa abordagem reduz a repetição de código e facilita a validação de diferentes condições de negócio.

Os testes estão organizados nos seguintes arquivos:

- `NotaDesempenhoServiceTests.cs`
- `FrequenciaServiceTests.cs`
- `MatriculaFinanceiraServiceTests.cs`

## Requisitos para execução

Antes de executar o projeto, instale o SDK do .NET 10 e o Git.

Para verificar a versão do .NET instalada, utilize:

```bash
dotnet --version
```

## Como executar o projeto

### 1. Clonar o repositório

```bash
git clone https://github.com/nathycaroline/edutech-platform-xunit.git
cd edutech-platform-xunit
```

### 2. Restaurar as dependências

```bash
dotnet restore
```

### 3. Compilar a solução

```bash
dotnet build
```

### 4. Executar os testes unitários

```bash
dotnet test
```

O comando `dotnet test` executa os testes disponíveis nos projetos de teste configurados na solução e apresenta o resultado de cada execução.

## Organização da equipe

- **Desenvolvedor 1 — Backend/Core:** implementação da estrutura da aplicação e das regras de negócio.
- **Desenvolvedor 2 — QA/Testes:** desenvolvimento dos testes unitários e validação dos resultados.
- **Desenvolvedor 3 — Documentação/DevOps:** configuração do repositório, controle de versão, licença, `.gitignore` e documentação técnica.

## Controle de versão

O código-fonte é mantido no GitHub para facilitar o compartilhamento dos arquivos, o acompanhamento das alterações e a colaboração entre os integrantes da equipe.

Repositório: [edutech-platform-xunit](https://github.com/nathycaroline/edutech-platform-xunit)

## Licença

Este projeto está licenciado sob a licença MIT. Consulte o arquivo [LICENSE](LICENSE) para obter os termos completos.
