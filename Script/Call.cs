using System;

namespace QsScript {


	[Serializable]
    public class Call : Expression
    {
        public override bool IsCalculable => true;
        public MethodPath Method;
        public Expression[] Params;

        public Call()
        {

        }
        public Call(Expression @this, string name, params Expression[] @params)
        {
            Method = new MethodPath(@this, name);
            Params = @params;
        }
        public Call(MethodPath path, Expression[] @params)
        {
            Method = path;
            Params = @params;
        }
		protected override BasicObject calc() {
			if(Method == null)
				return Void.Value;
			var thisScop = Method.This?.Calc() ?? VM.CurrentScop;

			return call(thisScop.GetFunction(Method.Name), VM.GetCleanScop(thisScop), Params);
		}			  
		/// <param name="thisScop">Remarque : thisScop must be executed befor passing to function</param>
		public static BasicObject call(BasicObject thisScop, string fName, Expression[] Params) {
			thisScop = thisScop ?? VM.CurrentScop;
			return call((thisScop).GetFunction(fName), VM.GetCleanScop(thisScop), Params);
		}

		/// <param name="thisScop">Remarque : thisScop must be executed befor passing to function</param>
		public static BasicObject call(Function fn, BasicObject ns, Expression[] Params)
        {
            if (fn == null) return ns;
            int i = 0;
            foreach (var p in fn.@params)
            {
                if (i < Params.Length)
                {
                    var pp = Params[i++];
                    ns[p] = pp.Calc();
					Dot h;
                }
                else break;
            }
            VM.OpenScop(ns);
            var r = fn.body.Calc();
            if (IsReturn)
                r = VM.StopReturn();
            VM.CloseScop();
            return r;
        }
    }
}