using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GraphAlgorithmVisualizer.Visualization
{
    /// <summary>
    /// Interface implemented by visualizable MathObjects that appear on the main Canvas and can be interacted with, can have its properties viewed and changed, can be moved around and such.
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
        /// <summary>
        /// Builds and returns a Dictionary with each entry containing a combination of Forms.Control and Forms.Label as a ControlLabelSet that will be put in the GB_Properties for the user to view/modify and an Integer which is meant to uniquely identify the Control when any applied modifications to its value are sent back to the ISelectable object through SetProperty() method.
        /// <para>Labels are optional, Controls are required. Each Control is also required to have a unique Name, otherwise Hell will break loose.</para>
        /// </summary>
        Dictionary<int, ControlLabelSet> GetProperties();
        /// <summary>
        /// Sets the ISelectable's inside property to the value wrapped in the Forms.Control.
        /// </summary>
        /// <param name="key">The identifying Integer which uniquely identifies which ISelectable's inside property should be changed.</param>
        /// <param name="control">A Windows.Forms.Control with the applied changes to its value.</param>
        void SetProperty(int key, Control control);
        /// <summary>
        /// Returns a Label object which shows the object's identity in GB_MathObjectProperties in bold text.
        /// </summary>
        /// <returns></returns>
        Label GetIdentityLabel();
    }
}
