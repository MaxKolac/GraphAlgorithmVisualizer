using System;
using System.Drawing;
using GraphAlgorithmVisualizer.Exceptions;
using GraphAlgorithmVisualizer.Visualization;
using GraphAlgorithmVisualizer.Visualization.Shapes;

namespace GraphAlgorithmVisualizer.MathObjects
{
    /// <summary>
    /// A connection between two vertices. It can be visually represented either as a simple line or an arrow, pointing towards the End Vertex, if it is directional.
    /// </summary>
    internal class Edge : IVisualizable
    {
        private readonly CurvableLine visualArrow;
        public Point Position => visualArrow.Middle;
        public int X => visualArrow.Middle.X;
        public int Y => visualArrow.Middle.Y;

        /// <summary>
        /// <c>Vertex</c> from which the <c>Edge</c> begins. Only matters if the <c>Edge</c> is directional.
        /// </summary>
        public readonly Vertex Start;
        /// <summary>
        /// <c>Vertex</c> to which the <c>Edge</c> goes. Only matters if the <c>Edge</c> is <c>Directional</c>.
        /// </summary>
        public readonly Vertex End;
        /// <summary>
        /// Defines if the <c>Edge</c> allows travel in both directions. If <c>true</c>, then only stepping from <c>Start</c> to <c>End</c> vertices is allowed. Additionally, it determines if the Edge will be visualized as an Arrow or a simple line.
        /// </summary>
        public readonly bool IsDirectional;
        /// <summary>
        /// Optional property used by some graph algorithms. Represents the abstract metric used to determine the Edge's length in the Graph.
        /// </summary>
        public readonly int? Distance;

        public Edge(Vertex start, Vertex end, bool isDirectional)
        {
            visualArrow = isDirectional ?
                new Arrow(start.Position, end.Position) :
                new CurvableLine(start.Position, end.Position);
            Start = start;
            End = end;
            IsDirectional = isDirectional;
            Distance = null;
        }
        public Edge(Vertex start, Vertex end, bool isDirectional, int distance) : this(start, end, isDirectional)
        {
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

        public void SetStart(Point p)
        {
            Start.SetPosition(p.X, p.Y);
            visualArrow.SetStart(p.X, p.Y);
        }
        public void SetPosition(int x, int y) => visualArrow.SetPosition(x, y);
        public void ResetMiddle() => visualArrow.ResetMiddle();
        public void SetEnd(Point p) 
        {
            End.SetPosition(p.X, p.Y);
            visualArrow.SetEnd(p.X, p.Y); 
        }
        public void MovePosition(int deltaX, int deltaY) => visualArrow.MovePosition(deltaX, deltaY);
        public void Draw(Graphics graphics)
        {
            visualArrow.SetStart(Start.Position.X, Start.Position.Y);
            visualArrow.SetEnd(End.Position.X, End.Position.Y);
            visualArrow.Draw(graphics);
            graphics.DrawString(
                $"{Distance}", 
                DrawingTools.DefaultFont, 
                DrawingTools.DefaultFontColor, 
                new Point(
                    Math.Abs(End.Position.X + Start.Position.X) / 2, 
                    Math.Abs(End.Position.Y + Start.Position.Y) / 2)
                ); 
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
