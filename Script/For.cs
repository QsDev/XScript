using System;


namespace QsScript {

	[Serializable]
    public class For : Expression
    {
        public override bool IsCalculable => true;
        public Expression body;
        public Expression inc;
        public Expression init;
        public Expression test;
        public For()
        {

        }
        public For(Expression init, Expression test, Expression inc, Expression body)
        {
            this.init = init;
            this.test = test;
            this.inc = inc;
            this.body = body;
        }
        protected override BasicObject calc()
        {
            init.Calc();
            BasicObject r = Void.Value;
            while (test.Calc().ToNumbre<bool>())
            {
                r = body.Calc();
                if (IsBreak) VM.StopBreak();
                if (IsReturn) return r;
                if (IsContinue) VM.StopContinue();
                inc.Calc();
            }
            return r;
        }
    }


}