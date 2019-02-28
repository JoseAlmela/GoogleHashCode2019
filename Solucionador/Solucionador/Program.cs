using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Solucionador.Util;

namespace Solucionador
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            File.WriteAllLines(_PATH_, new string[] { "test222" });

            Console.ReadKey();
        }
    }
}
