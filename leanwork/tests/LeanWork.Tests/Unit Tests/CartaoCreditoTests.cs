using System;
using System.Collections.Generic;
using System.Text;
using LeanWork.Domain.CartaoCredito;
using Xunit;

namespace LeanWork.Tests.Unit_Tests
{
    public class CartaoCreditoTests
    {
        // AAA => Arrange, Act, Assert

        [Fact]
        [Trait("CartaoCredito", "Visa")]
        public void CartaoCredito_ValidarVisa_RetornarComSucesso() 
        {
            // Arrange                            
            CartaoCredito c = CartaoCredito.CartaoCreditoFactory.NovoCartaoCredito("4111111111111111");

            // Act
            var result = c.EhValido();

            // Assert
            Assert.True(result);
            Assert.StrictEqual(c.Bandeira,"Visa");
        }

        [Fact]
        [Trait("CartaoCredito", "Visa")]
        public void CartaoCredito_ValidarVisa_RetornarComFalha()
        {
            // Arrange                            
            CartaoCredito c = CartaoCredito.CartaoCreditoFactory.NovoCartaoCredito("4111111111111");

            // Act
            var result = c.EhValido();

            // Assert
            Assert.False(result);
            Assert.StrictEqual(c.Bandeira,"Visa");
        }

        [Fact]
        [Trait("CartaoCredito", "Amex")]
        public void CartaoCredito_ValidarAmex_RetornarComSucesso()
        {
            // Arrange                            
            CartaoCredito c = CartaoCredito.CartaoCreditoFactory.NovoCartaoCredito("378282246310005");

            // Act
            var result = c.EhValido();

            // Assert
            Assert.True(result);
            Assert.StrictEqual(c.Bandeira,"AMEX");
        }

        [Fact]
        [Trait("CartaoCredito", "MasterCard")]
        public void CartaoCredito_ValidarMasteCard_RetornarComSucesso()
        {
            // Arrange                            
            CartaoCredito c = CartaoCredito.CartaoCreditoFactory.NovoCartaoCredito("5105105105105100");

            // Act
            var result = c.EhValido();

            // Assert
            Assert.True(result);
            Assert.StrictEqual(c.Bandeira,"MasterCard");
        }

        [Fact]
        [Trait("CartaoCredito", "MasterCard")]
        public void CartaoCredito_ValidarMasteCard_RetornarComFalha()
        {
            // Arrange                            
            CartaoCredito c = CartaoCredito.CartaoCreditoFactory.NovoCartaoCredito("5105105105105106");

            // Act
            var result = c.EhValido();

            // Assert
            Assert.False(result);
            Assert.StrictEqual(c.Bandeira,"MasterCard");
        }

        [Fact]
        [Trait("CartaoCredito", "Discover")]
        public void CartaoCredito_ValidarDiscover_RetornarComSucesso()
        {
            // Arrange                            
            CartaoCredito c = CartaoCredito.CartaoCreditoFactory.NovoCartaoCredito("6011111111111117");

            // Act
            var result = c.EhValido();

            // Assert
            Assert.True(result);
            Assert.StrictEqual(c.Bandeira,"Discover");
        }

        [Fact]
        [Trait("CartaoCredito", "Desconhecido")]
        public void CartaoCredito_ValidarDesconhecido_RetornarComFalha()
        {
            // Arrange                            
            CartaoCredito c = CartaoCredito.CartaoCreditoFactory.NovoCartaoCredito("9111111111111111");

            // Act
            var result = c.EhValido();

            // Assert
            Assert.False(result);
            Assert.StrictEqual(c.Bandeira,"Desconhecido");
        }
    }
}
