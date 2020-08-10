using Dapper.Contrib.Extensions;

namespace Hungry.Core
{
    [Table("PedidoAdendo")]
    public class PedidoAdendo : BaseDbEntity<PedidoAdendo>
    {
        public int PedidoId { get; set; }
        public int AdendoId { get; set; }
        public decimal Valor { get; set; }
    }
}