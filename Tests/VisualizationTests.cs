using GraphAlgorithmVisualizer.MathObjects;
using GraphAlgorithmVisualizer.Visualization.Shapes;
using System;
using System.Drawing;

namespace GraphAlgorithmVisualizer.Tests
{
    internal class VisualizationTests
    {
        public static void GraphDrawingTest(Graphics graphics, int pictureBoxWidth, int pictureBoxHeight)
        {
            Graph graph = new Graph(true, true, 9);
            /*graph.AddEdge(graph[0], graph[1], 4);
            graph.AddEdge(graph[0], graph[2], 2);

            graph.AddEdge(graph.V(1), graph.V(2), 3);
            graph.AddEdge(graph.GetVertex(1), graph[3], 2);
            graph.AddEdge(graph[1], graph[4], 3);

            graph.AddEdge(graph.V(2), graph.V(1), 1);
            graph.AddEdge(graph.V(2), graph.V(3), 4);
            graph.AddEdge(graph.V(2), graph.V(4), 5);

            graph.AddEdge(graph[4], graph.GetVertex(3), 1);*/

            for (int i = 1; i < graph.VerticesCount; i++)
                graph.AddEdge(graph[0], graph[i], i * 2);

            int offset = 50;
            graph[0].MoveTo(pictureBoxWidth / 2, pictureBoxHeight / 2);
            graph[1].MoveTo(graph[0].X - offset, graph[0].Y - offset);
            graph[2].MoveTo(graph[0].X + offset, graph[0].Y - offset);
            graph[3].MoveTo(graph[0].X - offset, graph[0].Y + offset);
            graph[4].MoveTo(graph[0].X + offset, graph[0].Y + offset);

            graph[5].MoveTo(graph[0].X, graph[0].Y - offset * 2);
            graph[6].MoveTo(graph[0].X + offset * 2, graph[0].Y);
            graph[7].MoveTo(graph[0].X, graph[0].Y + offset * 2);
            graph[8].MoveTo(graph[0].X - offset * 2, graph[0].Y);

            //graph[1, 2].Draw(graphics);

            //graph[0].Draw(graphics);
            //graph[1].Draw(graphics);
            //graph[2].Draw(graphics);
            //graph[3].Draw(graphics);
            //graph[4].Draw(graphics);

            graph.Draw(graphics);
        }
        public static void GraphPositioningTest(Graphics graphics, int pictureBoxWidth, int pictureBoxHeight)
        {
            Graph graph = new Graph(true, 8);
            for (int i = 1; i < 8; i++)
            {
                graph.AddEdge(graph[0], graph[i], i * 3);
            }
            graph.MoveTo(pictureBoxWidth / 2, pictureBoxHeight / 2);
            graph.Draw(graphics);
        }
    }
}
