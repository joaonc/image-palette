using System;
using System.Drawing;
using System.Xml.Serialization;

namespace ImagePalette
{
    public class ImagePaletteResult
    {
        [XmlElement(Type = typeof(ColorSerializable))]
        public Color Color { get; set; }

        public int Count { get; set; }

        public ImagePaletteResult()
        {
            Color = Color.Empty;
        }

        public ImagePaletteResult(Color color, int count)
        {
            Color = color;
            Count = count;
        }
    }
}
