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
            List<Photo> photos;
            Console.WriteLine("Hello World!");
            File.WriteAllLines(_PATH_, new string[] { "test222" });

            Console.ReadKey();
        }

        public static List<Photo> LoadPhotos()
        {
            List<Photo> photos = new List<Photo>();
            string filename = "";

            using (StreamReader stream = new StreamReader(Util._PATH_ + filename))
            {
                string firstLine = stream.ReadLine();
            }
        }
    }
}
