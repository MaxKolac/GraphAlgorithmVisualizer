using System.Collections.Generic;
using System.Text;
using GraphAlgorithmVisualizer.Exceptions;
using GraphAlgorithmVisualizer.MathObjects;

namespace GraphAlgorithmVisualizer.Algorithms
{
    internal class BreadthFirstSearch
    {
        private readonly Dictionary<Vertex, Vertex> previousVertex;
        private readonly Dictionary<Vertex, int> distance;
        private readonly Dictionary<Vertex, bool> visited;
        private readonly Graph graph;
        
        public Vertex PreviousVertexOf(Vertex vertex) => previousVertex[vertex];
        public int DistanceOf(Vertex vertex) => distance[vertex];
        public bool WasVisited(Vertex vertex) => visited[vertex];
        public Vertex StartVertex { get; private set; }

        public BreadthFirstSearch(Graph graph)
        {
            previousVertex = new Dictionary<Vertex, Vertex>();
            distance = new Dictionary<Vertex, int>();
            visited = new Dictionary<Vertex, bool>();
            this.graph = graph;
        }

        /// <summary>
        /// Analyzes the <c>Graph</c> provided in constructor and fills the <c>previousVertex</c> and <c>distance</c> dictionaries with algorithm results.
        /// </summary>
        /// <param name="start">The <c>Vertex</c> from the <c>Graph</c> which will be a starting point for the algorithm.</param>
        /// <exception cref="System.Exception"></exception>
        public void Perform(Vertex start)
        {
            if (!graph.Contains(start))
                throw new GraphException("Start Vertex was not found on Graph's Vertices list.");

            Queue<Vertex> queue = new Queue<Vertex>();
            previousVertex.Clear();
            distance.Clear();
            visited.Clear();
            StartVertex = start;
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
                    if (!edge.IsStartingFrom(dequeuedVertex))
                        continue;
                    /*if (edge.IsDirectional && !edge.Start.Equals(dequeuedVertex))
                        continue;
                    if (!edge.IsDirectional && !edge.Start.Equals(dequeuedVertex) && !edge.End.Equals(dequeuedVertex))
                        continue;*/
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
