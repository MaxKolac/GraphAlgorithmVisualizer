using System.Drawing;

namespace GraphAlgorithmVisualizer.Visualization.Shapes
{
    /// <summary>
    /// A filled square with the Edge's distance inside of it.
    /// </summary>
    internal class LabelSquare : Shape
    {
        public new Point Position => base.Position;
        public new int X => base.X;
        public new int Y => base.Y;
        public string Label { get; private set; }

        private const int squareSingleHeight = 12 + 4;
        private const int squareSingleWidth = 12 + 4;
        private int squareWidth;

        public LabelSquare(int x, int y, string label) : base(x, y)
        {
            SetLabelText(label);
        }

        public void SetLabelText(string text)
        {
            Label = text;
            squareWidth = squareSingleWidth * text.Length;
        }

        public override void Draw(Graphics graphics)
        {
            Point leftUpperCorner = new Point(X - (squareWidth / 2), Y - (squareSingleHeight / 2));
            graphics.FillRectangle(new SolidBrush(Color.White), leftUpperCorner.X, leftUpperCorner.Y, squareWidth, squareSingleHeight);
            graphics.DrawString(Label, DrawingTools.DefaultFont, DrawingTools.DefaultFontColor, leftUpperCorner.X, leftUpperCorner.Y - 2);
            graphics.DrawRectangle(DrawingTools.DefaultOutline, leftUpperCorner.X, leftUpperCorner.Y, squareWidth, squareSingleHeight);
        }
        public override void SetPosition(int x, int y) => base.Position = new Point(x, y);
        public override void MovePosition(int deltaX, int deltaY) => base.Position = new Point(Position.X + deltaX, Position.Y + deltaY);
    }
}
