using System.Drawing;
using GraphAlgorithmVisualizer.Exceptions;
using GraphAlgorithmVisualizer.Visualization;

namespace GraphAlgorithmVisualizer.MathObjects
{
    internal class Edge : IVisualizable
    {
        private Point position;
        public int X { get { return position.X; } set { position = new Point(position.X, value); } }
        public int Y { get { return position.Y; } set { position = new Point(value, position.Y); } }

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
        /// <summary>
        /// Optional property used by some graph algorithm. Determines the abstract "length" this edge has.
        /// </summary>
        public readonly int? Distance;

        public Edge(Vertex start, Vertex end, bool isDirectional, int? distance)
        {
            Start = start;
            End = end;
            IsDirectional = isDirectional;
            if (distance <= 0)
                throw new GraphException("Attempted to create an Edge with non-positive Distance.");
            Distance = distance;
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

        public void MoveTo(int x, int y) => position = new Point(x, y);
        public void Draw(Graphics graphics)
        {
            graphics.DrawLine(DrawingTools.GlobalPen, Start.X, Start.Y, End.X, End.Y);
            if (IsDirectional)
            {
                //TODO: draw arrow's end
            }
            if (Distance is null) return;
            //TODO: draw distance String
        }

        public override string ToString()
        {
            string arrow = IsDirectional ? "->" : "-";
            return Distance is null ?
                $"({Start.Index}{arrow}{End.Index})" :
                $"({Start.Index}{arrow}{End.Index} [{Distance}])";
        }
    }
}
