using System;


namespace QsScript {

	[Serializable]
    public class Do : Expression
    {
        public override bool IsCalculable => true;
        public Expression body;
        public Expression test;
        public Do()
        {

        }
        public Do(Expression test, Expression body)
        {
            this.test = test;
            this.body = body;
        }
        protected override BasicObject calc()
        {
            BasicObject r = Void.Value;
            do
            {
                r = body.Calc();
                if (IsBreak) return VM.StopBreak();
                if (IsContinue) VM.StopContinue();
                if (IsReturn) return r;
            }
            while (test.Calc().ToNumbre<bool>());
            return r;
        }
    }



}