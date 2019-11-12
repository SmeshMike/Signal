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
            this.Start = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.NoisePerc = new System.Windows.Forms.TextBox();
            this.BackFur = new System.Windows.Forms.Button();
            this.NoiseText = new System.Windows.Forms.TextBox();
            this.Fur1 = new System.Windows.Forms.TextBox();
            this.AfterFur = new System.Windows.Forms.Button();
            this.FrontFur = new System.Windows.Forms.Button();
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
            series2.Name = "Сигнал";
            this.SignGraph.Series.Add(series2);
            this.SignGraph.Size = new System.Drawing.Size(1027, 625);
            this.SignGraph.TabIndex = 0;
            // 
            // SinCount
            // 
            this.SinCount.Location = new System.Drawing.Point(1048, 41);
            this.SinCount.Name = "SinCount";
            this.SinCount.Size = new System.Drawing.Size(100, 20);
            this.SinCount.TabIndex = 1;
            this.SinCount.Text = "0";
            this.SinCount.TextChanged += new System.EventHandler(this.SinCount_TextChanged);
            this.SinCount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SinCount_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1045, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "Количсетво\nсинусоид";
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(1048, 614);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(100, 23);
            this.Start.TabIndex = 3;
            this.Start.Text = "Поiхали";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1159, 614);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Почистить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Clear_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1203, 551);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Пошумим";
            // 
            // NoisePerc
            // 
            this.NoisePerc.Location = new System.Drawing.Point(1159, 567);
            this.NoisePerc.Name = "NoisePerc";
            this.NoisePerc.Size = new System.Drawing.Size(100, 20);
            this.NoisePerc.TabIndex = 6;
            this.NoisePerc.Text = "0";
            // 
            // BackFur
            // 
            this.BackFur.Location = new System.Drawing.Point(1048, 508);
            this.BackFur.Name = "BackFur";
            this.BackFur.Size = new System.Drawing.Size(100, 23);
            this.BackFur.TabIndex = 7;
            this.BackFur.Text = "Обратное";
            this.BackFur.UseVisualStyleBackColor = true;
            this.BackFur.Click += new System.EventHandler(this.BackFur_Click);
            // 
            // NoiseText
            // 
            this.NoiseText.Location = new System.Drawing.Point(1048, 567);
            this.NoiseText.Name = "NoiseText";
            this.NoiseText.Size = new System.Drawing.Size(100, 20);
            this.NoiseText.TabIndex = 8;
            this.NoiseText.Text = "0";
            // 
            // Fur1
            // 
            this.Fur1.Location = new System.Drawing.Point(1048, 445);
            this.Fur1.Name = "Fur1";
            this.Fur1.Size = new System.Drawing.Size(100, 20);
            this.Fur1.TabIndex = 9;
            this.Fur1.Text = "512";
            // 
            // AfterFur
            // 
            this.AfterFur.Location = new System.Drawing.Point(1178, 475);
            this.AfterFur.Name = "AfterFur";
            this.AfterFur.Size = new System.Drawing.Size(75, 56);
            this.AfterFur.TabIndex = 11;
            this.AfterFur.Text = "AfterFur";
            this.AfterFur.UseVisualStyleBackColor = true;
            this.AfterFur.Click += new System.EventHandler(this.AfterFur_Click);
            // 
            // FrontFur
            // 
            this.FrontFur.Location = new System.Drawing.Point(1048, 475);
            this.FrontFur.Name = "FrontFur";
            this.FrontFur.Size = new System.Drawing.Size(100, 23);
            this.FrontFur.TabIndex = 12;
            this.FrontFur.Text = "Прямое";
            this.FrontFur.UseVisualStyleBackColor = true;
            this.FrontFur.Click += new System.EventHandler(this.FrontFur_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1265, 657);
            this.Controls.Add(this.FrontFur);
            this.Controls.Add(this.AfterFur);
            this.Controls.Add(this.Fur1);
            this.Controls.Add(this.NoiseText);
            this.Controls.Add(this.BackFur);
            this.Controls.Add(this.NoisePerc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Start);
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
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NoisePerc;
        private System.Windows.Forms.Button BackFur;
        private System.Windows.Forms.TextBox NoiseText;
        private System.Windows.Forms.TextBox Fur1;
        private System.Windows.Forms.Button AfterFur;
        private System.Windows.Forms.Button FrontFur;
    }
}