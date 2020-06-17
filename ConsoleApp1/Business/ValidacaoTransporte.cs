using ConsoleAirlines.Business.Inferface;
using ConsoleApp1.Entites.Enums;
using ConsoleApp1.Interfaces;
using System;

namespace ConsoleAirlines.Business
{
    public class ValidacaoTransporte : IValidacaoTransporte
    {
        public void ValidarTiposCompanhia(TipoPessoa tipo1, TipoPessoa tipo2)
        {
            if ((tipo1 == TipoPessoa.Piloto && tipo2 == TipoPessoa.Comissaria) || (tipo1 == TipoPessoa.Comissaria && tipo2 == TipoPessoa.Piloto))
                throw new Exception("Piloto e Comissária não podem ficar a sós.");
            if ((tipo1 == TipoPessoa.ChefeDeServico && tipo2 == TipoPessoa.Oficial) || (tipo1 == TipoPessoa.Oficial && tipo2 == TipoPessoa.ChefeDeServico))
                throw new Exception("Chefe de Servico e Oficial não podem ficar a sós.");
        }

        public void RestricoesLocal(ILocal local)
        {
            if (local.QuantidadeOcupantes >= 2 && local.ContemTipo(TipoPessoa.Presidiario) && !local.ContemTipo(TipoPessoa.Presidiario))
                throw new Exception("O Presidiário não pode ficar sem a presença do Policial.");
            if (local.QuantidadeOcupantes == 2)
            {
                ValidarTiposCompanhia(local.Ocupantes[0].Tipo, local.Ocupantes[1].Tipo);
            }
        }

        public void ValidarCompanhiaViagem(IPessoa motorista, IPessoa passageiro)
        {
            ValidarTiposCompanhia(motorista.Tipo, passageiro.Tipo);   
        }

        public void ValidarMotorista(IPessoa pessoaMotorista)
        {
            if (!pessoaMotorista.PodeDirigir)
                throw new Exception("A pessoa selecionada para motorista não pode dirigir.");
        }
    }
}
