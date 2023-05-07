namespace GraphAlgorithmVisualizer.Forms
{
    partial class RandomGraphCreatorDialog
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
            this.NUD_EdgesMax = new System.Windows.Forms.NumericUpDown();
            this.NUD_EdgesMin = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.NUD_DistanceMax = new System.Windows.Forms.NumericUpDown();
            this.NUD_DistanceMin = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.NUD_VerticesMax = new System.Windows.Forms.NumericUpDown();
            this.NUD_VerticesMin = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.CB_IsDirectional = new System.Windows.Forms.CheckBox();
            this.CB_UsesDistances = new System.Windows.Forms.CheckBox();
            this.BTN_Cancel = new System.Windows.Forms.Button();
            this.BTN_Create = new System.Windows.Forms.Button();
            this.GB_Options.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_EdgesMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_EdgesMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_DistanceMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_DistanceMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_VerticesMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_VerticesMin)).BeginInit();
            this.SuspendLayout();
            // 
            // GB_Options
            // 
            this.GB_Options.Controls.Add(this.NUD_EdgesMax);
            this.GB_Options.Controls.Add(this.NUD_EdgesMin);
            this.GB_Options.Controls.Add(this.label3);
            this.GB_Options.Controls.Add(this.NUD_DistanceMax);
            this.GB_Options.Controls.Add(this.NUD_DistanceMin);
            this.GB_Options.Controls.Add(this.label2);
            this.GB_Options.Controls.Add(this.NUD_VerticesMax);
            this.GB_Options.Controls.Add(this.NUD_VerticesMin);
            this.GB_Options.Controls.Add(this.label1);
            this.GB_Options.Controls.Add(this.CB_IsDirectional);
            this.GB_Options.Controls.Add(this.CB_UsesDistances);
            this.GB_Options.Location = new System.Drawing.Point(12, 12);
            this.GB_Options.Name = "GB_Options";
            this.GB_Options.Size = new System.Drawing.Size(380, 208);
            this.GB_Options.TabIndex = 0;
            this.GB_Options.TabStop = false;
            this.GB_Options.Text = "Opcje";
            // 
            // NUD_EdgesMax
            // 
            this.NUD_EdgesMax.Location = new System.Drawing.Point(194, 80);
            this.NUD_EdgesMax.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.NUD_EdgesMax.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_EdgesMax.Name = "NUD_EdgesMax";
            this.NUD_EdgesMax.Size = new System.Drawing.Size(54, 20);
            this.NUD_EdgesMax.TabIndex = 14;
            this.NUD_EdgesMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NUD_EdgesMax.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // NUD_EdgesMin
            // 
            this.NUD_EdgesMin.Location = new System.Drawing.Point(134, 80);
            this.NUD_EdgesMin.Maximum = new decimal(new int[] {
            45,
            0,
            0,
            0});
            this.NUD_EdgesMin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_EdgesMin.Name = "NUD_EdgesMin";
            this.NUD_EdgesMin.Size = new System.Drawing.Size(54, 20);
            this.NUD_EdgesMin.TabIndex = 13;
            this.NUD_EdgesMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NUD_EdgesMin.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(113, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Losuj liczbę krawędzi z zakresu:";
            // 
            // NUD_DistanceMax
            // 
            this.NUD_DistanceMax.Enabled = false;
            this.NUD_DistanceMax.Location = new System.Drawing.Point(194, 167);
            this.NUD_DistanceMax.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.NUD_DistanceMax.Name = "NUD_DistanceMax";
            this.NUD_DistanceMax.Size = new System.Drawing.Size(54, 20);
            this.NUD_DistanceMax.TabIndex = 11;
            this.NUD_DistanceMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NUD_DistanceMax.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // NUD_DistanceMin
            // 
            this.NUD_DistanceMin.Enabled = false;
            this.NUD_DistanceMin.Location = new System.Drawing.Point(134, 167);
            this.NUD_DistanceMin.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.NUD_DistanceMin.Name = "NUD_DistanceMin";
            this.NUD_DistanceMin.Size = new System.Drawing.Size(54, 20);
            this.NUD_DistanceMin.TabIndex = 10;
            this.NUD_DistanceMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NUD_DistanceMin.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(223, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Losuj wartości dystansów krawędzi z zakresu:";
            // 
            // NUD_VerticesMax
            // 
            this.NUD_VerticesMax.Location = new System.Drawing.Point(194, 41);
            this.NUD_VerticesMax.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NUD_VerticesMax.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_VerticesMax.Name = "NUD_VerticesMax";
            this.NUD_VerticesMax.Size = new System.Drawing.Size(54, 20);
            this.NUD_VerticesMax.TabIndex = 8;
            this.NUD_VerticesMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NUD_VerticesMax.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NUD_VerticesMax.ValueChanged += new System.EventHandler(this.VerticesValueChanged);
            // 
            // NUD_VerticesMin
            // 
            this.NUD_VerticesMin.Location = new System.Drawing.Point(134, 41);
            this.NUD_VerticesMin.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NUD_VerticesMin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_VerticesMin.Name = "NUD_VerticesMin";
            this.NUD_VerticesMin.Size = new System.Drawing.Size(54, 20);
            this.NUD_VerticesMin.TabIndex = 7;
            this.NUD_VerticesMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NUD_VerticesMin.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NUD_VerticesMin.ValueChanged += new System.EventHandler(this.VerticesValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(101, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Losuj liczbę wierzchołków z zakresu:";
            // 
            // CB_IsDirectional
            // 
            this.CB_IsDirectional.AutoSize = true;
            this.CB_IsDirectional.Checked = true;
            this.CB_IsDirectional.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CB_IsDirectional.Location = new System.Drawing.Point(146, 106);
            this.CB_IsDirectional.Name = "CB_IsDirectional";
            this.CB_IsDirectional.Size = new System.Drawing.Size(102, 17);
            this.CB_IsDirectional.TabIndex = 5;
            this.CB_IsDirectional.Text = "Graf skierowany";
            this.CB_IsDirectional.UseVisualStyleBackColor = true;
            // 
            // CB_UsesDistances
            // 
            this.CB_UsesDistances.AutoSize = true;
            this.CB_UsesDistances.Checked = true;
            this.CB_UsesDistances.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CB_UsesDistances.Location = new System.Drawing.Point(82, 129);
            this.CB_UsesDistances.Name = "CB_UsesDistances";
            this.CB_UsesDistances.Size = new System.Drawing.Size(219, 17);
            this.CB_UsesDistances.TabIndex = 4;
            this.CB_UsesDistances.Text = "Graf wymaga dystansów na krawędziach";
            this.CB_UsesDistances.UseVisualStyleBackColor = true;
            this.CB_UsesDistances.CheckedChanged += new System.EventHandler(this.UsesDistanceCheckedState);
            // 
            // BTN_Cancel
            // 
            this.BTN_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BTN_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BTN_Cancel.Location = new System.Drawing.Point(206, 226);
            this.BTN_Cancel.Name = "BTN_Cancel";
            this.BTN_Cancel.Size = new System.Drawing.Size(188, 23);
            this.BTN_Cancel.TabIndex = 4;
            this.BTN_Cancel.Text = "Anuluj";
            this.BTN_Cancel.UseVisualStyleBackColor = true;
            // 
            // BTN_Create
            // 
            this.BTN_Create.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BTN_Create.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BTN_Create.Location = new System.Drawing.Point(12, 226);
            this.BTN_Create.Name = "BTN_Create";
            this.BTN_Create.Size = new System.Drawing.Size(188, 23);
            this.BTN_Create.TabIndex = 3;
            this.BTN_Create.Text = "Twórz nowy graf";
            this.BTN_Create.UseVisualStyleBackColor = true;
            // 
            // RandomGraphCreatorDialog
            // 
            this.AcceptButton = this.BTN_Create;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BTN_Cancel;
            this.ClientSize = new System.Drawing.Size(404, 261);
            this.Controls.Add(this.BTN_Cancel);
            this.Controls.Add(this.BTN_Create);
            this.Controls.Add(this.GB_Options);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RandomGraphCreatorDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kreator losowego grafu";
            this.TopMost = true;
            this.GB_Options.ResumeLayout(false);
            this.GB_Options.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_EdgesMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_EdgesMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_DistanceMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_DistanceMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_VerticesMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_VerticesMin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GB_Options;
        private System.Windows.Forms.Button BTN_Cancel;
        private System.Windows.Forms.Button BTN_Create;
        private System.Windows.Forms.CheckBox CB_IsDirectional;
        private System.Windows.Forms.CheckBox CB_UsesDistances;
        private System.Windows.Forms.NumericUpDown NUD_VerticesMax;
        private System.Windows.Forms.NumericUpDown NUD_VerticesMin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NUD_DistanceMax;
        private System.Windows.Forms.NumericUpDown NUD_DistanceMin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown NUD_EdgesMax;
        private System.Windows.Forms.NumericUpDown NUD_EdgesMin;
        private System.Windows.Forms.Label label3;
    }
}