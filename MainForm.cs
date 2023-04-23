using System;
using System.Drawing;
using System.Windows.Forms;
using GraphAlgorithmVisualizer.MathObjects;
using GraphAlgorithmVisualizer.Tests;
using GraphAlgorithmVisualizer.Visualization;

namespace GraphAlgorithmVisualizer
{
    public partial class MainForm : Form
    {
        private readonly Graphics graphics;
        private readonly Graph graph;

        private ISelectable selectedMathObject = null;

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
            graph = VisualizationTests.ExampleDistancedGraph(true);
            graph.SetPosition(PB_Canvas.Width / 2, PB_Canvas.Height / 2);
            graph.Draw(graphics);
        }

        private void CanvasMouseMove(object sender, MouseEventArgs e)
        {
            ClearCanvas();
            Point cursorPosition = PB_Canvas.PointToClient(Cursor.Position);
            if (MouseButtons.Left == e.Button)
            {
                selectedMathObject?.SetPosition(cursorPosition.X, cursorPosition.Y);
                selectedMathObject?.DrawSelectedState(graphics);
            }
            else
            {
                selectedMathObject = DetectNearestSelectableObject();
                selectedMathObject?.DrawDetectedState(graphics);
            }
            DrawGraph();
        }

        /// <summary>
        /// Iterates over MathObjects of the Graph and compares absolute distance between user's cursor position and the MathObject's position.
        /// </summary>
        /// <returns>The ISelectable implementing object which was the closest to user's cursor. If no object was detected within a radius of 50.0, null is returned instead.</returns>
        private ISelectable DetectNearestSelectableObject()
        {
            if (graph is null) return null;

            Point cursorPosition = PB_Canvas.PointToClient(Cursor.Position);
            ISelectable detectedObject = null;
            double distanceToClosestShape = double.MaxValue;

            foreach (ISelectable selectableObject in graph.VerticesArray)
            {
                double distanceToCurrentObject = Math.Sqrt(
                    Math.Pow(selectableObject.X - cursorPosition.X, 2) + 
                    Math.Pow(selectableObject.Y - cursorPosition.Y, 2)
                );

                if (distanceToClosestShape > distanceToCurrentObject && distanceToCurrentObject < 50d)
                {
                    detectedObject = selectableObject;
                    distanceToClosestShape = distanceToCurrentObject;
                }
            }
            return detectedObject;
        }

        /// <summary>
        /// Calls the Graph.Draw() method and forces PB_Canvas control to refresh.
        /// </summary>
        private void DrawGraph()
        {
            graph?.Draw(graphics);
            PB_Canvas.Refresh();
        }

        /// <summary>
        /// Fills the Canvas entirely with the PB_Canvas' background color.
        /// </summary>
        private void ClearCanvas() => graphics.FillRectangle(new SolidBrush(PB_Canvas.BackColor), 0, 0, PB_Canvas.Width, PB_Canvas.Height);
    }
}
