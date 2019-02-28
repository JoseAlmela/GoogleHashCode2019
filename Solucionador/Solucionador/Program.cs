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
        private const string inputB = "b_lovely_landscapes.txt";
        private const string inputC = "c_memorable_moments.txt";
        private const string inputD = "d_pet_pictures.txt";
        private const string inputE = "e_shiny_selfies.txt";
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var photosA = LoadPhotos(Path.Combine(_PATH_, "input", inputA));
            var photosB = LoadPhotos(Path.Combine(_PATH_, "input", inputB));
            var photosC = LoadPhotos(Path.Combine(_PATH_, "input", inputC));
            var photosD = LoadPhotos(Path.Combine(_PATH_, "input", inputD));
            var photosE = LoadPhotos(Path.Combine(_PATH_, "input", inputE));


            (new SlideShow { presentation = SolucionPanda1(photosA)}).ToFile(inputA);

            (new SlideShow { presentation = SolucionPanda1(photosB)}).ToFile(inputB);

            (new SlideShow { presentation = SolucionPanda1(photosC) }).ToFile(inputC);

            (new SlideShow { presentation = SolucionPanda1(photosD) }).ToFile(inputD);

            (new SlideShow { presentation = SolucionPanda1(photosE) }).ToFile(inputE);

            Console.ReadKey();
        }

        private static List<Slide> SolucionPanda1(Photo[] photos)
        {
            var hPhotos = photos
                .Where(p => p.IsHorizontal)
                .OrderByDescending(p => p.Tags.Length)
                .ToList();
            var vPhotos = photos
                .Where(p => !p.IsHorizontal)
                .OrderByDescending(p => p.Tags.Length)
                .ToList();

            List<Slide> presentation = new List<Slide>();
            while (hPhotos.Count > 0 || vPhotos.Count > 0)
            {
                if (hPhotos.Count > 0 && vPhotos.Count > 0)
                {
                    if (hPhotos.First().Tags.Length > vPhotos.First().Tags.Length)
                    {
                        presentation.Add(new Slide { Id1 = hPhotos.First().Index });
                        hPhotos.RemoveAt(0);
                    }
                    else
                    {
                        if (vPhotos.Count > 1)
                        {
                            var slide = new Slide { Id1 = vPhotos.First().Index };
                            vPhotos.RemoveAt(0);
                            slide.Id2 = vPhotos.First().Index;
                            vPhotos.RemoveAt(0);
                            presentation.Add(slide);
                        }
                        else if (vPhotos.Count == 1)
                        {
                            vPhotos.RemoveAt(0);
                        }
                    }
                }
                else if (hPhotos.Count > 0)
                {
                    presentation.Add(new Slide { Id1 = hPhotos.First().Index });
                    hPhotos.RemoveAt(0);
                }
                else if (vPhotos.Count > 0)
                {
                    if (vPhotos.Count > 1)
                    {
                        var slide = new Slide { Id1 = vPhotos.First().Index };
                        vPhotos.RemoveAt(0);
                        slide.Id2 = vPhotos.First().Index;
                        vPhotos.RemoveAt(0);
                        presentation.Add(slide);
                    }
                    else
                    {
                        vPhotos.RemoveAt(0);
                    }
                }
            }

            return presentation;
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
