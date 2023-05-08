using System.Collections.Generic;
using GraphAlgorithmVisualizer.Exceptions;
using GraphAlgorithmVisualizer.MathObjects;

namespace GraphAlgorithmVisualizer.Algorithms
{
    internal class BreadthFirstSearch : Algorithm
    {
        public BreadthFirstSearch(Graph graph) : base(graph)
        {
            if (graph.AcceptableDistances != DistanceRange.Natural)
                throw new AlgorithmException("Algorytm wyszukiwania \"wszerz\" nie może być wykonywany na grafach, które mogą zawierać ujemne lub zerowe dystance na swoich krawędziach.");
        }

        public override void Perform(Vertex start)
        {
            base.Perform(start);
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
        public override void PerformAndCount(Vertex start)
        {
            base.Perform(start);
            Queue<Vertex> queue = new Queue<Vertex>(); AssignmentsCount++;
            queue.Enqueue(start); AssignmentsCount++;

            ComparisonsCount++;
            while (queue.Count != 0)
            {
                IterationsCount++;
                Vertex dequeuedVertex = queue.Dequeue(); AssignmentsCount++;
                foreach (Edge edge in graph.EdgesArray)
                {
                    IterationsCount++;
                    ComparisonsCount++;
                    if (!edge.IsStartingFrom(dequeuedVertex))                    
                        continue;
                    Vertex matchedVertex = edge.Start.Equals(dequeuedVertex) ? edge.Start : edge.End; AssignmentsCount++; ComparisonsCount++;
                    Vertex otherVertex = edge.Start.Equals(dequeuedVertex) ? edge.End : edge.Start; AssignmentsCount++; ComparisonsCount++;
                    ComparisonsCount++;
                    if (!queue.Contains(otherVertex) && !visited[otherVertex])
                    {
                        queue.Enqueue(otherVertex); AssignmentsCount++;
                        distance[otherVertex] = distance[matchedVertex] + 1; AssignmentsCount++;
                        previousVertex[otherVertex] = matchedVertex; AssignmentsCount++;
                    }
                }
                visited[dequeuedVertex] = true; AssignmentsCount++;
                ComparisonsCount++;
            }
        }
    }
}
