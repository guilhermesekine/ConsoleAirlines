using ConsoleAirlines.Business;
using ConsoleAirlines.Business.Inferface;
using ConsoleApp1.Business;
using ConsoleApp1.Entites.Enums;
using System;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTests
    {
        private ValidacaoTransporte _validacaoTransporte = new ValidacaoTransporte();

        [Fact]
        public void Deve_Lancar_Exception_Se_Presidiario_Ficar_Sem_Policial()
        {
            var localBuilder = new LocalBuilder();
            var local = localBuilder.SetDescricao("Local Teste").Create();
            var pessoaBuilder = new PessoaBuilder();
            local.AdicionarPessoa(pessoaBuilder.SetNome("Jorge").SetTipoPessoa(TipoPessoa.Presidiario).Create());
            local.AdicionarPessoa(pessoaBuilder.SetNome("Mateus").SetTipoPessoa(TipoPessoa.Oficial).Create());
            local.AdicionarPessoa(pessoaBuilder.SetNome("Bruno").SetTipoPessoa(TipoPessoa.Oficial).Create());
            local.AdicionarPessoa(pessoaBuilder.SetNome("Marrone").SetTipoPessoa(TipoPessoa.Piloto).Create());

            var ex = Assert.Throws<Exception>(() => _validacaoTransporte.RestricoesLocal(local));
            Assert.Equal("O Presidiário não pode ficar sem a presença do Policial.", ex.Message);
        }

        [Fact]
        public void Deve_Lancar_Exception_Se_Piloto_E_Comissaria_Ficarem_A_Sos()
        {
            var localBuilder = new LocalBuilder();
            var local = localBuilder.SetDescricao("Local Teste").Create();
            var pessoaBuilder = new PessoaBuilder();
            local.AdicionarPessoa(pessoaBuilder.SetNome("Jorge").SetTipoPessoa(TipoPessoa.Piloto).Create());
            local.AdicionarPessoa(pessoaBuilder.SetNome("Mateus").SetTipoPessoa(TipoPessoa.Comissaria).Create());

            var ex = Assert.Throws<Exception>(() => _validacaoTransporte.RestricoesLocal(local));
            Assert.Equal("Piloto e Comissária não podem ficar a sós.", ex.Message);
        }

        [Fact]
        public void Deve_Lancar_Exception_Se_ChefeDeServico_E_Oficial_Ficarem_A_Sos()
        {
            var localBuilder = new LocalBuilder();
            var local = localBuilder.SetDescricao("Local Teste").Create();
            var pessoaBuilder = new PessoaBuilder();
            local.AdicionarPessoa(pessoaBuilder.SetNome("Jorge").SetTipoPessoa(TipoPessoa.ChefeDeServico).Create());
            local.AdicionarPessoa(pessoaBuilder.SetNome("Mateus").SetTipoPessoa(TipoPessoa.Oficial).Create());

            var ex = Assert.Throws<Exception>(() => _validacaoTransporte.RestricoesLocal(local));
            Assert.Equal("Chefe de Servico e Oficial não podem ficar a sós.", ex.Message);
        }

    }
}
