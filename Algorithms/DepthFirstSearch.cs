using System.Collections.Generic;
using System.Text;
using GraphAlgorithmVisualizer.Exceptions;
using GraphAlgorithmVisualizer.MathObjects;

namespace GraphAlgorithmVisualizer.Algorithms
{
    internal class DepthFirstSearch
    {
        private readonly Dictionary<Vertex, bool> visited;
        private readonly Dictionary<Vertex, int> outgoingUnvisitedEdges;
        private readonly Graph graph;

        public bool WasVisited(Vertex v) => visited[v];
        public bool IsCrossroad(Vertex v) => outgoingUnvisitedEdges[v];
        public Vertex StartVertex { get; private set; }

        public DepthFirstSearch(Graph graph) 
        { 
            visited = new Dictionary<Vertex, bool>();
            outgoingUnvisitedEdges = new Dictionary<Vertex, int>();
            this.graph = graph;
        }

        public void Perform(Vertex start)
        {
            if (!graph.Contains(start))
                throw new GraphException("Start Vertex was not found on Graph's Vertices list.");

            visited.Clear();
            outgoingUnvisitedEdges.Clear();
            StartVertex = start;
            foreach (Vertex v in graph.VerticesArray)
            {
                visited.Add(v, false);
                outgoingUnvisitedEdges.Add(v, 0);
            }

            GoDownBranch(start);
            bool continueLoop = true;
            while (continueLoop)
            {
                continueLoop = false;
                foreach (Vertex vertex in graph.VerticesArray)
                {
                    ///////??????/
                    if (!visited[vertex])
                    {
                        continueLoop = true;
                        GoDownBranch(vertex);
                    }
                }
            }
        }

        /// <summary>
        /// Performs one iteration of "going down" a branch of the <c>Graph</c> from the starting Vertex.
        /// As it goes down the vertices, it marks them as "visited" and whether or not they are considered "crossroads" a.k.a. have more than 1 Edge coming out of them and will need to be revisited again.
        /// Once it reaches a Vertex with no Edges other than the one the algorithm went through to reach this Vertex, it returns.
        /// </summary>
        /// <param name="v">The starting Vertex from which the method starts from.</param>
        private void GoDownBranch(Vertex v)
        {
            Vertex currentVertex = v;
            Vertex matchedEdgesVertex = null;
            Vertex otherEdgesVertex = null;
            //List<Edge> connectingUnvisitedEdges = new List<Edge>();

            do
            {
                visited[currentVertex] = true;
                //connectingUnvisitedEdges.Clear();

                foreach (Edge edge in graph.EdgesArray)
                {
                    if (!edge.IsStartingFrom(currentVertex))
                        continue;
                    matchedEdgesVertex = edge.Start.Equals(currentVertex) ? edge.Start : edge.End;
                    otherEdgesVertex = edge.Start.Equals(currentVertex) ? edge.End : edge.Start;
                    if (!visited[otherEdgesVertex])
                        //connectingUnvisitedEdges.Add(edge);
                        outgoingUnvisitedEdges[matchedEdgesVertex]++;
                }
                //if (connectingUnvisitedEdges.Count >= 1)
                if (outgoingUnvisitedEdges[matchedEdgesVertex] > 0)
                    currentVertex = otherEdgesVertex;
                //if (connectingUnvisitedEdges.Count > 1)
                //outgoingUnvisitedEdges[currentVertex] = true;
                //} while (connectingUnvisitedEdges.Count > 0);
            } while (outgoingUnvisitedEdges[currentVertex] > 0);
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

            builder.AppendLine("isCrossroad Dictionary: ");
            foreach (KeyValuePair<Vertex, bool> pair in outgoingUnvisitedEdges)
                builder.AppendLine($"\t{pair.Key}\t|\t{pair.Value}");
            return builder.ToString();
        }
    }
}
