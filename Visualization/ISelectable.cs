using System.Drawing;

namespace GraphAlgorithmVisualizer.Visualization
{
    /// <summary>
    /// Interface implemented by visualizable MathObjects that appear on the main Canvas and can be interacted with, moved around and such.
    /// Subinterface of IVisualizable.
    /// </summary>
    internal interface ISelectable : IVisualizable
    {
        /// <summary>
        /// Draws additional visual representation to show to the user that the object is succesfully Detected by the program.
        /// </summary>
        /// <param name="graphics">The Graphics object to draw the Detected form on.</param>
        void DrawDetectedState(Graphics graphics);
        /// <summary>
        /// Draws additional visual representation to show to the user that the object is succesfully Selected by user's cursor.
        /// </summary>
        /// <param name="graphics">The Graphics object to draw the Selected form on.</param>
        void DrawSelectedState(Graphics graphics);
    }
}
