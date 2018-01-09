using System;
using QsScript.Help;

namespace QsScript {
	[Serializable]
	public class Object : Scop {
        public override bool IsCalculable => false;
        public Class Type;
		public Object() {
			
		}
		public override Function GetFunction(string name) {
			var f = Type?.GetFunction(name);
			if(f == null) {
				f = funcs.Get(name);
				if(f == null && isMultiScops)
					f = Base?.GetFunction(name);
			}
			return f ?? FThrow;
		}
		public override void Initialize() {
			if(Type == null)
				throw new TypeLoadException();
		}
		public override KeyPaireV GetField(string s) {
			return vars.Get(s);
		}
        public override string ToString()
        {

            System.Text.StringBuilder s = new System.Text.StringBuilder("(" + (Type?.Name ?? "Object") + " ){");
            for (int i = 0; i <= vars.index; i++)
            {
                var v = vars.values[i];
                s.AppendFormat("{0} = {1} ;", v.Name, v.Value);
            }
            return s.Append('}').ToString();
        }
    }
}
