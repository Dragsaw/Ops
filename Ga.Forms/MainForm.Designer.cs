namespace Ga.Forms
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.individualsGrid = new System.Windows.Forms.DataGridView();
            this.ButtonRun = new System.Windows.Forms.Button();
            this.pointsChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.populationSize = new System.Windows.Forms.NumericUpDown();
            this.initSize = new System.Windows.Forms.NumericUpDown();
            this.scaleY = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.maxY = new System.Windows.Forms.NumericUpDown();
            this.minY = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.scaleX = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.maxX = new System.Windows.Forms.NumericUpDown();
            this.minX = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.mutationChance = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.runsCount = new System.Windows.Forms.NumericUpDown();
            this.ButtonRunMultiple = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.individualsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointsChart)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.populationSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.initSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mutationChance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.runsCount)).BeginInit();
            this.SuspendLayout();
            // 
            // individualsGrid
            // 
            this.individualsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.individualsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.individualsGrid.Location = new System.Drawing.Point(605, 144);
            this.individualsGrid.Name = "individualsGrid";
            this.individualsGrid.Size = new System.Drawing.Size(367, 405);
            this.individualsGrid.TabIndex = 0;
            this.individualsGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.individualsGrid_CellDoubleClick);
            // 
            // ButtonRun
            // 
            this.ButtonRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonRun.Location = new System.Drawing.Point(286, 68);
            this.ButtonRun.Name = "ButtonRun";
            this.ButtonRun.Size = new System.Drawing.Size(75, 23);
            this.ButtonRun.TabIndex = 1;
            this.ButtonRun.Text = "Run";
            this.ButtonRun.UseVisualStyleBackColor = true;
            this.ButtonRun.Click += new System.EventHandler(this.button1_Click);
            // 
            // pointsChart
            // 
            this.pointsChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea3.Name = "ChartArea1";
            this.pointsChart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.pointsChart.Legends.Add(legend3);
            this.pointsChart.Location = new System.Drawing.Point(12, 12);
            this.pointsChart.Name = "pointsChart";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.pointsChart.Series.Add(series3);
            this.pointsChart.Size = new System.Drawing.Size(587, 537);
            this.pointsChart.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.ButtonRunMultiple);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.runsCount);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.mutationChance);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.populationSize);
            this.groupBox1.Controls.Add(this.ButtonRun);
            this.groupBox1.Controls.Add(this.initSize);
            this.groupBox1.Controls.Add(this.scaleY);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.maxY);
            this.groupBox1.Controls.Add(this.minY);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.scaleX);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.maxX);
            this.groupBox1.Controls.Add(this.minX);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(605, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(367, 126);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(286, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Popultation size:";
            // 
            // populationSize
            // 
            this.populationSize.Location = new System.Drawing.Point(100, 97);
            this.populationSize.Name = "populationSize";
            this.populationSize.Size = new System.Drawing.Size(50, 20);
            this.populationSize.TabIndex = 12;
            // 
            // initSize
            // 
            this.initSize.Location = new System.Drawing.Point(100, 71);
            this.initSize.Name = "initSize";
            this.initSize.Size = new System.Drawing.Size(50, 20);
            this.initSize.TabIndex = 11;
            // 
            // scaleY
            // 
            this.scaleY.Location = new System.Drawing.Point(212, 45);
            this.scaleY.Name = "scaleY";
            this.scaleY.Size = new System.Drawing.Size(50, 20);
            this.scaleY.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(156, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Scale:";
            // 
            // maxY
            // 
            this.maxY.Location = new System.Drawing.Point(100, 45);
            this.maxY.Name = "maxY";
            this.maxY.Size = new System.Drawing.Size(50, 20);
            this.maxY.TabIndex = 8;
            // 
            // minY
            // 
            this.minY.Location = new System.Drawing.Point(6, 45);
            this.minY.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.minY.Name = "minY";
            this.minY.Size = new System.Drawing.Size(50, 20);
            this.minY.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(62, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "< Y <";
            // 
            // scaleX
            // 
            this.scaleX.Location = new System.Drawing.Point(212, 19);
            this.scaleX.Name = "scaleX";
            this.scaleX.Size = new System.Drawing.Size(50, 20);
            this.scaleX.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(156, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Scale:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "Initial population size:";
            // 
            // maxX
            // 
            this.maxX.Location = new System.Drawing.Point(100, 19);
            this.maxX.Name = "maxX";
            this.maxX.Size = new System.Drawing.Size(50, 20);
            this.maxX.TabIndex = 2;
            // 
            // minX
            // 
            this.minX.Location = new System.Drawing.Point(6, 19);
            this.minX.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.minX.Name = "minX";
            this.minX.Size = new System.Drawing.Size(50, 20);
            this.minX.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "< X <";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(156, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 34);
            this.label7.TabIndex = 16;
            this.label7.Text = "Mutation chance:";
            // 
            // mutationChance
            // 
            this.mutationChance.DecimalPlaces = 1;
            this.mutationChance.Location = new System.Drawing.Point(212, 71);
            this.mutationChance.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mutationChance.Name = "mutationChance";
            this.mutationChance.Size = new System.Drawing.Size(50, 20);
            this.mutationChance.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(156, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 27);
            this.label8.TabIndex = 18;
            this.label8.Text = "Runs count:";
            // 
            // runsCount
            // 
            this.runsCount.Location = new System.Drawing.Point(212, 97);
            this.runsCount.Name = "runsCount";
            this.runsCount.Size = new System.Drawing.Size(50, 20);
            this.runsCount.TabIndex = 17;
            // 
            // ButtonRunMultiple
            // 
            this.ButtonRunMultiple.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonRunMultiple.Location = new System.Drawing.Point(286, 94);
            this.ButtonRunMultiple.Name = "ButtonRunMultiple";
            this.ButtonRunMultiple.Size = new System.Drawing.Size(75, 23);
            this.ButtonRunMultiple.TabIndex = 19;
            this.ButtonRunMultiple.Text = "Run Multiple";
            this.ButtonRunMultiple.UseVisualStyleBackColor = true;
            this.ButtonRunMultiple.Click += new System.EventHandler(this.button2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pointsChart);
            this.Controls.Add(this.individualsGrid);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.individualsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointsChart)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.populationSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.initSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mutationChance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.runsCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView individualsGrid;
        private System.Windows.Forms.Button ButtonRun;
        private System.Windows.Forms.DataVisualization.Charting.Chart pointsChart;
        private System.Windows.Forms.NumericUpDown scaleY;
        private System.Windows.Forms.NumericUpDown maxY;
        private System.Windows.Forms.NumericUpDown scaleX;
        private System.Windows.Forms.NumericUpDown maxX;
        private System.Windows.Forms.NumericUpDown minX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown minY;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown initSize;
        private System.Windows.Forms.NumericUpDown populationSize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown runsCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown mutationChance;
        private System.Windows.Forms.Button ButtonRunMultiple;
    }
}

