using System;
using System.Collections.Generic;
using System.Text;
using CursoOnline.Dominio.Enums;

namespace CursoOnline.Dominio
{
   public class Curso
    {
        public string Nome { get; set; }
        public double CargaHoraria { get; set; }
        public PublicoAlvo PublicoAlvo { get; set; }
        public double ValorDoCurso { get; set; }

        public Curso(string nome, double cargaHoraria, PublicoAlvo publicoAlvo, double valorDoCurso)
        {
            Nome = nome;
            CargaHoraria = cargaHoraria;
            PublicoAlvo = publicoAlvo;
            ValorDoCurso = valorDoCurso;

            if (string.IsNullOrEmpty(Nome))
            {
                throw new ArgumentException("Nome não pode ser  nulo ou vazio.");
            }
            if (cargaHoraria < 1)
            {
                throw new ArgumentException("Carga Horaria deve ser maior que 1 hora.");
            }
            if(cargaHoraria > 200)
            {
                throw new ArgumentException("Carga horaria não pode passar 200 horas");
            }
            if(valorDoCurso <= 0)
            {
                throw new ArgumentException("Valor deve ser maior que zero");
            }
        }

        
    }
}
