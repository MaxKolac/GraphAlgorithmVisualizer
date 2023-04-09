using System;
using System.Windows.Forms;
using GraphAlgorithmVisualizer.Algorithms;
using GraphAlgorithmVisualizer.MathObjects;

namespace GraphAlgorithmVisualizer
{
    internal static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            Graph graph = new Graph(false, 5);
            graph.AddEdge(new Edge(graph.V(0), graph.V(1), graph.IsDirectional));
            graph.AddEdge(new Edge(graph.V(0), graph.V(4), graph.IsDirectional));

            graph.AddEdge(new Edge(graph.V(1), graph.V(2), graph.IsDirectional));
            graph.AddEdge(new Edge(graph.V(1), graph.V(3), graph.IsDirectional));

            graph.AddEdge(new Edge(graph.V(2), graph.V(4), graph.IsDirectional));
            graph.AddEdge(new Edge(graph.V(2), graph.V(3), graph.IsDirectional));

            graph.AddEdge(new Edge(graph.V(3), graph.V(4), graph.IsDirectional));
            
            Console.WriteLine(graph.ToString());
            Console.ReadKey();

            BreadthFirstSearch bfs = new BreadthFirstSearch();
            bfs.Perform(graph, graph.V(2));
            Console.WriteLine(bfs.ToString());
            Console.ReadKey();
        }
    }
}
