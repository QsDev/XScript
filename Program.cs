using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using QsScript.Engine;

namespace QsScript {
	
	internal class Program : Editor {
		public void Test() {
			
			Bloc global = new Bloc();
            global.Add(@class("enum", null).SetScop(
            Field("A", "int"), Field("B", "real"),
            Bloc(
                get("a").setTo("A"), get("b").setTo("B"), get("this").AsReturn()
                ).AsFunction("save", "a", "b")
            ));
            global
                .Add(New("enum").setTo("inst"))
                .Add(get("inst").Call("save", Const(3.0), Const(6)))
                .Add(get("inst", "A").setTo("x"))
                .Add(Bloc(get("x").CalcWith(Operation.plus, get("x")).setTo("x")).AsWhile(get("x").CalcWith(Operation.Lth, Const(100))))
                .Add(get("x").CalcWith(Operation.mult, get("x")).AsReturn());
			try {
				var file = File.Open(@"a:\h\test2.xml", FileMode.OpenOrCreate);
				file.Seek(0, SeekOrigin.Begin);
				file.Flush();
				//VM.Serializer.Serialize(file, global);
				//file.Dispose();
			} catch(System.Exception ee) {
			}
            var x = 3;
            while (x<100)
            {
                x += x;
            }
            x = x * x;
            Console.WriteLine(x);
            VM.Reset();
            var xx = global.Calc();
            Console.WriteLine(xx);
			xx.ToString();
            Console.ReadKey();

		}

		//private void CurrentDomain_FirstChanceException(object sender, System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs e) {
		//	this.get("");
		//}

		private void ee() {
			
		}

		static int Main(string[] args) {

			new Program().Test();
			return 0;
		}
		public static Stream Execute(Stream s) {

			Expression fr = Void.Value;
			try {
				var o = VM.Serializer.Deserialize(s) as Expression;

				if(o != null) {
					var m = o.Calc();
					if(m == null) {
						fr = new Text("UnrecognizeError").AsThrow();
					} else; } else
					fr = new Text("Code en Error Format").AsThrow();
			} catch(System.Exception e) {
				fr = new Text(e.Message).AsThrow();
			}
			Stream l = new MemoryStream(2048);
			VM.Serializer.Serialize(l, fr);
			return l;
		}
    }
}
