using System;
namespace QsScript {

	public class BasicConst : BasicObject
    {
		public BasicObject this[int index] { get { return GetData(index); } set { SetData(index, value); } }
		public BasicObject this[string name] { get { return GetData(name); } set { SetData(name, value); } }

        public override bool IsCalculable => false;

        public override void Add(Function function)
        {
            throw new NotImplementedException();
        }

		public sealed override BasicObject GetData(int s) {
			return this;
		}

		public override BasicObject GetData(string s) {
			return this;
		}

		public override Function GetFunction(string name)
        {
			//throw new NotImplementedException();
			return null;
        }

		public sealed override void SetData(int s, BasicObject v) {
			
		}

		public sealed override void SetData(string s, BasicObject v) {
			
		}

		protected override BasicObject calc()
        {
            return this;
        }

    }

}