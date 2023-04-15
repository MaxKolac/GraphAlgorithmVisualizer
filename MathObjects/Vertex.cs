using System.Drawing;
using GraphAlgorithmVisualizer.Visualization;

namespace GraphAlgorithmVisualizer.MathObjects
{
    /// <summary>
    /// Single point of a Graph with a unique identifing Index. It may be connected to another vertex through an <c>Edge</c>.
    /// </summary>
    internal class Vertex : IVisualizable
    {
        private Point position;
        public int X { get { return position.X; } set { position = new Point(position.X, value); } }
        public int Y { get { return position.Y; } set { position = new Point(value, position.Y); } }

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

        public void MoveTo(int x, int y) => position = new Point(x, y);
        public void Draw(Graphics graphics)
        {
            graphics.DrawEllipse(DrawingTools.GlobalPen, X - 6, Y - 6, 12, 12);
            graphics.DrawString($"{Index}", DrawingTools.GlobalFont, DrawingTools.GlobalBrush, X, Y);
        }

        public override string ToString()
        {
            return $"({Index})";
        }
    }
}
