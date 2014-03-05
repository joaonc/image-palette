using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ImagePalette
{
    /// <summary>
    /// Name of possible columns in PaletteGrid
    /// </summary>
    public static class PaletteGridColumns
    {
        public static string R = "R";
        public static string G = "G";
        public static string B = "B";
        public static string A = "A";
        public static string Hex = "Hex";
        public static string Color = "Color";
        public static string Count = "Count";
        public static string Percentage = "%";

        /// <summary>
        /// Gets all the column names defined in this class.
        /// </summary>
        /// <returns></returns>
        public static List<string> GetColumnNames()
        {
            List<string> cols = new List<string>();

            foreach (FieldInfo fi in typeof(PaletteGridColumns).GetFields())
            {
                // Get the value defined in the string, not the name of the string field
                cols.Add((string)fi.GetValue(null));
            }

            return cols;
        }
    }
}
