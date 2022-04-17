using System;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        private string Numero
        {
            set
            {
                this.numero = ValidarOperando(value);
            }
        }

        #region Constructores

        public Operando() : this(0) { }

        public Operando(double numero)
        {
            this.numero = numero;
        }

        public Operando(string strNumero)
        {
            Numero = strNumero;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Comprobará que el valor recibido sea numérico. 
        /// Permite al usuario el ingreso de numeros con coma o con punto, ya que el programa trabajara de manera independiente a la configuración local del usuario.
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns> En caso de exito, retornara el numero recibido como double, de lo contrario 0. </returns>
        private double ValidarOperando(string strNumero)
        {
            double retorno = 0;

            if (!string.IsNullOrEmpty(strNumero) && double.TryParse(strNumero, out double numeroEntero))
            {
                retorno = Convert.ToDouble(strNumero, System.Globalization.CultureInfo.InvariantCulture);
            }

            return retorno;
        }

        /// <summary>
        /// Validará que la cadena de caracteres esté compuesta SOLAMENTE por caracteres '0' o '1'.
        /// </summary>
        /// <param name="binario"></param>
        /// <returns> TRUE si solo hay 1 o 0, y en el caso contrario, FALSE. </returns>

        private bool EsBinario(string binario)
        {
            bool retorno = false;

            if (!string.IsNullOrEmpty(binario))
            {
                foreach (char numero in binario)
                {
                    if (numero == '0' || numero == '1')
                    {
                        retorno = true;
                    }
                }
            }

            return retorno;
        }

        /// <summary>
        /// Validará que el numero ingresado sea un binario y luego lo convertirá a decimal, en caso de ser posible.
        /// </summary>
        /// <param name="binario"></param>
        /// <returns> El numero binario convertido a decimal en caso de exito, de lo contrario "Valor invalido". </returns>
        public string BinarioDecimal(string binario)
        {
            string retorno = "Valor invalido";
            int numeroEntero;

            if (EsBinario(binario))
            {
                numeroEntero = Convert.ToInt32(binario, 2);
                if (numeroEntero > 0)
                {
                    retorno = numeroEntero.ToString();
                }
            }

            return retorno;
        }

        /// <summary>
        /// Validará que el numero ingresado como string sea un decimal y luego lo convertirá a binario, en caso de ser posible.
        /// </summary>
        /// <param name="numero"></param>
        /// <returns> Retornara el numero binario como un string, en caso de exito. Caso contrario, retornara "Valor inválido". </returns>
        public string DecimalBinario(string numero)
        {
            string retorno = "Valor inválido";

            if (int.TryParse(numero, out int numeroEntero) && numeroEntero > 0)
            {
                retorno = Convert.ToString(numeroEntero, 2);
            }

            return retorno;
        }

        /// <summary>
        /// Validará que el numero ingresado como double sea un decimal y luego lo convertirá a binario, en caso de ser posible.
        /// </summary>
        /// <param name="numero"></param>
        /// <returns> Retornara el numero binario como un string, en caso de exito. Caso contrario, retornara "Valor inválido". </returns>
        public string DecimalBinario(double numero)
        {
            return DecimalBinario(numero.ToString());

        }

        #region Sobrecargas

        /// <summary>
        /// Realiza la suma entre dos objetos de tipo Operando
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns> Resultado de la operacion. </returns>
        public static double operator +(Operando n1, Operando n2)
        {
            double resultado = 0;

            if (n1 is not null && n2 is not null)
            {
                resultado = n1.numero + n2.numero;
            }

            return resultado;
        }

        /// <summary>
        /// Realiza la resta entre dos objetos de tipo Operando
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns> Resultado de la operacion. </returns>
        public static double operator -(Operando n1, Operando n2)
        {
            double resultado = 0;

            if (n1 is not null && n2 is not null)
            {
                resultado = n1.numero - n2.numero;
            }

            return resultado;
        }

        /// <summary>
        /// Realiza la multiplicacion entre dos objetos de tipo Operando
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns> Resultado de la operacion. </returns>
        public static double operator *(Operando n1, Operando n2)
        {
            double resultado = 0;

            if (n1 is not null && n2 is not null)
            {
                resultado = n1.numero * n2.numero;
            }

            return resultado;
        }

        /// <summary>
        /// Realiza la division entre dos objetos de tipo Operando
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns> Resultado de la operacion. </returns>
        public static double operator /(Operando n1, Operando n2)
        {
            double resultado = 0;

            if (n1 is not null && n2 is not null)
            {
                if (n2.numero != 0)
                {
                    resultado = n1.numero / n2.numero;
                }
                else
                {
                    resultado = double.MinValue;
                }
            }

            return resultado;
        }
        #endregion

        #endregion
    }
}
