using System.Collections.Generic;
using System.Linq;
using System.Text;
using GraphAlgorithmVisualizer.Exceptions;
using GraphAlgorithmVisualizer.MathObjects;

namespace GraphAlgorithmVisualizer.Algorithms
{
    internal class DepthFirstSearch
    {
        private readonly Dictionary<Vertex, bool> visited;
        private readonly Dictionary<Vertex, Vertex> previousVertex;
        private readonly Dictionary<Vertex, List<Vertex>> outgoingEdges;
        private readonly Graph graph;

        public bool WasVisited(Vertex v) => visited[v];
        public Vertex PreviousVertexOf(Vertex v) => previousVertex[v];
        public Vertex StartVertex { get; private set; }

        public DepthFirstSearch(Graph graph) 
        { 
            visited = new Dictionary<Vertex, bool>();
            previousVertex = new Dictionary<Vertex, Vertex>();
            outgoingEdges = new Dictionary<Vertex, List<Vertex>>();
            this.graph = graph;
        }

        public void Perform(Vertex start)
        {
            if (!graph.Contains(start))
                throw new GraphException("Start Vertex was not found on Graph's Vertices list.");

            visited.Clear();
            previousVertex.Clear();
            outgoingEdges.Clear();
            StartVertex = start;
            foreach (Vertex v in graph.VerticesArray)
            {
                visited.Add(v, false);
                previousVertex.Add(v, null);
                outgoingEdges.Add(v, new List<Vertex>());
            }

            GoDownBranch(start);
            while (visited.Values.Contains(false))
            {
                foreach (KeyValuePair<Vertex, bool> kvp in visited)
                {
                    if (kvp.Value == false)
                        GoDownBranch(kvp.Key);
                }
            }
        }

        /// <summary>
        /// Performs one iteration of "going down" a branch of the <c>Graph</c> from the starting Vertex.
        /// As it goes down the vertices, it marks them as "visited" and tracks which vertices should be visited next from the current vertex. Once a list of those vertices is fulfilled, method enters a recursion and starts "going down" a branch from each connected Vertex.
        /// Once it reaches a Vertex with no Edges other than the one the algorithm went through to reach this Vertex, it returns.
        /// </summary>
        /// <param name="v">The starting Vertex from which the method starts from.</param>
        private void GoDownBranch(Vertex currentVertex)
        {
            visited[currentVertex] = true;
            foreach (Edge edge in graph.EdgesArray)
            {
                if (!edge.IsStartingFrom(currentVertex))
                    continue;
                Vertex matchedEdgesVertex = edge.Start.Equals(currentVertex) ? edge.Start : edge.End;
                Vertex otherEdgesVertex = edge.Start.Equals(currentVertex) ? edge.End : edge.Start;
                if (!visited[otherEdgesVertex])
                {
                    previousVertex[otherEdgesVertex] = currentVertex;
                    outgoingEdges[matchedEdgesVertex].Add(otherEdgesVertex);
                }
            }
            foreach (Vertex nextVertex in outgoingEdges[currentVertex])
                GoDownBranch(nextVertex);
        }

        /// <returns>
        /// A formatted <c>String</c> of the contents of <c>visited</c> and <c>isCrossroad</c> dictionaries.
        /// </returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("visited Dictionary: ");
            foreach (KeyValuePair<Vertex, bool> pair in visited)
                builder.AppendLine($"\t{pair.Key}\t|\t{pair.Value}");

            builder.AppendLine("previousVertex Dictionary: ");
            foreach (KeyValuePair<Vertex, Vertex> pair in previousVertex)
                builder.AppendLine($"\t{pair.Key}\t|\t{pair.Value}");

            builder.AppendLine("outgoingEdges Dictionary: ");
            foreach (KeyValuePair<Vertex, List<Vertex>> pair in outgoingEdges)
            {
                builder.Append($"\t{pair.Key}\t|\t");
                foreach (Vertex v in pair.Value)
                    builder.Append($"{v} ");
                builder.AppendLine();
            }
            return builder.ToString();
        }
    }
}
