using System;
using System.Collections.Generic;
using System.Text;

namespace Hungry.Core
{
    public class Cliente : BaseDbEntity<Cliente>
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
    }
}
