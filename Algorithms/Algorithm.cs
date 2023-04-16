﻿using GraphAlgorithmVisualizer.Exceptions;
using GraphAlgorithmVisualizer.MathObjects;
using System.Collections.Generic;
using System.Text;

namespace GraphAlgorithmVisualizer.Algorithms
{
    internal abstract class Algorithm
    {
        protected readonly Dictionary<Vertex, bool> visited;
        protected readonly Dictionary<Vertex, Vertex> previousVertex;
        protected readonly Dictionary<Vertex, int> distance;
        protected readonly Graph graph;

        public bool WasVisited(Vertex v) => visited[v];
        public Vertex PreviousVertexOf(Vertex v) => previousVertex[v];
        public int DistanceOf(Vertex vertex) => distance[vertex];
        public Vertex StartVertex { get; private set; }

        protected Algorithm(Graph graph)
        {
            visited = new Dictionary<Vertex, bool>();
            previousVertex = new Dictionary<Vertex, Vertex>();
            distance = new Dictionary<Vertex, int>();
            this.graph = graph;
        }

        /// <summary>
        /// Clears all Algorithm inherited Dictionaries of its previous KeyValuePairs and adds empty KeyValuePairs for each of Graph's Vertex with default values.
        /// </summary>
        /// <param name="setStartingDistanceAsIntMax">If <c>true</c>, new entries in distance dictionary will begin with the value of <c>Int.MaxValue</c>. If false, they start with the value of 0.</param>
        protected void ClearDictionaries(bool setStartingDistanceAsIntMax)
        {
            visited.Clear();
            previousVertex.Clear();
            distance.Clear();
            foreach (Vertex vertex in graph.VerticesArray)
            {
                previousVertex.Add(vertex, null);
                distance.Add(vertex, setStartingDistanceAsIntMax ? int.MaxValue : 0);
                visited.Add(vertex, false);
            }
        }
        /// <summary>
        /// Sets StartVertex to the provided Vertex, only if it is a part of the <c>Graph</c>.
        /// </summary>
        /// <param name="v">The Vertex to set as StartVertex.</param>
        /// <exception cref="GraphException">Thrown if the provided Vertex isn't in <c>Graph</c>'s vertices list.</exception>
        protected void SetStartVertex(Vertex v)
        {
            if (!graph.Contains(v))
                throw new GraphException("Start Vertex was not found on Graph's Vertices list.");
            StartVertex = v;
        }
        /// <summary>
        /// Analyzes the <c>Graph</c> and fills the <c>previousVertex</c> and <c>distance</c> dictionaries with algorithm results.
        /// </summary>
        /// <param name="start">The <c>Vertex</c> from the <c>Graph</c> which will be a starting point for the algorithm.</param>
        public virtual void Perform(Vertex start)
        {
            SetStartVertex(start);
            ClearDictionaries(false);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("visited Dictionary: ");
            foreach (KeyValuePair<Vertex, bool> pair in visited)
                builder.AppendLine($"\t{pair.Key}\t|\t{pair.Value}");

            builder.AppendLine("previousVertex Dictionary: ");
            foreach (KeyValuePair<Vertex, Vertex> pair in previousVertex)
                builder.AppendLine($"\t{pair.Key}\t|\t{pair.Value}");

            builder.AppendLine("distance Dictionary: ");
            foreach (KeyValuePair<Vertex, int> pair in distance)
                builder.AppendLine($"\t{pair.Key}\t|\t{pair.Value}");
            return builder.ToString();
        }
    }
}