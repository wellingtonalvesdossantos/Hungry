using System;
using System.Collections.Generic;
using System.Text;

namespace Hungry.Core.Builders
{
    public class PedidoBuilder
    {
        private Pedido _pedido = new Pedido();

        public PedidoBuilder(string endereco, Cliente cliente)
        {
            _pedido.Endereco = endereco;
            _pedido.ClienteId = cliente.Id;
        }

        public Pedido Build()
        {
            var frete = new PedidoAdendo() { AdendoId = Adendo.FRETE, Valor = 0 };
            _pedido.Adendos.Add(frete);
            return _pedido;
        }

        public PedidoBuilder AdicionarPizza(Produto produto, int quantidade = 1)
        {
            var item = new PedidoItem()
            {
                ProdutoId = produto.Id,
                ValorUnitario = produto.Valor,
                Quantidade = quantidade
            };
            _pedido.Itens.Add(item);
            return this;
        }

        public PedidoBuilder AdicionarPizzaBrotinho(Produto produto, int quantidade = 1)
        {
            for (int i = 1; i <= quantidade; i++)
            {
                var item = new PedidoItem()
                {
                    ProdutoId = produto.Id,
                    ValorUnitario = produto.Valor,
                    Quantidade = 0.75M
                };
                _pedido.Itens.Add(item); 
            }
            return this;
        }

        public PedidoBuilder AdicionarPizzaMeioAMeio(Produto produto1, Produto produto2)
        {
            var item1 = new PedidoItem()
            {
                ProdutoId = produto1.Id,
                ValorUnitario = produto1.Valor,
                Quantidade = 0.5M
            };
            var item2 = new PedidoItem()
            {
                ProdutoId = produto2.Id,
                ValorUnitario = produto2.Valor,
                Quantidade = 0.5M
            };
            _pedido.Itens.Add(item1);
            _pedido.Itens.Add(item2);
            return this;
        }
    }
}
