using System;
using GraphAlgorithmVisualizer.MathObjects;

namespace GraphAlgorithmVisualizer.Algorithms
{
    internal class AlgorithmTests
    {
        public static void BFSTest()
        {
            Graph graph = new Graph(false, 5);
            graph.AddEdge(graph.V(0), graph.V(1));
            graph.AddEdge(graph.V(0), graph.V(4));

            graph.AddEdge(graph.V(1), graph.V(2));
            graph.AddEdge(graph.V(1), graph.V(3));

            graph.AddEdge(graph.V(2), graph.V(4));
            graph.AddEdge(graph.V(2), graph.V(3));

            graph.AddEdge(graph.V(3), graph.V(4));

            Console.WriteLine(graph.ToString());
            Console.ReadKey();

            BreadthFirstSearch bfs = new BreadthFirstSearch(graph);
            bfs.Perform(graph.V(2));
            Console.WriteLine(bfs.ToString());
            Console.ReadKey();
        }

        public static void DFSTest()
        {
            Graph graph = new Graph(false, 13);
            graph.AddEdge(graph.V(0), graph.V(1));
            graph.AddEdge(graph.V(0), graph.V(2));

            graph.AddEdge(graph.V(1), graph.V(3));
            graph.AddEdge(graph.V(1), graph.V(4));

            graph.AddEdge(graph.V(2), graph.V(6));
            graph.AddEdge(graph.V(2), graph.V(12));

            graph.AddEdge(graph.V(3), graph.V(5));
            graph.AddEdge(graph.V(4), graph.V(7));
            graph.AddEdge(graph.V(5), graph.V(8));

            graph.AddEdge(graph.V(6), graph.V(9));
            graph.AddEdge(graph.V(6), graph.V(10));
            graph.AddEdge(graph.V(6), graph.V(11));

            Console.WriteLine(graph.ToString());
            Console.ReadKey();

            DepthFirstSearch dfs = new DepthFirstSearch(graph);
            dfs.Perform(graph.V(0));
            Console.WriteLine(dfs.ToString());
            Console.ReadKey();
        }

        public static void DjikstraTest()
        {

        }
    }
}
