using RedGrape.Infra.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedGrape.Infra.Core.Utils
{
    public class ThrowHelper
    {
        public static void ThrowIfNull(object obj)
        {
            if (obj == null) throw new RedGrapeIsNullException();
        }

        public static void ThrowIfNull(object obj, string msg)
        {
            if (obj == null) throw new RedGrapeIsNullException(msg);
        }

        public static void ThrowIfSmallThan(string propName ,string str , int length)
        {
            ThrowHelper.ThrowIfNull(str);

            if (str.Length < length)
                throw new RedGrapeIsStringSmallThan(propName);
        }

        public static void ThrowIf(Func<bool> validate , string msg)
        {
            if (validate.Invoke() == false)
                throw new RedGrapeException("msg", RedGrapeErrorCode.unknown);
        }

        public static void ThrowIf(Func<bool> validate, string msg , int redGrapeErrorCode)
        {
            if (validate.Invoke() == false)
                throw new RedGrapeException(msg, redGrapeErrorCode);
        }
    }
}
