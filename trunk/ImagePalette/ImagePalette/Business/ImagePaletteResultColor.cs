using System;
using System.Drawing;
using System.Xml.Serialization;

namespace ImagePalette
{
    public class ImagePaletteResultColor
    {
        /// <summary>
        /// The color in the image.
        /// </summary>
        [XmlElement(Type = typeof(ColorSerializable))]
        public Color Color { get; set; }

        /// <summary>
        /// The number of times a given color was counted in an image.
        /// Depends on the Coverage parameter, ie, more coverage likely means this (and all other) number would increase.
        /// </summary>
        public int Count { get; set; }

        public ImagePaletteResultColor()
        {
            Color = Color.Empty;
        }

        public ImagePaletteResultColor(Color color, int count)
        {
            Color = color;
            Count = count;
        }
    }
}
