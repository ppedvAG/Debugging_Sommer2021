using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace HalloTPL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //Parallel.Invoke(Zähle, Zähle, Zähle, Zähle);
            // Parallel.For(0, 1000000, i => Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: {i}"));

            Task t1 = new Task(() =>
            {
                Console.WriteLine("T1 gestartet");
                Thread.Sleep(1500);
                throw new FileNotFoundException();
                Console.WriteLine("T1 fertig");
            });


            //immer: ohne parameter
            t1.ContinueWith(t =>
            {
                Console.WriteLine("T1 continue");
            });

            t1.ContinueWith(t =>
            {
                Console.WriteLine($"T1 ERROR: {t.Exception.InnerException.Message}");
            }, TaskContinuationOptions.OnlyOnFaulted);

            t1.ContinueWith(t =>
            {
                Console.WriteLine($"T1 OK");
            }, TaskContinuationOptions.OnlyOnRanToCompletion);



            Task<long> t2 = new Task<long>(() =>
            {
                Console.WriteLine("T2 gestartet");
                Thread.Sleep(1200);
                Console.WriteLine("T2 fertig");
                return 9385734987543987;
            });

            //t2.ContinueWith(t =>
            //{
            //    Console.WriteLine($"T2 Continue: {t.Result}");
            //});

            t1.Start();
            t2.Start();

            t2.Wait();
            Console.WriteLine($"T2 Result: {t2.Result}");


            Console.WriteLine("Ende");
            Console.ReadKey();
        }

        private static void Zähle()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: {i}");
            }
        }
    }
}
