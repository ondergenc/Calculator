namespace Calculator.Helper
{
    public interface IBindableObject
    {
        void SetBindableValue(object argValue);
        object GetBindableValue();
    }
}
