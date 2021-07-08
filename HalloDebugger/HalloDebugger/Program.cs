using System;
using System.Diagnostics;

namespace HalloDebugger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine("go?");
            Console.ReadKey();

#if DEBUG
            Console.WriteLine("DEBUG");
#else
            Console.WriteLine("RELEASE");
#endif

            Trace.AutoFlush = true;
            Trace.Listeners.Add(new ConsoleTraceListener());
            Trace.Listeners.Add(new TextWriterTraceListener("log.txt"));
            Trace.Listeners.Add(new EventLogTraceListener("Application"));


            Debug.WriteLine("Hallo Debugger");
            Trace.WriteLine("Hallo Tace", "PANIK");



            Console.WriteLine("Ende");
            Console.ReadKey();
        }
    }
}
