using System;


namespace QsScript {

	[Serializable]
    public class Function : Expression
    {
        public override bool IsCalculable => true;
        public string name;
        public string[] @params;
        public Expression body;
        public Function()
        {

        }
        public Function(string name, string[] @params, Expression exp)
        {
            this.name = name;
            this.body = exp;
            this.@params = @params;
        }
        protected override BasicObject calc()
        {
            VM.AddFunction(this);
            return Void.Value;
        }
    }


}