using Hungry.Core;
using Hungry.Core.Builders;
using NUnit.Framework;

namespace Hungry.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AdicionarPizza()
        {
            var produto = Produto.GetById(5);
            var cliente = Cliente.GetById(1);
            var builder = new PedidoBuilder("Rua da minha tia, 100", cliente);

            //Act
            builder = builder.AdicionarPizza(produto);
            var pedido = builder.Build();
            var valorTotal = pedido.ObterValorTotal();

            //Assert
            Assert.AreEqual(valorTotal, 55.00);
        }

        [Test]
        public void AdicionarPizzaBrotinho()
        {
            var produto = Produto.GetById(5);
            var cliente = Cliente.GetById(1);
            var builder = new PedidoBuilder("Rua da minha tia, 100", cliente);

            //Act
            builder = builder.AdicionarPizzaBrotinho(produto);
            var pedido = builder.Build();
            var valorTotal = pedido.ObterValorTotal();

            //Assert
            Assert.AreEqual(valorTotal, 41.25);
        }

        [Test]
        public void AdicionarPizzaMeioAMeio()
        {
            var produto1 = Produto.GetById(5);
            var produto2 = Produto.GetById(6);
            var cliente = Cliente.GetById(1);
            var builder = new PedidoBuilder("Rua da minha tia, 100", cliente);

            //Act
            builder = builder.AdicionarPizzaMeioAMeio(produto1, produto2);
            var pedido = builder.Build();
            var valorTotal = pedido.ObterValorTotal();

            //Assert
            Assert.AreEqual(valorTotal, 50.00);
        }
    }
}