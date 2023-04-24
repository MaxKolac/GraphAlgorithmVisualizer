using System.Windows.Forms;

namespace GraphAlgorithmVisualizer.Visualization
{
    /// <summary>
    /// A simple class which acts as a package, containing a Windows.Forms.Control and a Label representing it.
    /// </summary>
    internal class ControlLabelSet
    {
        public readonly Label Label;
        public readonly Control Control;

        public ControlLabelSet(Label label, Control control)
        {
            Label = label;
            Control = control;
        }
    }
}
