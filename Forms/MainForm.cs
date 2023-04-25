﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GraphAlgorithmVisualizer.Algorithms;
using GraphAlgorithmVisualizer.Exceptions;
using GraphAlgorithmVisualizer.Forms;
using GraphAlgorithmVisualizer.MathObjects;
using GraphAlgorithmVisualizer.Tests;
using GraphAlgorithmVisualizer.Visualization;
using GraphAlgorithmVisualizer.Visualization.Shapes;

namespace GraphAlgorithmVisualizer
{
    public partial class MainForm : Form
    {
        private readonly Graphics graphics;
        private Graph graph;

        private ISelectable selectedMathObject = null;
        private ISelectable lastSelectedMathObject = null;
        private readonly Dictionary<string, int> lastSelectedMathObjectProperties = new Dictionary<string, int>();

        private Point cursorPosition = new Point();
        private int? cursorOffsetX = null;
        private int? cursorOffsetY = null;

        private bool showAddEdgeDialog = true;
        private AddingNewEdgeState addingNewEdgeMode = AddingNewEdgeState.NotActive;
        private Vertex selectedStartVertex = null;
        private Vertex selectedEndVertex = null;

        private enum AddingNewEdgeState { NotActive, NoVerticesSelected, StartVertexSelected }

        public MainForm()
        {
            InitializeComponent();
            PB_Canvas.Image = new Bitmap(PB_Canvas.Width, PB_Canvas.Height);
            graphics = Graphics.FromImage(PB_Canvas.Image);
            CB_Algorithm.SelectedIndex = 0;

            ClearCanvas();
            graph = VisualizationTests.ExampleDistancedGraph(true);
            graph.SetPosition(PB_Canvas.Width / 2, PB_Canvas.Height / 2);
            DrawGraph();
        }

        private void CanvasMouseMove(object sender, MouseEventArgs e)
        {
            ClearCanvas();
            cursorPosition = PB_Canvas.PointToClient(Cursor.Position);
            switch (addingNewEdgeMode)
            {
                case AddingNewEdgeState.NotActive:
                    if (MouseButtons.Left == e.Button)
                    {
                        selectedMathObject?.SetPosition(cursorPosition.X - (cursorOffsetX ?? 0), cursorPosition.Y - (cursorOffsetY ?? 0));
                        selectedMathObject?.DrawSelectedState(graphics);
                    }
                    else
                    {
                        selectedMathObject = DetectNearestSelectableObject();
                        selectedMathObject?.DrawDetectedState(graphics);
                    }
                    break;
                case AddingNewEdgeState.NoVerticesSelected:
                    selectedMathObject = DetectNearestSelectableObject();
                    selectedStartVertex = selectedMathObject as Vertex;
                    selectedStartVertex?.DrawDetectedState(graphics);
                    break;
                case AddingNewEdgeState.StartVertexSelected:
                    selectedStartVertex.DrawSelectedState(graphics);
                    new Arrow(selectedStartVertex.Position, cursorPosition).Draw(graphics);
                    selectedMathObject = DetectNearestSelectableObject();
                    selectedEndVertex = selectedMathObject as Vertex;
                    selectedEndVertex?.DrawDetectedState(graphics);
                    break;
            }
            DrawGraph();
        }
        private void CanvasMouseDown(object sender, MouseEventArgs e)
        {
            switch (addingNewEdgeMode)
            {
                case (AddingNewEdgeState.NotActive):
                    cursorOffsetX = selectedMathObject is null ? 0 : cursorPosition.X - selectedMathObject.X;
                    cursorOffsetY = selectedMathObject is null ? 0 : cursorPosition.Y - selectedMathObject.Y;
                    lastSelectedMathObject = selectedMathObject;
                    FillPropertiesGroupBox();
                    break;
                case (AddingNewEdgeState.NoVerticesSelected):
                    if (selectedStartVertex is null) return;
                    selectedMathObject.DrawSelectedState(graphics);
                    addingNewEdgeMode = AddingNewEdgeState.StartVertexSelected;
                    break;
                case (AddingNewEdgeState.StartVertexSelected):
                    //As of right now, Loops, despite being mathematically valid, aren't supported
                    if (selectedEndVertex is null || selectedStartVertex.Equals(selectedEndVertex)) return;
                    if (graph.UsesDistances) 
                        graph.AddEdge(selectedStartVertex, selectedEndVertex, 1); 
                    else 
                        graph.AddEdge(selectedStartVertex, selectedEndVertex);
                    lastSelectedMathObject = graph.GetEdge(selectedStartVertex.Index, selectedEndVertex.Index);
                    GB_MathObjectProperties.Enabled = true;
                    FillPropertiesGroupBox();
                    addingNewEdgeMode = AddingNewEdgeState.NotActive;
                    selectedStartVertex = null;
                    selectedEndVertex = null;
                    break;
            }
        }

            //Various Utility Methods

