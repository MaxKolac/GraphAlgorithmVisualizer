using GraphAlgorithmVisualizer.MathObjects;
using GraphAlgorithmVisualizer.Visualization.Shapes;
using System;
using System.Collections.Generic;
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
            graph[0].SetPosition(pictureBoxWidth / 2, pictureBoxHeight / 2);
            graph[1].SetPosition(graph[0].X - offset, graph[0].Y - offset);
            graph[2].SetPosition(graph[0].X + offset, graph[0].Y - offset);
            graph[3].SetPosition(graph[0].X - offset, graph[0].Y + offset);
            graph[4].SetPosition(graph[0].X + offset, graph[0].Y + offset);

            graph[5].SetPosition(graph[0].X, graph[0].Y - offset * 2);
            graph[6].SetPosition(graph[0].X + offset * 2, graph[0].Y);
            graph[7].SetPosition(graph[0].X, graph[0].Y + offset * 2);
            graph[8].SetPosition(graph[0].X - offset * 2, graph[0].Y);

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
            Graph graph = new Graph(true, true, 8);
            for (int i = 1; i < graph.VerticesCount; i++)
            {
                graph.AddEdge(graph[0], graph[i], i * 3);
            }
            graph.SetPosition(pictureBoxWidth / 2, pictureBoxHeight / 2);
            graph.ArrangeVerticesInCircle(200);
            graph[0].SetPosition(pictureBoxWidth / 2, pictureBoxHeight / 2);
            graph.Draw(graphics);
        }

        public static void ArrowTest(Graphics graphics, int pictureBoxWidth, int pictureBoxHeight)
        {
            Arrow[] arrows1 = new Arrow[10];
            Point startingPoint = new Point((pictureBoxWidth / 2) - 150, (pictureBoxHeight / 2) - 100);
            Point endingPoint = new Point((pictureBoxWidth / 2) - 150, (pictureBoxHeight / 2) + 100);
            for (int i = 0; i < arrows1.Length; i++)
            {
                arrows1[i] = new Arrow(startingPoint, endingPoint);
                arrows1[i].MovePosition(i * 10, 0);
                arrows1[i].Draw(graphics);
                startingPoint = new Point(startingPoint.X + 50, startingPoint.Y);
                endingPoint = new Point(endingPoint.X + 50, endingPoint.Y);
            }

            Arrow[] arrows2 = new Arrow[9];
            double alpha = Extensions.ToRadians(360d / arrows2.Length);
            double radius = 150;
            Point middlePoint = new Point(pictureBoxWidth / 2, pictureBoxHeight / 2);
            for (int i = 0; i < arrows2.Length; i++)
            {
                double totalAngle = alpha * i;
                arrows2[i] = new Arrow(middlePoint, middlePoint);
                arrows2[i].SetEnd(
                    arrows2[i].Start.X + (int)Math.Round(radius * Math.Cos(totalAngle)),
                    arrows2[i].Start.Y + (int)Math.Round(radius * Math.Sin(totalAngle))
                    );
                arrows2[i].ResetMiddle();
                arrows2[i].Draw(graphics);
            }

        }

        public static void CurvableLineTest(Graphics graphics, int pictureBoxWidth, int pictureBoxHeight)
        {
            List<CurvableLine> lines = new List<CurvableLine>();
            Point startingPoint = new Point((pictureBoxWidth / 2) - 150, (pictureBoxHeight / 2) - 100);
            Point endingPoint = new Point((pictureBoxWidth / 2) - 150, (pictureBoxHeight / 2) + 100);
            for (int i = 0; i < 10; i++)
            {
                Random rnd = new Random();
                lines.Add(rnd.Next(0, 10) < 5 ? new CurvableLine(startingPoint, endingPoint) : new Arrow(startingPoint, endingPoint));
                lines[i].MovePosition(i * 10, 0);
                lines[i].Draw(graphics);
                startingPoint = new Point(startingPoint.X + 50, startingPoint.Y);
                endingPoint = new Point(endingPoint.X + 50, endingPoint.Y);
            }
        }

        public static Graph ExampleDistancedGraph(bool isDirectional)
        {
            Graph graph = new Graph(isDirectional, true, 7);
            graph.AddEdge(graph.V(0), graph.V(1), 4);
            graph.AddEdge(graph.V(1), graph.V(2), 15);
            graph.AddEdge(graph.V(2), graph.V(3), 1);
            graph.AddEdge(graph.V(3), graph.V(4), 4);
            graph.AddEdge(graph.V(4), graph.V(5), 5);
            graph.AddEdge(graph.V(5), graph.V(6), 12);
            graph.AddEdge(graph.V(6), graph.V(0), 2);

            graph.AddEdge(graph.V(2), graph.V(4), 7);
            graph.AddEdge(graph.V(1), graph.V(5), 21);
            graph.AddEdge(graph.V(3), graph.V(6), 1);
            return graph;
        }

        public static Graph ExampleUndistancedGraph(bool isDirectional)
        {
            Graph graph = new Graph(isDirectional, false, 7);
            graph.AddEdge(graph.V(0), graph.V(1));
            graph.AddEdge(graph.V(1), graph.V(2));
            graph.AddEdge(graph.V(2), graph.V(3));
            graph.AddEdge(graph.V(3), graph.V(4));
            graph.AddEdge(graph.V(4), graph.V(5));
            graph.AddEdge(graph.V(5), graph.V(6));
            graph.AddEdge(graph.V(6), graph.V(0));

            graph.AddEdge(graph.V(2), graph.V(4));
            graph.AddEdge(graph.V(1), graph.V(5));
            graph.AddEdge(graph.V(3), graph.V(6));
            return graph;
        }
    }
}
