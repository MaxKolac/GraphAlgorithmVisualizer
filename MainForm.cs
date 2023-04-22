using System;
using System.Drawing;
using System.Windows.Forms;
using GraphAlgorithmVisualizer.MathObjects;
using GraphAlgorithmVisualizer.Tests;

namespace GraphAlgorithmVisualizer
{
    public partial class MainForm : Form
    {
        private readonly Graphics graphics;
        private readonly Graph graph;

        public MainForm()
        {
            InitializeComponent();

            PB_Canvas.Image = new Bitmap(PB_Canvas.Width, PB_Canvas.Height);
            graphics = Graphics.FromImage(PB_Canvas.Image);
            graphics.FillRectangle(new SolidBrush(PB_Canvas.BackColor), 0, 0, PB_Canvas.Width, PB_Canvas.Height);

            //VisualizationTests.GraphDrawingTest(graphics, PB_Canvas.Width, PB_Canvas.Height);
            //VisualizationTests.GraphPositioningTest(graphics, PB_Canvas.Width, PB_Canvas.Height);
            //VisualizationTests.ArrowTest(graphics, PB_Canvas.Width, PB_Canvas.Height);
            //VisualizationTests.CurvableLineTest(graphics, PB_Canvas.Width, PB_Canvas.Height);
            graph = VisualizationTests.ExampleGraph();
            graph.SetPosition(PB_Canvas.Width / 2, PB_Canvas.Height / 2);
            graph.Draw(graphics);
        }
    }
}
