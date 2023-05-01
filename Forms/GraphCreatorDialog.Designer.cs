namespace GraphAlgorithmVisualizer.Forms
{
    partial class GraphCreatorDialog
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
            this.GB_Options = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CB_AcceptableDistances = new System.Windows.Forms.ComboBox();
            this.CB_IsDirectional = new System.Windows.Forms.CheckBox();
            this.CB_UsesDistances = new System.Windows.Forms.CheckBox();
            this.NUD_Vertices = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.BTN_Create = new System.Windows.Forms.Button();
            this.BTN_Cancel = new System.Windows.Forms.Button();
            this.GB_Options.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Vertices)).BeginInit();
            this.SuspendLayout();
            // 
            // GB_Options
            // 
            this.GB_Options.Controls.Add(this.label2);
            this.GB_Options.Controls.Add(this.CB_AcceptableDistances);
            this.GB_Options.Controls.Add(this.CB_IsDirectional);
            this.GB_Options.Controls.Add(this.CB_UsesDistances);
            this.GB_Options.Controls.Add(this.NUD_Vertices);
            this.GB_Options.Controls.Add(this.label1);
            this.GB_Options.Location = new System.Drawing.Point(13, 13);
            this.GB_Options.Name = "GB_Options";
            this.GB_Options.Size = new System.Drawing.Size(309, 147);
            this.GB_Options.TabIndex = 0;
            this.GB_Options.TabStop = false;
            this.GB_Options.Text = "Opcje";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(250, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Zakres dozwolonych wartości Dystansów krawędzi:";
            // 
            // CB_AcceptableDistances
            // 
            this.CB_AcceptableDistances.Enabled = false;
            this.CB_AcceptableDistances.FormattingEnabled = true;
            this.CB_AcceptableDistances.Items.AddRange(new object[] {
            "Ujemne, dodatnie oraz zero",
            "Ujemne i dodatnie bez zera",
            "Dodatnie oraz zero",
            "Tylko dodatnie"});
            this.CB_AcceptableDistances.Location = new System.Drawing.Point(67, 117);
            this.CB_AcceptableDistances.Name = "CB_AcceptableDistances";
            this.CB_AcceptableDistances.Size = new System.Drawing.Size(179, 21);
            this.CB_AcceptableDistances.TabIndex = 4;
            // 
            // CB_IsDirectional
            // 
            this.CB_IsDirectional.AutoSize = true;
            this.CB_IsDirectional.Location = new System.Drawing.Point(108, 58);
            this.CB_IsDirectional.Name = "CB_IsDirectional";
            this.CB_IsDirectional.Size = new System.Drawing.Size(102, 17);
            this.CB_IsDirectional.TabIndex = 3;
            this.CB_IsDirectional.Text = "Graf skierowany";
            this.CB_IsDirectional.UseVisualStyleBackColor = true;
            // 
            // CB_UsesDistances
            // 
            this.CB_UsesDistances.AutoSize = true;
            this.CB_UsesDistances.Location = new System.Drawing.Point(54, 78);
            this.CB_UsesDistances.Name = "CB_UsesDistances";
            this.CB_UsesDistances.Size = new System.Drawing.Size(219, 17);
            this.CB_UsesDistances.TabIndex = 2;
            this.CB_UsesDistances.Text = "Graf wymaga dystansów na krawędziach";
            this.CB_UsesDistances.UseVisualStyleBackColor = true;
            this.CB_UsesDistances.CheckedChanged += new System.EventHandler(this.UsesDistancesCheckChanged);
            // 
            // NUD_Vertices
            // 
            this.NUD_Vertices.Location = new System.Drawing.Point(102, 32);
            this.NUD_Vertices.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NUD_Vertices.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_Vertices.Name = "NUD_Vertices";
            this.NUD_Vertices.Size = new System.Drawing.Size(114, 20);
            this.NUD_Vertices.TabIndex = 1;
            this.NUD_Vertices.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NUD_Vertices.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Liczba początkowych wierzchołków:";
            // 
            // BTN_Create
            // 
            this.BTN_Create.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BTN_Create.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BTN_Create.Location = new System.Drawing.Point(13, 166);
            this.BTN_Create.Name = "BTN_Create";
            this.BTN_Create.Size = new System.Drawing.Size(152, 23);
            this.BTN_Create.TabIndex = 1;
            this.BTN_Create.Text = "Twórz nowy graf";
            this.BTN_Create.UseVisualStyleBackColor = true;
            // 
            // BTN_Cancel
            // 
            this.BTN_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BTN_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BTN_Cancel.Location = new System.Drawing.Point(170, 166);
            this.BTN_Cancel.Name = "BTN_Cancel";
            this.BTN_Cancel.Size = new System.Drawing.Size(152, 23);
            this.BTN_Cancel.TabIndex = 2;
            this.BTN_Cancel.Text = "Anuluj";
            this.BTN_Cancel.UseVisualStyleBackColor = true;
            // 
            // GraphCreatorDialog
            // 
            this.AcceptButton = this.BTN_Create;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BTN_Cancel;
            this.ClientSize = new System.Drawing.Size(334, 201);
            this.Controls.Add(this.BTN_Cancel);
            this.Controls.Add(this.BTN_Create);
            this.Controls.Add(this.GB_Options);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GraphCreatorDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kreator nowego grafu";
            this.TopMost = true;
            this.GB_Options.ResumeLayout(false);
            this.GB_Options.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Vertices)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GB_Options;
        private System.Windows.Forms.Button BTN_Create;
        private System.Windows.Forms.CheckBox CB_IsDirectional;
        private System.Windows.Forms.CheckBox CB_UsesDistances;
        private System.Windows.Forms.NumericUpDown NUD_Vertices;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTN_Cancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CB_AcceptableDistances;
    }
}