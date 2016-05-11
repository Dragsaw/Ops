namespace Gapp
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
            this.GroupAlgorithm = new System.Windows.Forms.GroupBox();
            this.numRunCount = new System.Windows.Forms.NumericUpDown();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonRunAll = new System.Windows.Forms.Button();
            this.listCrossover = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numMutationChance = new System.Windows.Forms.NumericUpDown();
            this.listPostGenerationSelection = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.listSelection = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listInitialization = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numN = new System.Windows.Forms.NumericUpDown();
            this.buttonInfo = new System.Windows.Forms.Button();
            this.groupFunction = new System.Windows.Forms.GroupBox();
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
            this.buttonLocalSearch = new System.Windows.Forms.Button();
            this.GroupAlgorithm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRunCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMutationChance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numN)).BeginInit();
            this.groupFunction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numScaleY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numScaleX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinX)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupAlgorithm
            // 
            this.GroupAlgorithm.Controls.Add(this.numRunCount);
            this.GroupAlgorithm.Controls.Add(this.buttonAdd);
            this.GroupAlgorithm.Controls.Add(this.buttonRunAll);
            this.GroupAlgorithm.Controls.Add(this.listCrossover);
            this.GroupAlgorithm.Controls.Add(this.label6);
            this.GroupAlgorithm.Controls.Add(this.label5);
            this.GroupAlgorithm.Controls.Add(this.numMutationChance);
            this.GroupAlgorithm.Controls.Add(this.listPostGenerationSelection);
            this.GroupAlgorithm.Controls.Add(this.label4);
            this.GroupAlgorithm.Controls.Add(this.listSelection);
            this.GroupAlgorithm.Controls.Add(this.label3);
            this.GroupAlgorithm.Controls.Add(this.listInitialization);
            this.GroupAlgorithm.Controls.Add(this.label2);
            this.GroupAlgorithm.Controls.Add(this.label1);
            this.GroupAlgorithm.Controls.Add(this.numN);
            this.GroupAlgorithm.Location = new System.Drawing.Point(12, 12);
            this.GroupAlgorithm.MinimumSize = new System.Drawing.Size(390, 140);
            this.GroupAlgorithm.Name = "GroupAlgorithm";
            this.GroupAlgorithm.Size = new System.Drawing.Size(420, 140);
            this.GroupAlgorithm.TabIndex = 0;
            this.GroupAlgorithm.TabStop = false;
            this.GroupAlgorithm.Text = "Algorithm";
            // 
            // numRunCount
            // 
            this.numRunCount.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Gapp.Properties.Settings.Default, "DefaultRunCount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numRunCount.Location = new System.Drawing.Point(289, 113);
            this.numRunCount.Name = "numRunCount";
            this.numRunCount.Size = new System.Drawing.Size(44, 20);
            this.numRunCount.TabIndex = 27;
            this.numRunCount.Value = global::Gapp.Properties.Settings.Default.DefaultRunCount;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(339, 82);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonRunAll
            // 
            this.buttonRunAll.Location = new System.Drawing.Point(339, 111);
            this.buttonRunAll.Name = "buttonRunAll";
            this.buttonRunAll.Size = new System.Drawing.Size(75, 23);
            this.buttonRunAll.TabIndex = 16;
            this.buttonRunAll.Text = "Run All";
            this.buttonRunAll.UseVisualStyleBackColor = true;
            this.buttonRunAll.Click += new System.EventHandler(this.buttonRunAll_Click);
            // 
            // listCrossover
            // 
            this.listCrossover.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listCrossover.FormattingEnabled = true;
            this.listCrossover.Location = new System.Drawing.Point(294, 18);
            this.listCrossover.Name = "listCrossover";
            this.listCrossover.Size = new System.Drawing.Size(116, 21);
            this.listCrossover.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(231, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Crossover:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(126, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "μ:";
            // 
            // numMutationChance
            // 
            this.numMutationChance.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Gapp.Properties.Settings.Default, "DefaultU", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numMutationChance.DecimalPlaces = 1;
            this.numMutationChance.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numMutationChance.Location = new System.Drawing.Point(148, 18);
            this.numMutationChance.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMutationChance.Name = "numMutationChance";
            this.numMutationChance.Size = new System.Drawing.Size(44, 20);
            this.numMutationChance.TabIndex = 8;
            this.numMutationChance.Value = global::Gapp.Properties.Settings.Default.DefaultU;
            // 
            // listPostGenerationSelection
            // 
            this.listPostGenerationSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listPostGenerationSelection.FormattingEnabled = true;
            this.listPostGenerationSelection.Location = new System.Drawing.Point(92, 101);
            this.listPostGenerationSelection.Name = "listPostGenerationSelection";
            this.listPostGenerationSelection.Size = new System.Drawing.Size(100, 21);
            this.listPostGenerationSelection.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 27);
            this.label4.TabIndex = 6;
            this.label4.Text = "Post Generation Selection:";
            // 
            // listSelection
            // 
            this.listSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listSelection.FormattingEnabled = true;
            this.listSelection.Location = new System.Drawing.Point(76, 71);
            this.listSelection.Name = "listSelection";
            this.listSelection.Size = new System.Drawing.Size(116, 21);
            this.listSelection.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Selection:";
            // 
            // listInitialization
            // 
            this.listInitialization.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listInitialization.FormattingEnabled = true;
            this.listInitialization.Location = new System.Drawing.Point(76, 44);
            this.listInitialization.Name = "listInitialization";
            this.listInitialization.Size = new System.Drawing.Size(116, 21);
            this.listInitialization.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Initialization:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "N:";
            // 
            // numN
            // 
            this.numN.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Gapp.Properties.Settings.Default, "DefaultN", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numN.Location = new System.Drawing.Point(76, 18);
            this.numN.Name = "numN";
            this.numN.Size = new System.Drawing.Size(44, 20);
            this.numN.TabIndex = 0;
            this.numN.Value = global::Gapp.Properties.Settings.Default.DefaultN;
            // 
            // buttonInfo
            // 
            this.buttonInfo.Location = new System.Drawing.Point(12, 158);
            this.buttonInfo.Name = "buttonInfo";
            this.buttonInfo.Size = new System.Drawing.Size(75, 23);
            this.buttonInfo.TabIndex = 17;
            this.buttonInfo.Text = "Info";
            this.buttonInfo.UseVisualStyleBackColor = true;
            this.buttonInfo.Click += new System.EventHandler(this.buttonInfo_Click);
            // 
            // groupFunction
            // 
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
            this.groupFunction.Location = new System.Drawing.Point(438, 12);
            this.groupFunction.Name = "groupFunction";
            this.groupFunction.Size = new System.Drawing.Size(334, 140);
            this.groupFunction.TabIndex = 17;
            this.groupFunction.TabStop = false;
            this.groupFunction.Text = "Function";
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
            this.numMaxX.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Gapp.Properties.Settings.Default, "DefaultUpperX", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numMaxX.Location = new System.Drawing.Point(94, 47);
            this.numMaxX.Name = "numMaxX";
            this.numMaxX.Size = new System.Drawing.Size(44, 20);
            this.numMaxX.TabIndex = 19;
            this.numMaxX.Value = global::Gapp.Properties.Settings.Default.DefaultUpperX;
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
            // buttonLocalSearch
            // 
            this.buttonLocalSearch.Location = new System.Drawing.Point(93, 158);
            this.buttonLocalSearch.Name = "buttonLocalSearch";
            this.buttonLocalSearch.Size = new System.Drawing.Size(111, 23);
            this.buttonLocalSearch.TabIndex = 18;
            this.buttonLocalSearch.Text = "Local Search Form";
            this.buttonLocalSearch.UseVisualStyleBackColor = true;
            this.buttonLocalSearch.Click += new System.EventHandler(this.buttonLocalSearch_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(784, 291);
            this.Controls.Add(this.buttonLocalSearch);
            this.Controls.Add(this.groupFunction);
            this.Controls.Add(this.buttonInfo);
            this.Controls.Add(this.GroupAlgorithm);
            this.MinimumSize = new System.Drawing.Size(800, 330);
            this.Name = "MainForm";
            this.Text = "Main Form";
            this.GroupAlgorithm.ResumeLayout(false);
            this.GroupAlgorithm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRunCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMutationChance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numN)).EndInit();
            this.groupFunction.ResumeLayout(false);
            this.groupFunction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numScaleY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numScaleX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupAlgorithm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numN;
        private System.Windows.Forms.ComboBox listSelection;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox listInitialization;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox listCrossover;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numMutationChance;
        private System.Windows.Forms.ComboBox listPostGenerationSelection;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonRunAll;
        private System.Windows.Forms.Button buttonInfo;
        private System.Windows.Forms.GroupBox groupFunction;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numScaleY;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numScaleX;
        private System.Windows.Forms.NumericUpDown numMaxY;
        private System.Windows.Forms.NumericUpDown numMaxX;
        private System.Windows.Forms.NumericUpDown numMinY;
        private System.Windows.Forms.NumericUpDown numMinX;
        private System.Windows.Forms.TextBox textBoxFunction;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numRunCount;
        private System.Windows.Forms.Button buttonLocalSearch;
    }
}

