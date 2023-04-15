using System.Drawing;

namespace GraphAlgorithmVisualizer.Visualization
{
    internal class DrawingTools
    {
        public static Pen GlobalPen => new Pen(Color.Black, 3);
        public static SolidBrush GlobalBrush => new SolidBrush(Color.Black);
        public static Font GlobalFont => new Font(FontFamily.GenericSansSerif, 12);
    }
}
