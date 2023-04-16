using System.Drawing;

namespace GraphAlgorithmVisualizer.Visualization
{
    /// <summary>
    /// Interface implemented by MathObjects that allows them to be rendered and visualized on an Graphics object using System.Drawing library.
    /// </summary>
    internal interface IVisualizable
    {
        //int X { get; set; }
        //int Y { get; set; }

        /// <summary>
        /// Changes the object's coordinates to (x,y).
        /// </summary>
        //void MoveTo(int x, int y);
        /// <summary>
        /// Draws the visual representation of the object on the specified Graphics.
        /// </summary>
        void Draw(Graphics graphics);
    }
}
