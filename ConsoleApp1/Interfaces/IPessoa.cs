using ConsoleApp1.Entites.Enums;
using System;

namespace ConsoleApp1.Interfaces
{
    public interface IPessoa
    {
        string Nome { get; }
        Guid Id { get; }
        TipoPessoa Tipo { get; }
        bool PodeDirigir { get; }

        string Exibicao();
    }
}
