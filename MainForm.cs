using GraphAlgorithmVisualizer.Tests;
using System.Drawing;
using System.Windows.Forms;

namespace GraphAlgorithmVisualizer
{
    public partial class MainForm : Form
    {
        private readonly Graphics graphics;

        public MainForm()
        {
            InitializeComponent();

            PB_Canvas.Image = new Bitmap(PB_Canvas.Width, PB_Canvas.Height);
            graphics = Graphics.FromImage(PB_Canvas.Image);
            graphics.FillRectangle(new SolidBrush(PB_Canvas.BackColor), 0, 0, PB_Canvas.Width, PB_Canvas.Height);

            //VisualizationTests.GraphDrawingTest(graphics, PB_Canvas.Width, PB_Canvas.Height);
            //VisualizationTests.GraphPositioningTest(graphics, PB_Canvas.Width, PB_Canvas.Height);
            VisualizationTests.ArrowTest(graphics, PB_Canvas.Width, PB_Canvas.Height);
        }
    }
}
