using System;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Realiza un calculo, segun el operando ingresado
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns>Retorna el resultado de la operacion</returns>
         public static double Operar(Operando num1, Operando num2, char operador)
        {
            double resultado;

            switch (ValidarOperador(operador))
            {
                case '-':
                    resultado = num1 - num2;
                    break;
                case '*':
                    resultado = num1 * num2;
                    break;
                case '/':
                    resultado = num1 / num2;
                    break;
                default:
                    resultado = num1 + num2;
                    break;
            }
            return resultado;
        }

        /// <summary>
        /// Valida el operador ingresado
        /// </summary>
        /// <param name="operador"></param>
        /// <returns>En caso de que sea "+, -, * o /", retorna el operador ingresado. Si no es ninguno de estos, retorna "+".</returns>
        private static char ValidarOperador(char operador)
        {
            char retorno = '+';

            if(operador == '+' || operador == '-' || operador == '*' || operador == '/')
            {
                retorno = operador;
            }

            return retorno;
        }

       
    }
}
