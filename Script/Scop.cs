using System;
using QsScript.Help;

namespace QsScript {

	public partial class Scop {

		#region Field Getter Setter
		public override BasicObject GetData(string s) => GetField(s)?.Value;

		public override BasicObject GetData(int s) => GetField(s)?.Value;

		public override void SetData(string s, BasicObject v) {

			var kp = GetField(s);
			if(kp != null)
				kp.Value = v;
            else
                vars.Add(s, v);
        }

		public override void SetData(int s, BasicObject v) {
			var kp = GetField(s);
			if(kp != null)
				kp.Value = v;
            
		}

		#endregion
	}
	[Serializable]
	public partial class Scop : BasicObject {
        public override bool IsCalculable => true;
        public ListV vars = new ListV();
		public ListF funcs = new ListF();
		public BasicObject Base;
		public bool isMultiScops = false;
        public override string ToString()
        {
            System.Text.StringBuilder s = new System.Text.StringBuilder("("+"Scop"+"){");
            for (int i = 0; i <= vars.index; i++)
            {
                var v = vars.values[i];
                s.AppendFormat("{0} = {1} ;", v.Name, v.Value);
            }
            return s.Append('}').ToString();
        }
        public Scop() {

		}
		public Scop(BasicObject @this) {
			Base = @this;
		}
		public BasicObject This { get { return Base; } }

		public override void Initialize() { //TODO : simplify;
			this ["this"] = This;
			this["my"] = this;
		}
		public override KeyPaireV GetField(string s) {
			return vars.Get(s) ?? Base?.GetField(s);
		}
		public new BasicObject this[string index] {
			get {
				return GetField(index)?.Value ?? Void.Value;
			}
			set {
				var l = GetField(index);
				if(l == null)
					vars.Add(index, value);
				else
					l.Value = value;
			}
		}


		public override void Add(Function function) {
			funcs.Add(function.name, function);
		}

		public override Function GetFunction(string name) {
			Function f = funcs.Get(name);
			if(f == null && isMultiScops)
				f = Base?.GetFunction(name);

			return f == null ? FThrow : f;
		}
		public static Function FThrow = new Function("throw", new string[0], new Throw());

		#region Help

		internal override void Dispose() {
			funcs.Clear();
			Base = null;
			vars.Clear();
		}

		protected sealed override BasicObject calc() {
			return this;
		}
		#endregion

	}


}