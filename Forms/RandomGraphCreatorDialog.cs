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
            randomizedGraph = GenerateRandomGraph(
                rnd.Next(
                (int)Math.Min(NUD_VerticesMin.Value, NUD_VerticesMax.Value),
                (int)Math.Max(NUD_VerticesMin.Value, NUD_VerticesMax.Value) + 1
                ),
                rnd.Next(
                (int)Math.Min(NUD_EdgesMin.Value, NUD_EdgesMax.Value),
                (int)Math.Max(NUD_EdgesMin.Value, NUD_EdgesMax.Value) + 1
                ),
                CB_IsDirectional.Checked,
                CB_UsesDistances.Checked,
                (int)Math.Min(NUD_DistanceMin.Value, NUD_DistanceMax.Value),
                (int)Math.Max(NUD_DistanceMin.Value, NUD_DistanceMax.Value));
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

        /// <summary>
        /// Generates and returns a randomized Graph with the provided properties.
        /// </summary>
        /// <param name="verticesCount">The exact amount of Vertices to put in the Graph.</param>
        /// <param name="edgesCount">The exact amount of Edges to create between Vertices. If this number is too high, it's automatically reduced to the maximum possible amount of Edges.</param>
        /// <param name="isDirectional">Whether or not the Graph should be directional.</param>
        /// <param name="usesDistances">Whether or not should the Graph implement distances on all Edges. If this is set to false, then distance bounds are ignored.</param>
        /// <param name="lowerDistanceBound">The lower inclusive bound of range from which Distance values will be randomized.</param>
        /// <param name="upperDistanceBound">The upperr inclusive bound of range from which Distance values will be randomized.</param>
        public static Graph GenerateRandomGraph(int verticesCount, int edgesCount, bool isDirectional, bool usesDistances, int lowerDistanceBound, int upperDistanceBound)
        {
            Random rnd = new Random();
            int n = (int)Math.Floor((verticesCount * (verticesCount - 3) / 2f) + verticesCount);
            if (isDirectional) n *= 2;
            edgesCount = Math.Min(edgesCount, n);

            DistanceRange acceptableRange;
            int lowerBound = Math.Min(lowerDistanceBound, upperDistanceBound);
            int upperBound = Math.Max(lowerDistanceBound, upperDistanceBound);
            if (lowerBound < 0)
                acceptableRange = DistanceRange.Full;
            else if (lowerBound == 0)
                acceptableRange = DistanceRange.Whole;
            else
                acceptableRange = DistanceRange.Natural;

            Graph graph = new Graph(isDirectional, usesDistances, acceptableRange, verticesCount);
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
                graph.AddEdge(graph[firstIndex], graph[secondIndex], rnd.Next(lowerBound, upperBound + 1));
            }
            return graph;
        }
    }
}