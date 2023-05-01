using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using GraphAlgorithmVisualizer.Exceptions;
using GraphAlgorithmVisualizer.Utils;
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
        public int X => Position.X;
        public int Y => Position.Y;

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
        /// <param name="usesDistances">Whether or not the Graph will require all Edges to have a non-null distance value.</param>
        public Graph(bool isDirectional, bool usesDistances) : this(isDirectional, usesDistances, 0) 
        {
        }
        /// <summary>
        /// Creates a new Graph with a collection of vertices.
        /// </summary>
        /// <param name="isDirectional">Whether or not the <c>Graph</c> will be directional or not.</param>
        /// <param name="usesDistances">Whether or not the Graph will require all Edges to have a non-null distance value.</param>
        /// <param name="verticesCount">With how many vertices should the <c>Graph</c> be created.</param>
        public Graph(bool isDirectional, bool usesDistances, int verticesCount)
        {
            IsDirectional = isDirectional;
            UsesDistances = usesDistances;
            for (int i = 0; i < verticesCount; i++)
                AddVertex(i);
            Position = new Point(0, 0);
            SetPosition(0, 0);
            ArrangeVerticesInCircle(100);
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
        private void AddVertex(Vertex v)
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
        public void AddEdge(Vertex v1, Vertex v2) => AddEdge(UsesDistances ? new Edge(v1, v2, IsDirectional, 1) : new Edge(v1, v2, IsDirectional));
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
        private void AddEdge(Edge e)
        {
            if (Edges.Contains(e))
                Console.WriteLine("Warning! Added a duplicate Edge to the Edges list.");
            if (!Vertices.Contains(e.Start) || !Vertices.Contains(e.End))
                throw new GraphException("Attempted to add an Edge whose Start/End does not exist in the Vertices list.");
            if (e.IsDirectional != IsDirectional)
                throw new GraphException("Attempted to add a mismatching Edge to a Graph. Objects did not have the same value of IsDirectional.");
            if (UsesDistances && e.Distance is null)
                throw new GraphException("Attempted to add an Edge without a Distance value to a Graph which requires it to be non-null.");
            e.SetStart(GetVertex(e.Start.Index).Position);
            e.SetEnd(GetVertex(e.End.Index).Position);
            e.ResetMiddle();
            if (!UsesDistances && !(e.Distance is null))
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
        /// Returns true, if the Graph contains an Edge that starts from a Vertex with ID of startVertexIndex and ends in a Vertex with ID of endVertexIndex, regardless of its distance.
        /// </summary>
        /// <param name="startVertexIndex">The ID of the Vertex from which the Edge starts.</param>
        /// <param name="endVertexIndex">The ID of the Vertex in which the Edge ends.</param>
        public bool EdgeExists(int startVertexIndex, int endVertexIndex)
        {
            foreach (Edge edge in Edges)
            {
                if (edge.IsStartingFrom(GetVertex(startVertexIndex)) && edge.IsEndingIn(GetVertex(endVertexIndex)))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// A short alias of the GetVertex() method.
        /// </summary>
        public Vertex V(int index) => GetVertex(index);
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
        /// Returns a list of all MathObjects in the Graph that implement ISelectable interface.
        /// </summary>
        public List<ISelectable> GetISelectableMathObjects()
        {
            List<ISelectable> list = new List<ISelectable>();
            list.AddRange(Vertices);
            list.AddRange(Edges);
            return list;
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
        /// Searches and removes the first Vertex object that matches the Vertex provided as an argument.
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
            Vertices.Remove(matchedVertex);

            for (int i = EdgesCount - 1; i >= 0; i--)
                if (Edges[i].Start.Equals(v) || Edges[i].End.Equals(v))
                    Edges.RemoveAt(i);
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
            for (int i = EdgesCount - 1; i >= 0; i--)
                if (Edges[i].Equals(edge)) 
                    Edges.RemoveAt(i);
        }

        /// <summary>
        /// Iterates over all Edges and calls UpdatePointOfEdge() method on each of them;
        /// </summary>
        private void UpdatePointsOfAllEdges() 
        {
            foreach (Edge e in Edges)
            {
                e.SetStart(GetVertex(e.Start.Index).Position);
                e.SetEnd(GetVertex(e.End.Index).Position);
                e.ResetMiddle();
            }
        }

        public void SetPosition(int x, int y)
        {
            int deltaX = x - Position.X;
            int deltaY = y - Position.Y;
            Position = new Point(x, y);

            foreach (Vertex v in Vertices)
                v.MovePosition(deltaX, deltaY);
            UpdatePointsOfAllEdges();
        }
        public void MovePosition(int deltaX, int deltaY) => SetPosition(Position.X + deltaX, Position.Y + deltaY);
        public void Draw(Graphics graphics)
        {
            foreach (Edge e in Edges)
                e.Draw(graphics);
            foreach (Vertex v in Vertices)
                v.Draw(graphics);
        }

        /// <summary>
        /// Arranges vertices visually in a scheme of a circle, with each Vertex being placed same distance away from each other along the circumference.
        /// </summary>
        /// <param name="radius">The radius of the circle.</param>
        public void ArrangeVerticesInCircle(double radius)
        {
            double alpha = Mathx.ToRadians(360d / Vertices.Count);
            for (int i = 0; i < Vertices.Count; i++)
            {
                double totalAngle = alpha * i;
                GetVertex(i).SetPosition(X + (int)Math.Round(radius * Math.Cos(totalAngle)), Y + (int)Math.Round(radius * Math.Sin(totalAngle)));
            }
            UpdatePointsOfAllEdges();
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
