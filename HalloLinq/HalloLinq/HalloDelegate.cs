using System;
using System.Collections.Generic;
using System.Linq;

namespace HalloLinq
{
    delegate void EinfacherDelegate();
    delegate void DelegateMitPara(string msg);
    delegate long CalcDelegate(int a, int b);

    class HalloDelegate
    {
        public HalloDelegate()
        {
            EinfacherDelegate einfacherDelegate = EinfacheMethode;
            Action action = EinfacheMethode;
            Action actionAno = delegate () { Console.WriteLine("Ich bin eine anonyme methode"); };
            Action actionAno2 = () => { Console.WriteLine("ano"); };
            Action actionAno3 = () => Console.WriteLine("ano");

            DelegateMitPara delegateMitPara = MethodeMitPara;
            Action<string> action1 = MethodeMitPara;
            Action<string> action2 = (string x) => { Console.WriteLine(x); };
            Action<string> action3 = (string x) => Console.WriteLine(x);
            Action<string> action4 = (x) => Console.WriteLine(x);
            Action<string> action5 = x => Console.WriteLine(x);

            CalcDelegate calcDele = Minus;
            Func<int, int, long> calcDele2 = Sum;
            Func<int, int, long> calcDele3 = (int x, int y) => { return x + y; };
            Func<int, int, long> calcDele4 = (x, y) => { return x + y; };
            Func<int, int, long> calcDele5 = (x, y) => x + y;

            List<string> texte = new List<string>();
            texte.Where(Filter);
            texte.Where(x => x.StartsWith("b"));

            calcDele.Invoke(12, 3);
        }

        private bool Filter(string arg)
        {
            if (arg.StartsWith("b"))
                return true;
            else
                return false;
        }

        private long Minus(int a, int b)
        {
            return 12 - 3;
        }

        private long Sum(int a, int b)
        {
            return a + b;
        }

        void EinfacheMethode()
        {
            Console.WriteLine("Hallo");
        }

        void MethodeMitPara(string txt)
        {
            Console.WriteLine(txt);
        }
    }
}
