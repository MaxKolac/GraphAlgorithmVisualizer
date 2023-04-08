using GraphAlgorithmVisualizer.Exceptions;
using System.Collections.Generic;
using System.Diagnostics;

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
        public readonly List<Vertex> Vertices = new List<Vertex>();
        /// <summary>
        /// A List of all <c>Edges inside the graph.</c>
        /// </summary>
        public readonly List<Edge> Edges = new List<Edge>();
        /// <summary>
        /// Whether or not the <c>Graph</c> is considered to be directional or not.
        /// </summary>
        public readonly bool IsDirectional;

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
                Debug.Write("Warning! Added a duplicate Edge to the Edges list.");
            if (!Vertices.Contains(e.Start) || !Vertices.Contains(e.End))
                throw new GraphException("Attempted to add an Edge whose Start/End does not exist in the Vertices list.");
            Edges.Add(e);
        }
    }
}
