using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        #region Atributos
        private double numero;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad solo escritura con validacion.
        /// </summary>
        private string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor que recibe un string
        /// Constructor por defecto.
        /// </summary>
        /// <param name="strNumero">Recibo un numero para inicializar el objeto.</param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }
        /// <summary>
        /// Constructor que recibe un double
        /// </summary>
        /// <param name="dbNumero">Recibo un numero para inicializar el objeto.</param>
        public Numero(double dbNumero) : this(dbNumero.ToString())
        {
            
        }
        /// <summary>
        /// Constructor sin parametro inicializa en cero
        /// </summary>
        public Numero() : this(0)
        {

        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo para validar numero
        /// </summary>
        /// <param name="strNumero">Numero a validar.</param>
        /// <returns>Retorno numero validado.</returns>
        private static double ValidarNumero(string strNumero)
        {
            double.TryParse(strNumero, out double dbNumero);
            return dbNumero;
        }
        /// <summary>
        /// Metodo para convertir de binario a decimal.
        /// </summary>
        /// <param name="strResultado">Numero a convertir.</param>
        /// <returns>Retorno el numero convertido en decimal.</returns>
        public static string BinarioADecimal(string strResultado)
        {
            Numero dbNumero = new Numero(strResultado);
            char[] arrResultado = strResultado.ToCharArray();
            Array.Reverse(arrResultado);
            double suma = 0;
            if (EsBinario(strResultado))
            {
                for (int i = 0; i < arrResultado.Length; i++)
                {
                    if (arrResultado[i] == '1')
                        suma += (int)Math.Pow(2, i);
                }
                strResultado = suma.ToString();
            }
            else if (dbNumero.numero == 0)
                strResultado = "0";
            else
                strResultado = "Valor inválido";
            return strResultado;
        }

        /// <summary>
        /// Metodo para convertir de decimal a binario
        /// </summary>
        /// <param name="strResultado">Numero a convertir.</param>
        /// <returns>Retorno el numero convertido en binario.</returns>
        public static string DecimalABinario(string strResultado)
        {
            Numero auxiliar = new Numero(strResultado);
            double dbNumero = Math.Floor(auxiliar.numero);
            strResultado = "";
            if (dbNumero > 0)
            {
                while (dbNumero > 0)
                {
                    if (dbNumero % 2 == 0)
                        strResultado = "0" + strResultado;
                    else
                        strResultado = "1" + strResultado;
                    dbNumero = (int)(dbNumero / 2);
                }
            }
            else if (dbNumero == 0)
                strResultado = "0";
            else
                strResultado = "Valor invalido";
            return strResultado;
        }
        /// <summary>
        /// Metodo para convertir de decimal a binario
        /// </summary>
        /// <param name="strResultado">Numero a convertir.</param>
        /// <returns>Retorno el numero convertido en binario</returns>
        public static string DecimalABinario(double dbResultado)
        {
            return DecimalABinario(dbResultado.ToString());
        }

        /// <summary>
        /// Metodo para validar binario
        /// </summary>
        /// <param name="binario">cadena a chequear.</param>
        /// <returns>Retorno true o false.</returns>
        private static bool EsBinario(string binario)
          {
              bool retorno = true;
              foreach (char item in binario)
              {
                  if (item != '0' && item != '1')
                  {
                      retorno = false;
                      break;
                  }
              }
              return retorno;
         }

        /*private static bool EsBinario(string binario)
        {
            bool retorno = true;
            for (int i = 0; i < binario.Length; i++)
            {
                if (binario[i] != '0' && binario[i] != '1')
                {
                    retorno = false;
                    break;
                }
            }

            return retorno;
        }*/
        #endregion

        #region Operaciones
        /// <summary>
        /// Operación suma
        /// </summary>
        /// <param name="numero1">Operador para la suma.</param>
        /// <param name="numero2">Operador para la suma.</param>
        /// <returns>Retorno resultado de la suma.</returns>
        public static double operator +(Numero numero1, Numero numero2)
        {
            double resultado = numero1.numero + numero2.numero;
            return resultado;
        }
        /// <summary>
        /// Operacion resta
        /// </summary>
        /// <param name="numero1">Operador para la división.</param>
        /// <param name="numero2">Operador para la división.</param>
        /// <returns>Retorno resultado de la </returns>        
        public static double operator -(Numero numero1, Numero numero2)
        {
            double resultado = numero1.numero - numero2.numero;
            return resultado;
        }
        /// <summary>
        /// Operacion division
        /// </summary>
        /// <param name="numero1">Operador para la división.</param>
        /// <param name="numero2">Operador para la división.</param>
        /// <returns>Retorno resultado de la división.</returns>
        public static double operator /(Numero numero1, Numero numero2)
        {
            double resultado;
            if (numero2.numero == 0)
                resultado = double.MinValue;
            else
                resultado = numero1.numero / numero2.numero;
            return resultado;
        }
        /// <summary>
        /// Operacion multiplicacion
        /// </summary>
        /// <param name="numero1">Operador para la multiplicación.</param>
        /// <param name="numero2">Operador para la multiplicación.</param>
        /// <returns>Retorno resultado de la multiplicación.</returns>
        public static double operator *(Numero numero1, Numero numero2)
        {
            double resultado = numero1.numero * numero2.numero;
            return resultado;
        }
        #endregion
    }
}