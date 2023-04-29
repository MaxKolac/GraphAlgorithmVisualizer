using System;
using System.Drawing;

namespace GraphAlgorithmVisualizer.Visualization.Shapes
{
    /// <summary>
    /// A rectangle made of dashed lines, drawn based on two given corners. First corner is kept as the Shape.Position. MovePosition and SetPosition affect only the first corner. The opposite, second corner, needs to be accessed through SetSecondPosition().
    /// </summary>
    internal class SelectionRectangle : Shape
    {
        public Point FirstCorner => Position;
        public Point SecondCorner { get; private set; }

        public int LeftBound => Math.Min(FirstCorner.X, SecondCorner.X);
        public int RightBound => Math.Max(FirstCorner.X, SecondCorner.X);
        public int UpperBound => Math.Min(FirstCorner.Y, SecondCorner.Y);
        public int LowerBound => Math.Max(FirstCorner.Y, SecondCorner.Y);

        public SelectionRectangle(Point firstCorner, Point secondCorner) : base(firstCorner.X, firstCorner.Y)
        {
            SecondCorner = secondCorner;
        }

        public override void Draw(Graphics graphics)
        {
            Point upperLeftCorner = new Point(
                Math.Min(FirstCorner.X, SecondCorner.X),
                Math.Min(FirstCorner.Y, SecondCorner.Y)
                );
            int rectWidth = Math.Abs(FirstCorner.X - SecondCorner.X);
            int rectHeight = Math.Abs(FirstCorner.Y - SecondCorner.Y);
            Point lowerRightCorner = new Point(
                upperLeftCorner.X + rectWidth,
                upperLeftCorner.Y + rectHeight
                );

            graphics.DrawLine(DrawingTools.SelectionRectPen, upperLeftCorner, new Point(upperLeftCorner.X + rectWidth, upperLeftCorner.Y));
            graphics.DrawLine(DrawingTools.SelectionRectPen, upperLeftCorner, new Point(upperLeftCorner.X, upperLeftCorner.Y + rectHeight));
            graphics.DrawLine(DrawingTools.SelectionRectPen, lowerRightCorner, new Point(lowerRightCorner.X - rectWidth, lowerRightCorner.Y));
            graphics.DrawLine(DrawingTools.SelectionRectPen, lowerRightCorner, new Point(lowerRightCorner.X, lowerRightCorner.Y - rectHeight));
        }
        /// <summary>
        /// Sets the position of the first corner to the specified (X,Y) position.
        /// </summary>
        public override void SetPosition(int x, int y) => Position = new Point(x, y);
        /// <summary>
        /// Moves the position of the firsts corner by the specified deltas.
        /// </summary>
        public override void MovePosition(int deltaX, int deltaY) => SetPosition(X + deltaX, Y + deltaY);

        public void SetSecondPosition(Point p) => SecondCorner = new Point(p.X, p.Y);
        /// <summary>
        /// Returns true, if the provided coordinates can be considered to be inside the bounds.
        /// </summary>
        public bool IsWithinSelectionBounds(Point coordinatesToCheck) =>
            LeftBound <= coordinatesToCheck.X && coordinatesToCheck.X <= RightBound &&
            UpperBound <= coordinatesToCheck.Y && coordinatesToCheck.Y <= LowerBound;
    }
}
