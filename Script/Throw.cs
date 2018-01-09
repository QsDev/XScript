using System;


namespace QsScript {

    [Serializable]
    public class Throw : Expression
    {
        public override bool IsCalculable => true;
        public Expression Exeption;
        public Throw()
        {

        }
        public Throw(Expression ex)
        {
            Exeption = ex;
        }

        protected override BasicObject calc()
        {
            var l = Exeption.Calc();
            VM.SetThrow(l);
            return l;
        }
    }

}