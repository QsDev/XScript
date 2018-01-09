using System;


namespace QsScript {

	[Serializable]
    public class Exception : Scop
    {
        public string ex;
        public Exception()
        {

        }
        public Exception(string ex)
            : base(null)
        {
            this.ex = ex;
        }
    }

}