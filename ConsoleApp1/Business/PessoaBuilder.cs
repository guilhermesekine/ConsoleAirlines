using ConsoleApp1.Entites;
using ConsoleApp1.Entites.Enums;
using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Business
{
    public class PessoaBuilder
    {
        private string _nome;
        private TipoPessoa _tipo;

        public PessoaBuilder SetNome(string nome)
        {
            _nome = nome;
            return this;
        }

        public PessoaBuilder SetTipoPessoa(TipoPessoa tipo)
        {
            _tipo = tipo;
            return this;
        }

        public IPessoa Create()
        {
            return new Pessoa(_nome, _tipo);
        }
    }
}