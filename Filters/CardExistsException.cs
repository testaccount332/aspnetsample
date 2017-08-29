using System;

namespace aspapp2.Filters
{
    public class CardExistsException : Exception
    {
        
        public CardExistsException()
        {

        }

        public CardExistsException(string message) : base(message)
        {
            base.Data.Add("X-Request-Id", "yes");
        }

        public CardExistsException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}