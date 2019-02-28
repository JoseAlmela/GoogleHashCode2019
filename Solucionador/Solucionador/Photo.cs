using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucionador
{
    public class Photo
    {
        private bool isHorizontal;
        private List<string> tags;

        public bool IsHorizontal { get => isHorizontal; set => isHorizontal = value; }
        public List<string> Tags { get => tags; set => tags = value; }
    }
}
