using System;
using System.Linq;
using Calculator.Helper;

namespace Calculator.BaseCalculator
{
    public delegate void ChangedDelegate(object argOldValue, object argValue);
    public class Field : IBindableObject
    {
        public event ChangedDelegate Changed;

        public Field(object value)
        {
        }

        private object _value;

        private bool dontFire;
        public bool DontFire
        {
            get { return dontFire; }
            set { dontFire = value; }
        }


        public object Value
        {
            get { return _value; }
            set
            {
                if (value == null)
                    return;
                object tempValue = _value;
                _value = value;
                if (!dontFire && Changed != null && ((IsSimpleType(_value.GetType()) && _value != tempValue) || !IsSimpleType(_value.GetType())))
                {
                    Changed(tempValue, _value);
                }
            }
        }

        public void SetBindableValue(object argValue)
        {
            this.Value = argValue;
        }

        public static bool IsSimpleType(Type type)
        {
            return
                type.IsPrimitive ||
                new Type[] {
            typeof(Enum),
            typeof(String),
            typeof(Decimal),
            typeof(DateTime),
            typeof(DateTimeOffset),
            typeof(TimeSpan),
            typeof(Guid)
                }.Contains(type) ||
                Convert.GetTypeCode(type) != TypeCode.Object ||
                (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>) && IsSimpleType(type.GetGenericArguments()[0]))
                ;
        }

        public object GetBindableValue()
        {
            return this.Value;
        }
    }
}
