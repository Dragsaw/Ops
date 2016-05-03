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
            this.buttonRun = new System.Windows.Forms.Button();
            this.groupFunction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numScaleY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numScaleX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinX)).BeginInit();
            this.SuspendLayout();
            // 
            // groupFunction
            // 
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
            // LocalSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 426);
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
    }
}