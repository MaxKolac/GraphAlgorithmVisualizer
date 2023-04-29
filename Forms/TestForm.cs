using GraphAlgorithmVisualizer.Visualization.Shapes;
using System.Drawing;
using System.Windows.Forms;

namespace GraphAlgorithmVisualizer.Forms
{
    public partial class TestForm : Form
    {
        private readonly Graphics graphics;
        private FormState state = FormState.None;

        private SelectionRectangle rectangle;
        private Point selectionRect_firstCorner = new Point();

        private enum FormState { None, SelectionRectBegan }

        public TestForm()
        {
            InitializeComponent();
            PB_Canvas.Image = new Bitmap(PB_Canvas.Width, PB_Canvas.Height);
            graphics = Graphics.FromImage(PB_Canvas.Image);
        }

        private void PB_Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (state == FormState.None)
            {
                selectionRect_firstCorner = PB_Canvas.PointToClient(Cursor.Position);
                rectangle = new SelectionRectangle(selectionRect_firstCorner, selectionRect_firstCorner);
                rectangle.Draw(graphics);
                state = FormState.SelectionRectBegan;
                PB_Canvas.Refresh();
            }
        }

        private void PB_Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (state == FormState.SelectionRectBegan)
            {
                CleanCanvas();
                rectangle.SetSecondPosition(PB_Canvas.PointToClient(Cursor.Position));
                rectangle.Draw(graphics);
                PB_Canvas.Refresh();
            }
        }

        private void PB_Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (state == FormState.SelectionRectBegan)
            {
                CleanCanvas();
                state = FormState.None;
            }
        }

        private void CleanCanvas() => graphics.FillRectangle(new SolidBrush(PB_Canvas.BackColor), 0, 0, PB_Canvas.Width, PB_Canvas.Height);
    }
}
