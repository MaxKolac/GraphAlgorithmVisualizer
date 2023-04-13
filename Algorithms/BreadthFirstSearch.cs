using System.Collections.Generic;
using GraphAlgorithmVisualizer.MathObjects;

namespace GraphAlgorithmVisualizer.Algorithms
{
    internal class BreadthFirstSearch : Algorithm
    {
        public BreadthFirstSearch(Graph graph) : base(graph)
        {
        }

        public override void Perform(Vertex start)
        {
            SetStartVertex(start);
            ClearDictionaries();
            Queue<Vertex> queue = new Queue<Vertex>();
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

        public override string ToString() => base.ToString();
    }
}
