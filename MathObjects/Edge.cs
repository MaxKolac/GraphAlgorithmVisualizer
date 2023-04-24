using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GraphAlgorithmVisualizer.Exceptions;
using GraphAlgorithmVisualizer.Visualization;
using GraphAlgorithmVisualizer.Visualization.Shapes;

namespace GraphAlgorithmVisualizer.MathObjects
{
    /// <summary>
    /// A connection between two vertices. It can be visually represented either as a simple line or an arrow, pointing towards the End Vertex, if it is directional.
    /// </summary>
    internal class Edge : ISelectable
    {
        private readonly CurvableLine visualArrow;
        public Point Position => visualArrow.Middle;
        public int X => visualArrow.Middle.X;
        public int Y => visualArrow.Middle.Y;

        /// <summary>
        /// <c>Vertex</c> from which the <c>Edge</c> begins. Only matters if the <c>Edge</c> is directional.
        /// </summary>
        public readonly Vertex Start;
        /// <summary>
        /// <c>Vertex</c> to which the <c>Edge</c> goes. Only matters if the <c>Edge</c> is <c>Directional</c>.
        /// </summary>
        public readonly Vertex End;
        /// <summary>
        /// Defines if the <c>Edge</c> allows travel in both directions. If <c>true</c>, then only stepping from <c>Start</c> to <c>End</c> vertices is allowed. Additionally, it determines if the Edge will be visualized as an Arrow or a simple line.
        /// </summary>
        public readonly bool IsDirectional;
        /// <summary>
        /// Optional property used by some graph algorithms. Represents the abstract metric used to determine the Edge's length in the Graph.
        /// </summary>
        public int? Distance { get; private set; }

        /// <summary>
        /// Creates a new Edge with the Distance property being set to null.
        /// </summary>
        /// <param name="start">The Start Vertex object, from which the Edge begins.</param>
        /// <param name="end">The End Vertex object, into which the Edge flows.</param>
        /// <param name="isDirectional">Whether or not the Edge is inside of a Directional Graph. If true, then travel from End to Start vertices is not allowed.</param>
        public Edge(Vertex start, Vertex end, bool isDirectional)
        {
            visualArrow = isDirectional ?
                new Arrow(start.Position, end.Position) :
                new CurvableLine(start.Position, end.Position);
            Start = start;
            End = end;
            IsDirectional = isDirectional;
            Distance = null;
        }
        /// <summary>
        /// Creates a new Edge with the Distance property.
        /// </summary>
        /// <param name="start">The Start Vertex object, from which the Edge begins.</param>
        /// <param name="end">The End Vertex object, into which the Edge flows.</param>
        /// <param name="isDirectional">Whether or not the Edge is inside of a Directional Graph. If true, then travel from End to Start vertices is not allowed.</param>
        /// <param name="distance">The abstract metric which represents the distance between Start and End vertices. Must be greater than 0.</param>
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
        /// <summary>
        /// Sets a new value to Distance. If Distance was already a null, method does nothing.
        /// </summary>
        /// <param name="distance">The Distance value to set. Must be greater than 0, or an exception will be thrown.</param>
        public void SetDistance(int distance)
        {
            if (Distance is null) return;
            if (distance <= 0)
                throw new GraphException("Attempted to create an Edge with non-positive Distance.");
            Distance = distance;
        }

        public void SetStart(Point p)
        {
            Start.SetPosition(p.X, p.Y);
            visualArrow.SetStart(p.X, p.Y);
        }
        public void SetPosition(int x, int y) => visualArrow.SetPosition(x, y);
        public void ResetMiddle() => visualArrow.ResetMiddle();
        public void SetEnd(Point p) 
        {
            End.SetPosition(p.X, p.Y);
            visualArrow.SetEnd(p.X, p.Y); 
        }
        public void MovePosition(int deltaX, int deltaY) => visualArrow.MovePosition(deltaX, deltaY);
        public void Draw(Graphics graphics)
        {
            visualArrow.SetStart(Start.Position.X, Start.Position.Y);
            visualArrow.SetEnd(End.Position.X, End.Position.Y);
            visualArrow.Draw(graphics);
            new LabelSquare(visualArrow.Middle.X, visualArrow.Middle.Y, Distance.ToString()).Draw(graphics);
        }
        public void DrawDetectedState(Graphics graphics) => DrawState(DrawingTools.DefaultDetectedOutline, graphics, 25);
        public void DrawSelectedState(Graphics graphics) => DrawState(DrawingTools.DefaultSelectedOutline, graphics, 25);
        private void DrawState(Pen pen, Graphics graphics, int size) => graphics.DrawEllipse(pen, X - (size / 2), Y - (size / 2), size, size);
        public Dictionary<int, ControlLabelSet> GetProperties()
        {
            Dictionary<int, ControlLabelSet> properties = new Dictionary<int, ControlLabelSet>();

            Label positionXLabel = new Label()
            {
                Text = "Współrzędna X"
            };
            Control positionX = new TextBox()
            {
                Text = X.ToString(),
                TextAlign = HorizontalAlignment.Center,
                ReadOnly = true
            };

            Label positionYLabel = new Label()
            {
                Text = "Współrzędna Y"
            };
            Control positionY = new TextBox()
            {
                Text = Y.ToString(),
                TextAlign = HorizontalAlignment.Center,
                ReadOnly = true
            };

            Control isDirectional = new CheckBox()
            {
                AutoCheck = false,
                Text = "Krawędź jest skierowana",
                TextAlign = ContentAlignment.MiddleLeft,
                Checked = IsDirectional
            };

            properties.Add(0, new ControlLabelSet(positionXLabel, positionX));
            properties.Add(1, new ControlLabelSet(positionYLabel, positionY));
            properties.Add(2, new ControlLabelSet(null, isDirectional));

            if (Distance is null) return properties;

            Label distanceLabel = new Label()
            {
                Text = "Dystans"
            };
            Control distance = new NumericUpDown()
            {
                Minimum = 1,
                Maximum = 99,
                Value = (decimal)Distance
            };
            properties.Add(3, new ControlLabelSet(distanceLabel, distance));
            return properties;
        }
        public void SetProperty(int key, Control control)
        {
            switch (key)
            {
                case 0:
                    //ReadOnly Control
                    //if (!(control is TextBox positionX) || !int.TryParse(positionX.Text, out int parsedX)) return;
                    //SetPosition(parsedX, Position.Y);
                    break;
                case 1:
                    //ReadOnly Control
                    //if (!(control is TextBox positionY) || !int.TryParse(positionY.Text, out int parsedY)) return;
                    //SetPosition(Position.X, parsedY);
                    break;
                case 2:
                    //ReadOnly Control and IsDirectional is readonly
                    //if (!(control is CheckBox checkbox) || !bool.TryParse(checkbox.Checked.ToString(), out bool parsedValue)) return;
                    //IsDirectional = parsedValue;
                    break;
                case 3:
                    if (Distance is null) return;
                    if (!(control is NumericUpDown nud) || !decimal.TryParse(nud.Value.ToString(), out decimal parsedValue)) return;
                    SetDistance((int)parsedValue);
                    break;
                default:
                    throw new GraphException($"Invalid property key passed to SetProperty method - key: {key}");
            }
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
