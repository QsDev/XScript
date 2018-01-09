using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using QsScript.Help;

namespace QsScript {


	[Serializable]
	public class Class : Expression
    {
        public override bool IsCalculable => true;
        public readonly static List<Class> Classes = new List<Class>();
        public string Name;
        public string baseType;

        public List FMC = new List();

        [NonSerialized, XmlIgnore]
        public readonly ListF Constructors = new ListF();
        [NonSerialized, XmlIgnore]
        public readonly List<Field> Fields = new List<Field>();
        [NonSerialized, XmlIgnore]
        public readonly ListF Functions = new ListF();
		[NonSerialized, XmlIgnore]
		private bool initialized;

		public Class()
        {
        }
        public Class(string name, params Expression[] fields_methods)
        {
            Name = name;
            FMC.AddRange(fields_methods);
        }

        public Class(string name, string @base)
        {
            Name = name;
            baseType = @base;
        }
        public Class SetScop(params Expression [] exprs) { FMC.AddRange(exprs);return this; }
        protected override BasicObject calc()
        {
			if(initialized)
				return Void.Value;
            for (int i = 0; i <= FMC.index; i++)
                add(FMC.Get(i));
			Classes.Add(this);
			initialized = true;
            return Void.Value;
        }

        private void add(Expression fm)
        {
            if (fm is Field)
                Fields.Add((Field)fm);
            else if (fm is Function) {
                var f = ((Function)fm);
                (f.name == "constructor" ? Constructors : Functions).Add(f.name, f);
            }
            else if (fm is If || fm is For || fm is While || fm is Do || fm is Class || fm is Bloc || fm is Call || fm is get || fm is Try)
                add(fm.Calc());
            else fm.Calc();
        }

        public Class SetField(string name, string type)
        {
            var field = new Field(name, type);
            FMC.Add(field); //Fields.Add(field);
            return this;
        }
        public Class SetFunction(Expression code, string asName, params string[] @params)
        {
            Function f = new Function(asName, @params, code);
            FMC.Add(f);
            return this;
        }
        public Class SetInstructions(params Expression[] insts)
        {
            FMC.AddRange(insts);
            return this;
        }

        public Function GetConstructor(int l)
        {
            var values = Constructors.values;
            for (int i = 0; i <= Constructors.index; i++) {
                var c = (Function)Constructors.Get(i).Value;
                if (l == c.@params.Length)
                    return c;
            }
            return null;
        }
        public static Class GetType(string s)
        {
            foreach (var c in Classes) 
                if (c.Name == s) return c;
            return null;
        }

		public Function GetFunction(string name) => Functions.Get(name);

    }


}