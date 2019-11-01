using System;
using System.Collections.Generic;
using System.Text;

namespace Padaria
{
    public class Produto : Base
    {
        public string Nome { get; set; }
        public int Estoque { get; set; }
        public decimal Preco { get; set; }
    }
}
