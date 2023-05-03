using System.Collections.Generic;
using System.Linq;
using System.Text;
using GraphAlgorithmVisualizer.Exceptions;
using GraphAlgorithmVisualizer.MathObjects;

namespace GraphAlgorithmVisualizer.Algorithms
{
    internal class DepthFirstSearch : Algorithm
    { 
        private readonly Dictionary<Vertex, List<Vertex>> outgoingEdges;

        public DepthFirstSearch(Graph graph) : base(graph)
        {
            if (graph.AcceptableDistances != DistanceRange.Natural)
                throw new AlgorithmException("Algorytm wyszukiwania \"wgłąb\" nie może być wykonywany na grafach, które mogą zawierać ujemne lub zerowe dystance na swoich krawędziach.");
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
                foreach (Vertex v in graph.VerticesArray)
                    if (!visited[v])
                        GoDownBranch(v);
        }
        public override void PerformAndCount(Vertex start)
        {
            base.Perform(start);
            outgoingEdges.Clear(); operationsCount++;
            foreach (Vertex v in graph.VerticesArray)
            {
                iterationsCount++;
                outgoingEdges.Add(v, new List<Vertex>()); operationsCount++;
            }

            GoDownBranchAndCount(start);
            while (visited.Values.Contains(false))
            {
                iterationsCount++;
                comparisonsCount++;
                foreach (Vertex v in graph.VerticesArray)
                {
                    iterationsCount++;
                    comparisonsCount++;
                    if (!visited[v])
                        GoDownBranch(v);
                }
            }
        }
        /// <summary>
        /// Performs one iteration of "going down" a branch of the <c>Graph</c> from the starting Vertex.
        /// As it goes down the vertices, it marks them as "visited" and tracks which vertices should be visited next from the current vertex. Once a list of those vertices is fulfilled, method enters a recursion and starts "going down" a branch from each connected Vertex.
        /// Once it reaches a Vertex with no Edges other than the one the algorithm went through to reach this Vertex, it returns.
        /// </summary>
        /// <param name="currentVertex">The starting Vertex from which the method starts from.</param>
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
                    distance[otherEdgesVertex] = distance[currentVertex] + 1;
                    outgoingEdges[matchedEdgesVertex].Add(otherEdgesVertex);
                }
            }
            foreach (Vertex nextVertex in outgoingEdges[currentVertex])
                GoDownBranch(nextVertex);
        }
        /// <summary>
        /// Performs one iteration of "going down" a branch of the <c>Graph</c> from the starting Vertex.
        /// As it goes down the vertices, it marks them as "visited" and tracks which vertices should be visited next from the current vertex. Once a list of those vertices is fulfilled, method enters a recursion and starts "going down" a branch from each connected Vertex.
        /// Once it reaches a Vertex with no Edges other than the one the algorithm went through to reach this Vertex, it returns.
        /// This overload additionally counts the amount of iterations, operations and comparisons performed.
        /// </summary>
        /// <param name="currentVertex">The starting Vertex from which the method starts from.</param>
        private void GoDownBranchAndCount(Vertex currentVertex)
        {
            visited[currentVertex] = true; operationsCount++;
            foreach (Edge edge in graph.EdgesArray)
            {
                iterationsCount++;
                comparisonsCount++;
                if (!edge.IsStartingFrom(currentVertex))
                {
                    continue;
                }
                Vertex matchedEdgesVertex = edge.Start.Equals(currentVertex) ? edge.Start : edge.End; operationsCount++;
                Vertex otherEdgesVertex = edge.Start.Equals(currentVertex) ? edge.End : edge.Start; operationsCount++;
                comparisonsCount++;
                if (!visited[otherEdgesVertex])
                {
                    previousVertex[otherEdgesVertex] = currentVertex; operationsCount++;
                    distance[otherEdgesVertex] = distance[currentVertex] + 1; operationsCount++;
                    outgoingEdges[matchedEdgesVertex].Add(otherEdgesVertex); operationsCount++;
                }
            }
            foreach (Vertex nextVertex in outgoingEdges[currentVertex])
            {
                iterationsCount++;
                GoDownBranchAndCount(nextVertex);
            }
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
