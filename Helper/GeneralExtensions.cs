using System.Diagnostics;

namespace Calculator.Helper
{
    public static class GeneralExtensions
    {
        [DebuggerStepThrough]
        public static T To<T>(this object value)
        {
            return GeneralExtensions.To<T>(value, default(T));
        }

        [DebuggerStepThrough]
        public static T To<T>(this object value, T defaultValue)
        {
            return ConvertionHelper.ConvertValue<T>(value, defaultValue);
        }
    }
}
