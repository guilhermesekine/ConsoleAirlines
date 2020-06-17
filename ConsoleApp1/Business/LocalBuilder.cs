using ConsoleApp1.Entites;
using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Business
{
    public class LocalBuilder
    {
        private string _descricao;

        public LocalBuilder SetDescricao(string descricao)
        {
            _descricao = descricao;
            return this;
        }

        public ILocal Create()
        {
            return new Local(_descricao);
        }
    }
}