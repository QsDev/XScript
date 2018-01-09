using System;


namespace QsScript {

    [Serializable]
    public class Real : BasicConst
    {
        public float Value;
        public Real()
        {
            Value = 0f;
        }
        public Real(float v)
        {
            Value = v;
        }

        public override BasicObject Div(BasicObject r)
        {
            if (!r.IsNumbre()) throw null;
            switch (r.GetPower())
            {
                case 0:
                    var c = (Bool)r;
                    if (c.Value) return this;
                    else return new Real(float.PositiveInfinity);
                case 1:
                    return new Real(Value / r.ToNumbre<float>());
                case 2:
                    return new Real(Value / r.ToNumbre<float>());
                case 3:
                    return new Currency(Value / r.ToNumbre<double>());
                case 4:
                    return new Currency(Value / r.ToNumbre<long>());
                case 5:
                    return new Currency(Value / r.ToNumbre<double>());
            }
            return new Int(0);
        }

        public override BasicObject Equal(BasicObject r)
        {
            if (!r.IsNumbre()) throw null;
            switch (r.GetPower())
            {
                case 0:
                    return new Bool(Value == r.ToNumbre<float>());
                case 1:
                    return new Bool(Value == r.ToNumbre<float>());
                case 2:
                    return new Bool(Value == r.ToNumbre<float>());
                case 3:
                    return new Bool(Value == r.ToNumbre<long>());
                case 4:
                    return new Bool(Value == r.ToNumbre<long>());
                case 5:
                    return new Bool(Value == r.ToNumbre<double>());
            }
            return new Bool(false);
        }

        public override BasicObject Gte(BasicObject r)
        {

            if (!r.IsNumbre()) throw null;
            switch (r.GetPower())
            {
                case 0:
                    return new Bool(Value >= r.ToNumbre<int>());
                case 1:
                    return new Bool(Value >= r.ToNumbre<int>());
                case 2:
                    return new Bool(Value >= r.ToNumbre<float>());
                case 3:
                    return new Bool(Value >= r.ToNumbre<long>());
                case 4:
                    return new Bool(Value >= r.ToNumbre<long>());
                case 5:
                    return new Bool(Value >= r.ToNumbre<double>());
            }
            return new Bool(false);
        }

        public override BasicObject Gth(BasicObject r)
        {
            if (!r.IsNumbre()) throw null;
            switch (r.GetPower())
            {
                case 0:
                    return new Bool(Value > r.ToNumbre<int>());
                case 1:
                    return new Bool(Value > r.ToNumbre<int>());
                case 2:
                    return new Bool(Value > r.ToNumbre<float>());
                case 3:
                    return new Bool(Value > r.ToNumbre<long>());
                case 4:
                    return new Bool(Value > r.ToNumbre<long>());
                case 5:
                    return new Bool(Value > r.ToNumbre<double>());
            }
            return new Bool(false);
        }

        public override BasicObject IDiv(BasicObject r)
        {

            if (!r.IsNumbre()) throw null;
            switch (r.GetPower())
            {
                case 0:
                    return new Int((int)(Value / r.ToNumbre<int>()));
                case 1:
                    return new Int((int)(Value / r.ToNumbre<int>()));
                case 2:
                    return new Int(Convert.ToInt32(Value / r.ToNumbre<float>()));
                case 3:
                    return new Int(Convert.ToInt32(Value / r.ToNumbre<long>()));
                case 4:
                    return new Int(Convert.ToInt32(Value / r.ToNumbre<long>()));
                case 5:
                    return new Int(Convert.ToInt32(Value / r.ToNumbre<double>()));
            }
            return new Error();
        }

        public override bool IsNumbre()
        {
            return true;
        }

        public override BasicObject Lth(BasicObject r)
        {

            if (!r.IsNumbre()) throw null;
            switch (r.GetPower())
            {
                case 0:
                    return new Bool(Value <= r.ToNumbre<int>());
                case 1:
                    return new Bool(Value <= r.ToNumbre<int>());
                case 2:
                    return new Bool(Value <= r.ToNumbre<float>());
                case 3:
                    return new Bool(Value <= r.ToNumbre<long>());
                case 4:
                    return new Bool(Value <= r.ToNumbre<long>());
                case 5:
                    return new Bool(Value <= r.ToNumbre<double>());
            }
            return new Bool(false);
        }

        public override BasicObject Lte(BasicObject r)
        {
            if (!r.IsNumbre()) throw null;
            switch (r.GetPower())
            {
                case 0:
                    return new Bool(Value <= r.ToNumbre<int>());
                case 1:
                    return new Bool(Value <= r.ToNumbre<int>());
                case 2:
                    return new Bool(Value <= r.ToNumbre<float>());
                case 3:
                    return new Bool(Value <= r.ToNumbre<long>());
                case 4:
                    return new Bool(Value <= r.ToNumbre<long>());
                case 5:
                    return new Bool(Value <= r.ToNumbre<double>());
            }
            return new Bool(false);
        }

        public override BasicObject Like(BasicObject r)
        {
            return Equal(r);
        }

        public override BasicObject Minus(BasicObject r)
        {
            if (!r.IsNumbre()) throw null;
            switch (r.GetPower())
            {
                case 0:
                    return new Real(Value - r.ToNumbre<int>());
                case 1:
                    return new Real(Value - r.ToNumbre<int>());
                case 2:
                    return new Real(Value - r.ToNumbre<float>());
                case 3:
                    return new Currency((double)Value - r.ToNumbre<long>());
                case 4:
                    return new Currency((double)Value - r.ToNumbre<long>());
                case 5:
                    return new Currency(Value - r.ToNumbre<double>());
            }
            return new Int(0);
        }

        public override BasicObject Mod(BasicObject r)
        {
            if (!r.IsNumbre()) throw null;
            switch (r.GetPower())
            {
                case 0:
                    return new Real(Value % r.ToNumbre<int>());
                case 1:
                    return new Real(Value % r.ToNumbre<int>());
                case 2:
                    return new Real(Value % r.ToNumbre<float>());
                case 3:
                    return new Currency(Value % r.ToNumbre<long>());
                case 4:
                    return new Currency(Value % r.ToNumbre<long>());
                case 5:
                    return new Currency(Value % r.ToNumbre<double>());
            }
            return new Int(0);
        }

        public override BasicObject Mul(BasicObject r)
        {
            if (!r.IsNumbre()) throw null;

            switch (r.GetPower())
            {
                case 0:
                    return new Real(Value * r.ToNumbre<int>());
                case 1:
                    return new Real(Value * r.ToNumbre<int>());
                case 2:
                    return new Real(Value * r.ToNumbre<float>());
                case 3:
                    return new Currency(Value * r.ToNumbre<long>());
                case 4:
                    return new Currency(Value * r.ToNumbre<long>());
                case 5:
                    return new Currency(Value * r.ToNumbre<double>());
            }
            return new Int(0);
        }

        public override BasicObject Plus(BasicObject r)
        {
            if (!r.IsNumbre()) throw null;
            switch (r.GetPower())
            {
                case 0:
                    return new Real(Value + r.ToNumbre<int>());
                case 1:
                    return new Real(Value + r.ToNumbre<int>());
                case 2:
                    return new Real(Value + r.ToNumbre<float>());
                case 3:
                    return new Currency(Value + r.ToNumbre<long>());
                case 4:
                    return new Currency(Value + r.ToNumbre<long>());
                case 5:
                    return new Currency(Value + r.ToNumbre<double>());
            }
            return new Int(0);
        }
    }  

}