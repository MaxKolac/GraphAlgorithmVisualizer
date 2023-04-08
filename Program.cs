﻿using System;
using System.Collections.Generic;
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

            //TODO: debug this shit
            BreadthFirstSearch.Perform(graph, graph.V(2), out Dictionary<Vertex, Vertex> previousVertex, out Dictionary<Vertex, int> distance);

            Console.WriteLine("previousVertex Dictionary: ");
            foreach (KeyValuePair<Vertex, Vertex> pair in previousVertex)
                Console.WriteLine($"\t{pair.Key}\t|\t{pair.Value}");

            Console.WriteLine("distance Dictionary: ");
            foreach (KeyValuePair<Vertex, int> pair in distance)
                Console.WriteLine($"\t{pair.Key}\t|\t{pair.Value}");
            Console.ReadKey();
        }
    }
}
