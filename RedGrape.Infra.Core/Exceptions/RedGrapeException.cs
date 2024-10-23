using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedGrape.Infra.Core.Exceptions
{
    public class RedGrapeException : Exception
    {
        public RedGrapeException(int errorCode) : base()
        {
            this.ErrorCode = errorCode;
            this.Guid = Guid.NewGuid();
        }

        public RedGrapeException(string message, int errorCode) : base(message)
        {
            this.ErrorCode = errorCode;
            this.Guid = Guid.NewGuid();
        }

        public RedGrapeException(string message, Exception innerException, int errorCode)
            : base(message, innerException)
        {
            this.ErrorCode = errorCode;
            this.Guid = Guid.NewGuid();
        }

        public int ErrorCode { get; private set; }
        public Guid Guid { get; private set; }
    }
}
