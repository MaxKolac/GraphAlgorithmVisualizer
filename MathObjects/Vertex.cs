namespace GraphAlgorithmVisualizer.MathObjects
{
    /// <summary>
    /// Single point of a Graph. It may be connected to another vertex through an <c>Edge</c>.
    /// </summary>
    internal class Vertex
    {
        /// <summary>
        /// A unique integer that identifies this Vertex. Assigned by the Graph which created this Vertex.
        /// </summary>
        public readonly int Index;
        /// <summary>
        /// Whether or not the <c>Vertex</c> is contained inside a directed <c>Graph</c>. Influences how stages are set and returned.
        /// </summary>
        public readonly bool IsDirectional;

        /// <summary>
        /// Creates a new <c>Vertex</c>.
        /// </summary>
        /// <param name="id">Vertex's unique ID.</param>
        /// <param name="graphIsDirectional">Determines if it should behave as if it was in a directed or undirected Graph.</param>
        public Vertex(int index, bool graphIsDirectional)
        {
            Index = index;
            IsDirectional = graphIsDirectional;
        }

        public override string ToString()
        {
            return $"({Index})";
        }
    }
}
