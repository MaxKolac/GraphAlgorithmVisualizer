using System;
using System.Collections.Generic;
using GraphAlgorithmVisualizer.Exceptions;
using GraphAlgorithmVisualizer.MathObjects;

namespace GraphAlgorithmVisualizer.Algorithms
{
    internal class DijkstraAlgorithm : Algorithm
    {
        public DijkstraAlgorithm(Graph graph) : base(graph)
        {
            if (!graph.UsesDistances)
                throw new AlgorithmException("Algorytm Dijkstry może być przeprowadzony tylko na grafach implementujących dystanse.");
            if (graph.AcceptableDistances != DistanceRange.Natural)
                throw new AlgorithmException("Algorytm Dijkstry nie może być wykonywany na grafach, które mogą zawierać ujemne lub zerowe dystance na swoich krawędziach.");
        }

        public override void Perform(Vertex start)
        {
            SetStartVertex(start);
            ClearDictionaries(true);
            distance[start] = 0;

            DijkstraQueue<Vertex> dijkstraQueue = new DijkstraQueue<Vertex>();
            dijkstraQueue.Enqueue(start);
            foreach (Vertex v in graph.VerticesArray)
                if (!v.Equals(start))
                    dijkstraQueue.Enqueue(v);

            do
            {
                //Dequeue the next vertex from Queue.
                Vertex currentVertex = dijkstraQueue.Dequeue();
                visited[currentVertex] = true;

                //Build a list of all Edges starting from that Vertex
                List<Edge> outgoingEdges = new List<Edge>();
                foreach (Edge edge in graph.EdgesArray)
                {
                    if (!edge.IsStartingFrom(currentVertex))
                        continue;
                    outgoingEdges.Add(edge);
                }

                //Sort in descending order
                outgoingEdges.Sort();

                //Iterate over the matched, outgoing edges
                for (int i = 0; i < outgoingEdges.Count; i++)
                {
                    Vertex matchedVertex = outgoingEdges[i].Start == currentVertex ? outgoingEdges[i].Start : outgoingEdges[i].End;
                    Vertex otherVertex = outgoingEdges[i].Start == currentVertex ? outgoingEdges[i].End : outgoingEdges[i].Start;
                    if (distance[otherVertex] > distance[matchedVertex] + (outgoingEdges[i].Distance ?? 0))
                    {
                        distance[otherVertex] = (int)(distance[matchedVertex] + outgoingEdges[i].Distance); 
                        previousVertex[otherVertex] = matchedVertex;
                        dijkstraQueue.PushInFront(otherVertex);
                    }
                }
            } while (!dijkstraQueue.IsEmpty);
        }
        public override void PerformAndCount(Vertex start)
        {
            ResetPerformanceCounters();
            SetStartVertex(start); assignmentsCount++;
            ClearDictionaries(true); assignmentsCount++;
            distance[start] = 0; assignmentsCount++;

            DijkstraQueue<Vertex> dijkstraQueue = new DijkstraQueue<Vertex>(); assignmentsCount++;
            dijkstraQueue.Enqueue(start); assignmentsCount++;
            foreach (Vertex v in graph.VerticesArray)
            {
                iterationsCount++;
                comparisonsCount++;
                if (!v.Equals(start))
                {
                    dijkstraQueue.Enqueue(v); assignmentsCount++;
                }
            }

            do
            {
                //Dequeue the next vertex from Queue.
                Vertex currentVertex = dijkstraQueue.Dequeue(); assignmentsCount++;
                visited[currentVertex] = true; assignmentsCount++;

                //Build a list of all Edges starting from that Vertex
                List<Edge> outgoingEdges = new List<Edge>(); assignmentsCount++;
                foreach (Edge edge in graph.EdgesArray)
                {
                    iterationsCount++;
                    comparisonsCount++;
                    if (!edge.IsStartingFrom(currentVertex))
                        continue;
                    outgoingEdges.Add(edge); assignmentsCount++;
                }

                //Sort in descending order
                //https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.sort?redirectedfrom=MSDN&view=net-7.0#System_Collections_Generic_List_1_Sort
                //According to MSDN documentation, average time complexity is O(n * log n), because the used algorithm is QuickSort.
                //FYI, logarithm's base must be greater than 0
                outgoingEdges.Sort();
                assignmentsCount += outgoingEdges.Count > 0 ? (int)Math.Ceiling(outgoingEdges.Count * Math.Log(outgoingEdges.Count, 2)) : 0;

                //Iterate over the matched, outgoing edges
                for (int i = 0; i < outgoingEdges.Count; i++)
                {
                    iterationsCount++;
                    Vertex matchedVertex = outgoingEdges[i].Start == currentVertex ? outgoingEdges[i].Start : outgoingEdges[i].End; comparisonsCount++; assignmentsCount++;
                    Vertex otherVertex = outgoingEdges[i].Start == currentVertex ? outgoingEdges[i].End : outgoingEdges[i].Start; comparisonsCount++; assignmentsCount++;
                    comparisonsCount++;
                    if (distance[otherVertex] > distance[matchedVertex] + (outgoingEdges[i].Distance ?? 0))
                    {
                        distance[otherVertex] = (int)(distance[matchedVertex] + outgoingEdges[i].Distance); assignmentsCount++;
                        previousVertex[otherVertex] = matchedVertex; assignmentsCount++;
                        dijkstraQueue.PushInFront(
                            otherVertex, 
                            out int queueAssignments, 
                            out int queueComparisons,
                            out int queueIterations); 
                        assignmentsCount += queueAssignments;
                        comparisonsCount += queueComparisons;
                        iterationsCount += queueIterations;
                    }
                }
                iterationsCount++;
                comparisonsCount++;
            } while (!dijkstraQueue.IsEmpty);

            //Console.WriteLine($"iterations: {iterationsCount}\ncomparisons: {comparationsCount}\noperations: {operationsCount}");
            Console.WriteLine($"|E|:{graph.EdgesCount}\t|\t|V|:{graph.VerticesCount}\t|\tOper.:{iterationsCount + assignmentsCount + comparisonsCount}");
        }
    }

