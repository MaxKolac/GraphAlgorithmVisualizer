using GraphAlgorithmVisualizer.Exceptions;
using System.Collections.Generic;

namespace GraphAlgorithmVisualizer.MathObjects
{
    /// <summary>
    /// Single point of a Graph. It may be connected to another vertex through an <c>Edge</c>.
    /// </summary>
    internal class Vertex
    {
        /// <summary>
        /// Whether or not the <c>Vertex</c> is contained inside a directed <c>Graph</c>. Influences how stages are set and returned.
        /// </summary>
        public readonly bool IsDirectional;
        /// <summary>
        /// In other words, the amount of outgoing directional <c>Edges</c> coming from this <c>Vertex</c>.
        /// </summary>
        public int OutputStage => OutgoingEdges.Count;
        /// <summary>
        /// In other words, the amount of incoming directional <c>Edges</c> coming from this <c>Vertex</c>.
        /// </summary>
        public int InputStage => IncomingEdges.Count;
        /// <summary>
        /// Total amount of incoming and outgoing <c>Edges</c>.
        /// </summary>
        public int Stage => IsDirectional ? OutputStage + InputStage : (OutputStage + InputStage) / 2;
        /// <summary>
        /// List of <c>Edges</c> that are going out of this <c>Vertex</c>
        /// </summary>
        private readonly List<Edge> OutgoingEdges = new List<Edge>();
        /// <summary>
        /// List of <c>Edges</c> that are going into this <c>Vertex</c>
        /// </summary>
        private readonly List<Edge> IncomingEdges = new List<Edge>();

        /// <summary>
        /// Creates a new <c>Vertex</c>.
        /// </summary>
        /// <param name="id">Vertex's unique ID.</param>
        /// <param name="graphIsDirectional">Determines if it should behave as if it was in a directed or undirected Graph.</param>
        public Vertex(bool graphIsDirectional)
        {
            IsDirectional = graphIsDirectional;
        }

        /// <summary>
        /// Informs the <c>Vertex</c> about a new <c>Edge</c> that connects with it.
        /// </summary>
        /// <param name="e">THe <c>Edge</c> object which will be evaluated and added.</param>
        public void AddEdge(Edge e)
        {
            if (!e.Start.Equals(this) && !e.End.Equals(this))
                throw new GraphException("Attempted to give Vertex an Edge which did not contain the aformentioned Vertex on either of its ends.");

            if (e.IsDirectional)
            {
                if (e.Start.Equals(this))
                    OutgoingEdges.Add(e);
                else if (e.Start.Equals(this))
                    IncomingEdges.Add(e);
            }
            else
            {
                IncomingEdges.Add(e);
                OutgoingEdges.Add(e);
            }
        }
    }
}
