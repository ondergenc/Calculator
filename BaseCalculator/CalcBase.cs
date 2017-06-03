using System.Collections.Generic;


namespace Calculator.BaseCalculator
{
    public abstract class CalcBase : ICalc
    {
        public IList<Field> FormulaFieldList;
        public Field ResultField;

        public CalcBase()
        {
            FormulaFieldList = new List<Field>();
        }

        public abstract void Calculate(object Value);
        protected abstract void SetUp();

        public void AddFormulaField(Field argField)
        {
            FormulaFieldList.Add(argField);
        }

        public void InsertFormulaField(int argIndex, Field argField)
        {
            FormulaFieldList.Insert(argIndex, argField);
        }

        public void AddResultField(Field argResultField)
        {
            this.ResultField = argResultField;
            SetUp();
        }
    }
}
