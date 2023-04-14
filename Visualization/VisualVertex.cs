using System.Drawing;
using GraphAlgorithmVisualizer.MathObjects;

namespace GraphAlgorithmVisualizer.Visualization
{
    internal class VisualVertex : VisualObject
    {
        private readonly Vertex visualizedVertex;
        public int Index => visualizedVertex.Index;

        public VisualVertex(Vertex visualizedVertex, int x, int y) : base(x, y)
        {
            this.visualizedVertex = visualizedVertex;
        }

        public VisualVertex(Vertex visualizedVertex, Point position) : 
            this(visualizedVertex, position.X, position.Y)
        {
        }

        public override void Draw(Graphics canvas)
        {
            canvas.DrawEllipse(pen, X - 6, Y - 6, 12, 12);
            canvas.DrawString(visualizedVertex.Index.ToString(), font, new SolidBrush(Color.Black), X, Y);
        }
    }
}
