using System;

namespace GraphAlgorithmVisualizer.Exceptions
{
    internal class GraphException : Exception
    {
        public GraphException (string message) : base(message) { }
    }
}
