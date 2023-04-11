namespace GraphAlgorithmVisualizer.MathObjects
{
    internal class Edge
    {
        /// <summary>
        /// <c>Vertex</c> from which the <c>Edge</c> begins. Only matters if the <c>Edge</c> is directional.
        /// </summary>
        public readonly Vertex Start;
        /// <summary>
        /// <c>Vertex</c> to which the <c>Edge</c> goes. Only matters if the <c>Edge</c> is <c>Directional</c>.
        /// </summary>
        public readonly Vertex End;
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

        /// <summary>
        /// Checks if the <c>Edge</c> can be considered to be starting from the provided <c>Vertex</c>.
        /// </summary>
        /// <param name="v">The Vertex to look for in Edge's Start and End fields.</param>
        /// <returns>
        /// If the <c>Edge</c> is directional, <c>true</c> is returned only when the provided <c>Vertex</c> equals to this edge's Start.
        /// If the <c>Edge</c> isn't directional, <c>true</c> is returned if the provided <c>Vertex</c> is either Start or End.
        /// </returns>
        public bool IsStartingFrom(Vertex v) => IsDirectional ? Start.Equals(v) : Start.Equals(v) || End.Equals(v);
        /// <summary>
        /// Checks if the <c>Edge</c> can be considered to be ending in the provided <c>Vertex</c>.
        /// </summary>
        /// <param name="v">The Vertex to look for in Edge's Start and End fields.</param>
        /// <returns>
        /// If the <c>Edge</c> is directional, <c>true</c> is returned only when the provided <c>Vertex</c> equals to this edge's End.
        /// If the <c>Edge</c> isn't directional, <c>true</c> is returned if the provided <c>Vertex</c> is either Start or End.
        /// </returns>
        public bool IsEndingIn(Vertex v) => IsDirectional ? End.Equals(v) : Start.Equals(v) || End.Equals(v);
        
        public override string ToString()
        {
            return IsDirectional ? $"({Start.Index}->{End.Index})" : $"({Start.Index}-{End.Index})" ;
        }
    }
}
