using System.Collections.Generic;
using System.Windows.Documents;

namespace AcoustiCUtils
{
    public class Constr
    {
        //public int Id { get; set; }

        public string Code { get; set; }
        public int LenX { get; set; }
        public int LenY { get; set; }
        public int LenZ { get; set; }
        public bool dframe { get; set; }
        public int Area { get; set; }
        public int Perimeter { get; set; }
        public int step { get; set; }

        public List<Opening> Openings { get; set; }
    }

    public class Opening
    {
        public int Length { get; set; }
        public int Width { get; set; }

        public int Area { get; set; }

    }
}
