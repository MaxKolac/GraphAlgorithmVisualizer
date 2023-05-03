using System;
using GraphAlgorithmVisualizer.Exceptions;
using GraphAlgorithmVisualizer.MathObjects;

namespace GraphAlgorithmVisualizer.Algorithms
{
    internal class BellmanFordAlgorithm : Algorithm
    {
        public BellmanFordAlgorithm(Graph graph) : base(graph)
        {
            if (graph.AcceptableDistances != DistanceRange.FullExceptZero && graph.AcceptableDistances != DistanceRange.Natural)
                throw new AlgorithmException("Algorytm Bellmana-Forda może być wykonywany tylko na grafach, które zawierają jedynie ujemne i/lub dodatnie wartości Dystansów swoich krawędzi, z wykluczeniem zera.");
        }

        public override void Perform(Vertex start)
        {
            base.Perform(start);
            throw new NotImplementedException();
        }
        public override void PerformAndCount(Vertex start)
        {
            base.PerformAndCount(start);
            throw new NotImplementedException();
        }
    }
}
