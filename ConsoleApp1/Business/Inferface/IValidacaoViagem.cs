using ConsoleApp1.Interfaces;

namespace ConsoleAirlines.Business.Inferface
{
    public interface IValidacaoViagem
    {
        void ValidarMotorista(IPessoa pessoaMotorista);

        void ValidarCompanhiaViagem(IPessoa motorista, IPessoa passageiro);
    }
}
