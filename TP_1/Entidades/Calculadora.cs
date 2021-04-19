using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        #region Metodos
        /// <summary>
        /// Metodo privado de validacion.
        /// <param name="operador">Operador a validar.</param>
        /// <returns>Retorno operador validado en string.</returns>
        private static string ValidarOperador(char operador)
        {
            switch (operador)
            {
                case '+':
                    break;
                case '-':
                    break;
                case '/':
                    break;
                case '*':
                    break;
                default:
                    operador = '+';
                    break;
            }
            return operador.ToString(); 
        }
        /// <summary>
        /// Metodo estatico de operaciones.
        /// </summary>
        /// <param name="num1">Primero numero para operación</param>
        /// <param name="num2">Segundo numero para operación</param>
        /// <param name="operador">Tipo de operador</param>
        /// <returns>Retorno resultado de la operacion</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = 0;
            switch (ValidarOperador(Convert.ToChar(operador)))
            {
                case "+":
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
            }
            return resultado;
        }
        #endregion
    }

}
