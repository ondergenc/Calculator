using Calculator.Helper;

namespace Calculator.BaseCalculator.Formulas
{
    public class TotalFormulas : CalcBase
    {
        private void Field_Changed(object argOldValue, object argValue)
        {
            Calculate(argValue.To<int>(0) - argOldValue.To<int>());
        }

        public override void Calculate(object Value)
        {
            ResultField.Value = ResultField.Value.To<int>(0) + Value.To<int>(0);
        }

        protected override void SetUp()
        {
            foreach (var field in FormulaFieldList)
                field.Changed += Field_Changed;
        }
    }
}
