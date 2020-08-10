using Dapper;
using Dapper.Contrib.Extensions;
using Hungry.Core.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Hungry.Core
{
    [Table("Pedido")]
    public class Pedido : BaseDbEntity<Pedido>, IValidatable
    {
        public DateTime DataHoraCriacao { get; set; } = DateTime.Now;
        public string Endereco { get; set; }
        public int ClienteId { get; set; }

        [Write(false)]
        public List<PedidoItem> Itens { get; set; } = new List<PedidoItem>();
        [Write(false)]
        public List<PedidoAdendo> Adendos { get; set; } = new List<PedidoAdendo>();

        public void Validar()
        {
            if (!Itens.Any())
            {
                throw new Exception("Nenhum item adicionado ao pedido.");
            }

            if (ObterQuantidadePizzas() > 10)
            {
                throw new Exception(string.Format("Número máximo de itens excedido."));
            }
        }

        public decimal ObterValorTotal()
        {
            var valorItens = Itens.Sum(x => x.Valor);
            foreach (var adendo in Adendos)
            {
                valorItens += adendo.Valor;
            }
            return valorItens;
        }

        public int ObterQuantidadePizzas()
        {
            return
                Itens.Count(x => x.Quantidade == 0.7M) + //brotinhos
                (Itens.Count(x => x.Quantidade == 0.5M)/2) + //meio a meio
                Itens.Where(x => !x.Quantidade.IsInList(0.7M, 0.5M)).Sum(x => (int)x.Quantidade); //inteiras
        }

        public void Create()
        {
            using (var conn = DbContext.DbConnectionFactory.GetInstance())
            {
                using (var tr = conn.BeginTransaction())
                {
                    try
                    {
                        var id = (int)conn.Insert(this, tr);
                        Itens.ForEach(x => { x.PedidoId = id; conn.Insert(x, tr); });
                        Adendos.ForEach(x => { x.PedidoId = id; conn.Insert(x, tr); });
                        tr.Commit();
                    }
                    catch (Exception ex)
                    {
                        tr.Rollback();
                    }
                }
            }
        }

        public static Pedido GetFullById(int id)
        {
            var pedido = GetById(id);

            using (var conn = DbContext.DbConnectionFactory.GetInstance())
            {
                pedido.Itens = conn.Query<PedidoItem>("select * from " + nameof(PedidoItem) + " where pedidoid = @id", new { id }).ToList();
                pedido.Adendos = conn.Query<PedidoAdendo>("select * from " + nameof(PedidoAdendo) + " where pedidoid = @id", new { id }).ToList();
            }

            return pedido;
        }
    }
}
