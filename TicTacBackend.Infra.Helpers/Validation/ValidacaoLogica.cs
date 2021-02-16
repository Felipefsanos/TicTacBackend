using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacBackend.Infra.Helpers.Validation
{
    public static class ValidacaoLogica
    {
        /// <summary>
        /// Testa se uma condição é falsa
        /// </summary>
        /// <typeparam name="TException">O Tipo da exceção a ser gerada</typeparam>
        /// <param name="condition">A condição a ser testada</param>
        /// <param name="message">A mensagem a ser passada para a exceção</param>
        public static void IsFalse<TException>(bool condition, string message) where TException : Exception
        {
            if (!condition)
            {
                throw (TException)Activator.CreateInstance(typeof(TException), message);
            }
        }

        /// <summary>
        /// Testa se uma condição é verdadeira
        /// </summary>
        /// <typeparam name="TException">O Tipo da exceção a ser gerada</typeparam>
        /// <param name="condition">A condição a ser testada</param>
        /// <param name="message">A mensagem a ser passada para a exceção</param>
        public static void IsTrue<TException>(bool condition, string message) where TException : Exception
        {
            if (condition)
            {
                throw (TException)Activator.CreateInstance(typeof(TException), message);
            }
        }
    }
}
