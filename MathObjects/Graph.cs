using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using GraphAlgorithmVisualizer.Exceptions;
using GraphAlgorithmVisualizer.Visualization;

namespace GraphAlgorithmVisualizer.MathObjects
{
    /// <summary>
    /// By mathematical definition, a non-empty collection of <c>Vertices</c> and <c>Edges</c> that connect them.
    /// It may be directional, which means that all of its Edges act as a "one-way" roads.
    /// It may use Distances, which means that all of its Edges make use of an additional property called Distance.
    /// Keep in mind that vertices' IDs of a <c>Graph</c> start from 0.
    /// </summary>
    internal class Graph : IVisualizable
    {
        public Point Position { get; private set; }
        public int X { get { return Position.X; } set { Position = new Point(value, Position.Y); } }
        public int Y { get { return Position.Y; } set { Position = new Point(Position.X, value); } }

        /// <summary>
        /// A List of all <c>Vertices</c> inside the graph.
        /// </summary>
        private readonly List<Vertex> Vertices = new List<Vertex>();
        /// <summary>
        /// A List of all <c>Edges inside the graph.</c>
        /// </summary>
        private readonly List<Edge> Edges = new List<Edge>();
        /// <summary>
        /// Whether or not the <c>Graph</c> is considered to be directional or not.
        /// A directional Graph means that it only accepts directional Edges. Directional Edges act as a "one-way" roads - algorithm travel is only allowed from its Start to End. Undirectional Graph, and therefore undirectional Edges, allow the algorithms to travel both ways.
        /// </summary>
        public readonly bool IsDirectional;
        /// <summary>
        /// Whether or not the Edges are required to implement a non-zero, non-null Distance value.
        /// </summary>
        public readonly bool UsesDistances;

        /// <summary>
        /// Indexer which acts as a shortcut to GetVertex() method.
        /// </summary>
        public Vertex this[int index] => GetVertex(index);
        /// <summary>
        /// Indexer which acts as a shortcut to GetEdge() method.
        /// </summary>
        public Edge this[int index1, int index2] => GetEdge(index1, index2);

        /// <summary>
        /// An array containing all of the <c>Graph</c>'s vertices.
        /// </summary>
        public Vertex[] VerticesArray => Vertices.ToArray();
        /// <summary>
        /// An array containing all of the <c>Graph</c>'s edges.
        /// </summary>
        public Edge[] EdgesArray => Edges.ToArray();
        /// <returns>
        /// The amount of vertices in this <c>Graph</c>.
        /// </returns>
        public int VerticesCount => Vertices.Count;
        /// <returns>
        /// The amount of edges in this <c>Graph</c>.
        /// </returns>
        public int EdgesCount => Edges.Count;

        /// <summary>
        /// Creates a new empty Graph.
        /// </summary>
        /// <param name="isDirectional">Whether or not the <c>Graph</c> will be directional or not.</param>
        public Graph(bool isDirectional, bool usesDistances) : this(isDirectional, usesDistances, 0) 
        {
        }
        /// <summary>
        /// Creates a new Graph with a collection of vertices.
        /// </summary>
        /// <param name="isDirectional">Whether or not the <c>Graph</c> will be directional or not.</param>
        /// <param name="verticesCount">With how many vertices should the <c>Graph</c> be created.</param>
        public Graph(bool isDirectional, bool usesDistances, int verticesCount)
        {
            IsDirectional = isDirectional;
            UsesDistances = usesDistances;
            for (int i = 0; i < verticesCount; i++)
                AddVertex(i);
        }

        /// <summary>
        /// Appens a new Vertex and autofills its ID to be the amount of vertices.
        /// </summary>
        public void AddVertex() => AddVertex(Vertices.Count);
        /// <summary>
        /// Adds a new <c>Vertex</c> with a specified identifier in the form of an index.
        /// </summary>
        public void AddVertex(int index) => AddVertex(new Vertex(index, IsDirectional));
        /// <summary>
        /// Directly adds a Vertex object to the Vertices list.
        /// </summary>
        /// <param name="v">The Vertex to add.</param>
        /// <exception cref="GraphException">Thrown if a Vertex with the Index of the addedVertex already exists.</exception>
        public void AddVertex(Vertex v)
        {
            foreach (Vertex existingVertex in Vertices)
                if (v.Index == existingVertex.Index)
                    throw new GraphException("Attempted to add a Vertex to a Graph with an already occupied Index.");
            Vertices.Add(v);
        }

