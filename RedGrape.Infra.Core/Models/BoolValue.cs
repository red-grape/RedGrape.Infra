using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RedGrape.Infra.Core.Models
{
    public class BoolValue : Value<bool>
    {
        private readonly bool _value;

        protected BoolValue(bool value) : base(value)
        {
            _value = value;
        }
        protected BoolValue(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            var value = info.GetValue("values", typeof(bool));
            _value = value != null && (bool)value;
        }

        public static bool operator ==(BoolValue left, BoolValue right) => AreEqual(left, right);
        public static bool operator !=(BoolValue left, BoolValue right) => !AreEqual(left, right);
        public static bool operator ==(BoolValue left, bool right) => AreEqual(left, right);
        public static bool operator !=(BoolValue left, bool right) => !AreEqual(left, right);
        public static bool operator ==(bool right, BoolValue left) => AreEqual(left, right);
        public static bool operator !=(bool right, BoolValue left) => !AreEqual(left, right);

        private static bool AreEqual(BoolValue a, BoolValue b) => (object.Equals(a, null) && object.Equals(b, null))
                                                                    || (!object.Equals(a, null) && !object.Equals(b, null) && a.Equals(b));

        private static bool AreEqual(BoolValue a, bool b) => !object.Equals(a, null) && a._value == b;

        public override bool Equals(object obj)
        {
            return obj != null
                   && this.GetType() == obj.GetType()
                   && obj is BoolValue boolValue
                   && boolValue._value == _value;
        }

        public override int GetHashCode()
        {
            var hashCode = 1929208869;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + _value.GetHashCode();
            return hashCode;
        }
        public static implicit operator bool(BoolValue value)
        {
            if (object.Equals(value, null))
            {
                throw new ArgumentNullException(nameof(value), "Cannot convert NULL to a boolean value.");
            }

            return value._value;
        }

        public virtual bool ToBool() => _value;

    }
}
