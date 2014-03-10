using System;
using System.Collections.Generic;

namespace ImagePalette
{
    public class ImagePaletteResult
    {
        /// <summary>
        /// The total number of pixels in this image.
        /// </summary>
        public long Pixels { get; set; }

        /// <summary>
        /// The number of pixels processed in this image.
        /// </summary>
        public long PixelsCovered { get; set; }

        /// <summary>
        /// A list of colors within the loaded palette and the number of times they were counted in this image.
        /// </summary>
        public List<ImagePaletteResultColor> ColorCountList { get; set; }

        public ImagePaletteResult()
        {
            ColorCountList = new List<ImagePaletteResultColor>();
        }

        /// <summary>
        /// Constructor that stipulates the initial capacity of the list holding the results.
        /// </summary>
        /// <param name="capacity"></param>
        public ImagePaletteResult(int capacity)
        {
            ColorCountList = new List<ImagePaletteResultColor>(capacity);
        }
    }
}
