using System;

namespace QsScript.Help {
	[Serializable]
    public class KeyPaireV
    {
        public string Name;
        public BasicObject Value;

        public KeyPaireV()
        {

        }
        public KeyPaireV(string name, BasicObject value)
        {
            Name = name;
            Value = value;
        }
    }

    [Serializable]
    public class KeyPaireF
    {
        public string Name;
        public Function Value;

        public KeyPaireF()
        {

        }
        public KeyPaireF(string name, Function value)
        {
            Name = name;
            Value = value;
        }
    }
}
