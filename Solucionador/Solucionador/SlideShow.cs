using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucionador
{
    public class SlideShow
    {
        List<Slide> presentation = new List<Slide>();
    }

    public class Slide
    {
        public Photo Photo1 { get; set; }
        public Photo Photo2 { get; set; }

    }
}
