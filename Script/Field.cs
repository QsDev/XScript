using System;
using System.Collections.Generic;


namespace QsScript {
	[Serializable]
    public class Field : Expression
    {
        public override bool IsCalculable => true;
        public readonly static List<Field> NotResolved = new List<Field>();
        public string Name;
        public string TypeName;
        public int Index;
        [NonSerialized, System.Xml.Serialization.XmlIgnore()]
        public Class Type;
        public Field()
        {

        }
        public Field(string name, string type)
        {
            Name = name;
            TypeName = type;
        }

        protected override BasicObject calc()
        {
            if (!Resolve(this)) NotResolved.Add(this);
            return Void.Value;
        }

        private bool Resolve(Field field)
        {
            foreach (var c in Class.Classes)
                if (c.Name == field.Name) return true;
            return false;

        }
    }



}