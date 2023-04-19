using System;
using System.Drawing;

namespace GraphAlgorithmVisualizer.Visualization.Shapes
{
    /// <summary>
    /// A curvy line with an arrowhead at the end of it. Represents directional Edges. It starts from Start point and ends in End point, with the Middle point acting as a deformer to make the Arrow appear as a curve. 
    /// </summary>
    internal class Arrow : Shape
    {
        public Point Start { get; private set; }
        public Point Middle { get; private set; }
        public Point End { get; private set; }

        /// <summary>Angle between arrowhead's arm and the Arrow's line measured in degrees.</summary>
        private readonly double armAngle;
        /// <summary>The length of arrowhead's arms.</summary>
        private readonly double armLength;
        /// <summary>The distance between the arrowhead's starting point and the Arrow's End point. Needed so that the arrowhead won't be drawn under the Vertex's visual representation. It should equal Vertex's circle's radius.</summary>
        private const int lineEndOffset = 10;

        public Arrow(Point start, Point end, double armAngle, double armLength) : base((end.X - start.X) / 2, (end.Y - start.Y) / 2)
        {
            Start = start;
            End = end;
            ResetMiddle();
            this.armAngle = armAngle;
            this.armLength = armLength;
        }
        public Arrow(Point start, Point end) : this(start, end, 25, 20) { }

