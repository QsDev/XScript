using System;
using System.Collections.Generic;
using System.Xml.Serialization;
namespace QsScript {

	[Serializable]
    [XmlInclude(typeof(Error)), XmlInclude(typeof(Break)), XmlInclude(typeof(Return)), XmlInclude(typeof(Exception)), XmlInclude(typeof(Throw)), XmlInclude(typeof(Call)), XmlInclude(typeof(Void)), XmlInclude(typeof(BasicConst)), XmlInclude(typeof(Bool)), XmlInclude(typeof(Int)), XmlInclude(typeof(Real)), XmlInclude(typeof(Long)), XmlInclude(typeof(Currency)), XmlInclude(typeof(Date)), XmlInclude(typeof(Text)), XmlInclude(typeof(Bloc)), XmlInclude(typeof(Function)), XmlInclude(typeof(If)), XmlInclude(typeof(For)), XmlInclude(typeof(While)), XmlInclude(typeof(Do)), XmlInclude(typeof(Try)), XmlInclude(typeof(Dot)), XmlInclude(typeof(Scop)), XmlInclude(typeof(RefExpression)), XmlInclude(typeof(get)), XmlInclude(typeof(set)), XmlInclude(typeof(Parent)),XmlInclude(typeof(BasicObject)),XmlInclude(typeof(ByRef))]
	[XmlInclude(typeof(FieldPath)), XmlInclude(typeof(MethodPath)), XmlInclude(typeof(Field)), XmlInclude(typeof(Class)), XmlInclude(typeof(New))]
	[XmlInclude(typeof(Object)), XmlInclude(typeof(Import)), XmlInclude(typeof(Execute))]
	public  abstract partial class Expression
    {
        public abstract bool IsCalculable { get; }
        public Expression()
        {
        }

        public static bool IsContinue => VM.IsContinue;
        public static bool IsReturn => VM.IsReturn;

        public static bool IsBreak => VM.IsBreak;

        public static bool IsThrow => VM.IsThrow;

        public static int Swap(int i, int v, int length)
        {
            throw new NotImplementedException();
        }
        internal bool Apply( BasicObject @const)
        {
            throw new NotImplementedException();
        }
        public BasicObject Calc()
        {
            try {
                if (VM.JumperCode != 0)
                    return Void.Value;
                return calc();
            }
            catch (System.Exception e) {
                var scop = new RefExpression(this).Calc();
                VM.SetThrow(scop);
                return scop;
            }


        }
        protected abstract BasicObject calc();

        protected static void OpenScop( BasicObject cs) => VM.OpenScop(cs);
        protected static void OpenScop() => VM.OpenScop();
        protected static void CloseScop() => VM.CloseScop();
    }


    public partial class Expression
    {
		public static FieldPath @this = new FieldPath(null, "this");
		public static FieldPath @my = new FieldPath(null, "my");
		public static Dictionary<Type, Func<BasicObject, object>> IEO2CO = new Dictionary<Type, Func<BasicObject, object>>();
		public static Dictionary<Type, Func<object, BasicObject>> ICO2EO = new Dictionary<Type, Func<object, BasicObject>>();



		public BasicObject Const(object i) {
			if(i is bool)
				return new Bool((bool) i);
			if(i is int)
				return new Int((int) i);
			if(i is float)
				return new Real((float) i);
			if(i is long)
				return new Long((long) i);
			if(i is double)
				return new Currency((double) i);
			if(i is string)
				return new Text((string) i);
			if(i is DateTime)
				return new Date((DateTime) i);
			Func<object, BasicObject> c;
			if(i != null)
				if(ICO2EO.TryGetValue(i.GetType(), out c))
					return c(i);
			return Void.Value;

		}

		public object EO2BO(BasicObject i) {
			if(i is Bool)
				return ((Bool) i).Value;
			if(i is Int)
				return ((Int) i).Value;
			if(i is Real)
				return ((Real) i).Value;
			if(i is Long)
				return ((Long) i).Value;
			if(i is Currency)
				return ((Currency) i).Value;
			if(i is Text)
				return ((Text) i).Value;
			if(i is Date)
				return ((Date) i).Value;
			if(i == null || i == Void.Value)
				return null;

			Func<BasicObject, object> c;
			if(i != null)
				if(IEO2CO.TryGetValue(i.GetType(), out c))
					return c(i);
			return Void.Value;
		}

		public Bool Const(bool i)
        {
            return new Bool(i);
        }

        public Int Const(int i)
        {
            return new Int(i);
        }
        public Real Const(float i)
        {
            return new Real(i);
        }
        public Long Const(long i)
        {
            return new Long(i);
        }
        public Currency Const(double i)
        {
            return new Currency(i);
        }
        public Date Const(DateTime i)
        {
            return new Date(i);
        }
        public Text Const(string i)
        {
            return new Text(i);
        }

        public get get(string s) => new get(s);
        public set set(string s, Expression e) => new set(null, s, e);
        public set setTo(string s) => new set(null, s, this);
        public Call Call(string name, params Expression[] @params) => new Call(this, name, @params);

        public Function AsFunction(string name, params string[] @params) => new Function(name, @params, this);
        public Return AsReturn() => new Return(this);

        public Break AsBreak() => new Break(this);

        public Continue Continue() => new Continue();

        public ByRef AsByRef() => new ByRef(this);

        public Parent CalcWith(Operation op, Expression R) => new Parent(this, op, R);

        public Throw Throw(Expression e) => new Throw(e);
        public Throw AsThrow() => new Throw(this);

        public If AsIf(Expression condition) => new If(condition, this, null);

        public While AsWhile(Expression cond) => new While(cond, this);

        public Do AsDo(Expression cond) => new Do(cond, this);

        public For AsFor(Expression init, Expression test, Expression inc) => new For(init, test, inc, this);

        public Try AsTry() => new Try(this, null, null);

        public Bloc Bloc(params Expression[] expressions) => new Bloc().Add(expressions);

        public New New(string Type,params Expression[] types) => new New(Type, types);

        public Class @class(string name, string @base) => new Class(name, @base);

        public Field Field(string name, string type = null) => new Field(name, type);

        public Field Field(string name) => new Field(name, null);
        public Dot Dot(Expression e) => new Dot(e);
        public get get(params string[] fields)
        {
			if(fields.Length == 0)
				return new QsScript.get(my);
			var g = new get(fields[0]);
			for(int i = 1; i < fields.Length; i++)
				g = new QsScript.get(new FieldPath(g, fields[i]));
			return g;			
        }
        public Dot Dot(string e) => new Dot(get(e));
    }
}
