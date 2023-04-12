using GraphAlgorithmVisualizer.MathObjects;
using System.Text;

namespace GraphAlgorithmVisualizer.Algorithms
{
    internal class DjikstraAlgorithm : Algorithm
    {
        public DjikstraAlgorithm(Graph graph) : base(graph)
        {
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
            return builder.ToString();
        }
    }
}
