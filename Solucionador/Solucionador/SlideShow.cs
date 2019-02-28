using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Solucionador
{
    public class SlideShow
    {
        List<Slide> presentation = new List<Slide>();

        public void ToFile() {

            List<string> slidePhotos = new List<string>();
                slidePhotos.Add(presentation.Count.ToString());
                for (int i = 0; i < presentation.Count; i++)
                {
                    slidePhotos.Add(presentation[i].Id1.ToString() + (presentation[i].Id2.HasValue ? " " + presentation[i].Id2.ToString() : string.Empty));
                }
        }
    }

    public class Slide
    {
        public int Id1 { get; set; }
        public int? Id2 { get; set; }

    }
}
