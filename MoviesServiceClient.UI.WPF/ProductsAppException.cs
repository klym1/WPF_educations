using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MoviesServiceClient.WPF
{
    [Serializable]
    public class ProductsAppException : Exception
    {
        public ProductsAppException()
        {
        }

        public ProductsAppException(string message) : base(message)
        {
        }

        public ProductsAppException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ProductsAppException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
