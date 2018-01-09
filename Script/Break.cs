using System;
namespace QsScript {


	[Serializable]
    public class Break : Expression
    {
        public override bool IsCalculable => true;
        public Expression exp;
        public Break()
        {

        }
        public Break(Expression exp)
        {
            this.exp = exp;
        }
        protected override BasicObject calc()
        {
            var Value = exp.Calc();
            VM.SetBreak(Value);
            return Value;
        }
    }
}