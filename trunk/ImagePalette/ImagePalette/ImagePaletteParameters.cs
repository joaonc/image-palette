using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagePalette
{
    /// <summary>
    /// Application parameters.
    /// XML serializable.
    /// </summary>
    public class ImagePaletteParameters
    {
        public string FileName { get; set; }
        public int Coverage { get; set; }
        public string FileNameReference { get; set; }
        public int Distance { get; set; }
        public int ThresholdIndexed { get; set; }
        public int ThresholdMatched { get; set; }
    }
}
