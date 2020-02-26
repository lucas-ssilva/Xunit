using System;
using System.Collections.Generic;
using System.Text;
using CursoOnline.Dominio;
using CursoOnline.Dominio.Enums;
using ExpectedObjects;
using CursoOnline.DominioTeste._Util;
using Xunit.Abstractions;
using Bogus;

namespace CursoOnline.DominioTeste.Builders
{
    class CursoBuilder
    {
        private string _nome = "Informatica basica";
        private string _descricao = "uma Descrição";
        private double _cargaHoraria = 80;
        private PublicoAlvo _publicoAlvo = PublicoAlvo.Estudantes;
        private double _valor = 950.00;

        public static CursoBuilder Novo()
        {
            return new CursoBuilder();
        }

        public CursoBuilder ComNome(string nome)
        {
            _nome = nome;
            return this;
        }
        public CursoBuilder ComDescricao(string descricao)
        {
            _descricao = descricao;
            return this;
        }
        public CursoBuilder ComCargaHoraria(double CargaHoraria)
        {
            _cargaHoraria = CargaHoraria;
            return this;
        }
        public CursoBuilder ComValor(double valor)
        {
            _valor = valor;
            return this;
        }
        public CursoBuilder ComPublicoAlvo(PublicoAlvo publicoAlvo)
        {
           _publicoAlvo = publicoAlvo;
            return this;
        }

        public Curso Build()
        {
            return new Curso(_nome, _descricao, _cargaHoraria, _publicoAlvo, _valor);
        }
    }
}
