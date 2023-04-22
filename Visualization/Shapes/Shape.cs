using System.Drawing;

namespace GraphAlgorithmVisualizer.Visualization.Shapes
{
    /// <summary>
    /// Base abstract class of all drawable Shapes used for graph visualization
    /// </summary>
    internal abstract class Shape
    {
        protected Point Position;
        protected int X => Position.X;
        protected int Y => Position.Y;

        protected Shape(int x, int y)
        {
            Position = new Point(x, y);
        }

        public abstract void Draw(Graphics graphics);
        public abstract void SetPosition(int x, int y);
        public abstract void MovePosition(int deltaX, int deltaY);
    }
}
