using System.Collections.Generic;
using System.Text;
using GraphAlgorithmVisualizer.MathObjects;

namespace GraphAlgorithmVisualizer.Algorithms
{
    internal class BreadthFirstSearch : Algorithm
    {
        private readonly Dictionary<Vertex, int> distance;
        public int DistanceOf(Vertex vertex) => distance[vertex];

        public BreadthFirstSearch(Graph graph) : base(graph)
        {
            distance = new Dictionary<Vertex, int>();
        }

        public override void Perform(Vertex start)
        {
            SetStartVertex(start);
            ClearDictionaries();
            distance.Clear();
            Queue<Vertex> queue = new Queue<Vertex>();
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

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(base.ToString());
            builder.AppendLine("distance Dictionary: ");
            foreach (KeyValuePair<Vertex, int> pair in distance)
                builder.AppendLine($"\t{pair.Key}\t|\t{pair.Value}");
            return builder.ToString();
        }
    }
}
