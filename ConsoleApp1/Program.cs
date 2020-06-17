using ConsoleApp1.Business;
using ConsoleApp1.Entites;
using ConsoleApp1.Entites.Enums;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var localBuilder = new LocalBuilder();
            var origem = localBuilder.SetDescricao("Terminal").Create();

            var pessoaBuilder = new PessoaBuilder();
            origem.AdicionarPessoa(pessoaBuilder.SetNome("Robin").SetTipoPessoa(TipoPessoa.Policial).Create());
            origem.AdicionarPessoa(pessoaBuilder.SetNome("Batgirl").SetTipoPessoa(TipoPessoa.Comissaria).Create());
            origem.AdicionarPessoa(pessoaBuilder.SetNome("Wolverine").SetTipoPessoa(TipoPessoa.Oficial).Create());
            origem.AdicionarPessoa(pessoaBuilder.SetNome("Goku").SetTipoPessoa(TipoPessoa.Oficial).Create());
            origem.AdicionarPessoa(pessoaBuilder.SetNome("Flash").SetTipoPessoa(TipoPessoa.ChefeDeServico).Create());
            origem.AdicionarPessoa(pessoaBuilder.SetNome("Wonderwoman").SetTipoPessoa(TipoPessoa.Comissaria).Create());
            origem.AdicionarPessoa(pessoaBuilder.SetNome("Seiya").SetTipoPessoa(TipoPessoa.Presidiario).Create());
            origem.AdicionarPessoa(pessoaBuilder.SetNome("Allejo").SetTipoPessoa(TipoPessoa.Piloto).Create());
           
            var destino = localBuilder.SetDescricao("Avião").Create();

            new Transporte().ExecutarTransporte(origem, destino);
            Console.ReadKey();
        }
    }
}
