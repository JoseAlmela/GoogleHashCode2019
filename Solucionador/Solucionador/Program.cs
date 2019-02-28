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

        public static Photo[] LoadPhotos(string path)
        {
            List<string> lines = File.ReadAllLines(path).Skip(1).ToList();
            List<Photo> photos = new List<Photo>();

            for (int index = 0; index < lines.Count; index++)
            {
                string line = lines[index];
                string[] words = line.Split(' ');
                string[] tags = words.Skip(2).ToArray();
                Photo photo = new Photo()
                {
                    Index = index,
                    IsHorizontal = words[0] == "H",
                    Tags = tags,
                };

                photos.Add(photo);
            }

            return photos.ToArray();
        }
    }
}
