using System;
using System.Drawing;
using System.Text;
using GraphAlgorithmVisualizer.Exceptions;
using GraphAlgorithmVisualizer.Visualization;

namespace GraphAlgorithmVisualizer.MathObjects
{
    /// <summary>
    /// A connection between two vertices.
    /// </summary>
    internal class Edge : IVisualizable
    {
        private readonly Arrow visualArrow;
        public int X { get { return visualArrow.X; } set { visualArrow.MoveTo(value, visualArrow.Y); } }
        public int Y { get { return visualArrow.Y; } set { visualArrow.MoveTo(visualArrow.X, value); } }

        /// <summary>
        /// <c>Vertex</c> from which the <c>Edge</c> begins. Only matters if the <c>Edge</c> is directional.
        /// </summary>
        public readonly Vertex Start;
        /// <summary>
        /// <c>Vertex</c> to which the <c>Edge</c> goes. Only matters if the <c>Edge</c> is <c>Directional</c>.
        /// </summary>
        public readonly Vertex End;
        /// <summary>
        /// Defines if the <c>Edge</c> allows travel in both directions. If <c>true</c>, then only stepping from <c>Start</c> to <c>End</c> vertices is allowed. 
        /// </summary>
        public readonly bool IsDirectional;
        /// <summary>
        /// Optional property used by some graph algorithm. Determines the abstract "length" this edge has.
        /// </summary>
        public readonly int? Distance;

        public Edge(Vertex start, Vertex end, bool isDirectional)
        {
            visualArrow = new Arrow(Start.Position, End.Position);
            Start = start;
            End = end;
            IsDirectional = isDirectional;
        }
        public Edge(Vertex start, Vertex end, bool isDirectional, int distance) : this(start, end, isDirectional)
        {
            if (distance <= 0)
                throw new GraphException("Attempted to create an Edge with non-positive Distance.");
            Distance = distance;
        }

        /// <summary>
        /// Checks if the <c>Edge</c> can be considered to be starting from the provided <c>Vertex</c>.
        /// </summary>
        /// <param name="v">The Vertex to look for in Edge's Start and End fields.</param>
        /// <returns>
        /// If the <c>Edge</c> is directional, <c>true</c> is returned only when the provided <c>Vertex</c> equals to this edge's Start.
        /// If the <c>Edge</c> isn't directional, <c>true</c> is returned if the provided <c>Vertex</c> is either Start or End.
        /// </returns>
        public bool IsStartingFrom(Vertex v) => IsDirectional ? Start.Equals(v) : Start.Equals(v) || End.Equals(v);
        /// <summary>
        /// Checks if the <c>Edge</c> can be considered to be ending in the provided <c>Vertex</c>.
        /// </summary>
        /// <param name="v">The Vertex to look for in Edge's Start and End fields.</param>
        /// <returns>
        /// If the <c>Edge</c> is directional, <c>true</c> is returned only when the provided <c>Vertex</c> equals to this edge's End.
        /// If the <c>Edge</c> isn't directional, <c>true</c> is returned if the provided <c>Vertex</c> is either Start or End.
        /// </returns>
        public bool IsEndingIn(Vertex v) => IsDirectional ? End.Equals(v) : Start.Equals(v) || End.Equals(v);

        public void MoveTo(int x, int y) => visualArrow.MoveTo(x, y);
        public void Draw(Graphics graphics)
        {
            graphics.DrawLine(DrawingTools.DefaultOutline, Start.X, Start.Y, End.X, End.Y);
            graphics.DrawString($"{Distance}", DrawingTools.DefaultFont, DrawingTools.DefaultFontColor, new Point(Math.Abs(End.X + Start.X) / 2, Math.Abs(End.Y + Start.Y) / 2));

            if (!IsDirectional) return;
            //This is a mathematical disgrace and a mess and if my university teachers saw this they would throw me out INSTANTLY, but god DAMNIT it works...

            double ArrowArmAngle = Extensions.ToRadians(15d);
            int ArrowArmLength = 15;
            int LineEndOffset = 10; //This needs to be Vertex's size / 2

            //TODO: Despite this mess, QuarterAngleOffset still doesn't quite work
            //Mafs is hard :p, not too proud out of this "wooden else-if'ing"...
            double QuarterAngleOffset;
            if (End.X > Start.X && End.Y <= Start.Y)
                QuarterAngleOffset = Extensions.ToRadians(0);
            else if (End.X <= Start.X && End.Y < Start.Y)
                QuarterAngleOffset = Extensions.ToRadians(90);
            else if (End.X < Start.X && End.Y >= Start.Y)
                QuarterAngleOffset = Extensions.ToRadians(180);
            else //if (End.X >= Start.X && End.X > Start.Y)
                QuarterAngleOffset = Extensions.ToRadians(270);

            int DifferenceY = End.Y - Start.Y;
            int DifferenceX = End.X - Start.X;
            double Alpha = (DifferenceX == 0 || DifferenceY == 0) ? QuarterAngleOffset : Math.Atan(Math.Abs(DifferenceY) / Math.Abs(DifferenceX)) + QuarterAngleOffset;
            double Beta = Extensions.ToRadians(90d - Extensions.ToDegrees(Alpha));
            Point ArrowArmStartPoint = new Point(End.X - (int)Math.Round(LineEndOffset * Math.Sin(Beta)), End.Y + (int)Math.Round(LineEndOffset * Math.Sin(Alpha)));

            int ArrowOneX = ArrowArmStartPoint.X - (int)Math.Round(ArrowArmLength * Math.Sin(Beta - ArrowArmAngle));
            int ArrowOneY = ArrowArmStartPoint.Y + (int)Math.Round(ArrowArmLength * Math.Cos(Beta - ArrowArmAngle));
            int ArrowTwoX = ArrowArmStartPoint.X - (int)Math.Round(ArrowArmLength * Math.Sin(Beta + ArrowArmAngle));
            int ArrowTwoY = ArrowArmStartPoint.Y + (int)Math.Round(ArrowArmLength * Math.Cos(Beta + ArrowArmAngle));

            graphics.DrawLine(DrawingTools.DefaultOutline, ArrowArmStartPoint, new Point(ArrowOneX, ArrowOneY));
            graphics.DrawLine(DrawingTools.DefaultOutline, ArrowArmStartPoint, new Point(ArrowTwoX, ArrowTwoY));

            //Debug
            /*StringBuilder builder = new StringBuilder();
            builder.AppendLine(this.ToString());
            builder.AppendLine($"Alpha: {Alpha} ({Extensions.ToDegrees(Alpha)})");
            builder.AppendLine($"Beta: {Beta} ({Extensions.ToDegrees(Beta)})");
            builder.AppendLine($"ArrowArmStartPoint: {ArrowArmStartPoint}");
            Console.WriteLine(builder.ToString());*/
        }

        public override string ToString()
        {
            string arrow = IsDirectional ? "->" : "-";
            return Distance is null ?
                $"({Start.Index}{arrow}{End.Index})" :
                $"({Start.Index}{arrow}{End.Index} [{Distance}])";
        }
    }
}
