using System;
using System.ComponentModel;

namespace Calculator.Helper
{
    public static class ConvertionHelper
    {
        private static NullableConverter NullableConverter = null;

        [global::System.Diagnostics.DebuggerStepThrough()]
        public static T ConvertValue<T>(object value)
        {
            return ConvertValue<T>(value, default(T));
        }

        [global::System.Diagnostics.DebuggerStepThrough()]
        public static T ConvertValue<T>(object value, T defaultValue)
        {
            try
            {
                Type type = typeof(T);

                if (type.BaseType != null && type.BaseType.ToString() == "System.Enum")
                {
                    return (T)Enum.Parse(type, Convert.ToString(value));
                }
                else if (type is IConvertible) //Nullable olmayan değerler.
                {
                    return (T)Convert.ChangeType(value, type, new System.Globalization.CultureInfo("en-GB"));
                }
                else if (type.IsGenericType == true && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>))) //Nullable ise IConvertible değildir.
                {
                    NullableConverter = new NullableConverter(type);
                    type = NullableConverter.UnderlyingType;
                    return (T)Convert.ChangeType(value, type);
                }
                else if (value == null || (value.ToString() == ""))
                {
                    return defaultValue;
                }
                else
                {
                    return (T)Convert.ChangeType(value, type);
                }
            }
            catch
            {
                return defaultValue;
            }
        }
    }
}
