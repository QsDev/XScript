using System;


namespace QsScript {

	[Serializable]
    public class ByRef : Expression
    {
        public override bool IsCalculable => true;
        public Expression Value;
        public ByRef(Expression value)
        {
            Value = value;
        }
        public ByRef()
        {

        }

        protected override BasicObject calc()
        {
            return new RefExpression(Value ?? Void.Value);
        }
    }


}