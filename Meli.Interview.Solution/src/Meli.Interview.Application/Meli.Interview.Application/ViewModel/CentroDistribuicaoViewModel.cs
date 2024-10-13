using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meli.Interview.Application.ViewModel
{
    public class CentroDistribuicaoViewModel
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public string EnderecoCompleto { get; set; }

        public CentroDistribuicaoViewModel(int codigo, string descricao, string enderecoCompleto)
        {
            Codigo = codigo;
            Descricao = descricao;
            EnderecoCompleto = enderecoCompleto;
        }
    }
}
