namespace OutForm
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.SignGraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.SinCount = new System.Windows.Forms.TextBox();
            this.SinLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
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
            this.SignGraph.Size = new System.Drawing.Size(551, 303);
            this.SignGraph.TabIndex = 0;
            this.SignGraph.Text = "SignGraph";
            this.SignGraph.Click += new System.EventHandler(this.chart1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(200, 100);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "tabPage2";
            // 
            // SinCount
            // 
            this.SinCount.Location = new System.Drawing.Point(572, 45);
            this.SinCount.Name = "SinCount";
            this.SinCount.Size = new System.Drawing.Size(68, 22);
            this.SinCount.TabIndex = 1;
            this.SinCount.TextChanged += new System.EventHandler(this.SinCount_TextChanged);
            this.SinCount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SinCount_KeyDown);
            // 
            // SinLabel
            // 
            this.SinLabel.AutoSize = true;
            this.SinLabel.Location = new System.Drawing.Point(569, 12);
            this.SinLabel.Name = "SinLabel";
            this.SinLabel.Size = new System.Drawing.Size(74, 30);
            this.SinLabel.TabIndex = 3;
            this.SinLabel.Text = "Количество \nсинусоид";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(572, 291);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "go";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 588);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SinLabel);
            this.Controls.Add(this.SinCount);
            this.Controls.Add(this.SignGraph);
            this.Font = new System.Drawing.Font("Yandex-UI-Icons-Private", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MainForm";
            this.Text = "Graphic";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SignGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart SignGraph;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox SinCount;
        private System.Windows.Forms.Label SinLabel;
        private System.Windows.Forms.Button button1;
    }
}

