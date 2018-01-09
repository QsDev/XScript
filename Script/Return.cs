using System;


namespace QsScript {
    [Serializable]
    public class Return : Expression
    {
        public override bool IsCalculable => true;
        public Expression returnValue;
        public Return()
        {

        }
        public Return(Expression exp)
        {
            this.returnValue = exp;
        }

        protected override BasicObject calc()
        {
            var Value = returnValue.Calc();
            VM.SetReturn(Value);
            return Value;
        }
    }


}