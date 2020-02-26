using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CursoOnline.Dominio;
using CursoOnline.Dominio.Enums;
using ExpectedObjects;
using CursoOnline.DominioTeste._Util;
using Xunit.Abstractions;
using CursoOnline.DominioTeste.Builders;
using Bogus;

namespace CursoOnline.DominioTeste.Cursos
{

    public class CursoTeste : IDisposable
    {
        private readonly ITestOutputHelper _output;
        private string _nome;
        private string _descricao;
        private double _cargaHoraria;
        private PublicoAlvo _publicoAlvo;
        private double _valor;

        public CursoTeste(ITestOutputHelper output )
        {
            var faker = new Faker();
            _output = output;
            _nome = faker.Random.Word();
            _descricao = faker.Lorem.Paragraph();
            _cargaHoraria = faker.Random.Double(1, 200);
            _publicoAlvo = PublicoAlvo.Estudantes;
            _valor = faker.Random.Double(1, 10000);
        }

        public void Dispose()
        {

        }

        [Fact]
        public void DeveCriarCurso()
        {
            var CursoEsperado = new
            {
                nome = _nome,
                cargaHoraria = _cargaHoraria,
                descricao = _descricao,
                PublicoAlvo = _publicoAlvo,
                ValorDoCurso = _valor
            };

            Curso curso = new Curso(CursoEsperado.nome, CursoEsperado.descricao, CursoEsperado.cargaHoraria, CursoEsperado.PublicoAlvo, CursoEsperado.ValorDoCurso);

            CursoEsperado.ToExpectedObject().Matches(curso);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void CursoNaoDeveTerNomeInvalido(string NomeInvalido)
        {

            Assert.Throws<ArgumentException>(() => CursoBuilder.Novo().ComNome(NomeInvalido).Build()).ComMensagem("Nome não pode ser  nulo ou vazio.");
        }

        [Theory]
        [InlineData(-2)]
        [InlineData(-1000000)]
        public void CursoNãoPodeTerCargaHorariaMenorQue1(double CargaHorariaInvalida)
        {

                 Assert.Throws<ArgumentException>(() => CursoBuilder.Novo().ComCargaHoraria(CargaHorariaInvalida).Build()).ComMensagem("Carga Horaria deve ser maior que 1 hora.");
        }

        [Theory]
        [InlineData(250)]
        [InlineData(30000)]
        [InlineData(200.5)]
        public void CursoNãoPodeTerCargaHorariaMaiorQue200(double CargaHorariaInvalida)
        {
                 Assert.Throws<ArgumentException>(() => CursoBuilder.Novo().ComCargaHoraria(CargaHorariaInvalida).Build()).ComMensagem("Carga horaria não pode passar 200 horas");

        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-10000)]
        public void ValorDoCursoDeveSerMaiorQueZero(double ValorInvalido)
        {
            Assert.Throws<ArgumentException>(() => CursoBuilder.Novo().ComValor(ValorInvalido).Build()).ComMensagem("Valor deve ser maior que zero");
        }


    }

}

