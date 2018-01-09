using System;


namespace QsScript {

    [Serializable]
    public class get : Expression
    {
        public override bool IsCalculable => true;
        public FieldPath Path;
        public get()
        {

        }
        public get(string name)
        {
            Path = new FieldPath(null, name);
        }
        public get(FieldPath path) { Path = path; }
        protected override BasicObject calc()
        {
            BasicObject s = null;
            if (Path.This != null)
                s = Path.This.Calc();
            else s = VM.CurrentScop;
            return s?[Path.Name] ?? Void.Value;
        }

        public get Get(string l)
        {
            return new get(new FieldPath(this, l));
        }
    }


}