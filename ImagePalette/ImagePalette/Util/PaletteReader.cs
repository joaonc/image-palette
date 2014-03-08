using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagePalette
{
    /// <summary>
    /// Reads a palette from file.
    /// </summary>
    public class PaletteReader
    {
        string fileName;
        
        HashSet<Color> palette;

        public PaletteReader()
        {
        }

        public PaletteReader(string fileName)
        {
            FileName = fileName;
        }

        public string FileName
        {
            get { return fileName; }
            set
            {
                fileName = value;
                palette = null;
            }
        }

        public HashSet<Color> GetPalette()
        {
            if (palette == null)
            {
                switch (Path.GetExtension(FileName).ToLower())
                {
                    case ".pal":
                        ReadPAL();
                        break;
                    default:
                        break;
                }
            }

            return palette;
        }

        /// <summary>
        /// Reads Microsoft .PAL files, which contain palette information.
        /// The format is as follows:
        /// 'RIFF' (4 bytes)
        /// file length - 8 (4 bytes)
        /// 'PAL ' (4 bytes)
        /// 'data' (4 bytes)
        /// data size (filelength - 20) (4 bytes)
        /// version number (always 00 03) (2 bytes)
        /// number of colors in the image (2 bytes)
        /// 
        /// Then colors come in RGBA come in 4 bytes
        /// 
        /// Info taken from http://willperone.net/Code/codereadingpal.php
        /// More info at https://code.google.com/p/pal-reader
        /// 
        /// NOTE: Alpha representation in the Color object is inverse of that in PAL, ie
        ///       0 in PAL is 255 in Color.
        ///       This conversion is done in the code.
        /// </summary>
        void ReadPAL()
        {
            // Read the file
            FileStream fs = File.Open(fileName, FileMode.Open, FileAccess.Read);

            try
            {
                // Get the initial data
                int headerSize = 24;
                byte[] header = new byte[headerSize];
                fs.Read(header, 0, headerSize);

                palette = new HashSet<Color>();
                byte[] rgbaColor = new byte[4];
                while (fs.Position < fs.Length)
                {
                    fs.Read(rgbaColor, 0, 4);
                    // Alpha is inverted
                    Color color = Color.FromArgb(255 - rgbaColor[3], rgbaColor[0], rgbaColor[1], rgbaColor[2]);

                    palette.Add(color);
                }
            }
            finally
            {
                fs.Close();
            }
        }
    }
}
