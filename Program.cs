using System;
using System.Diagnostics;
using System.Threading;
using Nancy.Hosting.Self;

namespace NancyService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var nancyHost = new NancyHost(new Uri("http://localhost:8888/v1/")))
            {
                nancyHost.Start();
                Console.WriteLine("Nancy now listening - navigating to http://localhost:8888/v1/.");
                try
                {
                    Process.Start("http://localhost:8888/v1/");
                }
                catch (Exception)
                {
                }
       
                

//                Console.ReadKey();
                Thread.Sleep(Timeout.Infinite);
            }

            Console.WriteLine("Stopped. Good bye!");
        }
    }
}

