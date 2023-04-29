namespace GraphAlgorithmVisualizer.Forms
{
    partial class TestForm
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
            ((System.ComponentModel.ISupportInitialize)(this.PB_Canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // PB_Canvas
            // 
            this.PB_Canvas.Location = new System.Drawing.Point(12, 12);
            this.PB_Canvas.Name = "PB_Canvas";
            this.PB_Canvas.Size = new System.Drawing.Size(776, 426);
            this.PB_Canvas.TabIndex = 0;
            this.PB_Canvas.TabStop = false;
            this.PB_Canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PB_Canvas_MouseDown);
            this.PB_Canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PB_Canvas_MouseMove);
            this.PB_Canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PB_Canvas_MouseUp);
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PB_Canvas);
            this.Name = "TestForm";
            this.Text = "TestForm";
            ((System.ComponentModel.ISupportInitialize)(this.PB_Canvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PB_Canvas;
    }
}