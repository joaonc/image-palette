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
                    case ".csv":
                    case ".txt":
                        ReadCSV();
                        break;
                    default:
                        throw new NotImplementedException("Reader for the this extension not implemented: " + Path.GetExtension(FileName));
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
        private void ReadPAL()
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

        private string[] RealLineIntoColumns(StreamReader sr, char delimiter)
        {
            string line = sr.ReadLine();
            if (line != null)
                return line.Split(delimiter);

            return null;
        }

        private void ReadCSV()
        {
            char delimiter = ',';

            // Read the file
            StreamReader sr = new StreamReader(fileName);

            try
            {
                string[] line = RealLineIntoColumns(sr, delimiter);
                if (line == null || line.Length < 3 || line.Length > 4)
                    throw new Exception("Either 3 (RGB) or 4 (RGBA) columns are expected in the file " + fileName);

                palette = new HashSet<Color>();

                // Create the column mapping for the values (0 based index)
                Dictionary<string, int> columns = new Dictionary<string, int>();

                int i;
                if (!Int32.TryParse(line[0], out i))
                {
                    // Check if the first line has columns
                    // If it's not a number, then it's assumed the first line has the column names defined
                    for (i = line.Length - 1; i >= 0; i--)
                    {
                        switch (line[i].ToLower())
                        {
                            case "r":
                            case "red":
                                columns["R"] = i;
                                break;
                            case "g":
                            case "green":
                                columns["G"] = i;
                                break;
                            case "b":
                            case "blue":
                                columns["B"] = i;
                                break;
                            case "a":
                            case "alplha":
                                columns["A"] = i;
                                break;
                            default:
                                throw new Exception(string.Format("Unknow column {0} in file {1}.", line[i], fileName));
                        }
                    }

                    // Read new line
                    line = RealLineIntoColumns(sr, delimiter);
                }
                else
                {
                    // Default column mapping
                    columns["R"] = 0;
                    columns["G"] = 1;
                    columns["B"] = 2;
                    if (line.Length == 4)
                        columns["A"] = 3;
                }

                while (line != null)
                {
                    Color color = Color.FromArgb(
                        Convert.ToByte(line[columns["R"]]), Convert.ToByte(line[columns["G"]]), Convert.ToByte(line[columns["B"]]));
                    if (line.Length == 4)
                        color = Color.FromArgb(Convert.ToByte(line[columns["A"]]), color);

                    palette.Add(color);

                    line = RealLineIntoColumns(sr, delimiter);
                }

            }
            finally
            {
                sr.Close();
            }
        }
    }
}
