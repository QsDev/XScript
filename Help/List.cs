using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace QsScript.Help {
	[Serializable]
    public class ListV
    {
        public KeyPaireV[] values;
        public int index;
        public ListV()
        {
            values = new KeyPaireV[8];
            index = -1;
        }
        public void Add(KeyPaireV v)
        {
            if (index >= values.Length) expand();
            values[++index] = v;
        }

        private void expand()
        {
            var na = new KeyPaireV[values.Length + 8 * values.Length / 6];
            Array.Copy(values, 0, na, 0, values.Length);
            values = na;
        }
        private void expand(int by)
        {
            var na = new KeyPaireV[values.Length + by + 8];
            Array.Copy(values, 0, na, 0, values.Length);
            values = na;
        }
        public KeyPaireV Get(int i) => (i < 0 || i > index) ? null : values[i];
        public KeyPaireV Get(string name) => get(name);
        private KeyPaireV get(string name)
        {
            var length = name.Length;
            for (int i = index; i >= 0; i--) {
                var x = values[i];
                if (length == x.Name.Length) {
                    unsafe
                    {
                        fixed (char* c = name)
                        fixed (char* m = x.Name)
                        {
                            char* _c = c;
                            char* _m = m;
                            int j = 0;
                            for (; j < length; j++, _m++, _c++)
                                if (*_c != *_m) break;
                            if (j == length) return x;
                        }
                    }
                }
            }
            return null;
        }
        internal void Add(string name, BasicObject value)
        {
            var x = get(name);
            if (x == null) Add(new KeyPaireV(name, value));
            else x.Value = value;
        }

        internal void Clear()
        {
            index = -1;
        }
        internal void Init(List<Field> fields)
        {
            if (fields.Count > values.Length) expand(fields.Count - values.Length);
            foreach (var f in fields)
                values[++index] = new KeyPaireV(f.Name, Void.Value);
        }
    }
    
	[Serializable]
	public class ListF {
		public KeyPaireF[] values;
		public int index;
		public ListF() {
			values = new KeyPaireF[8];
			index = -1;
		}
		public void Add(KeyPaireF v) {
			if(index >= values.Length)
				expand();
			values[++index] = v;
		}

		private void expand() {
			var na = new KeyPaireF[values.Length + 8 * values.Length / 6];
			System.Array.Copy(values, 0, na, 0, values.Length);
			values = na;
		}
		public KeyPaireF Get(int i) => (i < 0 || i > index) ? null : values[i];
		public Function Get(string name) => get(name)?.Value;
		private KeyPaireF get(string name) {
			var length = name.Length;
			for(int i = index; i >= 0; i--) {
				var x = values[i];
				if(length == x.Name.Length) {
					unsafe
					{
						fixed (char* c = name)
						fixed (char* m = x.Name)
						{
							char* _c = c;
							char* _m = m;
							int j = 0;
							for(; j < length; j++, _m++, _c++)
								if(*_c != *_m)
									break;
							if(j == length)
								return x;
						}
					}
				}
			}
			return null;
		}
		internal void Add(string name, Function value) {
			var x = get(name);
			if(x == null)
				Add(new KeyPaireF(name, value));
			else
				x.Value = value;
		}

		internal void Clear() {
			index = -1;
		}

		internal void Addrange(ListF values) {
			var d = index + values.index + 2 - this.values.Length;
			if(d > 0)
				expand(d);
			Array.Copy(values.values, 0, this.values, index + 1, values.index + 1);
			index += values.index + 1;
		}

		private void expand(int by) {
			var na = new KeyPaireF[values.Length + by + 8];
			Array.Copy(values, 0, na, 0, values.Length);
			values = na;
		}

	}
    [Serializable]
    public class List	:System.Xml.Serialization.IXmlSerializable
    {
        public Expression[] values;
        public int index;
        public List() {

			values = new Expression[8];
            index = -1;
        }
        public void Add(Expression v)
        {
            if (index >= values.Length) expand();
            values[++index] = v;
        }

        private void expand()
        {
            var na = new Expression[values.Length + 8 * values.Length / 6];
            Array.Copy(values, 0, na, 0, values.Length);
            values = na;
        }
        private void expand(int by)
        {
            var na = new Expression[values.Length + by + 8];
            Array.Copy(values, 0, na, 0, values.Length);
            values = na;
        }
        public Expression Get(int i) => (i < 0 || i > index) ? null : values[i];        
        internal void Clear()
        {
            index = -1;
        }

        internal void AddRange(Expression[] insts)
        {								
			var d = index + insts.Length + 1 - this.values.Length;
			if(d > 0)
				expand(d);
			Array.Copy(insts, 0, values, index + 1, insts.Length);
            index += insts.Length;
			
        }

		public XmlSchema GetSchema() {
			return null;
		}

		public void ReadXml(XmlReader reader) {
			XmlSerializer x = VM.Serializer;
			var d = reader.Depth;			
			reader.MoveToContent();
			reader.Read();
			while(d-->0) {
				var v = x.Deserialize(reader);
				Add(v as Expression);
			}
			reader.ReadEndElement();
		}

		public void WriteXml(XmlWriter writer) {
			XmlSerializer x = new XmlSerializer(typeof(Expression));
			for(int i = 0; i <= index; i++) {
				x.Serialize(writer, values[i]);
			}
		}
	}

    
}
