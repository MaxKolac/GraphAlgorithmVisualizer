using GraphAlgorithmVisualizer.MathObjects;
using GraphAlgorithmVisualizer.Visualization;
using System.Drawing;
using System.Windows.Forms;

namespace GraphAlgorithmVisualizer.Tests
{
    internal class VisualizationTests
    {
        public static void GraphTest(Graphics graphics, PictureBox container)
        {
            Graph graph = new Graph(false, 13);
            graph.AddEdge(graph.V(0), graph.V(1));
            graph.AddEdge(graph.V(0), graph.V(2));

            graph.AddEdge(graph.V(1), graph.V(3));
            graph.AddEdge(graph.V(1), graph.V(4));

            graph.AddEdge(graph.V(2), graph.V(6));
            graph.AddEdge(graph.V(2), graph.V(12));

            graph.AddEdge(graph.V(3), graph.V(5));
            graph.AddEdge(graph.V(4), graph.V(7));
            graph.AddEdge(graph.V(5), graph.V(8));

            graph.AddEdge(graph.V(6), graph.V(9));
            graph.AddEdge(graph.V(6), graph.V(10));
            graph.AddEdge(graph.V(6), graph.V(11));

            VisualGraph visualGraph = new VisualGraph(graph, container.Width / 2, container.Height / 2);
            visualGraph.Draw(graphics);
        }
    }
}
