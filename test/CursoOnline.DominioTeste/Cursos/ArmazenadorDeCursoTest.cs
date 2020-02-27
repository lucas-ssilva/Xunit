﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CursoOnline.Dominio;
using Moq;
using CursoOnline.Dominio.Enums;

namespace CursoOnline.DominioTeste.Cursos
{
    public class ArmazenadorDeCursoTest
    {
        [Fact]
        public void DeveAdicionarCurso()
        {
            var cursoDto = new CursoDto
            {
                Nome = "Curso A",
                Descricao = "Descrição",
                CargaHoraria = 80,
                PublicoAlvoId = 1,
                ValorDoCurso = 950.0
            };

            var cursoRepositorioMock = new Mock<ICursoRepositorio>();

            var armazenadorDeCurso = new ArmazenadorDeCurso(cursoRepositorioMock.Object);

            armazenadorDeCurso.Armazenar(cursoDto);

            cursoRepositorioMock.Verify(r => r.Adicionar(It.IsAny<Curso>()));


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
        public int CargaHoraria { get; set; }
        public int PublicoAlvoId { get; set; }
        public double ValorDoCurso { get; set; }
    }
}