        /// <summary>
        /// Iterates over MathObjects of the Graph and compares absolute distance between user's cursor position and the MathObject's position.
        /// MathObjects which were added the most recently have priority over the rest to be considered Detected.
        /// </summary>
        /// <returns>The ISelectable implementing object which was the closest to user's cursor. If no object was detected within a radius of 30 pixels, null is returned instead.</returns>
        private ISelectable DetectNearestSelectableObject()
        {
            if (graph is null) return null;

            Point cursorPosition = PB_Canvas.PointToClient(Cursor.Position);
            ISelectable detectedObject = null;
            double distanceToClosestShape = double.MaxValue;

            List<ISelectable> objects = new List<ISelectable>();
            objects.AddRange(graph.VerticesArray);
            objects.AddRange(graph.EdgesArray);
            for (int i = objects.Count - 1; i >= 0; i--)
            {
                ISelectable selectableObject = objects[i];
                double distanceToCurrentObject = Math.Sqrt(
                    Math.Pow(selectableObject.X - cursorPosition.X, 2) + 
                    Math.Pow(selectableObject.Y - cursorPosition.Y, 2)
                );

                if (distanceToClosestShape > distanceToCurrentObject && distanceToCurrentObject < 30d)
                {
                    detectedObject = selectableObject;
                    distanceToClosestShape = distanceToCurrentObject;
                }
            }
            return detectedObject;
        }
        /// <returns>
        /// Returns the first, smallest integer which wasn't in use by current Vertices Indexes of the Graph.
        /// </returns>
        private int FindFirstUnusedVertexIndex()
        {
            int index = 0;
            List<int> indexesInUse = new List<int>();
            foreach (Vertex v in graph.VerticesArray)
                indexesInUse.Add(v.Index);
            while (indexesInUse.Contains(index))
                index++;
            return index;
        }
        /// <summary>
        /// Clears Controls inside GB_MathObjectProperties and the lastSelectedMathObjectsProperties dictionary and refills them with values from the lastSelectedMathObject, assuming its non-null. Additionally, adds event listeners to the retrieved Controls to update their respective property inside lastSelectedMathObject when its value changes.
        /// </summary>
        private void FillPropertiesGroupBox()
        {
            if (lastSelectedMathObject is null) return;
            GB_MathObjectProperties.Enabled = true;
            Control[] controlsArray = new Control[GB_MathObjectProperties.Controls.Count];
            GB_MathObjectProperties.Controls.CopyTo(controlsArray, 0);
            for (int i = controlsArray.Length - 1; i >= 0; i--)
            {
                Control control = controlsArray[i];
                if (control.Name == "BTN_RemoveMathObj") continue;
                GB_MathObjectProperties.Controls.Remove(control);
            }
            lastSelectedMathObjectProperties.Clear();
            
            Label identityLabel = lastSelectedMathObject.GetIdentityLabel();
            identityLabel.Location = new Point(5, 20);
            GB_MathObjectProperties.Controls.Add(identityLabel);

            int positionX = identityLabel.Location.X;
            int positionY = identityLabel.Location.Y + identityLabel.Height;
            foreach (KeyValuePair<int, ControlLabelSet> kvp in lastSelectedMathObject.GetProperties())
            {
                Label kvpLabel = kvp.Value.Label;
                Control kvpControl = kvp.Value.Control;
                if (kvpControl.Name is null)
                    throw new GraphException("Last selected MathObject's properties returned a Control without a Name property.");

                if (!(kvpLabel is null)) kvpLabel.Location = new Point(positionX, positionY);
                kvpControl.Location = new Point(positionX + (kvpLabel is null ? 0 : kvpLabel.Width + 30), positionY);
                positionY += kvpControl.Height + 3;

                if (kvpControl is TextBox textbox)
                    textbox.TextChanged += (sender, e) => 
                    { lastSelectedMathObject.SetProperty(lastSelectedMathObjectProperties[textbox.Name], textbox); FullyRedrawGraph(); };
                else if (kvpControl is CheckBox checkbox)
                    checkbox.CheckStateChanged += (sender, e) => 
                    { lastSelectedMathObject.SetProperty(lastSelectedMathObjectProperties[checkbox.Name], checkbox); FullyRedrawGraph(); };
                else if (kvpControl is NumericUpDown nud)
                    nud.ValueChanged += (sender, e) => 
                    { lastSelectedMathObject.SetProperty(lastSelectedMathObjectProperties[nud.Name], nud); FullyRedrawGraph(); };
                else
                    throw new GraphException("Last selected MathObject's properties contained an unsupported Control type. Cannot add a new EventListener to it.");
                
                lastSelectedMathObjectProperties.Add(kvpControl.Name, kvp.Key);
                if (!(kvpLabel is null)) 
                    GB_MathObjectProperties.Controls.Add(kvpLabel);
                GB_MathObjectProperties.Controls.Add(kvpControl);
            }
        }

            //Graph Rendering Methods

