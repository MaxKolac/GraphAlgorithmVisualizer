using GraphAlgorithmVisualizer.MathObjects;
using System.Text;

namespace GraphAlgorithmVisualizer.Algorithms
{
    internal class DjikstraAlgorithm : Algorithm
    {
        private readonly PriorityHeap<Vertex> heap;

        public DjikstraAlgorithm(Graph graph) : base(graph)
        {
            heap = new PriorityHeap<Vertex>();
        }

        public override void Perform(Vertex start)
        {
            SetStartVertex(start);
            ClearDictionaries();

            heap.Clear();
            foreach (Vertex v in graph.VerticesArray)
                heap.Insert(v);

            do
            {
                Vertex currentVertex = heap.DeleteMin();
                visited[currentVertex] = true;
                foreach (Edge edge in graph.EdgesArray)
                {
                    if (!edge.IsStartingFrom(currentVertex))
                        continue;
                    if (distance[edge.End] > distance[edge.Start] + edge.Distance)
                    {
                        distance[edge.End] = distance[edge.Start] + (edge.Distance ?? 0);
                        previousVertex[edge.End] = edge.Start;
                        heap.DecreaseKey(edge.End);
                    }
                }
            } while (!heap.IsEmpty);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(base.ToString());
            builder.AppendLine("heap contents: ");
            builder.AppendLine(heap.ToString());
            return builder.ToString();
        }
    }
}
