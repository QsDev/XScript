using System;


namespace QsScript {

    [Serializable]
    public sealed class Void : BasicConst
    {
        public static Void Value = new Void();
        private Void()
        {

        }
        public override BasicObject Div(BasicObject r)
        {
            return Value;
        }

        public override BasicObject Equal(BasicObject r)
        {
            return Value;
        }

        public override BasicObject Gte(BasicObject r)
        {
            return Value;
        }

        public override BasicObject Gth(BasicObject r)
        {
            return Value;
        }

        public override BasicObject IDiv(BasicObject r)
        {
            return Value;
        }

        public override bool IsNumbre()
        {
            return false;
        }

        public override BasicObject Like(BasicObject r)
        {
            return Value;
        }

        public override BasicObject Lte(BasicObject r)
        {
            return Value;
        }

        public override BasicObject Lth(BasicObject r)
        {
            return Value;
        }

        public override BasicObject Minus(BasicObject r)
        {
            return Value;
        }

        public override BasicObject Mod(BasicObject r)
        {
            return Value;
        }

        public override BasicObject Mul(BasicObject r)
        {
            return Value;
        }

        public override BasicObject Plus(BasicObject r)
        {
            return Value;
        }
    }


}