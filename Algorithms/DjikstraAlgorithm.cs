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
