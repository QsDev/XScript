using System;


namespace QsScript {

    [Serializable]
    public class RefExpression : BasicConst
    {
        public override bool IsCalculable => true;
        public BasicObject Scop;
        public Expression Value;
        public RefExpression()
        {
        }
        public RefExpression(Expression value = null)
        {
            Scop = VM.CurrentScop;
            Value = value;
        }
        protected override BasicObject calc()
        {
            VM.SetScop(Scop);
            var @const = Value.Calc();
            VM.CloseScop(true);
            return @const;
        }
    }
  

}