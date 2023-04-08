using System;
using System.Collections.Generic;
using System.Text;
using GraphAlgorithmVisualizer.Exceptions;

namespace GraphAlgorithmVisualizer.MathObjects
{
    /// <summary>
    /// By mathematical definition, a non-empty collection of <c>Vertices</c> and <c>Edges</c> that connect them.
    /// </summary>
    internal class Graph 
    {
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
        /// </summary>
        public readonly bool IsDirectional;
        /// <summary>
        /// An array containing all of the <c>Graph</c>'s vertices.
        /// </summary>
        public Vertex[] VerticesArray => Vertices.ToArray();
        /// <summary>
        /// An array containing all of the <c>Graph</c>'s edges.
        /// </summary>
        public Edge[] EdgesArray => Edges.ToArray();
        /// <returns>
        /// A <c>Vertex</c> from the <c>Graph</c>'s vertices list under the provided <c>index</c>.
        /// </returns>
        public Vertex V(int index) => Vertices[index];
        /// <returns>
        /// An <c>Edge</c> from the <c>Graph</c>'s edges list under the provided <c>index</c>.
        /// </returns>
        public Edge E(int index) => Edges[index];
        /// <returns>
        /// The amount of vertices in this <c>Graph</c>.
        /// </returns>
        public int VerticesCount => Vertices.Count;
        /// <returns>
        /// The amount of edges in this <c>Graph</c>.
        /// </returns>
        public int EdgesCount => Edges.Count;

        /// <summary>
        /// Creates a new <c>Graph</c>.
        /// </summary>
        /// <param name="isDirectional">Whether or not the <c>Graph</c> will be directional or not.</param>
        /// <param name="verticesCount">With how many vertices should the <c>Graph</c> be created.</param>
        public Graph(bool isDirectional, int verticesCount)
        {
            IsDirectional = isDirectional;
            for (int i = 0; i < verticesCount; i++)
                AddVertex();
        }

        /// <summary>
        /// Adds a new empty <c>Vertex</c>.
        /// </summary>
        public void AddVertex() => Vertices.Add(new Vertex(IsDirectional));
        /// <summary>
        /// Adds an <c>Edge</c> to connect two <c>Vertices</c>.
        /// </summary>
        /// <param name="e">The <c>Edge</c> to be added.</param>
        /// <exception cref="GraphException">Thrown if any of the following is true:
        /// <list type="bullet">
        /// <item>If the list of <c>Vertices</c> doesn't contain one of the vertices the <c>Edge</c> was meant to connect.</item>
        /// <item>If the program attempts to add a directional edge to a undirectional graph and vice versa.</item>
        /// </list>
        /// </exception>
        public void AddEdge(Edge e)
        {
            if (Edges.Contains(e))
                Console.WriteLine("Warning! Added a duplicate Edge to the Edges list.");
            if (!Vertices.Contains(e.Start) || !Vertices.Contains(e.End))
                throw new GraphException("Attempted to add an Edge whose Start/End does not exist in the Vertices list.");
            Edges.Add(e);
            Vertices[Vertices.IndexOf(e.Start)].AddEdge(e);
            Vertices[Vertices.IndexOf(e.End)].AddEdge(e);
        }
        /// <param name="v">The <c>Vertex</c> to look for in this <c>Graph</c>.</param>
        /// <returns>True, if the <c>Graph</c> contains the provided vertex on its Vertices list.</returns>
        public bool Contains(Vertex v) => Vertices.Contains(v);
        /// <param name="v">The <c>Edge</c> to look for in this <c>Graph</c>.</param>
        /// <returns>True, if the <c>Graph</c> contains the provided edge on its Edges list.</returns>
        public bool Contains(Edge e) => Edges.Contains(e);
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Vertices: ");
            builder.Append("\t{ ");
            for (int i = 0; i < Vertices.Count; i++)
                builder.Append($"{i} ");
            builder.AppendLine("}");
            builder.AppendLine("Edges: ");
            builder.Append("\t{ ");
            for (int i = 0; i < Edges.Count; i++)
            {
                builder.Append($"({Vertices.IndexOf(E(i).Start)}");
                builder.Append(E(i).IsDirectional ? "-->" : "<->");
                builder.Append($"{Vertices.IndexOf(E(i).End)}) ");
            }
            builder.AppendLine("}");
            return builder.ToString();
        }
    }
}
