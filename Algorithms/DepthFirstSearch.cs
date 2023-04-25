using System.Collections.Generic;
using System.Linq;
using System.Text;
using GraphAlgorithmVisualizer.MathObjects;

namespace GraphAlgorithmVisualizer.Algorithms
{
    internal class DepthFirstSearch : Algorithm
    { 
        private Dictionary<Vertex, List<Vertex>> outgoingEdges;

        public DepthFirstSearch(Graph graph) : base(graph)
        {
            outgoingEdges = new Dictionary<Vertex, List<Vertex>>();
        }

        public override void Perform(Vertex start)
        {
            base.Perform(start);
            outgoingEdges.Clear();
            foreach (Vertex v in graph.VerticesArray)
                outgoingEdges.Add(v, new List<Vertex>());

            GoDownBranch(start);
            while (visited.Values.Contains(false))
            {
                foreach (Vertex v in graph.VerticesArray)
                    if (!visited[v])
                        GoDownBranch(v);
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

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(base.ToString());
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
