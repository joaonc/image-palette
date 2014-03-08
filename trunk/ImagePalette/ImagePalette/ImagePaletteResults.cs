﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ImagePalette
{
    public class ImagePaletteResults
    {
        public ImagePaletteParameters Parameters { get; set; }
        public DictionarySerializable<string, DictionarySerializable<Color, int>> FileResults { get; set; }

        public ImagePaletteResults()
        {
            Parameters = new ImagePaletteParameters();
            FileResults = new DictionarySerializable<string, DictionarySerializable<Color, int>>();
        }

        public ImagePaletteResults(ImagePaletteParameters parameters)
        {
            Parameters = parameters;
            FileResults = new DictionarySerializable<string, DictionarySerializable<Color, int>>();
        }

        public void Save()
        {
            if (!string.IsNullOrWhiteSpace(Parameters.FileNameOutput))
                Util.SerializeToXmlFile(this, Parameters.FileNameOutput);
        }
    }
}
