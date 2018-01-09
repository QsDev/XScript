using System;
namespace QsScript {

	[Serializable] public class Bool:BasicConst
    {
        public bool Value;
        public static implicit operator bool (Bool b)=>b.Value;
        public Bool()
        {
            Value = false;
        }
        public Bool(bool b)
        {
            Value = b;
        }

        public override  BasicObject Div( BasicObject r)
        {
            throw new NotImplementedException();
        }

        public override  BasicObject Equal( BasicObject r)
        {
            return new Bool(Value == r.ToNumbre<bool>());
        }

        public override  BasicObject Gte( BasicObject r)
        {
            var v = r.ToNumbre<bool>();
            return new Bool(Value & v || Value & !v);
        }

        public override  BasicObject Gth( BasicObject r)
        {
            return new Bool(!Value & r.ToNumbre<bool>());
        }

        public override  BasicObject IDiv( BasicObject r)
        {
            throw new NotImplementedException();
        }

        public override bool IsNumbre()
        {
            return false;
        }

        public override  BasicObject Lth( BasicObject r)
        {
            return new Bool(!Value & r.ToNumbre<bool>());
        }

        public override  BasicObject Lte( BasicObject r)
        {
            var v = r.ToNumbre<bool>();
            return new Bool(Value & v || !Value & v);
        }

        public override  BasicObject Like( BasicObject r)
        {
            var v = r.ToNumbre<bool>();
            return new Bool(Value == v);
        }

        public override  BasicObject Minus( BasicObject r)
        {
            return new Int(ToNumbre<int>() - r.ToNumbre<int>());
        }

        public override  BasicObject Mod( BasicObject r)
        {
            throw new NotImplementedException();
        }

        public override  BasicObject Mul( BasicObject r)
        {
            return new Bool(Value & r.ToNumbre<bool>());
        }

        public override  BasicObject Plus( BasicObject r)
        {
            return new Int(ToNumbre<int>() + r.ToNumbre<int>());
        }
    }

}