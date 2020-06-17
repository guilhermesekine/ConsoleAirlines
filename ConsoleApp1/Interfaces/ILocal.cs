using ConsoleApp1.Entites;
using ConsoleApp1.Entites.Enums;
using System;
using System.Collections.Generic;

namespace ConsoleApp1.Interfaces
{
    public interface ILocal
    {
        string Descricao { get; }
        List<IPessoa> Ocupantes { get; }
        bool Vazio { get; }
        int QuantidadeOcupantes { get; }
        void ExibirOcupantes();
        bool ContemTipo(TipoPessoa oficial);
        IPessoa GetPessoaPorTipo(TipoPessoa oficial);
        void RemoverPessoa(IPessoa motorista);
        void AdicionarPessoa(IPessoa motorista);
    }
}
