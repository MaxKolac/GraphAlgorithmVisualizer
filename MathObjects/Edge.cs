namespace GraphAlgorithmVisualizer.MathObjects
{
    internal class Edge
    {
        /// <summary>
        /// <c>Vertex</c> from which the <c>Edge</c> begins. Only matters if the <c>Edge</c> is directional.
        /// </summary>
        public Vertex Start { set; get; }
        /// <summary>
        /// <c>Vertex</c> to which the <c>Edge</c> goes. Only matters if the <c>Edge</c> is <c>Directional</c>.
        /// </summary>
        public Vertex End { set; get; }
        /// <summary>
        /// Defines if the <c>Edge</c> allows travel in both directions. If <c>true</c>, then only stepping from <c>Start</c> to <c>End</c> vertices is allowed. 
        /// </summary>
        public readonly bool IsDirectional;

        public Edge(Vertex start, Vertex end, bool isDirectional) 
        {
            Start = start;
            End = end;
            IsDirectional = isDirectional;
        }
    }
}
