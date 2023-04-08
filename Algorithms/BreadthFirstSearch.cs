using GraphAlgorithmVisualizer.MathObjects;
using System.Collections.Generic;

namespace GraphAlgorithmVisualizer.Algorithms
{
    internal class BreadthFirstSearch
    {
        /*public static List<BFSRecord> PeformOn(Graph graph, Vertex start)
        {
            List<BFSRecord> results = new List<BFSRecord>();
            foreach (Vertex vertex in graph.Vertices)
            {
                results.Add(new BFSRecord(vertex, null, int.MaxValue));
            }
            SpecialQueue<Vertex> queue = new SpecialQueue<Vertex>(graph.Vertices.Count);
            queue.Inject(start);

            while (queue.Size > 0)
            {
                Vertex ejectedVertex = queue.Eject();
                foreach (Edge edge in graph.Edges)
                {
                    if (results.Find))
                }
            }
        }*/
    }

    internal class BFSRecord
    {
        public Vertex Vertex;
        public Vertex PreviousVertex;
        public int Distance;

        public BFSRecord(Vertex vertex, Vertex previousVertex, int distance)
        {
            Vertex = vertex;
            PreviousVertex = previousVertex;
            Distance = distance;
        }
    }
}
