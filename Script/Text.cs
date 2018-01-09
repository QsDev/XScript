using System;


namespace QsScript {

    [Serializable] public class Text : BasicConst
    {
        public string Value;
        public static Text Null = new Text(null);
        public static implicit operator string(Text b) => b.Value;
        public Text()
        {
            Value = string.Empty;
        }
        public Text(string b)
        {
            Value = b;
        }
        public override  BasicObject Div( BasicObject r)
        {
            throw new NotImplementedException();
        }

        public override  BasicObject Equal( BasicObject r)
        {
            if (r is Text)
                return new Bool(string.Compare(((Text)r).Value, Value, true) == 0);
            else if (r != null)
                return new Bool(string.Compare(r.ToString(), Value, true) == 0);
            return new Bool(false);
        }

        public override  BasicObject Gte( BasicObject r)
        {
            throw new NotImplementedException();
        }

        public override  BasicObject Gth( BasicObject r)
        {
            if (!r.IsNumbre()) return this;
            int i = r.ToNumbre<int>();
            var v = Value ?? "";
            i = Expression.Swap(i, 0, v.Length);
            return new Text(v.Substring(i));
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

            if (!r.IsNumbre()) return this;
            int i = r.ToNumbre<int>();
            var v = Value ?? "";
            i = Expression.Swap(i, 0, v.Length);
            return new Text(v.Substring(0, i));
        }

        public override  BasicObject Lte( BasicObject r)
        {
            throw new NotImplementedException();
        }

        public override  BasicObject Like( BasicObject r)
        {
            System.Text.RegularExpressions.Regex e = new System.Text.RegularExpressions.Regex(r.ToString());
            return new Bool(e.Match(Value).Success);
        }

        public override  BasicObject Minus( BasicObject r)
        {
            throw new NotImplementedException();
        }

        public override  BasicObject Mod( BasicObject r)
        {
            throw new NotImplementedException();
        }

        public override  BasicObject Mul( BasicObject r)
        {
            throw new NotImplementedException();
        }

        public override  BasicObject Plus( BasicObject r)
        {
            return new Text(Value + r.ToString());
        }
    }

}