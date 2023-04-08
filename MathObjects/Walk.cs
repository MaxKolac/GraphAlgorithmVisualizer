using GraphAlgorithmVisualizer.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace GraphAlgorithmVisualizer.MathObjects
{
    /// <summary>
    /// An ordered collection of vertices and edges that creates a followable path through the graph.
    /// </summary>
    internal class Walk
    {
        /// <summary>
        /// An ordered list of vertices inlucded in the <c>Walk</c>.
        /// </summary>
        public readonly SortedList<int, Vertex> Vertices;
        /// <summary>
        /// An ordered list of edges inlucded in the <c>Walk</c>.
        /// </summary>
        public readonly SortedList<int, Edge> Edges;
        /// <summary>
        /// The mathematical definition of walk's <c>Length</c> is the count of edges this <c>Walk</c> contains.
        /// </summary>
        public int Length => Edges.Count;
        /// <summary>
        /// Which of the mathematical definitions does this walk matches the most.
        /// See also <see cref="WalkType"/>.
        /// </summary>
        //public readonly WalkType Type = WalkType.Walk;
        /// <summary>
        /// The <c>Graph</c> in which this <c>Walk</c> is contained and originated from.
        /// </summary>
        private readonly Graph graph;

        /// <summary>
        /// Creates a new Walk.
        /// </summary>
        /// <param name="graph">The <c>Graph</c> in which this <c>Walk</c> is contained.</param>
        /// <param name="initialVertex">The starting <c>Vertex</c>.</param>
        public Walk(Graph graph, Vertex initialVertex)
        {
            Vertices = new SortedList<int, Vertex>();
            Edges = new SortedList<int, Edge>();
            this.graph = graph;
            Vertices.Add(1, initialVertex);
        }

        public void AddVertex(Vertex addedVertex)
        {
            if (!graph.Contains(addedVertex))
                throw new GraphException("Attempted to add a Vertex which the Graph did not have listed in its Vertecies list.");
            if (graph.IsDirectional && !graph.Contains(new Edge(Vertices.Last().Value, addedVertex, graph.IsDirectional)))
                throw new GraphException("Attempted to add a Vertex which is not on the finish of any directional Edges coming out of the Walk's last added Vertex, according to Graph's Edges list.");
            else if (!graph.IsDirectional && !graph.Contains(new Edge(addedVertex, Vertices.Last().Value, graph.IsDirectional)))
                throw new GraphException("Attempted to add a Vertex which is not on the start or finish of any bidirectional Edges.");
            //Type = CheckType();
            Vertices.Add(Length + 1, addedVertex);
            Edges.Add(Length, new Edge(Vertices.Last().Value, addedVertex, graph.IsDirectional));

        }

        public void AddEdge(Edge addedEdge)
        {
            if (!graph.Contains(addedEdge))
                throw new GraphException("Attempted to add an Edge which the Graph did not have listed in its Edges list.");
            if (!Vertices.Last().Value.Equals(addedEdge.Start))
                throw new GraphException("Attempted to add an Edge which did not start from the Walk's last Vertex.");
            //Type = CheckType();
            Edges.Add(Length, addedEdge);
            Vertices.Add(Length + 1, addedEdge.End);
        }

        /// <summary>
        /// Evaluates the entire Walk and determines which mathematical definition this Walk matches the most.
        /// </summary>
        //private WalkType CheckType()
        //{

        //}
    }

    /// <summary>
    /// Different types of a walk as an enumerator.
    /// </summary>
    public enum WalkType
    {
        /// <summary>
        /// The standard type of a walk, no special attributes.
        /// </summary>
        Walk,
        /// <summary>
        /// Trail is a walk, in which all <c>Edges</c> are distinct.
        /// </summary>
        Trail,
        /// <summary>
        /// Path is a walk, in which all <c>Vertices</c> (and therefore <c>Edges</c>) are distinct.
        /// </summary>
        Path,
        /// <summary>
        /// Cycle is a walk, in which the last <c>Vertex</c> is also its first.
        /// </summary>
        Cycle,
        /// <summary>
        /// Loop is a Cycle with a length of 1.
        /// </summary>
        Loop
    }
}
