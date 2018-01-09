using System;
using QsScript.Help;

namespace QsScript {


	public abstract partial class BasicObject {
		public BasicObject this[int index] { get { return GetData(index); } set { SetData(index, value); } }
		public BasicObject this[string name]
        {
            get { return GetData(name); }
            set
            {

                SetData(name, value);
            }
        }
        #region Field Getter Setter
        public abstract BasicObject GetData(string s);
		public abstract BasicObject GetData(int s);

		public abstract void SetData(string s, BasicObject v);

		public abstract void SetData(int s, BasicObject v);

		public virtual KeyPaireV GetField(string name) => null;
		public virtual KeyPaireV GetField(int index) => null;

		#endregion
	}

	[Serializable]
	public abstract partial class BasicObject:Expression
    {
        public abstract Function GetFunction(string name);
        public abstract void Add(Function function);


        public virtual bool IsNumbre() => false;
        public T ToNumbre<T>()
        {
            if (typeof(T) == typeof(int)) {
                if (this is Int) return (T)(object)((Int)this).Value;
                if (this is Real) return (T)(object)Convert.ToInt32(((Real)this).Value);
                if (this is Currency) return (T)(object)Convert.ToInt32(((Currency)this).Value);
                if (this is Bool) return (T)(object)Convert.ToInt32(((Bool)this).Value);
            }
            else if (typeof(T) == typeof(float)) {
                if (this is Int) return (T)(object)Convert.ToSingle(((Real)this).Value);
                if (this is Real) return (T)(object)Convert.ToSingle(((Real)this).Value);
                if (this is Currency) return (T)(object)Convert.ToSingle(((Currency)this).Value);
                if (this is Bool) return (T)(object)Convert.ToSingle(((Bool)this).Value);
            }
            else if (typeof(T) == typeof(double)) {
                if (this is Int) return (T)(object)Convert.ToDouble(((Real)this).Value);
                if (this is Real) return (T)(object)Convert.ToDouble(((Real)this).Value);
                if (this is Currency) return (T)(object)Convert.ToDouble(((Currency)this).Value);
                if (this is Bool) return (T)(object)Convert.ToDouble(((Bool)this).Value);
            }
            else if (typeof(T) == typeof(bool)) {
                if (this is Int) return (T)(object)Convert.ToBoolean(((Real)this).Value);
                if (this is Real) return (T)(object)Convert.ToBoolean(((Real)this).Value);
                if (this is Currency) return (T)(object)Convert.ToBoolean(((Currency)this).Value);
                if (this is Bool) return (T)(object)Convert.ToBoolean(((Bool)this).Value);
            }
            else if (typeof(T) == typeof(DateTime)) {
                if (this is Int) return (T)(object)Convert.ToDateTime(((Real)this).Value);
                if (this is Real) return (T)(object)Convert.ToDateTime(((Real)this).Value);
                if (this is Currency) return (T)(object)Convert.ToDateTime(((Currency)this).Value);
                if (this is Bool) return (T)(object)Convert.ToDateTime(((Bool)this).Value);
            }
            return default(T);
        }

        public int GetPower()
        {
            if (this is Bool) return 0;
            if (this is Int) return 1;
            if (this is Real) return 2;
            if (this is Long) return 3;
            if (this is Date) return 4;
            if (this is Currency) return 5;
            if (this is Text) return -1;
            return int.MinValue;
        }
        internal virtual void Dispose()
        {
        }
        public virtual void Initialize() { }       

        #region Operateurs
        public BasicObject Calc(Operation op, BasicObject r)
        {
            if (r is Error) return r;
            switch (op) {
                case Operation.Eq:
                    return Equal(r);
                case Operation.plus:
                    return Plus(r);
                case Operation.minus:
                    return Minus(r);
                case Operation.mult:
                    return Mul(r);
                case Operation.div:
                    return Div(r);
                case Operation.idiv:
                    return IDiv(r);
                case Operation.mod:
                    return Mod(r);
                case Operation.Like:
                    return Like(r);
                case Operation.Gth:
                    return Gth(r);
                case Operation.Lth:
                    return Lth(r);
                case Operation.Lte:
                    return Lte(r);
                case Operation.Gte:
                    return Gte(r);
                default: throw null;
            }
        }

        public virtual BasicObject Gte(BasicObject r) { return Void.Value; }
        public virtual BasicObject Lth(BasicObject r) { return Void.Value; }
        public virtual BasicObject Lte(BasicObject r) { return Void.Value; }
        public virtual BasicObject Gth(BasicObject r) { return Void.Value; }
        public virtual BasicObject Like(BasicObject r) { return Void.Value; }
        public virtual BasicObject Mod(BasicObject r) { return Void.Value; }
        public virtual BasicObject IDiv(BasicObject r) { return Void.Value; }
        public virtual BasicObject Div(BasicObject r) { return Void.Value; }

        public virtual BasicObject Mul(BasicObject r) { return Void.Value; }

        public virtual BasicObject Minus(BasicObject r) { return Void.Value; }

        public virtual BasicObject Plus(BasicObject r) { return Void.Value; }

        public virtual BasicObject Equal(BasicObject r) { return Void.Value; }
        #endregion

    }

}