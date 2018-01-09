using System;
using System.IO;

namespace QsScript {
	[Serializable]
	public class Execute : Expression {
		public Expression QsXML;
		public Execute() { }
		public Execute(Expression textQsXMLFormat) { QsXML = textQsXMLFormat; }

		protected  override BasicObject calc() {
			var d = QsXML.Calc();
			var t = d as Text;
			if(t != null)
				try {
					var o = VM.Serializer.Deserialize(new MemoryStream(System.Text.Encoding.Unicode.GetBytes(t.Value))) as Expression;
					if(o != null)
						return o.Calc();
				} catch { }
			VM.SetThrow(d);
			return Void.Value;
		}
        public override bool IsCalculable => true;
    }
}
