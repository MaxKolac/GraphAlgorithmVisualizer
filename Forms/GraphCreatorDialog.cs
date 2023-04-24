using System.Windows.Forms;

namespace GraphAlgorithmVisualizer.Forms
{
    public partial class GraphCreatorDialog : Form
    {
        public GraphCreatorDialog()
        {
            InitializeComponent();
        }

        public DialogResult ShowDialog(out int initialVerticesCount, out bool isDirectional, out bool usesDistances)
        {
            DialogResult result = ShowDialog();
            initialVerticesCount = (int)NUD_Vertices.Value;
            isDirectional = CB_IsDirectional.Checked;
            usesDistances = CB_UsesDistances.Checked;
            return result;
        }
    }
}
