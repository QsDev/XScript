using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QsScript.Engine {
    public class Editor : Expression
    {
        public override bool IsCalculable => false;
        protected sealed override BasicObject calc()
        {
            throw new NotImplementedException();
        }
    }
}
