using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TicTacToe
{
    [Serializable]
    public class TicTacToeException : Exception
    {
        public TicTacToeException()
        {
        }

        public TicTacToeException(string message) : base(message)
        {
        }

        public TicTacToeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TicTacToeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
