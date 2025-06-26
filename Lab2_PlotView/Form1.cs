using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab2_PlotView
{
    public partial class Form1 : Form
    {
        List<PointF> points = new List<PointF>();
        List<double> values = new List<double>();
        int lastgen = -1;
        Random rnd = new Random();
        int scatterCount = 0;
        int histCount = 0;

        List<Panel> palette = new List<Panel>();
        public Form1()
        {
            InitializeComponent();
            plotView1.Initialize();
            AddPanelColor();
            AddPanelColor();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            points.Clear();
            listBox1.Items.Clear();
            int min_x = (int)minX.Value, max_x = (int)maxX.Value;
            int min_y = (int)minY.Value, max_y = (int)maxY.Value;
            for (int i = 0; i < 100; i++)
            {
                PointF point = new PointF(rnd.Next(min_x, max_x + 1), rnd.Next(min_y, max_y + 1));
                points.Add(point);

                string sf = string.Format("({0:F0}; {1:F0})", point.X, point.Y);
                listBox1.Items.Add(sf);
            }
            lastgen = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                plotView1.Clear();
                scatterCount = 0;
                histCount = 0;
            }
            if (lastgen == 0)
            {
                PlotScatterplot();
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            plotView1.Clear();
            scatterCount = 0;
            histCount = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            values.Clear();
            listBox2.Items.Clear();
            int min_x = (int)minValue.Value, max_x = (int)maxValue.Value;
            for (int i = 0; i < 1000; i++)
            {
                values.Add(rnd.Next(min_x, max_x + 1));
                listBox2.Items.Add(values[i]);
            }

            lastgen = 1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                plotView1.Clear();
                scatterCount = 0;
                histCount = 0;
            }
            if (lastgen == 1)
            {
                PlotHistogram();
            }
            else if (lastgen == 0 && checkBox2.Checked)
            {
                values = new List<double>();
                foreach (PointF point in points)
                {
                    values.Add(point.X);
                }
                PlotHistogram();
            }
        }

        private void PlotScatterplot()
        {
            List<Color>? colors = GetColorsFromPalette();
            if (palette.Count <= 1)
            {
                plotView1.PlotScatterplot(points, "scatter" + scatterCount, colors);
            }
            else
            {
                plotView1.PlotScatterplot(points, "scatter" + scatterCount, colors, false); // because I already generate the palette and for scatter both Gradient and Palette output is the same, unlike hist (see below), the same (Palette Color) will be used
            }
            scatterCount++;

        }
        private void PlotHistogram()
        {
            List<Color>? colors = GetColorsFromPalette();
            if (palette.Count <= 1)
            {
                plotView1.PlotHistogram(values, "hist" + histCount, colors);
            }
            else if (gradientCheckBox.Checked && !paletteCheckBox.Checked)
            {
                plotView1.PlotHistogram(values, "hist" + histCount, colors);
            }
            else
            {
                plotView1.PlotHistogram(values, "hist" + histCount, colors, false);
            }
            histCount++;
        }

        private double NextGaussian(double mean, double var)
        {
            double u1 = 1.0 - rnd.NextDouble();
            double u2 = 1.0 - rnd.NextDouble();
            double stdNorm = Math.Sqrt(-2.0 * Math.Log(u1)) *
                     Math.Sin(2.0 * Math.PI * u2);

            return (mean + var * stdNorm);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            points.Clear();
            listBox3.Items.Clear();

            double norm1, norm2;
            double mean1, var1, mean2, var2, cor, cort;

            mean1 = (double)firstMean.Value;
            mean2 = (double)secondMean.Value;
            var1 = (double)firstVar.Value;
            var2 = (double)secondVar.Value;
            cor = (double)corCof.Value;
            cort = Math.Sqrt(1 - cor * cor);
            for (int i = 0; i < 200; i++)
            {
                norm1 = NextGaussian(mean1, var1);
                norm2 = cor * norm1 + cort * NextGaussian(mean2, var2);

                PointF point = new PointF((float)norm1, (float)norm2);
                points.Add(point);

                string sf = string.Format("({0:F3}; {1:F3})", norm1, norm2);
                listBox3.Items.Add(sf);
            }
            lastgen = 0;
        }

        private List<Color>? GetColorsFromPalette()
        {
            if (palette.Count == 0) return null;
            List<Color> colors = new List<Color>();
            foreach (Panel panel in palette)
            {
                colors.Add(panel.BackColor);
            }
            return colors;
        }

        private void SetColorsFromPalette(List<Color> colors)
        {
            foreach (Panel panel in palette)
            {
                panel.Dispose();
            }
            palette.Clear();
            foreach (Color color in colors)
            {
                AddPanelColor(color, true);
            }
            RecalculatePalette();
        }
        private void AddPanelColor(Color? color = null, bool noRecalc = false)
        {
            if (color == null)
            {
                Random rnd = new Random();
                color = Color.FromArgb(255, rnd.Next(256), rnd.Next(256), rnd.Next(256));
            }
            Panel newCell = new Panel();
            palette.Add(newCell);

            newCell.BackColor = (Color)color;
            newCell.BorderStyle = BorderStyle.FixedSingle;
            newCell.MouseClick += openContextMenu;
            newCell.MouseDoubleClick += changeColorToolStripMenuItem_Click;
            colorPanel.Controls.Add(newCell);

            if (!noRecalc)
            {
                RecalculatePalette();
            }
        }

        private void RemovePaletteColor(Panel panel, bool noRecalc = false)
        {
            palette.Remove(panel);
            panel.Dispose();
            if (!noRecalc)
            {
                RecalculatePalette();
            }
        }
        private void addColorButton_Click(object sender, EventArgs e)
        {
            if (palette.Count < 10)
            {
                AddPanelColor();
            }
        }

        private void RecalculatePalette()
        {
            if (palette.Count > 0)
            {
                int w = (colorPanel.Width / palette.Count);
                int wadd = (colorPanel.Width - w * palette.Count) / 2;
                //double rem = ((double)colorPanel.Width % palette.Count);
                //if (rem >= 0.5) w++;

                palette.First().Size = new Size(w + wadd, colorPanel.Height);
                palette.First().Left = 0;
                for (int i = 1; i < palette.Count; i++)
                {
                    palette[i].Size = new Size(w, colorPanel.Height);
                    palette[i].Left = i * w + wadd;
                }

                palette.Last().Size = new Size(w + wadd, colorPanel.Height);
                if (gradientCheckBox.Enabled == false && palette.Count > 1)
                {
                    gradientCheckBox.Enabled = true;
                }
                else if (gradientCheckBox.Enabled == true && palette.Count <= 1)
                {
                    gradientCheckBox.Enabled = false;
                }
            }
        }

        private void openContextMenu(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            switch (me.Button)
            {
                case MouseButtons.Right:
                    contextMenuStrip1.Show((Panel)sender, new Point(me.X, me.Y));
                    break;
            }

        }

        private void changeColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = colorDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                if (sender.GetType() == typeof(ToolStripMenuItem))
                {
                    ((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl.BackColor = colorDialog1.Color;
                }
                else if (sender.GetType() == typeof(Panel))
                {
                    ((Panel)sender).BackColor = colorDialog1.Color;
                }
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Panel? panel = (Panel)contextMenuStrip1.SourceControl;
            panel = palette.Find(x => x == panel);
            if (panel != null)
            {
                RemovePaletteColor(panel);
            }
        }

        private void delColorButton_Click(object sender, EventArgs e)
        {
            if (palette.Count > 0)
            {
                Panel panel = palette.Last();
                RemovePaletteColor(panel);
            }
        }

        private void gradientCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (gradientCheckBox.Checked)
            {
                List<Color> colors = GetColorsFromPalette();
                colors = Painter.CreateGradient(colors.First(), colors.Last());
                SetColorsFromPalette(colors);

                paletteCheckBox.Enabled = true;
            }
            else
            {
                List<Color> colors = GetColorsFromPalette();
                colors = [colors.First(), colors.Last()];
                SetColorsFromPalette(colors);

                paletteCheckBox.Enabled = false;
            }
        }

        private void gradientCheckBox_EnabledChanged(object sender, EventArgs e)
        {
            if (gradientCheckBox.Enabled && gradientCheckBox.Checked)
            {
                gradientCheckBox.Checked = false;
            }
            else
            {
                paletteCheckBox.Enabled = false;
            }
        }
    }
}
