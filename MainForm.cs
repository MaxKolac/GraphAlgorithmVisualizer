using System.Drawing;
using System.Windows.Forms;
using GraphAlgorithmVisualizer.Tests;

namespace GraphAlgorithmVisualizer
{
    public partial class MainForm : Form
    {
        private readonly Graphics canvasGraphics;

        public MainForm()
        {
            InitializeComponent();
            PB_Canvas.Image = new Bitmap(PB_Canvas.Width, PB_Canvas.Height);
            canvasGraphics = PB_Canvas.CreateGraphics();
            canvasGraphics.FillRectangle(new SolidBrush(Color.White), PB_Canvas.Bounds);
            VisualizationTests.GraphTest(canvasGraphics, PB_Canvas);
        }
    }
}
