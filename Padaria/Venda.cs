using System;
using System.Collections.Generic;
using System.Text;

namespace Padaria
{
    public class Venda : Base
    {

        public Funcionario Funcionario { get; set; }
        public List<ItemVenda> Produtos { get; set; } = new List<ItemVenda>();
        public decimal Total { get; set; }
    }
}
