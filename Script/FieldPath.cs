using System;


namespace QsScript {

    [Serializable]
    public class FieldPath:Expression
    {
        public override bool IsCalculable => true;
        public Expression This;
        public string Name;
		public FieldPath() {

		}
        public FieldPath(Expression _this, string name)
        {
            Name = name;
            This = _this;
        }

        protected override BasicObject calc()
        {
			return Void.Value;
            //throw new NotImplementedException();
        }
		public set set(Expression e) =>
			 new set(this, e);
		public get get(Expression e) =>
			 new get(this);
	}


}