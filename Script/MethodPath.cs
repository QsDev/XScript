using System;


namespace QsScript {


    [Serializable]
    public class MethodPath : Expression
    {
        public override bool IsCalculable => true;
        public Expression This;
        public string Name;
        public MethodPath()
        {

        }
        public MethodPath(Expression _this, string name)
        {
            Name = name;
            This = _this;
        }

        protected override BasicObject calc()
        {
            throw new NotImplementedException();
        }
    }


}