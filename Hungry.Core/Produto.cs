using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hungry.Core
{
    [Table("Produto")]
    public class Produto : BaseDbEntity<Produto>
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
    }
}