        /// <summary>
        /// Calls the Graph.Draw() method and forces PB_Canvas control to refresh.
        /// </summary>
        private void DrawGraph()
        {
            graph?.Draw(graphics);
            PB_Canvas.Refresh();
        }
        /// <summary>
        /// Fills the Canvas entirely with the PB_Canvas' background color.
        /// </summary>
        private void ClearCanvas() => graphics.FillRectangle(new SolidBrush(PB_Canvas.BackColor), 0, 0, PB_Canvas.Width, PB_Canvas.Height);
        /// <summary>
        /// Combination of ClearCanvas() and DrawGraph() in one method.
        /// </summary>
        private void FullyRedrawGraph()
        {
            ClearCanvas();
            DrawGraph();
        }

            //Menu Strip Buttons Logic

        private void OpenGraphCreatorDialog(object sender, EventArgs e)
        {
            GraphCreatorDialog dialog = new GraphCreatorDialog();
            if (dialog.ShowDialog(out int verticesCount, out bool isDirectional, out bool usesDistances) == DialogResult.OK)
            {
                ClearCanvas();
                graph = new Graph(isDirectional, usesDistances, verticesCount);
                graph.SetPosition(PB_Canvas.Width / 2, PB_Canvas.Height / 2);
                DrawGraph();
            }
        }
        private void AddVertexButtonClicked(object sender, EventArgs e)
        {
            int newIndex = FindFirstUnusedVertexIndex();
            graph.AddVertex(newIndex);
            graph.GetVertex(newIndex).SetPosition(PB_Canvas.Width / 2, PB_Canvas.Height / 2);
            ClearCanvas();
            DrawGraph();
        }
        private void AddEdgeButtonClicked(object sender, EventArgs e)
        {
            GB_MathObjectProperties.Enabled = false;
            addingNewEdgeMode = AddingNewEdgeState.NoVerticesSelected;
            if (showAddEdgeDialog)
            {
                DialogResult result = MessageBox.Show(
                    "Aby dodać nową krawędź, najpierw kliknij na wierzchołek początkowy, a następnie wierzchołek końcowy." +
                    "\nWłaściwości nowo dodanej krawędzi będzie można zmienić po jej utworzeniu." +
                    "\nAby wyłączyć pokazywanie tego komunikatu, wciśnij \"Anuluj\"", 
                    "Jak dodać krawędź",
                    MessageBoxButtons.OKCancel
                    );
                showAddEdgeDialog = result != DialogResult.Cancel;
            }
        }
        private void RemoveMathObjButtonClicked(object sender, EventArgs e)
        {
            if (lastSelectedMathObject is null) return;
            GB_MathObjectProperties.Enabled = false;
            if (lastSelectedMathObject is Vertex vertex)
                graph.RemoveVertex(vertex);
            else if (lastSelectedMathObject is Edge edge)
                graph.RemoveEdge(edge);
            lastSelectedMathObject = null;
            FullyRedrawGraph();
        }
        private void AnalyzeButtonClicked(object sender, EventArgs e)
        {
            if (graph is null || graph.VerticesCount == 0 || graph.EdgesCount == 0)
            {
                MessageBox.Show("Aby algorytm mógł działać, potrzebuje niepustego grafu.");
                return;
            }
            if (!(lastSelectedMathObject is Vertex startVertex))
            {
                MessageBox.Show("Aby algorytm mógł działać, jeden z wierzchołków musi być wybrany jako początkowy." +
                    "\nZa wierzchołek początkowy uznawany jest ostatni kliknięty wierzchołek.");
                return;
            }
            Algorithm algorithm;
            DGV_AlgorithmResult.Rows.Clear();

            switch (CB_Algorithm.SelectedIndex)
            {
                case 0: //DepthFirstSearch
                    algorithm = new DepthFirstSearch(graph);
                    break;
                case 1: //BreadthFirstSearch
                    algorithm = new BreadthFirstSearch(graph);
                    break;
                case 2: //Djikstra Algorithm
                    if (!graph.UsesDistances)
                    {
                        MessageBox.Show("Algorytm Djikstra może być przeprowadzony tylko na grafach implementujących dystanse.");
                        return;
                    }
                    algorithm = new DjikstraAlgorithm(graph);
                    break;
                default:
                    throw new NotImplementedException();
            }

            algorithm.Perform(startVertex);
            DGV_AlgorithmResult.Columns[1].HeaderText = algorithm.GetFirstColumnLabel();
            DGV_AlgorithmResult.Columns[2].HeaderText = algorithm.GetSecondColumnLabel();
            for (int i = 0; i < graph.VerticesCount; i++)
            {
                Vertex v = graph.VerticesArray[i];
                DGV_AlgorithmResult.Rows.Add();
                DGV_AlgorithmResult.Rows[i].Cells[0].Value = v;
                DGV_AlgorithmResult.Rows[i].Cells[1].Value = algorithm.GetFirstColumnDataForVertex(v);
                DGV_AlgorithmResult.Rows[i].Cells[2].Value = algorithm.GetSecondColumnDataForVertex(v);
            }
        }
    }
}