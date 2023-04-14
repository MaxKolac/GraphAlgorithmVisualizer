using System.Drawing;

namespace GraphAlgorithmVisualizer.Visualization
{
    internal class VisualEdge : VisualObject
    {
        public readonly VisualVertex Start;
        public readonly VisualVertex End;
        public readonly bool IsDirectional;
        public readonly int? Distance;

        public VisualEdge(VisualVertex start, VisualVertex end, bool isDirectional, int? distance) : base((start.X + end.X) / 2, (start.Y + end.Y) / 2)
        {
            Start = start;
            End = end;
            IsDirectional = isDirectional;
            Distance = distance;
        }

        public override void Draw(Graphics canvas)
        {
            canvas.DrawLine(pen, Start.X, Start.Y, End.X, End.Y);
            if (IsDirectional)
            {
                //TODO: draw arrow's end
            }
            if (Distance is null) return;
            //TODO: draw distance String
        }
    }
}
