using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hungry.Core
{
    [Table("Adendo")]
    class Adendo : BaseDbEntity<Adendo>
    {
        public const int FRETE = 1;

        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public DateTime? VigenciaInicial { get; set; }
        public DateTime? VigenciaFinal { get; set; }
    }
}
