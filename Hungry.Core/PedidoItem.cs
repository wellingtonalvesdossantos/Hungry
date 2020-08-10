using Dapper.Contrib.Extensions;

namespace Hungry.Core
{
    [Table("PedidoItem")]
    public class PedidoItem : BaseDbEntity<PedidoItem>
    {
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal Quantidade { get; set; }
        [Write(false)]
        public decimal Valor { get { return ValorUnitario * Quantidade; } }
    }
}