using GraphAlgorithmVisualizer.MathObjects;
using System.Collections.Generic;

namespace GraphAlgorithmVisualizer.Algorithms
{
    internal class BreadthFirstSearch
    {
        public static void Perform(Graph graph, Vertex start, out Dictionary<Vertex, Vertex> previousVertex, out Dictionary<Vertex, int> distance)
        {
            previousVertex = new Dictionary<Vertex, Vertex>();
            distance = new Dictionary<Vertex, int>();
            Queue<Vertex> queue = new Queue<Vertex>();
            if (!graph.Contains(start))
                throw new System.Exception("Start Vertex was not found on Graph's Vertices list.");

            foreach (Vertex vertex in graph.VerticesArray)
            {
                previousVertex.Add(vertex, null);
                distance.Add(vertex, int.MaxValue);
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
                    else if (!edge.IsDirectional && (!edge.Start.Equals(dequeuedVertex) || !edge.End.Equals(dequeuedVertex)))
                        continue;
                    else
                    {
                        Vertex matchedVertex = edge.Start.Equals(dequeuedVertex) ? edge.Start : edge.End;
                        Vertex otherVertex = edge.Start.Equals(dequeuedVertex) ? edge.End : edge.Start;
                        if (distance[matchedVertex] == int.MaxValue)
                        {
                            queue.Enqueue(matchedVertex);
                            distance[matchedVertex] = distance[otherVertex] + 1;
                            previousVertex[matchedVertex] = otherVertex;
                        }
                    }
                }
            }
        }
    }
}
