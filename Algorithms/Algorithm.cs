using GraphAlgorithmVisualizer.Exceptions;
using GraphAlgorithmVisualizer.MathObjects;
using System.Collections.Generic;
using System.Text;

namespace GraphAlgorithmVisualizer.Algorithms
{
    internal abstract class Algorithm
    {
        protected Dictionary<Vertex, bool> visited;
        protected Dictionary<Vertex, Vertex> previousVertex;
        protected Graph graph;

        public bool WasVisited(Vertex v) => visited[v];
        public Vertex PreviousVertexOf(Vertex v) => previousVertex[v];
        public Vertex StartVertex { get; protected set; }

        protected Algorithm(Graph graph)
        {
            visited = new Dictionary<Vertex, bool>();
            previousVertex = new Dictionary<Vertex, Vertex>();
            this.graph = graph;
        }

        /// <summary>
        /// Clears all Algorithm inherited Dictionaries of its KeyValuePairs.
        /// </summary>
        protected void ClearDictionaries()
        {
            visited.Clear();
            previousVertex.Clear();
        }
        /// <summary>
        /// Sets StartVertex to the provided Vertex, only if it is a part of the <c>Graph</c>.
        /// </summary>
        /// <param name="v">The Vertex to set as StartVertex.</param>
        /// <exception cref="GraphException">Thrown if the provided Vertex isn't in <c>Graph</c>'s vertices list.</exception>
        protected void SetStartVertex(Vertex v)
        {
            if (!graph.Contains(v))
                throw new GraphException("Start Vertex was not found on Graph's Vertices list.");
            StartVertex = v;
        }
        /// <summary>
        /// Analyzes the <c>Graph</c>and fills the <c>previousVertex</c> and <c>distance</c> dictionaries with algorithm results.
        /// </summary>
        /// <param name="start">The <c>Vertex</c> from the <c>Graph</c> which will be a starting point for the algorithm.</param>
        public abstract void Perform(Vertex start);

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("visited Dictionary: ");
            foreach (KeyValuePair<Vertex, bool> pair in visited)
                builder.AppendLine($"\t{pair.Key}\t|\t{pair.Value}");

            builder.AppendLine("previousVertex Dictionary: ");
            foreach (KeyValuePair<Vertex, Vertex> pair in previousVertex)
                builder.AppendLine($"\t{pair.Key}\t|\t{pair.Value}");
            return builder.ToString();
        }
    }
}
