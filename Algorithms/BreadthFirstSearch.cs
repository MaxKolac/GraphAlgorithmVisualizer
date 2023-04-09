using System.Collections.Generic;
using System.Text;
using GraphAlgorithmVisualizer.Exceptions;
using GraphAlgorithmVisualizer.MathObjects;

namespace GraphAlgorithmVisualizer.Algorithms
{
    internal class BreadthFirstSearch
    {
        private Dictionary<Vertex, Vertex> previousVertex;
        private Dictionary<Vertex, int> distance;
        private Dictionary<Vertex, bool> visited;

        public BreadthFirstSearch()
        {
            previousVertex = new Dictionary<Vertex, Vertex>();
            distance = new Dictionary<Vertex, int>();
            visited = new Dictionary<Vertex, bool>();
        }

        /// <summary>
        /// Analyzes the provided <c>Graph</c> and fills the <c>previousVertex</c> and <c>distance</c> dictionaries with algorithm results.
        /// </summary>
        /// <param name="graph">The <c>Graph</c> object to analyze.</param>
        /// <param name="start">The <c>Vertex</c> from the <c>Graph</c> which will be a starting point for the algorithm.</param>
        /// <exception cref="System.Exception"></exception>
        public void Perform(Graph graph, Vertex start)
        {
            previousVertex = new Dictionary<Vertex, Vertex>();
            distance = new Dictionary<Vertex, int>();
            visited = new Dictionary<Vertex, bool>();
            Queue<Vertex> queue = new Queue<Vertex>();
            if (!graph.Contains(start))
                throw new GraphException("Start Vertex was not found on Graph's Vertices list.");

            foreach (Vertex vertex in graph.VerticesArray)
            {
                previousVertex.Add(vertex, null);
                distance.Add(vertex, 0);
                visited.Add(vertex, false);
            }

            distance[start] = 0;
            queue.Enqueue(start);

            while (queue.Count != 0)
            {
                Vertex dequeuedVertex = queue.Dequeue();
                foreach (Edge edge in graph.EdgesArray)
                {
                    if (edge.IsDirectional && !edge.Start.Equals(dequeuedVertex))
                        continue;
                    if (!edge.IsDirectional && !edge.Start.Equals(dequeuedVertex) && !edge.End.Equals(dequeuedVertex))
                        continue;
                    Vertex matchedVertex = edge.Start.Equals(dequeuedVertex) ? edge.Start : edge.End;
                    Vertex otherVertex = edge.Start.Equals(dequeuedVertex) ? edge.End : edge.Start;
                    if (!queue.Contains(otherVertex) && !visited[otherVertex])
                    {
                        queue.Enqueue(otherVertex);
                        distance[otherVertex] = distance[matchedVertex] + 1;
                        previousVertex[otherVertex] = matchedVertex;
                    }
                }
                visited[dequeuedVertex] = true;
            }
        }
        /// <returns>
        /// A formatted <c>String</c> of the contents of <c>previousVertex</c> and <c>distance</c> dictionaries.
        /// </returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("previousVertex Dictionary: ");
            foreach (KeyValuePair<Vertex, Vertex> pair in previousVertex)
                builder.AppendLine($"\t{pair.Key}\t|\t{pair.Value}");

            builder.AppendLine("distance Dictionary: ");
            foreach (KeyValuePair<Vertex, int> pair in distance)
                builder.AppendLine($"\t{pair.Key}\t|\t{pair.Value}");
            
            builder.AppendLine("visited Dictionary: ");
            foreach (KeyValuePair<Vertex, bool> pair in visited)
                builder.AppendLine($"\t{pair.Key}\t|\t{pair.Value}");
            return builder.ToString();
        }
    }
}
