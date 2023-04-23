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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.stwórzNowyGrafToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dodajWierzchołekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dodajKrawędźToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.PB_Canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CanvasMouseMove);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(624, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 422);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stwórzNowyGrafToolStripMenuItem,
            this.dodajWierzchołekToolStripMenuItem,
            this.dodajKrawędźToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(884, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip";
            // 
            // stwórzNowyGrafToolStripMenuItem
            // 
            this.stwórzNowyGrafToolStripMenuItem.Name = "stwórzNowyGrafToolStripMenuItem";
            this.stwórzNowyGrafToolStripMenuItem.Size = new System.Drawing.Size(119, 20);
            this.stwórzNowyGrafToolStripMenuItem.Text = "Stwórz nowy graf...";
            // 
            // dodajWierzchołekToolStripMenuItem
            // 
            this.dodajWierzchołekToolStripMenuItem.Name = "dodajWierzchołekToolStripMenuItem";
            this.dodajWierzchołekToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
            this.dodajWierzchołekToolStripMenuItem.Text = "Dodaj wierzchołek";
            // 
            // dodajKrawędźToolStripMenuItem
            // 
            this.dodajKrawędźToolStripMenuItem.Name = "dodajKrawędźToolStripMenuItem";
            this.dodajKrawędźToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.dodajKrawędźToolStripMenuItem.Text = "Dodaj krawędź";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.PB_Canvas);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.PB_Canvas)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PB_Canvas;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem stwórzNowyGrafToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dodajWierzchołekToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dodajKrawędźToolStripMenuItem;
    }
}