    internal class DijkstraQueue<T>
    {
        private readonly Queue<T> queue;
        public int Count => queue.Count;
        public bool IsEmpty => queue.Count == 0;

        public DijkstraQueue()
        {
            queue = new Queue<T>();
        }

        public void Enqueue(T item) => queue.Enqueue(item);
        public T Dequeue() => queue.Dequeue();
        /// <summary>
        /// Swaps the selected item down, closer to the start of the queue by one position.
        /// </summary>
        /// <param name="item">The element that will be pushed down the queue.</param>
        public void PushDown(T item)
        {
            if (!queue.Contains(item)) return;
            if (queue.Peek().Equals(item)) return;

            Queue<T> spareQueue = new Queue<T>();
            while (!queue.Peek().Equals(item))
                spareQueue.Enqueue(queue.Dequeue());

            int queueCount = queue.Count;
            int spareQueueCount = spareQueue.Count;

            for (int i = 0; i < spareQueueCount - 1; i++)
                queue.Enqueue(spareQueue.Dequeue());

            queue.Enqueue(queue.Dequeue());
            queue.Enqueue(spareQueue.Dequeue());

            for (int i = 0; i < queueCount - 1; i++)
                queue.Enqueue(queue.Dequeue());
        }
        /// <summary>
        /// Swaps the selected item down, closer to the start of the queue by one position.
        /// This overload additionally returns the amount of performed iterations, operations and comparisons.
        /// </summary>
        /// <param name="item">The element that will be pushed down the queue.</param>
        public void PushDown(T item, out int performedOperations)
        {
            performedOperations = 1;
            if (!queue.Contains(item)) return;
            performedOperations++;
            if (queue.Peek().Equals(item)) return;

            Queue<T> spareQueue = new Queue<T>(); performedOperations++;
            while (!queue.Peek().Equals(item))
            {
                performedOperations++;
                spareQueue.Enqueue(queue.Dequeue());
                performedOperations += 2;
            }

            int queueCount = queue.Count; performedOperations++;
            int spareQueueCount = spareQueue.Count; performedOperations++;

            for (int i = 0; i < spareQueueCount - 1; i++)
            {
                performedOperations++;
                queue.Enqueue(spareQueue.Dequeue());
                performedOperations += 2;
            }

            queue.Enqueue(queue.Dequeue()); performedOperations += 2;
            queue.Enqueue(spareQueue.Dequeue()); performedOperations += 2;

            for (int i = 0; i < queueCount - 1; i++)
            {
                performedOperations++;
                queue.Enqueue(queue.Dequeue());
                performedOperations += 2;
            }
        }
        /// <summary>
        /// Pushes the selected item down the Queue, in front of all other elements, so that it will become the next element to be dequeued.
        /// </summary>
        /// <param name="item">The item to put in first position, in front of all other elements.</param>
        public void PushInFront(T item)
        {
            if (!queue.Contains(item)) return;
            if (queue.Peek().Equals(item)) return;

            Queue<T> spareQueue = new Queue<T>();
            while (!queue.Peek().Equals(item))
                spareQueue.Enqueue(queue.Dequeue());

            queue.Enqueue(queue.Dequeue());
            int requeuesNeeded = queue.Count - 1;

            int spareQueueCount = spareQueue.Count;
            for (int i = 0; i < spareQueueCount; i++)
                queue.Enqueue(spareQueue.Dequeue());

            for (int i = 0; i < requeuesNeeded; i++)
                queue.Enqueue(queue.Dequeue());
        }
        /// <summary>
        /// Pushes the selected item down the Queue, in front of all other elements, so that it will become the next element to be dequeued.
        /// This overload additionally returns the amount of performed iterations, operations and comparisons.
        /// </summary>
        /// <param name="item">The item to put in first position, in front of all other elements.</param>
        public void PushInFront(T item, out int assignments, out int comparisons, out int iterations)
        {
            assignments = 1; 
            iterations = 0; 
            comparisons = 1;
            if (!queue.Contains(item)) return;
            assignments++;
            comparisons++;
            if (queue.Peek().Equals(item)) return;

            Queue<T> spareQueue = new Queue<T>(); assignments++;
            comparisons++;
            while (!queue.Peek().Equals(item))
            {
                iterations++;
                spareQueue.Enqueue(queue.Dequeue());
                assignments += 2;
            }

            queue.Enqueue(queue.Dequeue()); assignments += 2;
            int requeuesNeeded = queue.Count - 1; assignments++;

            int spareQueueCount = spareQueue.Count; assignments++;
            for (int i = 0; i < spareQueueCount; i++)
            {
                iterations++;
                queue.Enqueue(spareQueue.Dequeue());
                assignments += 2;
            }

            for (int i = 0; i < requeuesNeeded; i++)
            {
                iterations++;
                queue.Enqueue(queue.Dequeue());
                assignments += 2;
            }
        }
    }
}
