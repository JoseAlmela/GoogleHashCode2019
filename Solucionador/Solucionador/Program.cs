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
        private const string inputA = "a_example.txt";
        private const string inputC = "c_memorable_moments.txt";
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var photos = LoadPhotos(Path.Combine(_PATH_, "input", inputC));

            var hPhotos = photos
                .Where(p => p.IsHorizontal)
                .OrderByDescending(p => p.Tags.Length)
                .ToList();
            var vPhotos = photos
                .Where(p => !p.IsHorizontal)
                .OrderByDescending(p => p.Tags.Length)
                .ToList();

            List<Slide> presentation = new List<Slide>();
            while (hPhotos.Count >0 || vPhotos.Count > 0)
            {
                if(hPhotos.Count > 0 && vPhotos.Count > 0)
                {
                    if (hPhotos.First().Tags.Length > vPhotos.First().Tags.Length)
                    {
                        presentation.Add(new Slide { Id1 = hPhotos.First().Index });
                        hPhotos.RemoveAt(0);
                    }
                    else {
                        if(vPhotos.Count > 1)
                        {
                            var slide = new Slide { Id1 = vPhotos.First().Index };
                            vPhotos.RemoveAt(0);
                            slide.Id2 = vPhotos.First().Index;
                            vPhotos.RemoveAt(0);
                            presentation.Add(slide);
                        }
                        else if(vPhotos.Count == 1)
                        {
                            vPhotos.RemoveAt(0);
                        }
                    }
                }
                else if(hPhotos.Count > 0)
                {
                    presentation.Add(new Slide { Id1 = hPhotos.First().Index });
                    hPhotos.RemoveAt(0);
                }
                else if (vPhotos.Count > 0)
                {
                    if (vPhotos.Count > 1)
                    {
                        presentation.Add(new Slide { Id1 = vPhotos.First().Index });
                        vPhotos.RemoveAt(0);
                        presentation.Add(new Slide { Id2 = vPhotos.First().Index });
                        vPhotos.RemoveAt(0);
                    }
                    else
                    {
                        vPhotos.RemoveAt(0);
                    }
                }
            }

            (new SlideShow { presentation = presentation }).ToFile();

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
