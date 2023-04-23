using System.Drawing;

namespace GraphAlgorithmVisualizer.Visualization
{
    internal class DrawingTools
    {
        public static Pen DefaultOutline => new Pen(Color.Black, 2);
        public static Pen DefaultDetectedOutline => new Pen(Color.DarkOrange, 5);
        public static Pen DefaultSelectedOutline => new Pen(Color.Green, 5);
        public static SolidBrush DefaultBackColor => new SolidBrush(Color.LightGray);
        public static SolidBrush DefaultFontColor => new SolidBrush(Color.Black);
        public static Font DefaultFont => new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);
    }
}
