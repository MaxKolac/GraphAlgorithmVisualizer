namespace GraphAlgorithmVisualizer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PB_Canvas = new System.Windows.Forms.PictureBox();
            this.GB_MathObjectProperties = new System.Windows.Forms.GroupBox();
            this.BTN_RemoveMathObj = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.TSMI_CreateNewGraph = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_RandomGraphCreatorDialog = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_AddVertex = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_AddEdge = new System.Windows.Forms.ToolStripMenuItem();
            this.GB_Algorithms = new System.Windows.Forms.GroupBox();
            this.BTN_Analyze = new System.Windows.Forms.Button();
            this.CB_Algorithm = new System.Windows.Forms.ComboBox();
            this.DGV_AlgorithmResult = new System.Windows.Forms.DataGridView();
            this.Vertex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PreviousVertex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Distance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Canvas)).BeginInit();
            this.GB_MathObjectProperties.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.GB_Algorithms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_AlgorithmResult)).BeginInit();
            this.SuspendLayout();
            // 
            // PB_Canvas
            // 
            this.PB_Canvas.Location = new System.Drawing.Point(12, 27);
            this.PB_Canvas.Name = "PB_Canvas";
            this.PB_Canvas.Size = new System.Drawing.Size(606, 522);
            this.PB_Canvas.TabIndex = 0;
            this.PB_Canvas.TabStop = false;
            this.PB_Canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CanvasMouseDown);
            this.PB_Canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CanvasMouseMove);
            this.PB_Canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CanvasMouseUp);
            // 
            // GB_MathObjectProperties
            // 
            this.GB_MathObjectProperties.Controls.Add(this.BTN_RemoveMathObj);
            this.GB_MathObjectProperties.Location = new System.Drawing.Point(624, 27);
            this.GB_MathObjectProperties.Name = "GB_MathObjectProperties";
            this.GB_MathObjectProperties.Size = new System.Drawing.Size(248, 149);
            this.GB_MathObjectProperties.TabIndex = 1;
            this.GB_MathObjectProperties.TabStop = false;
            this.GB_MathObjectProperties.Text = "Właściwości ostatnio wybranego obiektu";
            // 
            // BTN_RemoveMathObj
            // 
            this.BTN_RemoveMathObj.Location = new System.Drawing.Point(167, 120);
            this.BTN_RemoveMathObj.Name = "BTN_RemoveMathObj";
            this.BTN_RemoveMathObj.Size = new System.Drawing.Size(75, 23);
            this.BTN_RemoveMathObj.TabIndex = 0;
            this.BTN_RemoveMathObj.Text = "Usuń obiekt";
            this.BTN_RemoveMathObj.UseVisualStyleBackColor = true;
            this.BTN_RemoveMathObj.Click += new System.EventHandler(this.RemoveMathObjButtonClicked);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_CreateNewGraph,
            this.TSMI_RandomGraphCreatorDialog,
            this.TSMI_AddVertex,
            this.TSMI_AddEdge});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(884, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip";
            // 
            // TSMI_CreateNewGraph
            // 
            this.TSMI_CreateNewGraph.Name = "TSMI_CreateNewGraph";
            this.TSMI_CreateNewGraph.Size = new System.Drawing.Size(119, 20);
            this.TSMI_CreateNewGraph.Text = "Stwórz nowy graf...";
            this.TSMI_CreateNewGraph.Click += new System.EventHandler(this.OpenGraphCreatorDialog);
            // 
            // TSMI_RandomGraphCreatorDialog
            // 
            this.TSMI_RandomGraphCreatorDialog.Name = "TSMI_RandomGraphCreatorDialog";
            this.TSMI_RandomGraphCreatorDialog.Size = new System.Drawing.Size(133, 20);
            this.TSMI_RandomGraphCreatorDialog.Text = "Generuj losowy graf...";
            this.TSMI_RandomGraphCreatorDialog.Click += new System.EventHandler(this.OpenRandomGraphCreatorDialog);
            // 
            // TSMI_AddVertex
            // 
            this.TSMI_AddVertex.Name = "TSMI_AddVertex";
            this.TSMI_AddVertex.Size = new System.Drawing.Size(115, 20);
            this.TSMI_AddVertex.Text = "Dodaj wierzchołek";
            this.TSMI_AddVertex.Click += new System.EventHandler(this.AddVertexButtonClicked);
            // 
            // TSMI_AddEdge
            // 
            this.TSMI_AddEdge.Name = "TSMI_AddEdge";
            this.TSMI_AddEdge.Size = new System.Drawing.Size(96, 20);
            this.TSMI_AddEdge.Text = "Dodaj krawędź";
            this.TSMI_AddEdge.Click += new System.EventHandler(this.AddEdgeButtonClicked);
            // 
            // GB_Algorithms
            // 
            this.GB_Algorithms.Controls.Add(this.BTN_Analyze);
            this.GB_Algorithms.Controls.Add(this.CB_Algorithm);
            this.GB_Algorithms.Location = new System.Drawing.Point(624, 182);
            this.GB_Algorithms.Name = "GB_Algorithms";
            this.GB_Algorithms.Size = new System.Drawing.Size(248, 46);
            this.GB_Algorithms.TabIndex = 2;
            this.GB_Algorithms.TabStop = false;
            this.GB_Algorithms.Text = "Analiza grafu przy użyciu algorytmu";
            // 
            // BTN_Analyze
            // 
            this.BTN_Analyze.Location = new System.Drawing.Point(189, 17);
            this.BTN_Analyze.Name = "BTN_Analyze";
            this.BTN_Analyze.Size = new System.Drawing.Size(53, 23);
            this.BTN_Analyze.TabIndex = 1;
            this.BTN_Analyze.Text = "Analizuj";
            this.BTN_Analyze.UseVisualStyleBackColor = true;
            this.BTN_Analyze.Click += new System.EventHandler(this.AnalyzeButtonClicked);
            // 
            // CB_Algorithm
            // 
            this.CB_Algorithm.FormattingEnabled = true;
            this.CB_Algorithm.Items.AddRange(new object[] {
            "Algorytm wyszukiwania \"wszesz\"",
            "Algorytm wyszukiwania \"wgłąb\"",
            "Algorytm Djikstra"});
            this.CB_Algorithm.Location = new System.Drawing.Point(6, 19);
            this.CB_Algorithm.Name = "CB_Algorithm";
            this.CB_Algorithm.Size = new System.Drawing.Size(177, 21);
            this.CB_Algorithm.TabIndex = 0;
            // 
            // DGV_AlgorithmResult
            // 
            this.DGV_AlgorithmResult.AllowUserToAddRows = false;
            this.DGV_AlgorithmResult.AllowUserToDeleteRows = false;
            this.DGV_AlgorithmResult.AllowUserToResizeColumns = false;
            this.DGV_AlgorithmResult.AllowUserToResizeRows = false;
            this.DGV_AlgorithmResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGV_AlgorithmResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Vertex,
            this.PreviousVertex,
            this.Distance});
            this.DGV_AlgorithmResult.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DGV_AlgorithmResult.Location = new System.Drawing.Point(624, 234);
            this.DGV_AlgorithmResult.Name = "DGV_AlgorithmResult";
            this.DGV_AlgorithmResult.ReadOnly = true;
            this.DGV_AlgorithmResult.RowHeadersVisible = false;
            this.DGV_AlgorithmResult.Size = new System.Drawing.Size(248, 315);
            this.DGV_AlgorithmResult.TabIndex = 3;
            // 
            // Vertex
            // 
            this.Vertex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Vertex.FillWeight = 35F;
            this.Vertex.HeaderText = "Wierzchołek";
            this.Vertex.Name = "Vertex";
            this.Vertex.ReadOnly = true;
            // 
            // PreviousVertex
            // 
            this.PreviousVertex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PreviousVertex.FillWeight = 40F;
            this.PreviousVertex.HeaderText = "Poprzedni wierz.";
            this.PreviousVertex.Name = "PreviousVertex";
            this.PreviousVertex.ReadOnly = true;
            // 
            // Distance
            // 
            this.Distance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Distance.FillWeight = 25F;
            this.Distance.HeaderText = "Dystans";
            this.Distance.Name = "Distance";
            this.Distance.ReadOnly = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.DGV_AlgorithmResult);
            this.Controls.Add(this.GB_Algorithms);
            this.Controls.Add(this.GB_MathObjectProperties);
            this.Controls.Add(this.PB_Canvas);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Projekt Nr. 2 - Kreator grafów z implementacją algorytmu Djikstry - Algorytmy i Z" +
    "łożoność - Maksymilian Kołaciński nr. alb.: 57527";
            ((System.ComponentModel.ISupportInitialize)(this.PB_Canvas)).EndInit();
            this.GB_MathObjectProperties.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.GB_Algorithms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_AlgorithmResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PB_Canvas;
        private System.Windows.Forms.GroupBox GB_MathObjectProperties;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem TSMI_CreateNewGraph;
        private System.Windows.Forms.ToolStripMenuItem TSMI_AddVertex;
        private System.Windows.Forms.ToolStripMenuItem TSMI_AddEdge;
        private System.Windows.Forms.GroupBox GB_Algorithms;
        private System.Windows.Forms.Button BTN_RemoveMathObj;
        private System.Windows.Forms.Button BTN_Analyze;
        private System.Windows.Forms.ComboBox CB_Algorithm;
        private System.Windows.Forms.DataGridView DGV_AlgorithmResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vertex;
        private System.Windows.Forms.DataGridViewTextBoxColumn PreviousVertex;
        private System.Windows.Forms.DataGridViewTextBoxColumn Distance;
        private System.Windows.Forms.ToolStripMenuItem TSMI_RandomGraphCreatorDialog;
    }
}