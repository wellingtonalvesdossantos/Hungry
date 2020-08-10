namespace Hungry.Core
{
    public class PedidoItem : BaseDbEntity<PedidoItem>
    {
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal Quantidade { get; set; }
        public decimal Valor { get { return ValorUnitario * Quantidade; } }
    }
}