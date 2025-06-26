using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_PlotView
{
    public class Axis
    {
        private Series _series;
        private List<double> _values;

        private double _maxValue = 0;
        private double _minValue = 0;
        private double _interval;
        private double _angle;

        // to turn data points of the axis around on the plot specify the corresponding angle
        public Axis(double minValue, double maxValue, int intervalsAmount, int angle)
        {
            SetMaxValue(maxValue);
            SetMinValue(minValue);
            SetInterval(intervalsAmount);
            SetAngle(angle);

            List<double> values = new List<double>();
            for (double i = _minValue; i < _maxValue; i += _interval)
            {
                values.Add(i);
            }
            values.Add(maxValue);
            values = values.Order().ToList();

            _values = new List<double>(values);
            _series = new Series(values, _angle);
        }
        // в случае если в дальнейшем понадобится делать какие-то дополнительные действия при изменении этих параметров,
        // удобнее реализовать их в виде методов
        private void SetMaxValue(double maxValue)
        {
            _maxValue = maxValue;
        }
        private void SetMinValue(double minValue)
        {
            _minValue = minValue;
        }
        private void SetInterval(int intervalsAmount)
        {
            _interval = (_maxValue - _minValue) / intervalsAmount;
        }
        private void SetAngle(int angle)
        {
            _angle = (angle * Math.PI) / 180;
        }

        private void MapToClient(RectangleF realArea, Rectangle clientArea)
        {
            _series.MapToClient(realArea, clientArea);
        }
        public Bitmap Show(Bitmap bitmap, RectangleF valueArea, Rectangle bitmapArea)
        {
            Bitmap newBitmap = (Bitmap)bitmap.Clone();
            MapToClient(valueArea, bitmapArea);

            Graphics g = Graphics.FromImage(newBitmap);
            List<Point> points = _series.GetClientPoints();
            Pen pen = new Pen(Color.Black, 1);

            // Draw Line
            Point pointMax = points.Last(), pointMin = points.First();
            g.DrawLine(pen, pointMin, pointMax);

            // Draw Origin Dot (0)
            Point point = Series.PointToClient(new PointF(0, 0), valueArea, bitmapArea);
            Point newPoint = new Point(point.X, point.Y);
            Rectangle rect = new Rectangle(newPoint, new Size(3, 3));
            g.DrawEllipse(pen, rect);
            g.FillEllipse(Brushes.Black, rect);

            // Draw strokes
            double sin = Math.Sin(_angle);
            double cos = Math.Cos(_angle);
            for (int i = 0; i < points.Count; i++)
            {
                g.DrawEllipse(pen, new RectangleF((float)(points[i].X - 1.5 * sin), (float)(points[i].Y - 1.5 * cos), 3, 3));
                g.DrawString(((int)(_values[i])).ToString(), 
                    new Font("Arial", 8), 
                    new SolidBrush(Color.Blue),
                    (float)(points[i].X - 25 * sin),
                    (float)(points[i].Y + 5 * cos));
            }
            g.Flush();
            return newBitmap;
        }
    }
}
