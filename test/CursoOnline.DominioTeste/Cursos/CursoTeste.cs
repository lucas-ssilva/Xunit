using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CursoOnline.Dominio;
using CursoOnline.Dominio.Enums;
using ExpectedObjects;
using CursoOnline.DominioTeste._Util;

namespace CursoOnline.DominioTeste.Cursos
{
    public class CursoTeste
    {
        [Fact]
        public void DeveCriarCurso()
        {
            var CursoEsperado = new
            {
                nome = "Informatica basica",
                cargaHoraria = (double)80,
                PublicoAlvo = PublicoAlvo.Estudantes,
                ValorDoCurso = (double)950.00
            };

            //Ação
            Curso curso = new Curso(CursoEsperado.nome, CursoEsperado.cargaHoraria, CursoEsperado.PublicoAlvo, CursoEsperado.ValorDoCurso);

            //Assert
            //CursoEsperado.ToExpectedObject().ShouldMatch(curso);
            CursoEsperado.ToExpectedObject().Matches(curso);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void CursoNaoDeveTerNomeInvalido(string NomeInvalido)
        {
            var CursoEsperado = new
            {
                nome = "Informatica basica",
                cargaHoraria = (double)80,
                PublicoAlvo = PublicoAlvo.Estudantes,
                ValorDoCurso = (double)950.00
            };

            Assert.Throws<ArgumentException>(() => new Curso(NomeInvalido,
            CursoEsperado.cargaHoraria, CursoEsperado.PublicoAlvo,
            CursoEsperado.ValorDoCurso)).ComMensagem("Nome não pode ser  nulo ou vazio.");
        }

        [Theory]
        [InlineData(-2)]
        [InlineData(-1000000)]
        public void CursoNãoPodeTerCargaHorariaMenorQue1(double CargaHorariaInvalida)
        {
            var CursoEsperado = new
            {
                nome = "Informatica basica",
                cargaHoraria = (double)80,
                PublicoAlvo = PublicoAlvo.Estudantes,
                ValorDoCurso = (double)950.00
            };

                 Assert.Throws<ArgumentException>(() => new Curso(CursoEsperado.nome,
                 CargaHorariaInvalida, CursoEsperado.PublicoAlvo,
                 CursoEsperado.ValorDoCurso)).ComMensagem("Carga Horaria deve ser maior que 1 hora.");
        }

        [Theory]
        [InlineData(250)]
        [InlineData(30000)]
        [InlineData(200.5)]
        public void CursoNãoPodeTerCargaHorariaMaiorQue200(double CargaHorariaInvalida)
        {
            var CursoEsperado = new
            {
                nome = "Informatica basica",
                cargaHoraria = (double)80,
                PublicoAlvo = PublicoAlvo.Estudantes,
                ValorDoCurso = (double)950.00
            };

                 Assert.Throws<ArgumentException>(() => new Curso(CursoEsperado.nome,
                 CargaHorariaInvalida, CursoEsperado.PublicoAlvo,
                 CursoEsperado.ValorDoCurso)).ComMensagem("Carga horaria não pode passar 200 horas");

        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-10000)]
        public void ValorDoCursoDeveSerMaiorQueZero(double ValorInvalido)
        {
            var CursoEsperado = new
            {
                nome = "Informatica basica",
                cargaHoraria = (double)80,
                PublicoAlvo = PublicoAlvo.Estudantes,
                ValorDoCurso = (double)950.00
            };

            Assert.Throws<ArgumentException>(() => new Curso(CursoEsperado.nome,
            CursoEsperado.cargaHoraria, CursoEsperado.PublicoAlvo,
           ValorInvalido)).ComMensagem("Valor deve ser maior que zero");
        }
    }

}

