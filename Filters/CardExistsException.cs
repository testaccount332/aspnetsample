using System;

namespace aspapp2.Filters
{
    public class CardExistsException : Exception
    {
        private string _message;

        public CardExistsException()
        {

        }
        
        public CardExistsException(string message) : base(message)
        {
          //  _message = base.Message;
        }

        public CardExistsException(string message, Exception innerException) : base(message, innerException)
        {
           // _message = message; 
        }
        
        //public override string Message => _message;
    }
}