        /// <summary>
        /// Creates a new <c>Edge</c> between two vertices and adds it to the Edges list. If this method is called on a Graph utilizing Distances, new Edge's Distance will be set to 0.
        /// </summary>
        /// <param name="v1">Start Vertex of the Edge.</param>
        /// <param name="v2">End Vertex of the Edge.</param>
        public void AddEdge(Vertex v1, Vertex v2) => AddEdge(UsesDistances ? new Edge(v1, v2, IsDirectional, 0) : new Edge(v1, v2, IsDirectional));
        /// <summary>
        /// Creates a new <c>Edge</c> between two vertices and adds it to the Edges list. This method assigns the new Edge the specified distance. If distances aren't utilized by the Graph, distance is ignored.
        /// </summary>
        /// <param name="v1">Start Vertex of the Edge.</param>
        /// <param name="v2">End Vertex of the Edge.</param>
        /// <param name="distance">The distance of the new Edge.</param>
        public void AddEdge(Vertex v1, Vertex v2, int distance) => AddEdge(UsesDistances ? new Edge(v1, v2, IsDirectional, distance) : new Edge(v1, v2, IsDirectional));
        /// <summary>
        /// Directly adds an copy of <c>Edge</c> object to Edges list.
        /// </summary>
        /// <param name="e">The <c>Edge</c> to be added.</param>
        public void AddEdge(Edge e)
        {
            if (Edges.Contains(e))
                Console.WriteLine("Warning! Added a duplicate Edge to the Edges list.");
            if (!Vertices.Contains(e.Start) || !Vertices.Contains(e.End))
                throw new GraphException("Attempted to add an Edge whose Start/End does not exist in the Vertices list.");
            if (e.IsDirectional != IsDirectional)
                throw new GraphException("Attempted to add a mismatching Edge to a Graph. Objects did not have the same value of IsDirectional.");
            if (UsesDistances && e.Distance is null)
                throw new GraphException("Attempted to add an Edge without a Distance value to a Graph which requires it to be non-null.");
            else if (!UsesDistances && !(e.Distance is null))
            {
                Console.WriteLine("Warning! Added an Edge with a Distance to a Graph which doesn't utilize Distances! Overwriting it to be null!");
                Edges.Add(new Edge(e.Start, e.End, IsDirectional));
                return;
            }
            Edges.Add(e);
        }

        /// <param name="v">The <c>Vertex</c> to look for in this <c>Graph</c>.</param>
        /// <returns>True, if the <c>Graph</c> contains the provided vertex on its Vertices list.</returns>
        public bool Contains(Vertex v) => Vertices.Contains(v);
        /// <param name="v">The <c>Edge</c> to look for in this <c>Graph</c>.</param>
        /// <returns>True, if the <c>Graph</c> contains the provided edge on its Edges list.</returns>
        public bool Contains(Edge e)
        {
            if (IsDirectional) return Edges.Contains(e);
            return e.Distance is null ?
                Edges.Contains(e) || Edges.Contains(new Edge(e.End, e.Start, IsDirectional)) :
                Edges.Contains(e) || Edges.Contains(new Edge(e.End, e.Start, IsDirectional, (int)e.Distance));
        }

        /// <summary>
        /// A short alias of the GetVertex() method.
        /// </summary>
        public Vertex V(int index) => GetVertex(index);
        /// <summary>
        /// A short alias of the GetEdge() method.
        /// </summary>
        /// <summary>
        /// Removes the lastly added Vertex and all Edges connected to it.
        /// </summary>
        public Edge E(int startVertexIndex, int endVertexIndex) => GetEdge(startVertexIndex, endVertexIndex);
        /// <param name="index">The Index to look for in the Vertices list.</param>
        /// <returns>Vertex with the specified Index.</returns>
        /// <exception cref="GraphException">Thrown if no Vertex with such Index is found.</exception>
        public Vertex GetVertex(int index)
        {
            foreach (Vertex v in Vertices)
                if (v.Index == index) 
                    return v;
            throw new GraphException("Could not find a Vertex with the specified Index.");
        }
        /// <param name="startVertexIndex">The Index of the Start Vertex.</param>
        /// <param name="endVertexIndex">The Index of the End Vertex.</param>
        /// <returns>An Edge object which can be considered to start from the starting Vertex and end in the ending Vertex.</returns>
        /// <exception cref="GraphException">Thrown if no matching Edge was found in Edges list.</exception>
        public Edge GetEdge(int startVertexIndex, int endVertexIndex)
        {
            foreach (Edge e in Edges)
                if (e.IsStartingFrom(GetVertex(startVertexIndex)) && e.IsEndingIn(GetVertex(endVertexIndex)))
                    return e;
            throw new GraphException("Could not find an Edge which would start and end in the provided vertices.");

        }

