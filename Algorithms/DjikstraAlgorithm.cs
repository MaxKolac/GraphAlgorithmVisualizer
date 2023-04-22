using System.Collections.Generic;
using GraphAlgorithmVisualizer.Exceptions;
using GraphAlgorithmVisualizer.MathObjects;

namespace GraphAlgorithmVisualizer.Algorithms
{
    internal class DjikstraAlgorithm : Algorithm
    {
        public DjikstraAlgorithm(Graph graph) : base(graph)
        {
            if (!graph.UsesDistances)
                throw new GraphException("Attempted to associate a Graph without distances with an instance of DjikstraAlgorithm class.");
        }

        public override void Perform(Vertex start)
        {
            SetStartVertex(start);
            ClearDictionaries(true);
            distance[start] = 0;

            DjikstraQueue<Vertex> djikstraQueue = new DjikstraQueue<Vertex>();
            foreach (Vertex v in graph.VerticesArray)
                djikstraQueue.Enqueue(v);

            do
            {
                Vertex currentVertex = djikstraQueue.Dequeue();
                visited[currentVertex] = true;
                foreach (Edge edge in graph.EdgesArray)
                {
                    if (!edge.IsStartingFrom(currentVertex))
                        continue;
                    Vertex matchedEdgesVertex = edge.Start.Equals(currentVertex) ? edge.Start : edge.End;
                    Vertex otherEdgesVertex = edge.Start.Equals(currentVertex) ? edge.End : edge.Start;
                    if (distance[otherEdgesVertex] > distance[matchedEdgesVertex] + edge.Distance)
                    {
                        distance[otherEdgesVertex] = distance[matchedEdgesVertex] + (edge.Distance ?? 0);
                        previousVertex[otherEdgesVertex] = matchedEdgesVertex;
                        djikstraQueue.PushDown(otherEdgesVertex);
                    }
                }
            } while (!djikstraQueue.IsEmpty);
        }
    }

    internal class DjikstraQueue<T>
    {
        private readonly Queue<T> queue;
        public int Count => queue.Count;
        public bool IsEmpty => queue.Count == 0;

        public DjikstraQueue()
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
    }
}
