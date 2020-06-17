using ConsoleAirlines.Business;
using ConsoleAirlines.Business.Inferface;
using ConsoleApp1.Entites;
using ConsoleApp1.Entites.Enums;
using ConsoleApp1.Interfaces;
using System;

namespace ConsoleApp1.Business
{
    class Transporte
    {
        private ValidacaoTransporte _validacaoTransporte;

        public Transporte()
        {
            _validacaoTransporte = new ValidacaoTransporte();
        }

        public void ExecutarTransporte(ILocal origem, ILocal destino)
        {
            try
            {
                Console.WriteLine("Transferindo de " + origem.Descricao + " para " + destino.Descricao);
                while (!origem.Vazio)
                {
                    Console.WriteLine("");
                    ExibirLocais(origem, destino);
                    Transferir(origem, destino);
                }
                ExibirLocais(origem, destino);
                Console.WriteLine("");
                Console.WriteLine("Transporte finalizado.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void ExibirLocais(ILocal primeiro, ILocal segundo)
        {
            primeiro.ExibirOcupantes();
            Console.WriteLine("");
            segundo.ExibirOcupantes();
        }

        private void Transferir(ILocal origem, ILocal destino)
        {
            IPessoa motorista = null;
            IPessoa passageiro = null;

            bool ultimaViagem = false;
            if (origem.ContemTipo(TipoPessoa.Oficial))
            {
                passageiro = origem.GetPessoaPorTipo(TipoPessoa.Oficial);
                motorista = origem.GetPessoaPorTipo(TipoPessoa.Piloto);
            }
            else if (origem.ContemTipo(TipoPessoa.Piloto))
            {
                passageiro = origem.GetPessoaPorTipo(TipoPessoa.Piloto);
                motorista = origem.GetPessoaPorTipo(TipoPessoa.ChefeDeServico);
            }
            else if (origem.ContemTipo(TipoPessoa.Comissaria))
            {
                passageiro = origem.GetPessoaPorTipo(TipoPessoa.Comissaria);
                motorista = origem.GetPessoaPorTipo(TipoPessoa.ChefeDeServico);
            }
            else if (origem.ContemTipo(TipoPessoa.ChefeDeServico))
            {
                passageiro = origem.GetPessoaPorTipo(TipoPessoa.ChefeDeServico);
                motorista = origem.GetPessoaPorTipo(TipoPessoa.Policial);
            }
            else
            {                 
                passageiro = origem.GetPessoaPorTipo(TipoPessoa.Presidiario);
                motorista = origem.GetPessoaPorTipo(TipoPessoa.Policial);
                ultimaViagem = true;
            }

            RealizarViagem(origem, destino, motorista, passageiro, ultimaViagem);
        }

        private void Desembarcar (IPessoa pessoa, ILocal origem, ILocal destino)
        {
            origem.RemoverPessoa(pessoa);
            destino.AdicionarPessoa(pessoa);
            Console.WriteLine(pessoa.Exibicao() + " desceu em: " + destino.Descricao);
        }

        private void RealizarViagem(ILocal origem, ILocal destino, IPessoa motorista, IPessoa passageiro, bool ultimaViagem)
        {
            _validacaoTransporte.ValidarMotorista(motorista);
            _validacaoTransporte.ValidarCompanhiaViagem(motorista, passageiro);
            Console.WriteLine("");
            Console.WriteLine("Realizando transporte -> Motorista: " + motorista.Exibicao() + ". Passageiro: " + passageiro.Exibicao());
            if (ultimaViagem)
            {
                Desembarcar(motorista, origem, destino);
            }
            Desembarcar(passageiro, origem, destino);
            Console.WriteLine("==================================================================================================================");
            _validacaoTransporte.RestricoesLocal(origem);
            _validacaoTransporte.RestricoesLocal(destino);
        }
    }
}
