using System.Drawing;
using GraphAlgorithmVisualizer.Visualization;

namespace GraphAlgorithmVisualizer.MathObjects
{
    /// <summary>
    /// Single point of a Graph with a unique identifing Index. It may be connected to another vertex through an <c>Edge</c>. Visually represented by a simple circle with its Index inside it.
    /// </summary>
    internal class Vertex : IVisualizable
    {
        public Point Position { get; private set; }
        public int X { get { return Position.X; } set { Position = new Point(Position.X, value); } }
        public int Y { get { return Position.Y; } set { Position = new Point(value, Position.Y); } }

        /// <summary>
        /// A unique integer that identifies this Vertex. Assigned by the Graph which created this Vertex.
        /// </summary>
        public readonly int Index;
        /// <summary>
        /// Whether or not the Vertex is contained inside a directed Graph.
        /// </summary>
        public readonly bool IsDirectional;

        /// <summary>
        /// Creates a new Vertex.
        /// </summary>
        /// <param name="id">Vertex's unique ID.</param>
        /// <param name="graphIsDirectional">Determines if it should behave as if it was in a directed or undirected Graph.</param>
        public Vertex(int index, bool graphIsDirectional)
        {
            Index = index;
            IsDirectional = graphIsDirectional;
        }

        public void MoveTo(int x, int y) => Position = new Point(x, y);
        public void Draw(Graphics graphics)
        {
            int size = 20;
            graphics.FillEllipse(DrawingTools.DefaultBackColor, X - (size / 2), Y - (size / 2), size, size);
            graphics.DrawEllipse(DrawingTools.DefaultOutline, X - (size / 2), Y - (size / 2), size, size);
            graphics.DrawString($"{Index}", DrawingTools.DefaultFont, DrawingTools.DefaultFontColor, X - (size / 2) + 3, Y - (size / 2));
        }

        public override string ToString()
        {
            return $"({Index})";
        }
    }
}
