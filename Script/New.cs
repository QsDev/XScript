using System;
using System.Xml.Serialization;


namespace QsScript {

	[Serializable]
    public class New : Expression
    {
        public override bool IsCalculable => true;
        public string TypeName;
        public Expression[] Params;

        [NonSerialized, XmlIgnore]
        public Class type;

        public New()
        {

        }
        public New(string type, Expression[] @params)
        {
            TypeName = type;
            Params = @params;
        }

        protected override BasicObject calc()
        {
            if (type == null) type = Class.GetType(TypeName);
			var r = new QsScript.Object() { Type = type };
            if (type == null) return r;
            //r.funcs.Addrange(type.Functions);
            r.vars.Init(type.Fields);
            var f = type.GetConstructor(Params.Length);
            return QsScript.Call.call(f, r, Params);
        }
    }

	

}