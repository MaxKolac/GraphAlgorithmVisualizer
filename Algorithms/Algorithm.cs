using System.Collections.Generic;
using System.Text;
using GraphAlgorithmVisualizer.Exceptions;
using GraphAlgorithmVisualizer.Forms;
using GraphAlgorithmVisualizer.MathObjects;

namespace GraphAlgorithmVisualizer.Algorithms
{
    /// <summary>
    /// Base class of all Graph algorithms. It holds 3 Dictionaries with entries for each Vertex in the Graph, and also a reference to the Graph object itself.
    /// </summary>
    internal abstract class Algorithm : IDataGridViewable<Vertex, int>
    {
        protected readonly Dictionary<Vertex, bool> visited;
        protected readonly Dictionary<Vertex, Vertex> previousVertex;
        protected readonly Dictionary<Vertex, int> distance;
        protected readonly Graph graph;

        public int ComparisonsCount { protected set; get; } = 0;
        public int IterationsCount { protected set; get; } = 0;
        public int AssignmentsCount { protected set; get; } = 0;

        /// <summary>
        /// If a Distance has a value greater or equal to Infinity, then the Distance is considered as "infinite".
        /// </summary>
        public const int Infinity = 999_999;
        /// <summary>
        /// If a Distance has a value lesser or equal to NegativeInfinity, then the Distance is considered as "negative infinite".
        /// </summary>
        public const int NegativeInfinity = -999_999;

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
        /// <param name="setInitialDistanceToInfinity">If <c>true</c>, new entries in distance dictionary will begin with the value of Infinity, a.k.a. "infinity". If false, they start with the value of 0.</param>
        protected void ClearDictionaries(bool setInitialDistanceToInfinity)
        {
            visited.Clear();
            previousVertex.Clear();
            distance.Clear();
            foreach (Vertex vertex in graph.VerticesArray)
            {
                previousVertex.Add(vertex, null);
                distance.Add(vertex, setInitialDistanceToInfinity ? Infinity : 0);
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
        /// Analyzes the <c>Graph</c>, fills the <c>previousVertex</c> and <c>distance</c> dictionaries with algorithm results and resets the performance counters.
        /// </summary>
        /// <param name="start">The <c>Vertex</c> from the <c>Graph</c> which will be a starting point for the algorithm.</param>
        public virtual void Perform(Vertex start)
        {
            ResetPerformanceCounters();
            SetStartVertex(start);
            ClearDictionaries(false);
        }
        /// <summary>
        /// Analyzes the <c>Graph</c>, fills the <c>previousVertex</c> and <c>distance</c> dictionaries with algorithm results and resets the performance counters.
        /// This variant additionally counts all comparisons, loop iterations and performed operations.
        /// </summary>
        /// <param name="start">The <c>Vertex</c> from the <c>Graph</c> which will be a starting point for the algorithm.</param>
        public virtual void PerformAndCount(Vertex start)
        {
            ResetPerformanceCounters();
            SetStartVertex(start); 
            ComparisonsCount++; 
            AssignmentsCount++;
            ClearDictionaries(false);
            AssignmentsCount += 3 * (graph.VerticesCount + 1);
            ComparisonsCount += graph.VerticesCount;
        }
        /// <summary>
        /// Sets all performance counters (iterations, operations, comparisons) back to zero.
        /// </summary>
        public void ResetPerformanceCounters()
        {
            AssignmentsCount = 0;
            IterationsCount = 0;
            ComparisonsCount = 0;
        }

        public virtual string GetFirstColumnLabel() => "Poprzedni wierz.";
        public virtual Vertex GetFirstColumnDataForVertex(Vertex v) => previousVertex[v];
        public virtual string GetSecondColumnLabel() => "Dystans";
        public virtual int GetSecondColumnDataForVertex(Vertex v) => distance[v];
        /// <returns>A formatted string containing a sum of assignments and a separate count of iterations.</returns>
        public virtual string GetOperationsPerformed() => $"Wykonane operacje: {AssignmentsCount + ComparisonsCount} + {IterationsCount} iteracji";

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
