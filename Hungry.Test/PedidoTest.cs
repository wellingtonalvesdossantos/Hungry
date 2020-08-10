using Hungry.Core;
using Hungry.Core.Builders;
using NUnit.Framework;
using System;

namespace Hungry.Test
{
    public class PedidoTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Validar_Success()
        {
            var produto1 = Produto.GetById(5);
            var produto2 = Produto.GetById(6);
            var cliente = Cliente.GetById(1);
            var builder = new PedidoBuilder("Rua da minha tia, 100", cliente);

            //Act
            builder
                .AdicionarPizza(produto1, 9)
                .AdicionarPizzaBrotinho(produto2);
            var pedido = builder.Build();
            var quantidadePizzas = pedido.ObterQuantidadePizzas();

            //Assert
            Assert.AreEqual(quantidadePizzas, 10);
        }

        [Test]
        public void Validar_Error_Empty()
        {
            var cliente = Cliente.GetById(1);
            var builder = new PedidoBuilder("Rua da minha tia, 100", cliente);

            //Act
            var ex = Assert.Throws<Exception>(() => builder.Build());

            //Assert
            Assert.That(ex.Message, Is.EqualTo("Nenhum item adicionado ao pedido."));
        }

        [Test]
        public void Validar_Error_Exceed()
        {
            var produto1 = Produto.GetById(5);
            var produto2 = Produto.GetById(6);
            var cliente = Cliente.GetById(1);
            var builder = new PedidoBuilder("Rua da minha tia, 100", cliente);

            //Act
            builder
                .AdicionarPizza(produto1, 10)
                .AdicionarPizzaBrotinho(produto2);
            var ex = Assert.Throws<Exception>(() => builder.Build());

            //Assert
            Assert.That(ex.Message, Is.EqualTo("Número máximo de itens excedido."));
        }
    }
}
