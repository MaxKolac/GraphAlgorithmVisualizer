using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GraphAlgorithmVisualizer.Exceptions;
using GraphAlgorithmVisualizer.Visualization;

namespace GraphAlgorithmVisualizer.MathObjects
{
    /// <summary>
    /// Single point of a Graph with a unique identifing Index. It may be connected to another vertex through an <c>Edge</c>. Visually represented by a simple circle with its Index inside it.
    /// </summary>
    internal class Vertex : ISelectable
    {
        public Point Position { get; private set; }
        public int X => Position.X;
        public int Y => Position.Y;

        /// <summary>
        /// A unique integer that identifies this Vertex. Assigned by the Graph which created this Vertex.
        /// </summary>
        public readonly int Index;
        /// <summary>
        /// Whether or not the Vertex is contained inside a directed Graph.
        /// </summary>
        public readonly bool IsDirectional;

        /// <summary>
        /// Creates a new Vertex.
        /// </summary>
        /// <param name="id">Vertex's unique ID.</param>
        /// <param name="graphIsDirectional">Determines if it should behave as if it was in a directed or undirected Graph.</param>
        public Vertex(int index, bool graphIsDirectional)
        {
            Index = index;
            IsDirectional = graphIsDirectional;
            Position = new Point(0, 0);
        }

        public void SetPosition(int x, int y) => Position = new Point(x, y);
        public void MovePosition(int deltaX, int deltaY) => Position = new Point(Position.X + deltaX, Position.Y + deltaY);
        public void Draw(Graphics graphics)
        {
            int size = 20;
            graphics.FillEllipse(DrawingTools.DefaultBackColor, Position.X - (size / 2), Position.Y - (size / 2), size, size);
            graphics.DrawEllipse(DrawingTools.DefaultOutline, Position.X - (size / 2), Position.Y - (size / 2), size, size);
            graphics.DrawString($"{Index}", DrawingTools.DefaultFont, DrawingTools.DefaultFontColor, Position.X - (size / 2) + 3, Position.Y - (size / 2));
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

            properties.Add(0, new ControlLabelSet(positionXLabel, positionX));
            properties.Add(1, new ControlLabelSet(positionYLabel, positionY));
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
                default:
                    throw new GraphException($"Invalid property key passed to SetProperty method - key: {key}");
            }
        }

        public override string ToString()
        {
            return $"({Index})";
        }
    }
}
