namespace Lab2_PlotView
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            plotView1 = new PlotView();
            button1 = new Button();
            listBox1 = new ListBox();
            button2 = new Button();
            minX = new NumericUpDown();
            maxX = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            maxY = new NumericUpDown();
            minY = new NumericUpDown();
            listBox2 = new ListBox();
            button3 = new Button();
            label5 = new Label();
            maxValue = new NumericUpDown();
            button4 = new Button();
            label6 = new Label();
            minValue = new NumericUpDown();
            button5 = new Button();
            button6 = new Button();
            label7 = new Label();
            corCof = new NumericUpDown();
            listBox3 = new ListBox();
            label8 = new Label();
            label9 = new Label();
            secondVar = new NumericUpDown();
            secondMean = new NumericUpDown();
            label10 = new Label();
            label11 = new Label();
            firstVar = new NumericUpDown();
            firstMean = new NumericUpDown();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            panel1 = new Panel();
            panel2 = new Panel();
            colorPanel = new Panel();
            addColorButton = new Button();
            delColorButton = new Button();
            colorDialog1 = new ColorDialog();
            contextMenuStrip1 = new ContextMenuStrip(components);
            changeColorToolStripMenuItem = new ToolStripMenuItem();
            removeToolStripMenuItem = new ToolStripMenuItem();
            gradientCheckBox = new CheckBox();
            paletteCheckBox = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)plotView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)minX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)maxX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)maxY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)minY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)maxValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)minValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)corCof).BeginInit();
            ((System.ComponentModel.ISupportInitialize)secondVar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)secondMean).BeginInit();
            ((System.ComponentModel.ISupportInitialize)firstVar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)firstMean).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // plotView1
            // 
            plotView1.BackColor = Color.White;
            plotView1.BorderStyle = BorderStyle.Fixed3D;
            plotView1.Location = new Point(345, 33);
            plotView1.Name = "plotView1";
            plotView1.Size = new Size(463, 405);
            plotView1.TabIndex = 0;
            plotView1.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(16, 18);
            button1.Name = "button1";
            button1.Size = new Size(128, 24);
            button1.TabIndex = 1;
            button1.Text = "Generate Points";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(16, 48);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(128, 79);
            listBox1.TabIndex = 2;
            // 
            // button2
            // 
            button2.Location = new Point(571, 444);
            button2.Name = "button2";
            button2.Size = new Size(75, 44);
            button2.TabIndex = 3;
            button2.Text = "Plot Scatterplot";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // minX
            // 
            minX.Location = new Point(164, 36);
            minX.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            minX.Name = "minX";
            minX.Size = new Size(60, 23);
            minX.TabIndex = 5;
            // 
            // maxX
            // 
            maxX.Location = new Point(248, 36);
            maxX.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            maxX.Name = "maxX";
            maxX.Size = new Size(60, 23);
            maxX.TabIndex = 6;
            maxX.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(155, 18);
            label1.Name = "label1";
            label1.Size = new Size(69, 15);
            label1.TabIndex = 7;
            label1.Text = "minimum x";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(239, 18);
            label2.Name = "label2";
            label2.Size = new Size(71, 15);
            label2.TabIndex = 8;
            label2.Text = "maximum x";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(239, 72);
            label3.Name = "label3";
            label3.Size = new Size(71, 15);
            label3.TabIndex = 12;
            label3.Text = "maximum y";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(155, 72);
            label4.Name = "label4";
            label4.Size = new Size(69, 15);
            label4.TabIndex = 11;
            label4.Text = "minimum y";
            // 
            // maxY
            // 
            maxY.Location = new Point(248, 90);
            maxY.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            maxY.Name = "maxY";
            maxY.Size = new Size(60, 23);
            maxY.TabIndex = 10;
            maxY.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // minY
            // 
            minY.Location = new Point(164, 90);
            minY.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            minY.Name = "minY";
            minY.Size = new Size(60, 23);
            minY.TabIndex = 9;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 15;
            listBox2.Location = new Point(19, 46);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(128, 79);
            listBox2.TabIndex = 13;
            // 
            // button3
            // 
            button3.Location = new Point(19, 14);
            button3.Name = "button3";
            button3.Size = new Size(128, 26);
            button3.TabIndex = 14;
            button3.Text = "Generate Values";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(157, 66);
            label5.Name = "label5";
            label5.Size = new Size(93, 15);
            label5.TabIndex = 16;
            label5.Text = "maximum value";
            // 
            // maxValue
            // 
            maxValue.Location = new Point(164, 84);
            maxValue.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            maxValue.Name = "maxValue";
            maxValue.Size = new Size(60, 23);
            maxValue.TabIndex = 15;
            maxValue.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // button4
            // 
            button4.Location = new Point(652, 444);
            button4.Name = "button4";
            button4.Size = new Size(75, 44);
            button4.TabIndex = 17;
            button4.Text = "Plot Histogram";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(157, 14);
            label6.Name = "label6";
            label6.Size = new Size(91, 15);
            label6.TabIndex = 19;
            label6.Text = "minimum value";
            // 
            // minValue
            // 
            minValue.Location = new Point(164, 32);
            minValue.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            minValue.Name = "minValue";
            minValue.Size = new Size(60, 23);
            minValue.TabIndex = 18;
            // 
            // button5
            // 
            button5.Location = new Point(733, 444);
            button5.Name = "button5";
            button5.Size = new Size(75, 44);
            button5.TabIndex = 20;
            button5.Text = "Clear";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(16, 156);
            button6.Name = "button6";
            button6.Size = new Size(128, 57);
            button6.TabIndex = 21;
            button6.Text = "Generate Correlated Normally Distributed Points";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(155, 156);
            label7.Name = "label7";
            label7.Size = new Size(93, 15);
            label7.TabIndex = 22;
            label7.Text = "correlation coef.";
            // 
            // corCof
            // 
            corCof.DecimalPlaces = 3;
            corCof.Increment = new decimal(new int[] { 1, 0, 0, 196608 });
            corCof.Location = new Point(163, 173);
            corCof.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            corCof.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
            corCof.Name = "corCof";
            corCof.Size = new Size(60, 23);
            corCof.TabIndex = 23;
            // 
            // listBox3
            // 
            listBox3.FormattingEnabled = true;
            listBox3.ItemHeight = 15;
            listBox3.Location = new Point(16, 218);
            listBox3.Name = "listBox3";
            listBox3.Size = new Size(128, 79);
            listBox3.TabIndex = 24;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(240, 245);
            label8.Name = "label8";
            label8.Size = new Size(67, 15);
            label8.TabIndex = 32;
            label8.Text = "second var.";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(156, 245);
            label9.Name = "label9";
            label9.Size = new Size(78, 15);
            label9.TabIndex = 31;
            label9.Text = "second mean";
            // 
            // secondVar
            // 
            secondVar.Location = new Point(247, 268);
            secondVar.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            secondVar.Minimum = new decimal(new int[] { 500, 0, 0, int.MinValue });
            secondVar.Name = "secondVar";
            secondVar.Size = new Size(60, 23);
            secondVar.TabIndex = 30;
            secondVar.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // secondMean
            // 
            secondMean.Location = new Point(163, 268);
            secondMean.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            secondMean.Name = "secondMean";
            secondMean.Size = new Size(60, 23);
            secondMean.TabIndex = 29;
            secondMean.Value = new decimal(new int[] { 21, 0, 0, 0 });
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(238, 200);
            label10.Name = "label10";
            label10.Size = new Size(49, 15);
            label10.TabIndex = 28;
            label10.Text = "first var.";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(154, 200);
            label11.Name = "label11";
            label11.Size = new Size(60, 15);
            label11.TabIndex = 27;
            label11.Text = "first mean";
            // 
            // firstVar
            // 
            firstVar.Location = new Point(247, 221);
            firstVar.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            firstVar.Minimum = new decimal(new int[] { 500, 0, 0, int.MinValue });
            firstVar.Name = "firstVar";
            firstVar.Size = new Size(60, 23);
            firstVar.TabIndex = 26;
            firstVar.Value = new decimal(new int[] { 4, 0, 0, 0 });
            // 
            // firstMean
            // 
            firstMean.Location = new Point(163, 221);
            firstMean.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            firstMean.Name = "firstMean";
            firstMean.Size = new Size(60, 23);
            firstMean.TabIndex = 25;
            firstMean.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(450, 458);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(115, 19);
            checkBox1.TabIndex = 33;
            checkBox1.Text = "Clear on plotting";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Checked = true;
            checkBox2.CheckState = CheckState.Checked;
            checkBox2.Location = new Point(19, 299);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(104, 34);
            checkBox2.TabIndex = 34;
            checkBox2.Text = "Use first values\r\n for histogram";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(checkBox2);
            panel1.Controls.Add(button6);
            panel1.Controls.Add(minY);
            panel1.Controls.Add(maxY);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(secondVar);
            panel1.Controls.Add(minX);
            panel1.Controls.Add(secondMean);
            panel1.Controls.Add(maxX);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(firstVar);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(firstMean);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(listBox3);
            panel1.Controls.Add(listBox1);
            panel1.Controls.Add(corCof);
            panel1.Location = new Point(12, 33);
            panel1.Name = "panel1";
            panel1.Size = new Size(327, 354);
            panel1.TabIndex = 35;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(button3);
            panel2.Controls.Add(listBox2);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(maxValue);
            panel2.Controls.Add(minValue);
            panel2.Location = new Point(12, 393);
            panel2.Name = "panel2";
            panel2.Size = new Size(327, 140);
            panel2.TabIndex = 36;
            // 
            // colorPanel
            // 
            colorPanel.BorderStyle = BorderStyle.Fixed3D;
            colorPanel.Location = new Point(571, 500);
            colorPanel.Name = "colorPanel";
            colorPanel.Size = new Size(237, 34);
            colorPanel.TabIndex = 37;
            // 
            // addColorButton
            // 
            addColorButton.Location = new Point(533, 500);
            addColorButton.Name = "addColorButton";
            addColorButton.Size = new Size(32, 34);
            addColorButton.TabIndex = 38;
            addColorButton.Text = "+";
            addColorButton.UseVisualStyleBackColor = true;
            addColorButton.Click += addColorButton_Click;
            // 
            // delColorButton
            // 
            delColorButton.Location = new Point(494, 500);
            delColorButton.Name = "delColorButton";
            delColorButton.Size = new Size(33, 34);
            delColorButton.TabIndex = 39;
            delColorButton.Text = "-";
            delColorButton.UseVisualStyleBackColor = true;
            delColorButton.Click += delColorButton_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { changeColorToolStripMenuItem, removeToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(146, 48);
            // 
            // changeColorToolStripMenuItem
            // 
            changeColorToolStripMenuItem.Name = "changeColorToolStripMenuItem";
            changeColorToolStripMenuItem.Size = new Size(145, 22);
            changeColorToolStripMenuItem.Text = "Change color";
            changeColorToolStripMenuItem.Click += changeColorToolStripMenuItem_Click;
            // 
            // removeToolStripMenuItem
            // 
            removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            removeToolStripMenuItem.Size = new Size(145, 22);
            removeToolStripMenuItem.Text = "Remove";
            removeToolStripMenuItem.Click += removeToolStripMenuItem_Click;
            // 
            // gradientCheckBox
            // 
            gradientCheckBox.AutoSize = true;
            gradientCheckBox.Enabled = false;
            gradientCheckBox.Location = new Point(416, 501);
            gradientCheckBox.Name = "gradientCheckBox";
            gradientCheckBox.Size = new Size(72, 34);
            gradientCheckBox.TabIndex = 40;
            gradientCheckBox.Text = "Show as \r\ngradient";
            gradientCheckBox.UseVisualStyleBackColor = true;
            gradientCheckBox.CheckedChanged += gradientCheckBox_CheckedChanged;
            gradientCheckBox.EnabledChanged += gradientCheckBox_EnabledChanged;
            // 
            // paletteCheckBox
            // 
            paletteCheckBox.AutoSize = true;
            paletteCheckBox.Enabled = false;
            paletteCheckBox.Location = new Point(348, 501);
            paletteCheckBox.Name = "paletteCheckBox";
            paletteCheckBox.Size = new Size(62, 34);
            paletteCheckBox.TabIndex = 41;
            paletteCheckBox.Text = "Use as\r\npalette";
            paletteCheckBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(836, 542);
            Controls.Add(paletteCheckBox);
            Controls.Add(gradientCheckBox);
            Controls.Add(delColorButton);
            Controls.Add(addColorButton);
            Controls.Add(colorPanel);
            Controls.Add(checkBox1);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button2);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(plotView1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)plotView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)minX).EndInit();
            ((System.ComponentModel.ISupportInitialize)maxX).EndInit();
            ((System.ComponentModel.ISupportInitialize)maxY).EndInit();
            ((System.ComponentModel.ISupportInitialize)minY).EndInit();
            ((System.ComponentModel.ISupportInitialize)maxValue).EndInit();
            ((System.ComponentModel.ISupportInitialize)minValue).EndInit();
            ((System.ComponentModel.ISupportInitialize)corCof).EndInit();
            ((System.ComponentModel.ISupportInitialize)secondVar).EndInit();
            ((System.ComponentModel.ISupportInitialize)secondMean).EndInit();
            ((System.ComponentModel.ISupportInitialize)firstVar).EndInit();
            ((System.ComponentModel.ISupportInitialize)firstMean).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PlotView plotView1;
        private Button button1;
        private ListBox listBox1;
        private Button button2;
        private NumericUpDown minX;
        private NumericUpDown maxX;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private NumericUpDown maxY;
        private NumericUpDown minY;
        private ListBox listBox2;
        private Button button3;
        private Label label5;
        private NumericUpDown maxValue;
        private Button button4;
        private Label label6;
        private NumericUpDown minValue;
        private Button button5;
        private Button button6;
        private Label label7;
        private NumericUpDown corCof;
        private ListBox listBox3;
        private Label label8;
        private Label label9;
        private NumericUpDown secondVar;
        private NumericUpDown secondMean;
        private Label label10;
        private Label label11;
        private NumericUpDown firstVar;
        private NumericUpDown firstMean;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private Panel panel1;
        private Panel panel2;
        private Panel colorPanel;
        private Button addColorButton;
        private Button delColorButton;
        private ColorDialog colorDialog1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem changeColorToolStripMenuItem;
        private ToolStripMenuItem removeToolStripMenuItem;
        private CheckBox gradientCheckBox;
        private CheckBox paletteCheckBox;
    }
}
