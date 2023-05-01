using System;

namespace GraphAlgorithmVisualizer.Exceptions
{
    internal class AlgorithmException : Exception
    {
        public AlgorithmException(string message) : base(message) { }
    }
}