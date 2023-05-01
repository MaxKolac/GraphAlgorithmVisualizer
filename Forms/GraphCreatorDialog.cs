using System.Windows.Forms;

namespace GraphAlgorithmVisualizer.Forms
{
    internal partial class GraphCreatorDialog : Form
    {
        public GraphCreatorDialog()
        {
            InitializeComponent();
            CB_AcceptableDistances.SelectedIndex = 0;
        }

        public DialogResult ShowDialog(out int initialVerticesCount, out MathObjects.DistanceRange distanceRange, out bool isDirectional, out bool usesDistances)
        {
            DialogResult result = ShowDialog();
            initialVerticesCount = (int)NUD_Vertices.Value;
            distanceRange = (MathObjects.DistanceRange)CB_AcceptableDistances.SelectedIndex;
            isDirectional = CB_IsDirectional.Checked;
            usesDistances = CB_UsesDistances.Checked;
            return result;
        }

        private void UsesDistancesCheckChanged(object sender, System.EventArgs e) => CB_AcceptableDistances.Enabled = CB_UsesDistances.Checked;
    }
}
