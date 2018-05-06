using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Exceptions
{
    class AccountAlreadyExistsException : Exception
    {
        public AccountAlreadyExistsException()
        {
        }

        public AccountAlreadyExistsException(string message) : base(message)
        {
        }

        public AccountAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public AccountAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
