using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_PlotView
{
    public abstract class Painter
    {
        public abstract Bitmap ShowScatterplot(Scatterplot plot, Bitmap bitmap, RectangleF valueArea, Rectangle bitmapArea);
        public abstract Bitmap ShowHistogram(Histogram plot, Bitmap bitmap, RectangleF valueArea, Rectangle bitmapArea);
        public static Color HSLtoRGB(double h, double s, double l)
        {
            double c = (1 - Math.Abs(2 * l - 1)) * s;
            int n = (int)(h / 60);
            double x = c * (1 - Math.Abs((h / 60) % 2 - 1));
            double m = l - c / 2;

            double r1 = 0, g1 = 0, b1 = 0;
            switch (n)
            {
                case 0:
                    r1 = c;
                    g1 = x;
                    break;
                case 1:
                    r1 = x;
                    g1 = c;
                    break;
                case 2:
                    g1 = c;
                    b1 = x;
                    break;
                case 3:
                    g1 = x;
                    b1 = c;
                    break;
                case 4:
                    r1 = x;
                    b1 = c;
                    break;
                case 5:
                    r1 = c;
                    b1 = x;
                    break;
            }
            return Color.FromArgb((int)((r1 + m) * 255), (int)((g1 + m) * 255), (int)((b1 + m) * 255));
        }

        public static List<Color> CreateGradient(Color colorStart, Color colorEnd)
        {
            List<Color> gradient = new List<Color>();
            double h1 = colorStart.GetHue();
            double h2 = colorEnd.GetHue();
            if (h2 < h1)
            {
                Color t = colorStart;
                colorStart = colorEnd;
                colorEnd = t;

                h1 = colorStart.GetHue();
                h2 = colorEnd.GetHue();
            }

            double s1 = colorStart.GetSaturation(), l1 = colorStart.GetBrightness();
            double s2 = colorEnd.GetSaturation(), l2 = colorEnd.GetBrightness();

            double hd = h2 - h1;
            double sd = s2 - s1;
            double ld = l2 - l1;

            int n = (int)Math.Sqrt(hd);
            if (hd > 180) // so the smaller half is taken
            {
                hd = 360 - hd;
                hd *= -1; // change direction on the color wheel
            }
            hd /= n;
            sd /= n;
            ld /= n;

            for (int i = 0; i < n; i++)
            {
                gradient.Add(HSLtoRGB(h1, s1, l1));
                h1 += hd;
                h1 = (360 + h1) % 360; // to loop around if h1 becomes negative
                s1 += sd;
                l1 += ld;
            }
            return gradient;
        }
    }

    public class SimpleColorPainter : Painter
    {
        public Color _color;
        public SimpleColorPainter(Color color)
        {
            _color = color;
        }

        public override Bitmap ShowScatterplot(Scatterplot plot, Bitmap bitmap, RectangleF valueArea, Rectangle bitmapArea)
        {
            List<Point> points = plot.MapToClient(valueArea, bitmapArea);

            Bitmap newBitmap = (Bitmap)bitmap.Clone();
            Graphics g = Graphics.FromImage(newBitmap);

            Pen pen = new Pen(_color);
            foreach (Point point in points)
            {
                g.DrawEllipse(pen, new RectangleF(point.X - 2, point.Y - 2, 4, 4));
            }
            g.Flush();
            return newBitmap;
        }
        public Bitmap ShowScatterplot(Scatterplot plot, Bitmap bitmap, RectangleF valueArea, Rectangle bitmapArea, Color color)
        {
            _color = color;
            Bitmap newBitmap = ShowScatterplot(plot, bitmap, valueArea, bitmapArea);
            return newBitmap;
        }

        public override Bitmap ShowHistogram(Histogram plot, Bitmap bitmap, RectangleF valueArea, Rectangle bitmapArea)
        {
            List<Point> points = plot.MapToClient(valueArea, bitmapArea);
            List<int> counts = plot.GetCounts();

            Bitmap newBitmap = (Bitmap)bitmap.Clone();
            Graphics g = Graphics.FromImage(newBitmap);

            Pen pen1 = new Pen(Color.FromArgb(_color.A / 2, _color));
            Pen pen2 = new Pen(Color.FromArgb(_color.A / 4, _color));
            Pen pen;
            bool whichPen = false;

            for (int i = 0, j = 0; i < points.Count(); i += 4, j++)
            {
                Rectangle rect = new Rectangle(
                    new Point(points[i + 1].X + 2, points[i + 1].Y),
                    new Size(points[i + 2].X - points[i].X - 2, points[i + 3].Y - points[i + 2].Y));
                whichPen = !whichPen;
                pen = (whichPen) ? pen1 : pen2;
                g.FillRectangle(pen.Brush, rect);
                g.DrawString(counts[j].ToString(), new Font("Tahoma", 8), pen.Brush, points[i + 1].X + 3, points[i + 1].Y - 4);
            }
            g.Flush();
            return newBitmap;
        }

        public Bitmap ShowHistogram(Histogram plot, Bitmap bitmap, RectangleF valueArea, Rectangle bitmapArea, Color color)
        {
            _color = color;
            Bitmap newBitmap = ShowHistogram(plot, bitmap, valueArea, bitmapArea);
            return newBitmap;
        }
    }

    public class GradientColorPainter : Painter
    {
        public Color _colorStart;
        public Color _colorEnd;

        public GradientColorPainter(Color colorStart, Color colorEnd)
        {
            _colorStart = colorStart;
            _colorEnd = colorEnd;
        }
        public override Bitmap ShowScatterplot(Scatterplot plot, Bitmap bitmap, RectangleF valueArea, Rectangle bitmapArea)
        {
            List<Color> colors = CreateGradient(_colorStart, _colorEnd);
            PaletteColorPainter pt = new PaletteColorPainter(colors);
            Bitmap newBitmap = pt.ShowScatterplot(plot, bitmap, valueArea, bitmapArea);
            return newBitmap;
        }
        public Bitmap ShowScatterplot(Scatterplot plot, Bitmap bitmap, RectangleF valueArea, Rectangle bitmapArea, Color colorStart, Color colorEnd)
        {
            _colorStart = colorStart;
            _colorEnd = colorEnd;
            Bitmap newBitmap = ShowScatterplot(plot, bitmap, valueArea, bitmapArea);
            return newBitmap;
        }

        public override Bitmap ShowHistogram(Histogram plot, Bitmap bitmap, RectangleF valueArea, Rectangle bitmapArea)
        {
            List<Point> points = plot.MapToClient(valueArea, bitmapArea);
            List<int> counts = plot.GetCounts();

            Bitmap newBitmap = (Bitmap)bitmap.Clone();
            Graphics g = Graphics.FromImage(newBitmap);

            List<Color> colors = CreateGradient(_colorStart, _colorEnd);
            int minY = points.Min(p => p.Y), maxY = points.Max(p => p.Y);
            int maxRectH = maxY - minY;
            int yd = maxRectH / colors.Count;
            List<int> topEdges = new List<int>();
            int k = 0;
            for (k = maxY - yd; k - minY >= yd; k -= yd)
            {
                topEdges.Add(k);
            }
            // extend the last interval if it doesn't include all Y
            if (k > 0)
            {
                k = minY;
                topEdges.Add(k);
            }

            // we will be coloring each individual rectangle into a gradient
            double alphak = 0.5;
            Pen pen = new Pen(Color.Black);
            for (int i = 0, n = 0, topY = 0, ii = 0; i < points.Count(); i += 4, ii++)
            {
                Rectangle rect = new Rectangle(
                    new Point(points[i + 1].X + 2, points[i + 1].Y),
                    new Size(points[i + 2].X - points[i].X - 2, points[i + 3].Y - points[i + 2].Y));
                n = Math.Min((int)Math.Ceiling((double)rect.Size.Height / yd), topEdges.Count);
                topY = rect.Location.Y;

                rect = new Rectangle(
                    new Point(rect.Location.X, maxY),
                    new Size(rect.Size.Width, 0)); // starting (zero height) rect
                for (int j = 0; j < n; j++)
                {
                    pen = new Pen(Color.FromArgb((int)(colors[j].A * alphak), colors[j]));
                    int y = Math.Max(topEdges[j], topY);
                    rect = new Rectangle(new Point(rect.Location.X, y), new Size(rect.Size.Width, rect.Location.Y - y));
                    g.FillRectangle(pen.Brush, rect);
                }
                g.DrawString(counts[ii].ToString(), new Font("Tahoma", 8), pen.Brush, points[i + 1].X + 3, points[i + 1].Y - 4);
            }
            g.Flush();
            return newBitmap;
        }

        public Bitmap ShowHistogram(Histogram plot, Bitmap bitmap, RectangleF valueArea, Rectangle bitmapArea, Color colorStart, Color colorEnd)
        {
            _colorStart = colorStart;
            _colorEnd = colorEnd;
            Bitmap newBitmap = ShowHistogram(plot, bitmap, valueArea, bitmapArea);
            return newBitmap;
        }
    }

    public class PaletteColorPainter : Painter
    {
        public List<Color> _colors;

        public PaletteColorPainter(List<Color> colors)
        {
            _colors = colors;
        }

        public override Bitmap ShowScatterplot(Scatterplot plot, Bitmap bitmap, RectangleF valueArea, Rectangle bitmapArea)
        {
            List<Point> points = plot.MapToClient(valueArea, bitmapArea);

            Bitmap newBitmap = (Bitmap)bitmap.Clone();
            Graphics g = Graphics.FromImage(newBitmap);

            int xd = (points.Last().X - points.First().X) / _colors.Count;
            for (int i = points.First().X + xd, k = 0, j = 0; i <= points.Last().X; i += xd, j++) // условие: правая граница интервала не выходит за последнюю точку
            {
                Pen pen = new Pen(_colors[j]);
                while ((k < points.Count) && ((points[k].X < i) || (points.Last().X - i < xd))) // последнее условие: пока расстояние между последней точкой и последней правой границей меньше длины интервала... (т.е. добавить оставшиеся за правой границей точки в этот же интервал)
                {
                    g.DrawEllipse(pen, new RectangleF(points[k].X - 2, points[k].Y - 2, 4, 4));
                    k++;
                }
            }
            g.Flush();
            return newBitmap;
        }
        public Bitmap ShowScatterplot(Scatterplot plot, Bitmap bitmap, RectangleF valueArea, Rectangle bitmapArea, List<Color> colors)
        {
            _colors = colors;
            Bitmap newBitmap = ShowScatterplot(plot, bitmap, valueArea, bitmapArea);
            return newBitmap;
        }

        public override Bitmap ShowHistogram(Histogram plot, Bitmap bitmap, RectangleF valueArea, Rectangle bitmapArea)
        {
            List<Point> points = plot.MapToClient(valueArea, bitmapArea);
            List<int> counts = plot.GetCounts();

            Bitmap newBitmap = (Bitmap)bitmap.Clone();
            Graphics g = Graphics.FromImage(newBitmap);

            int minY = points.Min(p => p.Y), maxY = points.Max(p => p.Y);
            int maxRectH = maxY - minY;
            int yd = maxRectH / _colors.Count;

            double alphak = 0.5;
            Pen pen = new Pen(Color.Black);
            for (int i = 0, n = 0, j = 0; i < points.Count(); i += 4, j++)
            {
                Rectangle rect = new Rectangle(
                    new Point(points[i + 1].X + 2, points[i + 1].Y),
                    new Size(points[i + 2].X - points[i].X - 2, points[i + 3].Y - points[i + 2].Y));
                n = Math.Min((int)Math.Floor((double)rect.Size.Height / yd), _colors.Count - 1);

                pen = new Pen(Color.FromArgb((int)(_colors[n].A * alphak), _colors[n]));
                g.FillRectangle(pen.Brush, rect);
                g.DrawString(counts[j].ToString(), new Font("Tahoma", 8), pen.Brush, points[i + 1].X + 3, points[i + 1].Y - 4);
            }
            g.Flush();
            return newBitmap;
        }

        public Bitmap ShowHistogram(Histogram plot, Bitmap bitmap, RectangleF valueArea, Rectangle bitmapArea, List<Color> colors)
        {
            _colors = colors;
            Bitmap newBitmap = ShowHistogram(plot, bitmap, valueArea, bitmapArea);
            return newBitmap;
        }
    }
}
