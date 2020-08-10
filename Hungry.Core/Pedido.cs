using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hungry.Core
{
    public class Pedido : BaseDbEntity<Pedido>
    {
        public string Nome { get; set; }
        public DateTime DataHoraCriacao { get; set; } = DateTime.Now;
        public string Endereco { get; set; }
        public int ClienteId { get; set; }

        public List<PedidoItem> Itens { get; set; } = new List<PedidoItem>();
        public List<PedidoAdendo> Adendos { get; set; } = new List<PedidoAdendo>();

        public decimal ObterValorTotal()
        {
            var valorItens = Itens.Sum(x => x.Valor);
            foreach (var adendo in Adendos)
            {
                valorItens += adendo.Valor;
            }
            return valorItens;
        }

    }
}
