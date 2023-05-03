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
            Queue<Vertex> queue = new Queue<Vertex>(); assignmentsCount++;
            queue.Enqueue(start); assignmentsCount++;

            comparisonsCount++;
            while (queue.Count != 0)
            {
                iterationsCount++;
                Vertex dequeuedVertex = queue.Dequeue(); assignmentsCount++;
                foreach (Edge edge in graph.EdgesArray)
                {
                    iterationsCount++;
                    comparisonsCount++;
                    if (!edge.IsStartingFrom(dequeuedVertex))                    
                        continue;
                    Vertex matchedVertex = edge.Start.Equals(dequeuedVertex) ? edge.Start : edge.End; assignmentsCount++; comparisonsCount++;
                    Vertex otherVertex = edge.Start.Equals(dequeuedVertex) ? edge.End : edge.Start; assignmentsCount++; comparisonsCount++;
                    comparisonsCount++;
                    if (!queue.Contains(otherVertex) && !visited[otherVertex])
                    {
                        queue.Enqueue(otherVertex); assignmentsCount++;
                        distance[otherVertex] = distance[matchedVertex] + 1; assignmentsCount++;
                        previousVertex[otherVertex] = matchedVertex; assignmentsCount++;
                    }
                }
                visited[dequeuedVertex] = true; assignmentsCount++;
                comparisonsCount++;
            }
        }
    }
}
