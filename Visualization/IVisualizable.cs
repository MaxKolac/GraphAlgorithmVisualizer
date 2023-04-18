using System.Drawing;

namespace GraphAlgorithmVisualizer.Visualization
{
    /// <summary>
    /// Interface implemented by MathObjects that allows them to be rendered and visualized on an Graphics object using System.Drawing library.
    /// </summary>
    internal interface IVisualizable
    {
        int X { get; set; }
        int Y { get; set; }

        /// <summary>
        /// Changes the object's coordinates to exact (x,y).
        /// </summary>
        void SetPosition(int x, int y);
        /// <summary>
        /// Changes the object's coordinaets by the specified deltas from its original position.
        /// </summary>
        void MovePosition(int deltaX, int deltaY);
        /// <summary>
        /// Draws the visual representation of the object on the specified Graphics.
        /// </summary>
        void Draw(Graphics graphics);
    }
}
