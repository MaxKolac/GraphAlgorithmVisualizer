﻿using System.Collections.Generic;
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
            Queue<Vertex> queue = new Queue<Vertex>(); operationsCount++;
            queue.Enqueue(start); operationsCount++;

            while (queue.Count != 0)
            {
                comparisonsCount++;
                iterationsCount++;
                Vertex dequeuedVertex = queue.Dequeue(); operationsCount++;
                foreach (Edge edge in graph.EdgesArray)
                {
                    iterationsCount++;
                    comparisonsCount++;
                    if (!edge.IsStartingFrom(dequeuedVertex))                    
                        continue;
                    Vertex matchedVertex = edge.Start.Equals(dequeuedVertex) ? edge.Start : edge.End; operationsCount++;
                    Vertex otherVertex = edge.Start.Equals(dequeuedVertex) ? edge.End : edge.Start; operationsCount++;
                    comparisonsCount++;
                    if (!queue.Contains(otherVertex) && !visited[otherVertex])
                    {
                        queue.Enqueue(otherVertex); operationsCount++;
                        distance[otherVertex] = distance[matchedVertex] + 1; operationsCount++;
                        previousVertex[otherVertex] = matchedVertex; operationsCount++;
                    }
                }
                visited[dequeuedVertex] = true; operationsCount++;
            }
        }
    }
}
