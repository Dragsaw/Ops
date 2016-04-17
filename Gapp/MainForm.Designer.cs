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
            this.numN = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listInitialization = new System.Windows.Forms.ComboBox();
            this.listSelection = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listPostGenerationSelection = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numMutationChance = new System.Windows.Forms.NumericUpDown();
            this.listCrossover = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numFirstPoint = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.numSecondPoint = new System.Windows.Forms.NumericUpDown();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonRunAll = new System.Windows.Forms.Button();
            this.buttonInfo = new System.Windows.Forms.Button();
            this.GroupAlgorithm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMutationChance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFirstPoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSecondPoint)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupAlgorithm
            // 
            this.GroupAlgorithm.Controls.Add(this.buttonAdd);
            this.GroupAlgorithm.Controls.Add(this.label8);
            this.GroupAlgorithm.Controls.Add(this.numSecondPoint);
            this.GroupAlgorithm.Controls.Add(this.label7);
            this.GroupAlgorithm.Controls.Add(this.numFirstPoint);
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
            // numN
            // 
            this.numN.Location = new System.Drawing.Point(76, 18);
            this.numN.Name = "numN";
            this.numN.Size = new System.Drawing.Size(44, 20);
            this.numN.TabIndex = 0;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Initialization:";
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
            // numFirstPoint
            // 
            this.numFirstPoint.Location = new System.Drawing.Point(294, 44);
            this.numFirstPoint.Name = "numFirstPoint";
            this.numFirstPoint.Size = new System.Drawing.Size(43, 20);
            this.numFirstPoint.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(272, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "1:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(345, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "2:";
            // 
            // numSecondPoint
            // 
            this.numSecondPoint.Location = new System.Drawing.Point(367, 44);
            this.numSecondPoint.Name = "numSecondPoint";
            this.numSecondPoint.Size = new System.Drawing.Size(43, 20);
            this.numSecondPoint.TabIndex = 14;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(339, 111);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonRunAll
            // 
            this.buttonRunAll.Location = new System.Drawing.Point(12, 158);
            this.buttonRunAll.Name = "buttonRunAll";
            this.buttonRunAll.Size = new System.Drawing.Size(75, 23);
            this.buttonRunAll.TabIndex = 16;
            this.buttonRunAll.Text = "Run All";
            this.buttonRunAll.UseVisualStyleBackColor = true;
            // 
            // buttonInfo
            // 
            this.buttonInfo.Location = new System.Drawing.Point(93, 158);
            this.buttonInfo.Name = "buttonInfo";
            this.buttonInfo.Size = new System.Drawing.Size(75, 23);
            this.buttonInfo.TabIndex = 17;
            this.buttonInfo.Text = "Info";
            this.buttonInfo.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(784, 291);
            this.Controls.Add(this.buttonInfo);
            this.Controls.Add(this.buttonRunAll);
            this.Controls.Add(this.GroupAlgorithm);
            this.MinimumSize = new System.Drawing.Size(800, 330);
            this.Name = "MainForm";
            this.Text = "Main Form";
            this.GroupAlgorithm.ResumeLayout(false);
            this.GroupAlgorithm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMutationChance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFirstPoint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSecondPoint)).EndInit();
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
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numSecondPoint;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numFirstPoint;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonRunAll;
        private System.Windows.Forms.Button buttonInfo;
    }
}

