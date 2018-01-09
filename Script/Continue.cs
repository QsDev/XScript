using System;


namespace QsScript {

	[Serializable]
    public class Continue : Expression
    {
        public override bool IsCalculable => false;
        public Continue()
        {

        }
        protected override BasicObject calc()
        {
            throw new NotImplementedException();
        }
    }
 

}