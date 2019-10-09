namespace OutForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.SignGraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.SinCount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SignGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // SignGraph
            // 
            chartArea2.Name = "ChartArea1";
            this.SignGraph.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.SignGraph.Legends.Add(legend2);
            this.SignGraph.Location = new System.Drawing.Point(12, 12);
            this.SignGraph.Name = "SignGraph";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.SignGraph.Series.Add(series2);
            this.SignGraph.Size = new System.Drawing.Size(476, 300);
            this.SignGraph.TabIndex = 0;
            // 
            // SinCount
            // 
            this.SinCount.Location = new System.Drawing.Point(494, 28);
            this.SinCount.Name = "SinCount";
            this.SinCount.Size = new System.Drawing.Size(100, 20);
            this.SinCount.TabIndex = 1;
            this.SinCount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SinCount_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(494, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SinCount);
            this.Controls.Add(this.SignGraph);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.SignGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart SignGraph;
        private System.Windows.Forms.TextBox SinCount;
        private System.Windows.Forms.Label label1;
    }
}