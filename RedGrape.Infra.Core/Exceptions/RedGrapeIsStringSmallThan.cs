using Microsoft.VisualBasic;

namespace RedGrape.Infra.Core.Exceptions
{
    public class RedGrapeIsStringSmallThan : RedGrapeException
    {
        public RedGrapeIsStringSmallThan(string propName) : base($"{propName} is null", RedGrapeErrorCode.is_null)
        {
        }

        public RedGrapeIsStringSmallThan(string propName,Exception innerException)
            : base($"{propName} is null", innerException, RedGrapeErrorCode.is_null)
        {
        }
    }
}