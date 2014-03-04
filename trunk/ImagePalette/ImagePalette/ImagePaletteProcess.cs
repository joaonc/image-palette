using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagePalette
{
    /// <summary>
    /// Class that does the processing.
    /// </summary>
    public class ImagePaletteProcess
    {
        public ImagePaletteParameters Parameters { get; private set; }
        public DataTable DataTableIndexed { get; private set; }
        public DataTable DataTableLoaded { get; private set; }

        public ImagePaletteProcess(ImagePaletteParameters parameters)
        {
            Parameters = parameters;
            DataTableIndexed = null;
            DataTableLoaded = null;
        }

        /// <summary>
        /// Given H,S,L in range of 0-1
        /// Returns a Color (RGB struct) in range of 0-255
        /// 
        /// Taken from http://www.geekymonkey.com/Programming/CSharp/RGB2HSL_HSL2RGB.htm
        /// </summary>
        /// <param name="h"></param>
        /// <param name="sl"></param>
        /// <param name="l"></param>
        /// <returns></returns>
        public static Color HSL2RGB(double h, double sl, double l)
        {
            double v;
            double r, g, b;

            r = l;   // default to gray
            g = l;
            b = l;
            v = (l <= 0.5) ? (l * (1.0 + sl)) : (l + sl - l * sl);
            if (v > 0)
            {
                double m;
                double sv;
                int sextant;
                double fract, vsf, mid1, mid2;

                m = l + l - v;
                sv = (v - m) / v;
                h *= 6.0;
                sextant = (int)h;
                fract = h - sextant;
                vsf = v * sv * fract;
                mid1 = m + vsf;
                mid2 = v - vsf;
                switch (sextant)
                {
                    case 0:
                        r = v;
                        g = mid1;
                        b = m;
                        break;
                    case 1:
                        r = mid2;
                        g = v;
                        b = m;
                        break;
                    case 2:
                        r = m;
                        g = v;
                        b = mid1;
                        break;
                    case 3:
                        r = m;
                        g = mid2;
                        b = v;
                        break;
                    case 4:
                        r = mid1;
                        g = m;
                        b = v;
                        break;
                    case 5:
                        r = v;
                        g = m;
                        b = mid2;
                        break;
                }
            }

            Color rgb = Color.FromArgb(255, Convert.ToByte(r * 255.0f), Convert.ToByte(g * 255.0f), Convert.ToByte(b * 255.0f));
            return rgb;
        }

        /// <summary>
        /// Calculates the distance between two colors, adjusted for the human eye.
        /// More details on the theory here: http://www.compuphase.com/cmetric.htm
        /// Important note from the link above:
        /// This formula has results that are very close to L*u*v* (with the modified lightness curve) and, more importantly,
        /// it is a more stable algorithm: it does not have a range of colours where it suddenly gives far from optimal results.
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double ColorDistance(Color c1, Color c2)
        {
            long rmean = ((long)c1.R + (long)c2.R) / 2;
            long r = (long)c1.R - (long)c2.R;
            long g = (long)c1.G - (long)c2.G;
            long b = (long)c1.B - (long)c2.B;

            return Math.Sqrt((((512 + rmean) * r * r) >> 8) + 4 * g * g + (((767 - rmean) * b * b) >> 8));
        }

        public bool IsWithinDistance(Color c1, Color c2)
        {
            double dist = ColorDistance(c1, c2);
            return dist <= Parameters.Distance;
        }

        /// <summary>
        /// Gets the table with the indexed colors that pass the given threshold of number of colors from the indexed image.
        /// </summary>
        /// <param name="dtIndexed"></param>
        /// <returns></returns>
        public DataTable GetIndexedThreshold(DataTable dtIndexed)
        {
            return null;
        }

        public DataTable GetMatchedByDistance(DataTable dtIndexed, DataTable dtLoaded)
        {
            return null;
        }
    }
}