using System;
using System.Drawing;

namespace GraphAlgorithmVisualizer.Visualization.Shapes
{
    /// <summary>
    /// A simple line which is has 3 points. Start, End and the Middle point which acts as a "deformer" to make the line appear curvy.
    /// </summary>
    internal class CurvableLine : Shape
    {
        public Point Start { get; protected set; }
        public Point Middle => Position;
        public Point End { get; protected set; }

        public CurvableLine(Point start, Point end) : base(start.X + ((end.X - start.X) / 2), start.Y + ((end.Y - start.Y) / 2))
        {
            Start = start;
            End = end;
        }

        public override void Draw(Graphics graphics) => graphics.DrawCurve(DrawingTools.DefaultOutline, new Point[] { Start, Position, End });

        /// <summary>
        /// Important! Keep in mind that you can't set the CurvableLine's position through this method. This method sets ONLY the middle point of the line. Use <c>SetStart()</c> and <c>SetEnd()</c> instead.
        /// </summary>
        /// <param name="x">The X coordinate to set the middle point to.</param>
        /// <param name="y">The Y coordinate to set the middle point to.</param>
        public override void SetPosition(int x, int y) => Position = new Point(x, y);
        /// <summary>
        /// Important! Keep in mind that you can't move the CurvableLine's position through this method. This method moves ONLY the middle point of the line. Use <c>SetStart()</c> and <c>SetEnd()</c> instead.
        /// </summary>
        /// <param name="deltaX">The X coordinate change to apply to the current X value.</param>
        /// <param name="deltaY">The Y coordinate change to apply to the current Y value.</param>
        public override void MovePosition(int deltaX, int deltaY) => Position = new Point(Position.X + deltaX, Position.Y + deltaY);
        /// <summary>
        /// Resets the Middle point's position to be exactly in the middle between Start and End positions.
        /// </summary>
        public void ResetMiddle() => Position = new Point(Start.X + ((End.X - Start.X) / 2), Start.Y + ((End.Y - Start.Y) / 2));
        /// <summary>
        /// Moves the Start point to the given coordinates. Make sure to call Draw() method to update the CurvableLine's appearance!.
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
