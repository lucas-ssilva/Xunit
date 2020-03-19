using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CursoOnline.Dominio;
using Moq;
using CursoOnline.Dominio.Enums;
using Bogus;
using CursoOnline.DominioTeste._Util;
using CursoOnline.DominioTeste.Builders;

namespace CursoOnline.DominioTeste.Cursos
{
    public class ArmazenadorDeCursoTest

    {
        private CursoDto _cursoDto;
        private ArmazenadorDeCurso _armazenadorDeCurso;
        private Mock<ICursoRepositorio> _cursoRepositorioMock;
        public ArmazenadorDeCursoTest()
        {


            var fake = new Faker();
            _cursoDto = new CursoDto
            {
                Nome = fake.Random.Words(),
                Descricao = fake.Lorem.Paragraph(),
                CargaHoraria = fake.Random.Double(2, 200),
                PublicoAlvo = "Estudantes",
                ValorDoCurso = fake.Random.Double(10, 10000)
            };

            _cursoRepositorioMock = new Mock<ICursoRepositorio>();
            _armazenadorDeCurso = new ArmazenadorDeCurso(_cursoRepositorioMock.Object);
        }

        [Fact] // moq verifica 
        public void DeveAdicionarCurso()
        {
            _armazenadorDeCurso.Armazenar(_cursoDto);

            _cursoRepositorioMock.Verify(r => r.Adicionar(It.Is<Curso>(c => c.Nome == _cursoDto.Nome && c.Descricao == _cursoDto.Descricao)));
        }
        [Fact]
        public void NaoDeveInformarPublicoAlvoInvalido()
        {

            _cursoDto.PublicoAlvo = "Medico";

            Assert.Throws<ArgumentException>(() => _armazenadorDeCurso.Armazenar(_cursoDto)).ComMensagem("Publico Alvo Invalido");
        }

        [Fact] // stub simula comportamento 
        public void NaoDeveAdicionarCursoComNomeIgual()
        {
            var cursoJaSalvo = CursoBuilder.Novo().ComNome(_cursoDto.Nome).Build();
            _cursoRepositorioMock.Setup(x => x.ObterPeloNome(_cursoDto.Nome)).Returns(cursoJaSalvo);
            Assert.Throws<ArgumentException>(() => _armazenadorDeCurso.Armazenar(_cursoDto)).
                ComMensagem("Nome do Curso já Consta no BD");
        }


    }
}
