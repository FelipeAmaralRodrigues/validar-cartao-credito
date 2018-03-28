using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;               
using LeanWork.Domain.Core.Models;

namespace LeanWork.Domain.CartaoCredito
{
    public class CartaoCredito : Entity<CartaoCredito>
    {
        public string Numero { get; private set; }

        public string Bandeira { get; private set; }     
        
        public override bool EhValido()
        {
            // Tome uma sequência de números inteiros positivos e a inverta. 
            string[] arrayNumero = new string[Numero.Length];
            for (var i = 0; i < Numero.Length; i++)
            {
                arrayNumero[i] = Numero[i].ToString();
            }                       
            Array.Reverse(arrayNumero);

            //Começando pelo segundo número, dobre o valor de cada número de forma alternada ("24145... = "28185...).
            int numero = -1;
            for(var i = 1; i < arrayNumero.Length; i++)
            {            
                if (!int.TryParse(arrayNumero[i], out numero))
                {
                    return false;
                }

                if (i % 2 != 0)
                {
                    arrayNumero[i] = (numero * 2).ToString();
                }
            }

            // Para dígitos maiores que 9 será necessário que some cada dígito ("10", 1 + 0 = 1) ou subtraia por 9 ("10", 10 - 9 = 1).
            for (var i = 1; i < arrayNumero.Length; i++)
            {
                if (arrayNumero[i].Length == 2)
                {            
                    arrayNumero[i] = (int.Parse(arrayNumero[i][0].ToString()) + int.Parse(arrayNumero[i][1].ToString())).ToString();
                }
            }

            // Some todos os números da sequência.
            var soma = arrayNumero.Sum(a => int.Parse(a));

            // Se o total for múltiplo de 10, o número é válido.
            if (soma % 10 == 0)
                return true;
            return false;   
        }

        public static class CartaoCreditoFactory
        {
            public static CartaoCredito NovoCartaoCredito(string numero)
            {
                var cartaoCredito = new CartaoCredito()
                {
                    Numero = numero
                };

                // AMEX
                if ((numero.Trim().StartsWith("34") || numero.Trim().StartsWith("37")) && numero.Trim().Length == 15)
                    cartaoCredito.Bandeira = "AMEX";

                // Discover
                else if (numero.Trim().StartsWith("6011") && numero.Trim().Length == 16)
                    cartaoCredito.Bandeira = "Discover";

                // MasterCard
                else if ((numero.Trim().StartsWith("51") || numero.Trim().StartsWith("55")) && numero.Trim().Length == 16)
                    cartaoCredito.Bandeira = "MasterCard";

                // Visa
                else if (numero.Trim().StartsWith("4") && (numero.Trim().Length == 13 || numero.Trim().Length == 16))
                    cartaoCredito.Bandeira = "Visa";

                // Outra
                else cartaoCredito.Bandeira = "Desconhecido";
                                                   
                return cartaoCredito;
            }
        }

    }
}
