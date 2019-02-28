using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static Solucionador.Util;


namespace Solucionador
{
    public class SlideShow
    {
        public List<Slide> presentation = new List<Slide>();

        public void ToFile(string prefix) {
            var now = DateTime.Now;
            List<string> outputFileContent = new List<string>();
                outputFileContent.Add(presentation.Count.ToString());
                for (int i = 0; i < presentation.Count; i++)
                {
                    outputFileContent.Add(presentation[i].Id1.ToString() + (presentation[i].Id2.HasValue ? " " + presentation[i].Id2.ToString() : string.Empty));
                }
            File.WriteAllLines(Path.Combine(_PATH_,"output", $"{now.Hour}{now.Minute}{now.Second}{prefix}"), outputFileContent);
        }
    }

    public class Slide
    {
        public int Id1 { get; set; }
        public int? Id2 { get; set; }

    }
}
