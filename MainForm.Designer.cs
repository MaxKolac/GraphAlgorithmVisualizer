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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.TSMI_CreateNewGraph = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_AddVertex = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_AddEdge = new System.Windows.Forms.ToolStripMenuItem();
            this.GB_Algorithms = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Canvas)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // PB_Canvas
            // 
            this.PB_Canvas.Location = new System.Drawing.Point(12, 27);
            this.PB_Canvas.Name = "PB_Canvas";
            this.PB_Canvas.Size = new System.Drawing.Size(606, 422);
            this.PB_Canvas.TabIndex = 0;
            this.PB_Canvas.TabStop = false;
            this.PB_Canvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CanvasMouseMove);
            this.PB_Canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CanvasMouseMove);
            // 
            // GB_MathObjectProperties
            // 
            this.GB_MathObjectProperties.Location = new System.Drawing.Point(624, 27);
            this.GB_MathObjectProperties.Name = "GB_MathObjectProperties";
            this.GB_MathObjectProperties.Size = new System.Drawing.Size(248, 116);
            this.GB_MathObjectProperties.TabIndex = 1;
            this.GB_MathObjectProperties.TabStop = false;
            this.GB_MathObjectProperties.Text = "Właściwości ostatnio wybranego obiektu";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_CreateNewGraph,
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
            this.GB_Algorithms.Location = new System.Drawing.Point(624, 149);
            this.GB_Algorithms.Name = "GB_Algorithms";
            this.GB_Algorithms.Size = new System.Drawing.Size(248, 300);
            this.GB_Algorithms.TabIndex = 2;
            this.GB_Algorithms.TabStop = false;
            this.GB_Algorithms.Text = "Algorytmy";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 461);
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
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
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
    }
}