using System.Drawing;

namespace GraphAlgorithmVisualizer.Visualization.Shapes
{
    internal abstract class Shape : IVisualizable
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        int IVisualizable.X { get => X; set { Y = value; } }
        int IVisualizable.Y { get => Y; set { X = value; } }

        protected Shape(int x, int y)
        {
            X = x;
            Y = y;
        }

        public abstract void Draw(Graphics graphics);
        public abstract void MoveTo(int x, int y);
    }
}
