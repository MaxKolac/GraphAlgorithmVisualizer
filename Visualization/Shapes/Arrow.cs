using System;
using System.Drawing;
using GraphAlgorithmVisualizer.Utils;

namespace GraphAlgorithmVisualizer.Visualization.Shapes
{
    /// <summary>
    /// A curvy line with an arrowhead at the end of it. Represents directional Edges. It starts from Start point and ends in End point, with the Middle point acting as a deformer to make the Arrow appear as a curve. 
    /// </summary>
    internal class Arrow : CurvableLine
    {
        /// <summary>Angle between arrowhead's arm and the Arrow's line measured in degrees.</summary>
        private readonly double armAngle;
        /// <summary>The length of arrowhead's arms.</summary>
        private readonly double armLength;
        /// <summary>The distance between the arrowhead's starting point and the Arrow's End point. Needed so that the arrowhead won't be drawn under the Vertex's visual representation. It should equal Vertex's circle's radius.</summary>
        private const int lineEndOffset = 10;

        public Arrow(Point start, Point end, double armAngle, double armLength) : base(start, end)
        {
            this.armAngle = armAngle;
            this.armLength = armLength;
        }
        public Arrow(Point start, Point end) : this(start, end, 25, 20) 
        {
        }

        public override void Draw(Graphics graphics)
        {
            double alphaRadians = Math.Asin(
                    Math.Abs(End.Y - Middle.Y) / 
                    Math.Sqrt(Math.Pow(End.X - Middle.X, 2) + Math.Pow(End.Y - Middle.Y, 2))
                );
            if (double.IsNaN(alphaRadians)) alphaRadians = 0;
            double betaRadians = Mathx.ToRadians(90d) - alphaRadians;
            double gammaRadians = Mathx.ToRadians(armAngle);
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
                arrowheadStartPoint = new Point(
                    End.X - (int)Math.Round(lineEndOffset * Math.Cos(alphaRadians)),
                    End.Y - (int)Math.Round(lineEndOffset * Math.Sin(alphaRadians))
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

            base.Draw(graphics);
            graphics.DrawLine(DrawingTools.DefaultOutline, arrowheadStartPoint, armEndOne);
            graphics.DrawLine(DrawingTools.DefaultOutline, arrowheadStartPoint, armEndTwo);
        }
    }
}