        /// <summary>
        /// Removes the last added Vertex and all Edges connected to it.
        /// </summary>
        public void RemoveVertex() => RemoveVertex(Vertices.Count - 1);
        /// <summary>
        /// Removes the Vertex with the matching Index and all connected Edges.
        /// </summary>
        /// <param name="index">The Index of the Vertex to remove.</param>
        /// <exception cref="GraphException">Thrown if program couldn't find a matching Vertex or if the Graph's Vertices list was empty.</exception>
        /// <exception cref="IndexOutOfRangeException">Thrown if index was out of Vertices List's bounds.</exception>
        public void RemoveVertex(int index)
        {
            if (Vertices.Count == 0)
                throw new GraphException("Attempted to remove a Vertex from a Graph with no vertices");
            if (index < 0 || Vertices.Count <= index)
                throw new IndexOutOfRangeException("index");
            RemoveVertex(GetVertex(index));
        }
        /// <summary>
        /// Searches and removes the first Vertex object that matches the Vertex provided as an arguemtn.
        /// </summary>
        /// <exception cref="GraphException">Thrown if no matching Vertex to remove was found.</exception>
        public void RemoveVertex(Vertex v)
        {
            Vertex matchedVertex = null;
            foreach (Vertex existingVertex in Vertices)
            {
                if (v.Index == existingVertex.Index)
                {
                    matchedVertex = v;
                    break;
                }
            }
            if (matchedVertex is null)
                throw new GraphException("Could not find a Vertex with the specified Index to remove.");

            foreach (Edge e in Edges)
            {
                if (e.Start.Equals(v) || e.End.Equals(v))
                    Edges.Remove(e);
            }
        }

        /// <summary>
        /// Removes an Edge with matching Start and End vertices from the Edges list.
        /// </summary>
        /// <param name="v1">The Start Vertex of the Edge to remove.</param>
        /// <param name="v2">The End Vertex of the Edge to remove.</param>
        public void RemoveEdge(Vertex v1, Vertex v2) => RemoveEdge(new Edge(v1, v2, IsDirectional));
        /// <summary>
        /// Removes an Edge with matching Start and End vertices from the Edges list.
        /// </summary>
        /// <param name="v1">The Start Vertex of the Edge to remove.</param>
        /// <param name="v2">The End Vertex of the Edge to remove.</param>
        /// <param name="distance">The Distance of the Edge to remove.</param>
        public void RemoveEdge(Vertex v1, Vertex v2, int distance) => RemoveEdge(new Edge(v1, v2, IsDirectional, distance));
        /// <summary>
        /// Removes the specified Edge from the Edges list.
        /// </summary>
        /// <param name="edge">The Edge object to remove.</param>
        public void RemoveEdge(Edge edge)
        {
            foreach (Edge e in Edges)
            {
                if (e.Equals(edge))
                    Edges.Remove(edge);
            }
        }

        /// <summary>
        /// Graph's implementation of MoveTo() method moves its own Position and also moves all of its Vertices' positions by the delta of Graph's its own position.
        /// </summary>
        /// <param name="x">The X coordinate of Graph's new position.</param>
        /// <param name="y">The Y coordinate of Graph's new position.</param>
        public void MoveTo(int x, int y)
        {
            int deltaX = Position.X - x;
            int deltaY = Position.Y - y;
            Position = new Point(x, y);

            foreach (Vertex v in Vertices)
                v.MoveTo(v.X + deltaX, v.Y + deltaY);
        }
        public void Draw(Graphics graphics)
        {
            foreach (Edge e in Edges)
                e.Draw(graphics);
            foreach (Vertex v in Vertices)
                v.Draw(graphics);
        }
        /// <summary>
        /// Arranges vertices visually in a scheme of a circle, with each Vertex being placed on the edge of that circle, placed apart from each other the same distance.
        /// </summary>
        /// <param name="radius">The radius of the circle.</param>
        public void ArrangeVerticesInCircle(double radius)
        {
            double alpha = Extensions.ToRadians(360d / Vertices.Count);
            for (int i = 0; i < Vertices.Count; i++)
            {
                double totalAngle = alpha * i;
                GetVertex(i).MoveTo(X + (int)Math.Round(radius * Math.Cos(totalAngle)), Y + (int)Math.Round(radius * Math.Sin(totalAngle)));
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Vertices: ");
            builder.Append("\t{ ");
            foreach (Vertex v in Vertices)
                builder.Append($"{v} ");
            builder.AppendLine("}");
            builder.AppendLine("Edges: ");
            builder.Append("\t{ ");
            foreach (Edge e in Edges)
                builder.Append($"{e} ");
            builder.AppendLine("}");
            return builder.ToString();
        }
    }
}
