using ConsoleApp1.Entites.Enums;
using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.Entites
{
    class Local : ILocal
    {
        public string Descricao { get; private set; }
        public List<IPessoa> Ocupantes { get; private set; }

        public Local(string descricao)
        {
            Descricao = descricao;
            Ocupantes = new List<IPessoa>();
        }

        public bool Vazio
        {
            get { return Ocupantes.Count == 0; }
        }

        public void ExibirOcupantes()
        {
            Console.WriteLine("Lista de ocupantes de " + Descricao + ":");
            if (Vazio)
                Console.WriteLine("O local está vazio.");
            foreach (Pessoa pessoa in Ocupantes)
                Console.WriteLine(pessoa.Exibicao());
        }

        public IPessoa GetPessoaPorTipo (TipoPessoa tipo)
        {
            return Ocupantes.FirstOrDefault(t => t.Tipo == tipo);
        }

        public int QuantidadeOcupantes
        {
            get { return Ocupantes.Count; }
        }

        public bool ContemTipo(TipoPessoa tipo)
        {
            return Ocupantes.Any(p => p.Tipo == tipo);
        }

        public void RemoverPessoa(IPessoa pessoa)
        {
            Ocupantes.Remove(pessoa);
        }

        public void AdicionarPessoa(IPessoa pessoa)
        {
            Ocupantes.Add(pessoa);
        }
    }
}
