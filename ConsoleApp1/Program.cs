using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var clase = new Clase();

            var inicio = DateTime.Now;
            Console.WriteLine($"INICIO: {inicio}");
            var task = clase.ExecuteAsync();
            var result = task.Result;
            var fin = DateTime.Now;
            Console.WriteLine($"FIN: {fin}, DURACION: {(fin-inicio).TotalMilliseconds/1000}");

            Thread.Sleep(10000);
        }
    }
}
