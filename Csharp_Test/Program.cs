using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace Csharp_Test 
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 嵌入文本资源的读取 
            //Assembly asm = Assembly.GetExecutingAssembly(); 

            //Stream  _stream = asm.GetManifestResourceStream("Csharp_Test.Unns.U_3_2.CL2");
            //StreamReader sr = new StreamReader(_stream);
            //Console.WriteLine(sr.ReadToEnd());
            //sr.Close();
            #endregion

            #region 集合的迭代
            //var tt = new Titles();
            //foreach(var str in tt)
            //{
            //    Console.WriteLine(str);
            //}
            #endregion

            #region 协变和逆变
            TB ob = new TB();
            TA oa = ob;
            TC oc = (TC)ob; //可能会发生问题 

            //case 1
            //不变,以下两条都是编译通不过的
            //NoVar<TA> ta = new NoVarB();
            //NoVar<TC> tc = new NoVarB();

            //case 2
            //逆变,第一条编译通不过，
            //Contra<TA> ca = new ContrB();
            Contra<TC> cc = new ContrB();
            //后面两种也是通不过的,这相当于A、B、C都是从O派生来的，A、B、C间不能互等。这与上面的情况是不同的。
            //ContrA ca     = new ContrB();
            //ContrC cc2    = new ContrB();

            //case 3
            //协变,第二条编译通不过
            Convar<TA> cva = new ConvarB();
            //Convar<TC> cvc = new ConvarB();

            Console.ReadKey();
            #endregion
        }
    }

    class TA { } 
    class TB:TA { }
    class TC:TB { }

    interface NoVar<T> { }
    class NoVarB:NoVar<TB> { }
    // 逆变
    interface Contra<in T> { }
    class ContrA:Contra<TA> { }
    class ContrB:Contra<TB> { }
    class ContrC:Contra<TC> { }
    // 协变
    interface Convar<out T> { }
    class ConvarB:Convar<TB> { }
    class Titles
    {
        string[] names = {"hello","world"};
        public IEnumerator<string> GetEnumerator()
        {
            yield return names[0];
            yield return names[1];
        }
    }
}
