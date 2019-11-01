using System;
using System.Collections.Generic;
using System.Text;

namespace Padaria
{
   public abstract class Base
    {
        public int Codigo { get; set; } = new Random().Next(1, 999999);
        public DateTime Cadastro { get; set; } = DateTime.Now;
    }
}
