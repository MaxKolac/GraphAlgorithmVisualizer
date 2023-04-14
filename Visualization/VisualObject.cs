using System.Drawing;

namespace GraphAlgorithmVisualizer.Visualization
{
    internal abstract class VisualObject
    {
        public int X;
        public int Y;

        protected Pen pen = new Pen(Color.Black, 3);
        protected Font font = new Font(FontFamily.GenericSansSerif, 8);

        protected VisualObject(int x, int y)
        {
            MoveTo(x, y);
        }
        
        protected VisualObject(Point p)
        {
            MoveTo(p.X, p.Y);
        }

        /// <summary>
        /// Moves the object to the specified (X,Y) coordinates.
        /// </summary>
        public void MoveTo(int x, int y)
        {
            X = x; 
            Y = y;
        }
        /// <summary>
        /// Draws the visualizable object on the specified canvas on the (X,Y) coordinates.
        /// </summary>
        public abstract void Draw(Graphics canvas);
    }
}
