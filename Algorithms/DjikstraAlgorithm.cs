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
            djikstraQueue.Enqueue(start);
            foreach (Vertex v in graph.VerticesArray)
                if (!v.Equals(start))
                    djikstraQueue.Enqueue(v);

            do
            {
                //Dequeue the next vertex from Queue.
                Vertex currentVertex = djikstraQueue.Dequeue();
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
                    if (distance[outgoingEdges[i].End] > distance[outgoingEdges[i].Start] + (outgoingEdges[i].Distance ?? 0))
                    {
                        distance[outgoingEdges[i].End] = (int)(distance[outgoingEdges[i].Start] + outgoingEdges[i].Distance);
                        previousVertex[outgoingEdges[i].End] = outgoingEdges[i].Start;
                        djikstraQueue.PushInFront(outgoingEdges[i].End);
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
    }
}
