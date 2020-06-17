using ConsoleApp1.Entites.Enums;
using ConsoleApp1.Interfaces;
using System;

namespace ConsoleApp1.Entites
{
    class Pessoa : IPessoa
    {
        public string Nome { get; private set; }
        public TipoPessoa Tipo { get; private set; }
        public bool PodeDirigir { get; private set; }
        public Guid Id { get; private set; }

        public Pessoa(string nome, TipoPessoa tipo)
        {
            Nome = nome;
            Tipo = tipo;
            Id = Guid.NewGuid();
            PodeDirigir = tipo == TipoPessoa.ChefeDeServico || tipo == TipoPessoa.Piloto || tipo == TipoPessoa.Policial;
        }

        public string Exibicao ()
        {
            return $"{Nome}({Tipo})";
        }

    }
}