        public override void Draw(Graphics graphics)
        {
            double alphaRadians = Math.Asin(
                    Math.Abs(End.Y - Middle.Y) / 
                    Math.Sqrt(Math.Pow(End.X - Middle.X, 2) + Math.Pow(End.Y - Middle.Y, 2))
                );
            double betaRadians = Extensions.ToRadians(90d) - alphaRadians;
            double gammaRadians = Extensions.ToRadians(armAngle);
            Point arrowheadStartPoint;
            Point armEndOne;
            Point armEndTwo;

            //Determining which quarter of the (X,Y) space the arrow is in
            //Comment: Yay, it works, me smart :thumbsup:
            if (End.X > Middle.X && End.Y <= Middle.Y) // 1st
            {
                arrowheadStartPoint = new Point(
                    End.X - (int)Math.Round(lineEndOffset * Math.Cos(alphaRadians)),
                    End.Y + (int)Math.Round(lineEndOffset * Math.Sin(alphaRadians))
                    );
                armEndOne = new Point(
                    arrowheadStartPoint.X - (int)Math.Round(armLength * Math.Sin(betaRadians - gammaRadians)),
                    arrowheadStartPoint.Y + (int)Math.Round(armLength * Math.Cos(betaRadians - gammaRadians))
                    );
                armEndTwo = new Point(
                    arrowheadStartPoint.X - (int)Math.Round(armLength * Math.Cos(alphaRadians - gammaRadians)),
                    arrowheadStartPoint.Y + (int)Math.Round(armLength * Math.Sin(alphaRadians - gammaRadians))
                    );
            }
            else if (End.X <= Middle.X && End.Y < Middle.Y) // 2nd
            {
                arrowheadStartPoint = new Point(
                    End.X + (int)Math.Round(lineEndOffset * Math.Cos(alphaRadians)),
                    End.Y + (int)Math.Round(lineEndOffset * Math.Sin(alphaRadians))
                    );
                armEndOne = new Point(
                    arrowheadStartPoint.X + (int)Math.Round(armLength * Math.Cos(alphaRadians - gammaRadians)),
                    arrowheadStartPoint.Y + (int)Math.Round(armLength * Math.Sin(alphaRadians - gammaRadians))
                    );
                armEndTwo = new Point(
                    arrowheadStartPoint.X + (int)Math.Round(armLength * Math.Sin(betaRadians - gammaRadians)),
                    arrowheadStartPoint.Y + (int)Math.Round(armLength * Math.Cos(betaRadians - gammaRadians))
                    );
            }
            else if (End.X < Middle.X && End.Y >= Middle.Y) // 3nd
            {
                arrowheadStartPoint = new Point(
                    End.X + (int)Math.Round(lineEndOffset * Math.Cos(alphaRadians)),
                    End.Y - (int)Math.Round(lineEndOffset * Math.Sin(alphaRadians))
                    );
                armEndOne = new Point(
                    arrowheadStartPoint.X + (int)Math.Round(armLength * Math.Sin(betaRadians - gammaRadians)),
                    arrowheadStartPoint.Y - (int)Math.Round(armLength * Math.Cos(betaRadians - gammaRadians))
                    );
                armEndTwo = new Point(
                    arrowheadStartPoint.X + (int)Math.Round(armLength * Math.Cos(alphaRadians - gammaRadians)),
                    arrowheadStartPoint.Y - (int)Math.Round(armLength * Math.Sin(alphaRadians - gammaRadians))
                    );
            }
            else //if (End.X >= Middle.X && End.Y > Middle.Y) // 4th
            {
                int x = (int)Math.Round(lineEndOffset * Math.Cos(alphaRadians));
                int y = (int)Math.Round(lineEndOffset * Math.Sin(alphaRadians));
                arrowheadStartPoint = new Point(
                    End.X - x,
                    End.Y - y
                    );
                armEndOne = new Point(
                    arrowheadStartPoint.X - (int)Math.Round(armLength * Math.Cos(alphaRadians - gammaRadians)),
                    arrowheadStartPoint.Y - (int)Math.Round(armLength * Math.Sin(alphaRadians - gammaRadians))
                    );
                armEndTwo = new Point(
                    arrowheadStartPoint.X - (int)Math.Round(armLength * Math.Sin(betaRadians - gammaRadians)),
                    arrowheadStartPoint.Y - (int)Math.Round(armLength * Math.Cos(betaRadians - gammaRadians))
                    );
            }

            graphics.DrawLine(DrawingTools.DefaultOutline, arrowheadStartPoint, armEndOne);
            graphics.DrawLine(DrawingTools.DefaultOutline, arrowheadStartPoint, armEndTwo);
            graphics.DrawCurve(DrawingTools.DefaultOutline, new Point[] { Start, Middle, End });
        }
        /// <summary>
        /// Important! Keep in mind that you can't set the Arrow's position through this method. This method sets ONLY the middle point of the arrow. Use <c>SetStart()</c> and <c>SetEnd()</c> instead.
        /// </summary>
        /// <param name="x">The X coordinate to set the middle point to.</param>
        /// <param name="y">The Y coordinate to set the middle point to.</param>
        public override void SetPosition(int x, int y) => Middle = new Point(x, y);
        /// <summary>
        /// Important! Keep in mind that you can't move the Arrow's position through this method. This method moves ONLY the middle point of the arrow. Use <c>SetStart()</c> and <c>SetEnd()</c> instead.
        /// </summary>
        /// <param name="deltaX">The X coordinate change to apply to the current X value.</param>
        /// <param name="deltaY">The Y coordinate change to apply to the current Y value.</param>
        public override void MovePosition(int deltaX, int deltaY) => Middle = new Point(Middle.X + deltaX, Middle.Y + deltaY);
        /// <summary>
        /// Resets the Middle point's position to be exactly in the middle between Start and End positions.
        /// </summary>
        public void ResetMiddle() => Middle = new Point(Start.X + ((End.X - Start.X) / 2), Start.Y + ((End.Y - Start.Y) / 2));
        /// <summary>
        /// Moves the Start point to the given coordinates. Make sure to call Draw() method to update the Arrow's appearance!.
        /// </summary>
        /// <param name="x">The X coordinate of the new Start point.</param>
        /// <param name="y">The Y coordinate of the new Start point.</param>
        public void SetStart(int x, int y) => Start = new Point(x, y);
        /// <summary>
        /// Moves the End point to the given coordinates. Make sure to call Draw() method to update the Arrow's appearance!.
        /// </summary>
        /// <param name="x">The X coordinate of the new End point.</param>
        /// <param name="y">The Y coordinate of the new End point.</param>
        public void SetEnd(int x, int y) => End = new Point(x, y);
    }
}
