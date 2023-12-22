namespace _3
{
    partial class formMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Grid = new PictureBox();
            panel1 = new Panel();
            buttonClear = new Button();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            buttonAddRandomNumber = new Button();
            textBoxRandomNumberSize = new TextBox();
            labelExecutionTime = new Label();
            label3 = new Label();
            buttonNext = new Button();
            label2 = new Label();
            buttonGrahamScan = new Button();
            labelPointCounter = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)Grid).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // Grid
            // 
            Grid.BackColor = SystemColors.ControlLightLight;
            Grid.Dock = DockStyle.Fill;
            Grid.Location = new Point(0, 0);
            Grid.Name = "Grid";
            Grid.Size = new Size(1002, 453);
            Grid.TabIndex = 0;
            Grid.TabStop = false;
            Grid.Click += Grid_Click;
            Grid.Paint += Grid_Paint;
            Grid.MouseUp += Grid_MouseUp;
            //Grid.MouseWheel += Grid_MouseWheel;//
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.BackColor = SystemColors.ControlDark;
            panel1.Controls.Add(buttonClear);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(buttonAddRandomNumber);
            panel1.Controls.Add(textBoxRandomNumberSize);
            panel1.Controls.Add(labelExecutionTime);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(buttonNext);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(buttonGrahamScan);
            panel1.Controls.Add(labelPointCounter);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(703, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(299, 453);
            panel1.TabIndex = 1;
            // 
            // buttonClear
            // 
            buttonClear.Location = new Point(89, 358);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(111, 33);
            buttonClear.TabIndex = 18;
            buttonClear.Text = "Clear!!";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += buttonClear_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(3, 358);
            label10.Name = "label10";
            label10.Size = new Size(0, 25);
            label10.TabIndex = 2;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 133);
            label9.Name = "label9";
            label9.Size = new Size(285, 25);
            label9.TabIndex = 17;
            label9.Text = "---------------------------------------";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(3, 33);
            label8.Name = "label8";
            label8.Size = new Size(285, 25);
            label8.TabIndex = 16;
            label8.Text = "---------------------------------------";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(0, 272);
            label7.Name = "label7";
            label7.Size = new Size(296, 25);
            label7.TabIndex = 15;
            label7.Text = "How many nodes you want to add?";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(3, 108);
            label6.Name = "label6";
            label6.Size = new Size(282, 25);
            label6.TabIndex = 14;
            label6.Text = "Right mouse click deletes a node!!";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 83);
            label5.Name = "label5";
            label5.Size = new Size(252, 25);
            label5.TabIndex = 13;
            label5.Text = "Left mouse click adds a node!!";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 58);
            label4.Name = "label4";
            label4.Size = new Size(237, 25);
            label4.TabIndex = 12;
            label4.Text = "Click left side to add nodes!!";
            // 
            // buttonAddRandomNumber
            // 
            buttonAddRandomNumber.Location = new Point(170, 308);
            buttonAddRandomNumber.Name = "buttonAddRandomNumber";
            buttonAddRandomNumber.Size = new Size(111, 33);
            buttonAddRandomNumber.TabIndex = 11;
            buttonAddRandomNumber.Text = "Add!!";
            buttonAddRandomNumber.UseVisualStyleBackColor = true;
            buttonAddRandomNumber.Click += buttonAddRandomNumber_Click;
            // 
            // textBoxRandomNumberSize
            // 
            textBoxRandomNumberSize.Location = new Point(6, 308);
            textBoxRandomNumberSize.Name = "textBoxRandomNumberSize";
            textBoxRandomNumberSize.Size = new Size(150, 31);
            textBoxRandomNumberSize.TabIndex = 10;
            textBoxRandomNumberSize.TextChanged += textBoxRandomNumberSize_TextChanged;
            // 
            // labelExecutionTime
            // 
            labelExecutionTime.AutoSize = true;
            labelExecutionTime.Location = new Point(150, 187);
            labelExecutionTime.Name = "labelExecutionTime";
            labelExecutionTime.Size = new Size(51, 25);
            labelExecutionTime.TabIndex = 7;
            labelExecutionTime.Text = "0 ms";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(0, 187);
            label3.Name = "label3";
            label3.Size = new Size(152, 25);
            label3.TabIndex = 6;
            label3.Text = "Execution Time = ";
            // 
            // buttonNext
            // 
            buttonNext.AutoSize = true;
            buttonNext.Location = new Point(161, 235);
            buttonNext.Name = "buttonNext";
            buttonNext.Size = new Size(121, 35);
            buttonNext.TabIndex = 5;
            buttonNext.Text = "Next!";
            buttonNext.UseVisualStyleBackColor = true;
            buttonNext.Click += buttonNext_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(0, 8);
            label2.Name = "label2";
            label2.Size = new Size(201, 25);
            label2.TabIndex = 4;
            label2.Text = "Graham Scan Algorithm";
            // 
            // buttonGrahamScan
            // 
            buttonGrahamScan.AutoSize = true;
            buttonGrahamScan.Location = new Point(3, 235);
            buttonGrahamScan.Name = "buttonGrahamScan";
            buttonGrahamScan.Size = new Size(149, 35);
            buttonGrahamScan.TabIndex = 3;
            buttonGrahamScan.Text = "Generate Hull!";
            buttonGrahamScan.UseVisualStyleBackColor = true;
            buttonGrahamScan.Click += buttonGrahamScan_Click;
            // 
            // labelPointCounter
            // 
            labelPointCounter.AutoSize = true;
            labelPointCounter.Location = new Point(150, 162);
            labelPointCounter.Name = "labelPointCounter";
            labelPointCounter.Size = new Size(22, 25);
            labelPointCounter.TabIndex = 1;
            labelPointCounter.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 162);
            label1.Name = "label1";
            label1.Size = new Size(142, 25);
            label1.TabIndex = 0;
            label1.Text = "Point Counter = ";
            // 
            // formMain
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(1002, 453);
            Controls.Add(panel1);
            Controls.Add(Grid);
            Name = "formMain";
            Text = "Convex Hull Visualizer";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)Grid).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private PictureBox Grid;
        private Panel panel1;
        private Label label1;
        private Label labelPointCounter;
        private Label label2;
        private Button buttonGrahamScan;
        private Button buttonNext;
        private Label label3;
        private Label labelExecutionTime;
        private TextBox textBox3;
        private Button buttonAddRandomNumber;
        private TextBox textBoxRandomNumberSize;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Button buttonClear;
        private Label label10;
    }
}