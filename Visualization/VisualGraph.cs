using System;
using System.Collections.Generic;
using System.Drawing;
using GraphAlgorithmVisualizer.Exceptions;
using GraphAlgorithmVisualizer.MathObjects;

namespace GraphAlgorithmVisualizer.Visualization
{
    internal class VisualGraph : VisualObject
    {
        private readonly List<VisualVertex> vertices;
        private readonly List<VisualEdge> edges;
        private readonly bool isDirectional;
        private Point middlePoint;

        public VisualGraph(Graph visualizedGraph, bool isDirectional, int x, int y) : base(x, y)
        {
            vertices = new List<VisualVertex>();
            edges = new List<VisualEdge>();
            middlePoint = new Point(x, y);
            this.isDirectional = isDirectional;
            foreach (Vertex v in visualizedGraph.VerticesArray)
                vertices.Add(new VisualVertex(v, middlePoint));
            foreach (Edge e in visualizedGraph.EdgesArray)
                edges.Add(new VisualEdge(
                    new VisualVertex(e.Start, middlePoint),
                    new VisualVertex(e.End, middlePoint),
                    e.IsDirectional,
                    e.Distance
                    ));
            
        }

        public VisualGraph(Graph visualizedGraph, bool isDirectional, Point position) : 
            this(visualizedGraph, isDirectional, position.X, position.Y)
        { 
        }

        /// <summary>
        /// Adds a new VisualVertex and autogenerates its Index.
        /// </summary>
        /// <param name="x">The X coordinate to place the new VisualVertex at.</param>
        /// <param name="y">The Y coordinate to place the new VisualVertex at.</param>
        public void AddVertex(int x, int y) => AddVertex(vertices.Count, x, y);
        /// <summary>
        /// Adds a new VisualVertex with the specified index.
        /// </summary>
        /// <param name="x">The X coordinate to place the new VisualVertex at.</param>
        /// <param name="y">The Y coordinate to place the new VisualVertex at.</param>
        public void AddVertex(int index, int x, int y)
        {
            foreach (VisualVertex v in vertices)
                if (v.Index == index)
                    throw new GraphException("Attempted to add a VisualVertex to a VisualGraph with an already occupied Index.");
            vertices.Add(new VisualVertex(new Vertex(vertices.Count, isDirectional), x, y));
        }
        public void AddEdge(VisualVertex v1, VisualVertex v2) => AddEdge(new VisualEdge(v1, v2, isDirectional, null));
        public void AddEdge(VisualVertex v1, VisualVertex v2, int distance) => AddEdge(new VisualEdge(v1, v2, isDirectional, distance));
        /// <summary>
        /// Directly adds an <c>VisualEdge</c> object to Edges list.
        /// </summary>
        /// <param name="e">The <c>VisualEdge</c> to be added.</param>
        /// <exception cref="GraphException">Thrown if any of the following is true:
        /// <list type="bullet">
        /// <item>If the list of <c>Vertices</c> doesn't contain one of the vertices the <c>VisualEdge</c> was meant to connect.</item>
        /// <item>If the program attempts to add a directional edge to a undirectional graph and vice versa.</item>
        /// </list>
        /// </exception>
        public void AddEdge(VisualEdge e)
        {
            if (edges.Contains(e))
                Console.WriteLine("Warning! Added a duplicate VisualEdge to the Edges list.");
            if (!vertices.Contains(e.Start) || !vertices.Contains(e.End))
                throw new GraphException("Attempted to add an VisualEdge whose Start/End does not exist in the Vertices list.");
            if (e.IsDirectional == isDirectional)
                throw new GraphException("Attempted to add a mismatching VisualEdge to a VisualGraph. Objects did not have the same value of IsDirectional.");
            edges.Add(e);
        }

        public override void Draw(Graphics canvas)
        {
            //TODO: No need to reinvent the wheel
            // Look up whatever I did in that previous school project
            int n = vertices.Count;
            double TwoPi = Math.PI * 2;
            double angle = 0;
            double singleAngle = 360f / n;

            double cosinus = Math.Cos(2f * Math.PI * (360f / n));
            double sinus = Math.Sin(2f * Math.PI * (360f / n));

            for (int i = 0; i < n; i++)
            {
                
                /*vertices[i].MoveTo(
                    vertices[i].X * cosinus, 
                    vertices[i].Y *
                    );*/
            }
        }
    }
}
