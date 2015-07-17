using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ImagePalette
{
    public class ImagePaletteResults
    {
        /// <summary>
        /// Parameters used to create these results.
        /// </summary>
        public ImagePaletteParameters Parameters { get; set; }

        /// <summary>
        /// Dictionary with FileName as Key and ImagePaletteResult as Value.
        /// </summary>
        public DictionarySerializable<string, ImagePaletteResult> FileResults { get; set; }

        public ImagePaletteResults()
        {
            Parameters = new ImagePaletteParameters();
            FileResults = new DictionarySerializable<string, ImagePaletteResult>();
        }

        public ImagePaletteResults(ImagePaletteParameters parameters)
        {
            Parameters = parameters;
            FileResults = new DictionarySerializable<string, ImagePaletteResult>();
        }

        public void Save()
        {
            if (!string.IsNullOrWhiteSpace(Parameters.FileNameOutput))
                Util.SerializeToXmlFile(this, Parameters.FileNameOutput);
        }
    }
}
