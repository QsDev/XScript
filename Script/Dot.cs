using System;
using QsScript.Help;

namespace QsScript {

	[Serializable]
	public class Dot : Expression {
        public override bool IsCalculable => true;
        public List exps = new List();
		public Dot() {
		}
		public Dot(params Expression[] dots) {
			exps.AddRange(dots);
		}

		/// <summary>
		/// Revolutionel Code !!!!!!!!!!!!!!!!!!!!!!!!!
		/// </summary>
		/// <returns></returns>
		protected override BasicObject calc() {
			var cs = VM.CurrentScop;
			for(int i = 0; i <= exps.index; i++) {
				var d = exps.Get(i);
				if(d is BasicConst) {
					var c = (BasicConst) d;
					if(c.IsNumbre())
						cs = cs[c.ToNumbre<int>().ToString()];
					else if(c is Text)
						cs = cs[((Text) c).Value];
				}
				if(d is get) {
					var g = (get) d;
					cs = cs[((get) d).Path.Name];
				} else if(d is set) {
					var s = (set) d;
					cs[s.Path.Name] = s.Value.Calc();
				} else if(d is Call) {
					var c = ((Call) d);
					cs = QsScript.Call.call(cs, c.Method.Name, c.Params);
				} else if(d is Bloc) {
					VM. OpenScop(cs);
					cs = d.Calc();
					VM.CloseScop(true);
				} else if(d is Dot)
					cs = d.Calc();
				else
					throw null;
				if(VM.JumperCode > 0)
					return cs;
			}
			return cs;
		}

		public Dot set(Expression e) { exps.Add(e); return this; }

		public Dot set(string e) { exps.Add(new get(e)); return this; }
	}
}