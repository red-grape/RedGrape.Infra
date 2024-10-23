using Microsoft.VisualBasic;

namespace RedGrape.Infra.Core.Exceptions
{
    public class RedGrapeIsNullException : RedGrapeException
    {
        public RedGrapeIsNullException() : base("value is null", RedGrapeErrorCode.is_null)
        {
        }

        public RedGrapeIsNullException(string msg) : base(msg, RedGrapeErrorCode.is_null)
        {
        }

        public RedGrapeIsNullException(Exception innerException)
            : base("value is null", innerException, RedGrapeErrorCode.is_null)
        {
        }

        public RedGrapeIsNullException(string msg , Exception innerException)
            : base(msg, innerException, RedGrapeErrorCode.is_null)
        {
        }
    }
}