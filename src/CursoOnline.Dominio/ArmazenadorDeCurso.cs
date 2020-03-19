using CursoOnline.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CursoOnline.Dominio
{

    public class ArmazenadorDeCurso
    {
        private readonly ICursoRepositorio _cursorepositorio;

        public ArmazenadorDeCurso(ICursoRepositorio cursoRepositorio)
        {
            _cursorepositorio = cursoRepositorio;
        }

        public void Armazenar(CursoDto cursoDto)
        {
            var cursoJaSalvo = _cursorepositorio.ObterPeloNome(cursoDto.Nome);

            if (cursoJaSalvo != null)
            {
                throw new ArgumentException("Nome do Curso já Consta no BD");
            }

            Enum.TryParse(typeof(PublicoAlvo), cursoDto.PublicoAlvo, out var publicoAlvo);

            if (publicoAlvo == null)
            {
                throw new ArgumentException("Publico Alvo Invalido");
            }
            var curso = new Curso(cursoDto.Nome, cursoDto.Descricao, cursoDto.CargaHoraria, (PublicoAlvo)publicoAlvo, cursoDto.ValorDoCurso);

            _cursorepositorio.Adicionar(curso);
        }
    }
    public interface ICursoRepositorio
    {
        void Adicionar(Curso curso);
        Curso ObterPeloNome(string nome);
    }


}

public class CursoDto
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public double CargaHoraria { get; set; }
    public string PublicoAlvo { get; set; }
    public double ValorDoCurso { get; set; }
}

    

