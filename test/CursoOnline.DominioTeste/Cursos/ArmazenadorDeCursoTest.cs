using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CursoOnline.Dominio;
using Moq;
using CursoOnline.Dominio.Enums;
using Bogus;

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
                CargaHoraria = fake.Random.Double(2,200),
                PublicoAlvoId = 1,
                ValorDoCurso = fake.Random.Double(10,10000)
            };

            _cursoRepositorioMock = new Mock<ICursoRepositorio>();
            _armazenadorDeCurso = new ArmazenadorDeCurso(_cursoRepositorioMock.Object);
        }

        [Fact]
        public void DeveAdicionarCurso()
        {
            _armazenadorDeCurso.Armazenar(_cursoDto);

            _cursoRepositorioMock.Verify(r => r.Adicionar(It.Is<Curso>(c => c.Nome == _cursoDto.Nome && c.Descricao == _cursoDto.Descricao)));


        }

        public interface ICursoRepositorio
        {
            void Adicionar(Curso curso);
        }

        public class ArmazenadorDeCurso
        {
            private readonly ICursoRepositorio _cursorepositorio;

            public ArmazenadorDeCurso(ICursoRepositorio cursoRepositorio)
            {
                _cursorepositorio = cursoRepositorio;
            }

            public void Armazenar(CursoDto cursoDto)
            {
                var curso = new Curso(cursoDto.Nome, cursoDto.Descricao, cursoDto.CargaHoraria, PublicoAlvo.Estudantes, cursoDto.ValorDoCurso);

                _cursorepositorio.Adicionar(curso);
            }
        }
    }

    public class CursoDto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double CargaHoraria { get; set; }
        public int PublicoAlvoId { get; set; }
        public double ValorDoCurso { get; set; }
    }
}
