using System;
namespace QsScript {

	[Serializable]
    public class Date : BasicConst
    {
        public DateTime Value;
        public Date()
        {
            Value = DateTime.Now;
        }
        public Date(DateTime d)
        {
            Value = d;
        }

        public override BasicObject Div(BasicObject r)
        {
            throw new NotImplementedException();
        }

        public override BasicObject Equal(BasicObject r)
        {
            throw new NotImplementedException();
        }

        public override BasicObject Gte(BasicObject r)
        {
            throw new NotImplementedException();
        }

        public override BasicObject Gth(BasicObject r)
        {
            throw new NotImplementedException();
        }

        public override BasicObject IDiv(BasicObject r)
        {
            throw new NotImplementedException();
        }

        public override bool IsNumbre()
        {
            throw new NotImplementedException();
        }

        public override BasicObject Lth(BasicObject r)
        {
            throw new NotImplementedException();
        }

        public override BasicObject Lte(BasicObject r)
        {
            throw new NotImplementedException();
        }

        public override BasicObject Like(BasicObject r)
        {
            throw new NotImplementedException();
        }

        public override BasicObject Minus(BasicObject r)
        {
            throw new NotImplementedException();
        }

        public override BasicObject Mod(BasicObject r)
        {
            throw new NotImplementedException();
        }

        public override BasicObject Mul(BasicObject r)
        {
            throw new NotImplementedException();
        }

        public override BasicObject Plus(BasicObject r)
        {
            throw new NotImplementedException();
        }
    }

}