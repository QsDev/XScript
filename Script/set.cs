using System;


namespace QsScript {


    [Serializable]
    public class set : Expression
    {
        public override bool IsCalculable => true;
        public FieldPath Path;
        public Expression Value;
        public set()
        {
            get h;
        }
        public set(Expression @this, string name, Expression s)
        {
            Path = new FieldPath(@this, name);
            Value = s;
        }
        public set(FieldPath path, Expression s)
        {
            Path = path;
            Value = s;
        }

        protected override BasicObject calc()
        {
            BasicObject c = Value.Calc();
            var v = (Path.This?.Calc() ?? VM.CurrentScop);
            v [Path.Name] = c;
            c = v.GetData(Path.Name);
            
            return c;
        }
    }


}