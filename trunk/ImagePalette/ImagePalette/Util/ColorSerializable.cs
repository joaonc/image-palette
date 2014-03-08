using System;
using System.Drawing;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text;

namespace ImagePalette
{
    public class ColorSerializable //: IXmlSerializable, ISerializable
    {
        private Color color;

        public ColorSerializable()
        {
        }

        public ColorSerializable(Color color)
        {
            this.color = color;
        }

        public Color ToColor()
        {
            return color;
        }

        public void FromColor(Color color)
        {
            this.color = color;
        }

        public static implicit operator Color(ColorSerializable colorSerializable)
        {
            return colorSerializable.ToColor();
        }

        public static implicit operator ColorSerializable(Color color)
        {
            return new ColorSerializable(color);
        }

        [XmlAttribute]
        public byte A
        {
            get { return color.A; }
            set
            {
                if (value != color.A) // avoid hammering named color if no alpha change
                    color = Color.FromArgb(value, color); 
            }
        }

        [XmlAttribute]
        public string RGB
        {
            get { return ColorTranslator.ToHtml(color); }
            set
            {
                if (A == 0xFF)  // preserve named color value if possible
                    color = ColorTranslator.FromHtml(value);
                else
                    color = Color.FromArgb(A, ColorTranslator.FromHtml(value));
            }
        }

        /// <summary>
        /// Whether or not to serialize the Alpha value.
        /// Use by XML Serialization automatically.
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeA() { return A < 0xFF; }
    }
}
