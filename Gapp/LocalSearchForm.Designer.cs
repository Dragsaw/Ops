namespace Gapp
{
    partial class LocalSearchForm
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
            this.groupFunction = new System.Windows.Forms.GroupBox();
            this.buttonRun = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.numScaleY = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.numScaleX = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numMaxY = new System.Windows.Forms.NumericUpDown();
            this.numMaxX = new System.Windows.Forms.NumericUpDown();
            this.numMinY = new System.Windows.Forms.NumericUpDown();
            this.numMinX = new System.Windows.Forms.NumericUpDown();
            this.textBoxFunction = new System.Windows.Forms.TextBox();
            this.grid = new System.Windows.Forms.DataGridView();
            this.buttonPrevious = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonFirst = new System.Windows.Forms.Button();
            this.buttonLast = new System.Windows.Forms.Button();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Initialization = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Selection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Search = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.initialCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selectedCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Run = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Health = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Genome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupFunction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numScaleY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numScaleX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // groupFunction
            // 
            this.groupFunction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupFunction.Controls.Add(this.buttonRun);
            this.groupFunction.Controls.Add(this.label10);
            this.groupFunction.Controls.Add(this.numScaleY);
            this.groupFunction.Controls.Add(this.label9);
            this.groupFunction.Controls.Add(this.numScaleX);
            this.groupFunction.Controls.Add(this.label8);
            this.groupFunction.Controls.Add(this.label7);
            this.groupFunction.Controls.Add(this.numMaxY);
            this.groupFunction.Controls.Add(this.numMaxX);
            this.groupFunction.Controls.Add(this.numMinY);
            this.groupFunction.Controls.Add(this.numMinX);
            this.groupFunction.Controls.Add(this.textBoxFunction);
            this.groupFunction.Location = new System.Drawing.Point(354, 12);
            this.groupFunction.Name = "groupFunction";
            this.groupFunction.Size = new System.Drawing.Size(334, 140);
            this.groupFunction.TabIndex = 18;
            this.groupFunction.TabStop = false;
            this.groupFunction.Text = "Function";
            // 
            // buttonRun
            // 
            this.buttonRun.Location = new System.Drawing.Point(253, 111);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(75, 23);
            this.buttonRun.TabIndex = 27;
            this.buttonRun.Text = "Run";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(144, 73);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Decimal places:";
            // 
            // numScaleY
            // 
            this.numScaleY.Location = new System.Drawing.Point(232, 71);
            this.numScaleY.Name = "numScaleY";
            this.numScaleY.Size = new System.Drawing.Size(44, 20);
            this.numScaleY.TabIndex = 25;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(144, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Decimal places:";
            // 
            // numScaleX
            // 
            this.numScaleX.Location = new System.Drawing.Point(232, 47);
            this.numScaleX.Name = "numScaleX";
            this.numScaleX.Size = new System.Drawing.Size(44, 20);
            this.numScaleX.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(56, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "< Y <";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(56, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "< X <";
            // 
            // numMaxY
            // 
            this.numMaxY.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Gapp.Properties.Settings.Default, "DefaultUpperValue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numMaxY.Location = new System.Drawing.Point(94, 71);
            this.numMaxY.Name = "numMaxY";
            this.numMaxY.Size = new System.Drawing.Size(44, 20);
            this.numMaxY.TabIndex = 20;
            this.numMaxY.Value = global::Gapp.Properties.Settings.Default.DefaultUpperValue;
            // 
            // numMaxX
            // 
            this.numMaxX.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Gapp.Properties.Settings.Default, "DefaultUpperValue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numMaxX.Location = new System.Drawing.Point(94, 47);
            this.numMaxX.Name = "numMaxX";
            this.numMaxX.Size = new System.Drawing.Size(44, 20);
            this.numMaxX.TabIndex = 19;
            this.numMaxX.Value = global::Gapp.Properties.Settings.Default.DefaultUpperValue;
            // 
            // numMinY
            // 
            this.numMinY.Location = new System.Drawing.Point(6, 71);
            this.numMinY.Name = "numMinY";
            this.numMinY.Size = new System.Drawing.Size(44, 20);
            this.numMinY.TabIndex = 18;
            // 
            // numMinX
            // 
            this.numMinX.Location = new System.Drawing.Point(6, 45);
            this.numMinX.Name = "numMinX";
            this.numMinX.Size = new System.Drawing.Size(44, 20);
            this.numMinX.TabIndex = 17;
            // 
            // textBoxFunction
            // 
            this.textBoxFunction.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Gapp.Properties.Settings.Default, "DefaultFunction", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxFunction.Location = new System.Drawing.Point(6, 19);
            this.textBoxFunction.Name = "textBoxFunction";
            this.textBoxFunction.Size = new System.Drawing.Size(322, 20);
            this.textBoxFunction.TabIndex = 0;
            this.textBoxFunction.Text = global::Gapp.Properties.Settings.Default.DefaultFunction;
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Initialization,
            this.Selection,
            this.Search,
            this.initialCount,
            this.selectedCount,
            this.Run,
            this.Health,
            this.Genome});
            this.grid.Location = new System.Drawing.Point(12, 158);
            this.grid.Name = "grid";
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(676, 256);
            this.grid.TabIndex = 19;
            // 
            // buttonPrevious
            // 
            this.buttonPrevious.Location = new System.Drawing.Point(48, 129);
            this.buttonPrevious.Name = "buttonPrevious";
            this.buttonPrevious.Size = new System.Drawing.Size(75, 23);
            this.buttonPrevious.TabIndex = 28;
            this.buttonPrevious.Text = "Previous";
            this.buttonPrevious.UseVisualStyleBackColor = true;
            this.buttonPrevious.Click += new System.EventHandler(this.ShowOtherIteration);
            // 
            // buttonNext
            // 
            this.buttonNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNext.Location = new System.Drawing.Point(237, 129);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(75, 23);
            this.buttonNext.TabIndex = 29;
            this.buttonNext.Text = "Next";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.ShowOtherIteration);
            // 
            // buttonFirst
            // 
            this.buttonFirst.Location = new System.Drawing.Point(12, 129);
            this.buttonFirst.Name = "buttonFirst";
            this.buttonFirst.Size = new System.Drawing.Size(30, 23);
            this.buttonFirst.TabIndex = 30;
            this.buttonFirst.Text = "<<";
            this.buttonFirst.UseVisualStyleBackColor = true;
            this.buttonFirst.Click += new System.EventHandler(this.ShowOtherIteration);
            // 
            // buttonLast
            // 
            this.buttonLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLast.Location = new System.Drawing.Point(318, 129);
            this.buttonLast.Name = "buttonLast";
            this.buttonLast.Size = new System.Drawing.Size(30, 23);
            this.buttonLast.TabIndex = 31;
            this.buttonLast.Text = ">>";
            this.buttonLast.UseVisualStyleBackColor = true;
            this.buttonLast.Click += new System.EventHandler(this.ShowOtherIteration);
            // 
            // Id
            // 
            this.Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Id.FillWeight = 4F;
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            // 
            // Initialization
            // 
            this.Initialization.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Initialization.FillWeight = 12F;
            this.Initialization.HeaderText = "Initialization";
            this.Initialization.Name = "Initialization";
            // 
            // Selection
            // 
            this.Selection.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Selection.FillWeight = 12F;
            this.Selection.HeaderText = "Selection";
            this.Selection.Name = "Selection";
            // 
            // Search
            // 
            this.Search.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Search.FillWeight = 12F;
            this.Search.HeaderText = "Search";
            this.Search.Name = "Search";
            // 
            // initialCount
            // 
            this.initialCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.initialCount.FillWeight = 12F;
            this.initialCount.HeaderText = "N";
            this.initialCount.Name = "initialCount";
            // 
            // selectedCount
            // 
            this.selectedCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.selectedCount.FillWeight = 12F;
            this.selectedCount.HeaderText = "n";
            this.selectedCount.Name = "selectedCount";
            // 
            // Run
            // 
            this.Run.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Run.FillWeight = 12F;
            this.Run.HeaderText = "Run";
            this.Run.Name = "Run";
            // 
            // Health
            // 
            this.Health.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Health.FillWeight = 12F;
            this.Health.HeaderText = "Health";
            this.Health.Name = "Health";
            // 
            // Genome
            // 
            this.Genome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Genome.FillWeight = 12F;
            this.Genome.HeaderText = "Genome";
            this.Genome.Name = "Genome";
            // 
            // LocalSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 426);
            this.Controls.Add(this.buttonLast);
            this.Controls.Add(this.buttonFirst);
            this.Controls.Add(this.buttonPrevious);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.groupFunction);
            this.Name = "LocalSearchForm";
            this.Text = "LocalSearchForm";
            this.groupFunction.ResumeLayout(false);
            this.groupFunction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numScaleY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numScaleX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupFunction;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numScaleY;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numScaleX;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numMaxY;
        private System.Windows.Forms.NumericUpDown numMaxX;
        private System.Windows.Forms.NumericUpDown numMinY;
        private System.Windows.Forms.NumericUpDown numMinX;
        private System.Windows.Forms.TextBox textBoxFunction;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Button buttonPrevious;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonFirst;
        private System.Windows.Forms.Button buttonLast;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Initialization;
        private System.Windows.Forms.DataGridViewTextBoxColumn Selection;
        private System.Windows.Forms.DataGridViewTextBoxColumn Search;
        private System.Windows.Forms.DataGridViewTextBoxColumn initialCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn selectedCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Run;
        private System.Windows.Forms.DataGridViewTextBoxColumn Health;
        private System.Windows.Forms.DataGridViewTextBoxColumn Genome;
    }
}