using System;
using System.Windows.Forms;
using GraphAlgorithmVisualizer.MathObjects;

namespace GraphAlgorithmVisualizer.Forms
{
    internal partial class RandomGraphCreatorDialog : Form
    {
        public RandomGraphCreatorDialog()
        {
            InitializeComponent();
        }

        public DialogResult ShowDialog(out Graph randomizedGraph)
        {
            DialogResult result = ShowDialog();
            Random rnd = new Random();

            int verticesCount = rnd.Next(
                (int)Math.Min(NUD_VerticesMin.Value, NUD_VerticesMax.Value),
                (int)Math.Max(NUD_VerticesMin.Value, NUD_VerticesMax.Value) + 1
                );
            int edgesCount = rnd.Next(
                (int)Math.Min(NUD_EdgesMin.Value, NUD_EdgesMax.Value),
                (int)Math.Max(NUD_EdgesMin.Value, NUD_EdgesMax.Value) + 1
                );

            DistanceRange acceptableRange;
            int lowerBound = (int)Math.Min(NUD_DistanceMin.Value, NUD_DistanceMax.Value);
            if (lowerBound < 0)
                acceptableRange = DistanceRange.Full;
            else if (lowerBound == 0)
                acceptableRange = DistanceRange.Whole;
            else
                acceptableRange = DistanceRange.Natural;

            Graph graph = new Graph(CB_IsDirectional.Checked, CB_UsesDistances.Checked, acceptableRange, verticesCount);
            for (int i = 0; i < edgesCount; i++)
            {
                int firstIndex = rnd.Next(0, graph.VerticesCount);
                int secondIndex = rnd.Next(0, graph.VerticesCount);
                while (graph.EdgeExists(firstIndex, secondIndex) || firstIndex == secondIndex)
                {
                    secondIndex++;
                    if (secondIndex >= graph.VerticesCount)
                    {
                        firstIndex = (firstIndex + 1) % graph.VerticesCount;
                        secondIndex = 0;
                    }
                }
                graph.AddEdge(graph[firstIndex], graph[secondIndex], rnd.Next((int)NUD_DistanceMin.Value, (int)NUD_DistanceMax.Value + 1));
            }
            randomizedGraph = graph;
            return result;
        }

        private void VerticesValueChanged(object sender, EventArgs e)
        {
            int n = (int)Math.Min(NUD_VerticesMin.Value, NUD_VerticesMax.Value);
            NUD_EdgesMax.Maximum = NUD_EdgesMin.Maximum = (n * (n - 3) / 2) + n;
            if (CB_IsDirectional.Checked)
            {
                NUD_EdgesMin.Maximum *= 2;
                NUD_EdgesMax.Maximum *= 2;
            }
        }

        private void UsesDistanceCheckedState(object sender, EventArgs e) => 
            NUD_DistanceMin.Enabled = NUD_DistanceMax.Enabled = CB_UsesDistances.Checked;
    }
}