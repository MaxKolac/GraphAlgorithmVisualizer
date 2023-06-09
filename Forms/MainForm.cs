﻿using System;
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
        private FormState formState = FormState.None;

        private enum FormState { 
            None, 
            AddingNewEdge_NoVerticesSelected, AddingNewEdge_OneVertexSelected, 
            MultipleSelection_Selecting, MultipleSelection_ObjectsSelected, MultipleSelection_OneOfObjectsClicked
        }

        private ISelectable selectedMathObject = null;
        private ISelectable lastSelectedMathObject = null;
        private readonly Dictionary<string, int> lastSelectedMathObjectProperties = new Dictionary<string, int>();

        private Point cursorPosition = new Point();
        private int? cursorOffsetX = null;
        private int? cursorOffsetY = null;

        private bool showAddEdgeDialog = true;
        private Vertex selectedStartVertex = null;
        private Vertex selectedEndVertex = null;

        private readonly SelectionRectangle selectionRectangle = new SelectionRectangle(Point.Empty, Point.Empty);
        private readonly List<ISelectable> selectedObjects = new List<ISelectable>();

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

        private void CanvasMouseDown(object sender, MouseEventArgs e)
        {
            cursorPosition = PB_Canvas.PointToClient(Cursor.Position);
            switch (formState)
            {
                case FormState.None:
                    lastSelectedMathObject = selectedMathObject;
                    FillPropertiesGroupBox();
                    if (selectedMathObject is null)
                    {
                        selectionRectangle.SetPosition(cursorPosition.X, cursorPosition.Y);
                        selectionRectangle.SetSecondPosition(cursorPosition);
                        selectionRectangle.Draw(graphics);
                        formState = FormState.MultipleSelection_Selecting;
                        break;
                    }
                    cursorOffsetX = cursorPosition.X - selectedMathObject.X;
                    cursorOffsetY = cursorPosition.Y - selectedMathObject.Y;
                    break;

                case FormState.AddingNewEdge_NoVerticesSelected:
                    selectedMathObject = DetectNearestSelectableObject();
                    if (selectedStartVertex is null) return;
                    selectedMathObject.DrawSelectedState(graphics);
                    formState = FormState.AddingNewEdge_OneVertexSelected;
                    break;

                case FormState.AddingNewEdge_OneVertexSelected:
                    //As of right now, Loops, despite being mathematically valid, aren't supported
                    if (selectedEndVertex is null || selectedStartVertex.Equals(selectedEndVertex)) return;
                    if (graph.UsesDistances) 
                        graph.AddEdge(selectedStartVertex, selectedEndVertex, 1); 
                    else 
                        graph.AddEdge(selectedStartVertex, selectedEndVertex);
                    lastSelectedMathObject = graph.GetEdge(selectedStartVertex.Index, selectedEndVertex.Index);
                    GB_MathObjectProperties.Enabled = true;
                    FillPropertiesGroupBox();
                    formState = FormState.None;
                    selectedStartVertex = null;
                    selectedEndVertex = null;
                    break;

                case FormState.MultipleSelection_Selecting:
                    break;

                case FormState.MultipleSelection_ObjectsSelected:
                    selectedMathObject = DetectNearestSelectableObject();
                    if (selectedMathObject is null)
                    {
                        selectedObjects.Clear();
                        formState = FormState.None;
                    }
                    else if (!selectedObjects.Contains(selectedMathObject))
                    {
                        selectedObjects.Clear();
                        lastSelectedMathObject = selectedMathObject;
                        formState = FormState.None;
                        FillPropertiesGroupBox();
                    }
                    else
                    {
                        foreach (ISelectable selectable in selectedObjects)
                            selectable.DrawSelectedState(graphics);
                        formState = FormState.MultipleSelection_OneOfObjectsClicked;
                    }
                    break;

                case FormState.MultipleSelection_OneOfObjectsClicked:
                    break;
            }
        }
        private void CanvasMouseMove(object sender, MouseEventArgs e)
        {
            ClearCanvas();
            Point previourCursorPosition = cursorPosition;
            cursorPosition = PB_Canvas.PointToClient(Cursor.Position);
            switch (formState)
            {
                case FormState.None:
                    if (MouseButtons.Left == e.Button)
                    {
                        selectedMathObject?.SetPosition(cursorPosition.X - (cursorOffsetX ?? 0), cursorPosition.Y - (cursorOffsetY ?? 0));
                        selectedMathObject?.DrawSelectedState(graphics);
                        break;
                    }
                    selectedMathObject = DetectNearestSelectableObject();
                    selectedMathObject?.DrawDetectedState(graphics);
                    break;

                case FormState.AddingNewEdge_NoVerticesSelected:
                    selectedMathObject = DetectNearestSelectableObject();
                    selectedStartVertex = selectedMathObject as Vertex;
                    selectedStartVertex?.DrawDetectedState(graphics);
                    break;

                case FormState.AddingNewEdge_OneVertexSelected:
                    selectedStartVertex.DrawSelectedState(graphics);
                    new Arrow(selectedStartVertex.Position, cursorPosition).Draw(graphics);
                    selectedMathObject = DetectNearestSelectableObject();
                    selectedEndVertex = selectedMathObject as Vertex;
                    selectedEndVertex?.DrawDetectedState(graphics);
                    break;

                case FormState.MultipleSelection_Selecting:
                    selectedObjects.Clear();
                    selectionRectangle.SetSecondPosition(cursorPosition);
                    selectionRectangle.Draw(graphics);
                    foreach (ISelectable selectable in graph.GetISelectableMathObjects())
                    {
                        if (selectionRectangle.IsWithinSelectionBounds(selectable.Position))
                        {
                            selectedObjects.Add(selectable);
                            selectable.DrawDetectedState(graphics);
                        }
                    }
                    break;

                case FormState.MultipleSelection_ObjectsSelected:
                    selectedMathObject = DetectNearestSelectableObject();
                    if (selectedMathObject is null || !selectedObjects.Contains(selectedMathObject))
                    {
                        foreach (ISelectable selectable in selectedObjects)
                            selectable.DrawDetectedState(graphics);
                    }
                    else
                    {
                        foreach (ISelectable selectable in selectedObjects)
                            selectable.DrawSelectedState(graphics);
                    }
                    break;

                case FormState.MultipleSelection_OneOfObjectsClicked:
                    foreach (ISelectable selectable in selectedObjects)
                    {
                        selectable.MovePosition(cursorPosition.X - previourCursorPosition.X, cursorPosition.Y - previourCursorPosition.Y);
                        selectable.DrawSelectedState(graphics);
                    }
                    break;
            }
            DrawGraph();
        }
        private void CanvasMouseUp(object sender, MouseEventArgs e)
        {
            ClearCanvas();
            switch (formState)
            {
                case FormState.None:
                case FormState.AddingNewEdge_NoVerticesSelected:
                case FormState.AddingNewEdge_OneVertexSelected:
                    break;

                case FormState.MultipleSelection_Selecting:
                    foreach (ISelectable selectable in selectedObjects)
                        selectable.DrawDetectedState(graphics);
                    if (selectedObjects.Count == 0)
                    {
                        formState = FormState.None;
                    }
                    else if (selectedObjects.Count == 1)
                    {
                        lastSelectedMathObject = selectedMathObject = selectedObjects[0];
                        cursorOffsetX = cursorPosition.X - selectedMathObject.X;
                        cursorOffsetY = cursorPosition.Y - selectedMathObject.Y;
                        formState = FormState.None;
                        FillPropertiesGroupBox();
                    }
                    else
                    {
                        lastSelectedMathObject = null;
                        FillPropertiesGroupBox();
                        formState = FormState.MultipleSelection_ObjectsSelected;
                    }
                    break;

                case FormState.MultipleSelection_ObjectsSelected:
                    break;

                case FormState.MultipleSelection_OneOfObjectsClicked:
                    foreach (ISelectable selectable in selectedObjects)   
                        selectable.DrawDetectedState(graphics);
                    formState = FormState.MultipleSelection_ObjectsSelected;
                    break;
            }
            DrawGraph();
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
            
            if (formState == FormState.MultipleSelection_Selecting || 
                formState == FormState.MultipleSelection_ObjectsSelected || 
                formState == FormState.MultipleSelection_OneOfObjectsClicked)
            {
                GB_MathObjectProperties.Controls.Add(
                    new Label()
                    {
                        AutoSize = true,
                        Text = "Zaznaczono wiele obiektów.",
                        Font = DrawingTools.DefaultFont,
                        Location = new Point(5, 20)
                    }
                );
                BTN_RemoveMathObj.Enabled = false;
                return;
            }
            BTN_RemoveMathObj.Enabled = true;

            if (lastSelectedMathObject is null) return;
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
                {
                    nud.ValueChanged += (sender, e) => 
                    {
                        //https://stackoverflow.com/questions/25938227/c-sharp-numericupdown-onvaluechanged-how-it-was-changed
                        NumericUpDown obj = (NumericUpDown)sender;
                        int currentValue = (int)obj.Value;
                        int lastValue = obj.Tag is null ? (int)obj.Value : int.Parse(obj.Tag.ToString());
                        obj.Tag = currentValue;

                        if (graph.AcceptableDistances == DistanceRange.FullExceptZero && currentValue == 0)
                        {
                            if (lastValue == 1)
                                obj.Value = -1;
                            else if (lastValue == -1) 
                                obj.Value = 1;
                        }
                        lastSelectedMathObject.SetProperty(lastSelectedMathObjectProperties[nud.Name], nud); 
                        FullyRedrawGraph(); 
                    };
                    switch (graph.AcceptableDistances)
                    {
                        case DistanceRange.Full:
                        case DistanceRange.FullExceptZero: nud.Minimum = -99; break;
                        case DistanceRange.Whole: nud.Minimum = 0; break;
                        case DistanceRange.Natural: nud.Minimum = 1; break;
                    }
                }
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
            if (dialog.ShowDialog(out int verticesCount, out DistanceRange acceptableDistances, out bool isDirectional, out bool usesDistances) == DialogResult.OK)
            {
                formState = FormState.None;
                ClearCanvas();
                graph = new Graph(isDirectional, usesDistances, acceptableDistances, verticesCount);
                graph.SetPosition(PB_Canvas.Width / 2, PB_Canvas.Height / 2);
                DrawGraph();
            }
        }
        private void OpenRandomGraphCreatorDialog(object sender, EventArgs e)
        {
            RandomGraphCreatorDialog dialog = new RandomGraphCreatorDialog();
            if (dialog.ShowDialog(out Graph randomizedGraph) == DialogResult.OK)
            {
                formState = FormState.None;
                ClearCanvas();
                graph = randomizedGraph;
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
            formState = FormState.AddingNewEdge_NoVerticesSelected;
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
                    "\nZa wierzchołek początkowy uznawany jest ostatni, pojedyńczy, kliknięty wierzchołek.");
                return;
            }
            Algorithm algorithm;
            DGV_AlgorithmResult.Rows.Clear();

            try
            {
                switch (CB_Algorithm.SelectedIndex)
                {
                    case 0: //DepthFirstSearch
                        algorithm = new DepthFirstSearch(graph);
                        break;
                    case 1: //BreadthFirstSearch
                        algorithm = new BreadthFirstSearch(graph);
                        break;
                    case 2: //Dijkstra Algorithm
                        algorithm = new DijkstraAlgorithm(graph);
                        break;
                    case 3: //Bellman-Ford Algorithm
                        algorithm = new BellmanFordAlgorithm(graph);
                        break;
                    default:
                        throw new NotImplementedException();
                }
                //algorithm.Perform(startVertex);
                algorithm.PerformAndCount(startVertex);
            } 
            catch (AlgorithmException exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }
            catch (NotImplementedException)
            {
                MessageBox.Show("Ten algorytm nie został jeszcze w pełni zaimplementowany.");
                return;
            }

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
            LB_PerformedOpetations.Text = algorithm.GetOperationsPerformed();
        }
    }
}
