using System;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImagePalette;

namespace ImagePaletteUnitTest
{
    [TestClass]
    public class ColorUtilUnitTest
    {
        private Dictionary<Tuple<Color, Color>, double> knownDistances;

        [TestInitialize]
        public void InitializeEachTest()
        {
            knownDistances = new Dictionary<Tuple<Color, Color>, double>();
            knownDistances.Add(new Tuple<Color, Color>(Color.Black, Color.White), 764.83331517396653d);
        }

        [TestMethod]
        public void ColorDistance_KnownDistances()
        {
            foreach (Tuple<Color, Color> colorTuple in knownDistances.Keys)
            {
                double distance = ColorUtil.ColorDistance(colorTuple.Item1, colorTuple.Item2);
                Assert.AreEqual(knownDistances[colorTuple], distance, 0.01d);
            }
        }

        /// <summary>
        /// Making sure the Alpha value isn't taken in consideration calculating the color distance.
        /// </summary>
        [TestMethod]
        public void ColorDistance_DifferentAlpha()
        {
            Random random = new Random();
            foreach (Tuple<Color, Color> colorTuple in knownDistances.Keys)
            {
                Color c1 = Color.FromArgb(random.Next(0, 127), colorTuple.Item1.R, colorTuple.Item1.G, colorTuple.Item1.B);
                Color c2 = Color.FromArgb(random.Next(128, 255), colorTuple.Item2.R, colorTuple.Item2.G, colorTuple.Item2.B);

                double distance = ColorUtil.ColorDistance(c1, c2);
                Assert.AreEqual(knownDistances[colorTuple], distance, 0.01d);
            }
        }

        /// <summary>
        /// Distance c1 to c2 (known) is the same as c2 to c1 (calculated).
        /// </summary>
        [TestMethod]
        public void ColorDistance_SwitchOrder()
        {
            foreach (Tuple<Color, Color> colorTuple in knownDistances.Keys)
            {
                double distance = ColorUtil.ColorDistance(colorTuple.Item2, colorTuple.Item1);
                Assert.AreEqual(knownDistances[colorTuple], distance, 0.01d);
            }
        }
    }
}
