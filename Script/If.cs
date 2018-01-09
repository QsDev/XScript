using System;


namespace QsScript {
    [Serializable]
    public class If : Expression
    {
        public override bool IsCalculable => true;
        public Expression condition, ifBody, elseBody;
        public If()
        {

        }
        public If(Expression test, Expression @true, Expression @false)
        {
            condition = test;
            ifBody = @true;
            elseBody = @false;
        }
        protected override BasicObject calc()
        {
            return (condition.Calc().ToNumbre<bool>() ? ifBody : elseBody).Calc();
        }
        public If Else(Expression falseBody)
        {
            elseBody = falseBody;
            return this;
        }
    }



}