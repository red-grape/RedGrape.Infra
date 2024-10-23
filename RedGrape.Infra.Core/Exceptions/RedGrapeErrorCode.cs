using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedGrape.Infra.Core.Exceptions
{
    public class RedGrapeErrorCode
    {
        public const int unknown = 1000;
        public const int is_null = 1001;
        public const int string_small_than = 1002;
        public const int not_found_encryptor_config = 1003;
    }
}
