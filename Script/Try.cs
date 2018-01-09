using System;


namespace QsScript {
    [Serializable]
    public class Try : Expression
    {
        public override bool IsCalculable => true;
        public Expression TryCode;
        public Expression CatchCode;
        public Expression FinalyCode;
        public Try()
        {

        }
        public Try(Expression body, Expression @catch, Expression finaly)
        {
            TryCode = body;
            CatchCode = @catch;
            FinalyCode = finaly;
        }
        protected override BasicObject calc()
        {
            BasicObject r;
            r = TryCode.Calc();
            if (IsThrow)
            {
                r = VM.StopThrow();
                return CatchCode.Calc();
            }
            return FinalyCode == null ? r : FinalyCode.Calc();
        }
        public Try Catch(Expression @catch)
        {
            this.CatchCode = @catch;
            return this;
        }
        public Try Finaly(Expression finaly)
        {
            FinalyCode = finaly;
            return this;
        }
    }



}