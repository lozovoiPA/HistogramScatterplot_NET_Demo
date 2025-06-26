using System;
using System.Collections.Generic;
using System.Data;
using System.DirectoryServices;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_PlotView
{
    public abstract class Plot
    {
        protected Series _series;
        public string _name;
        public List<Point> MapToClient(RectangleF valueArea, Rectangle bitmapArea)
        {
            _series.MapToClient(valueArea, bitmapArea); // confine data points of this plot to valueArea and map them to bitmapArea
            return _series.GetClientPoints();
        }
        public abstract RectangleF GetPlotArea();
        public abstract Bitmap ShowWith(Painter painter, Bitmap bitmap, RectangleF valueArea, Rectangle bitmapArea);
    }

    public class Scatterplot : Plot
    {
        public Scatterplot(Series series, string name, List<Color>? colors = null, bool isGradient = true)
        {
            _series = series;
            _name = name;
        }

        public override RectangleF GetPlotArea()
        {
            RectangleF plotArea = new RectangleF((float)_series.GetMinX(), 0, (float)_series.GetMaxX(), (float)_series.GetMaxY());
            return plotArea;
        }

        public override Bitmap ShowWith(Painter painter, Bitmap bitmap, RectangleF valueArea, Rectangle bitmapArea)
        {
            Bitmap newBitmap = painter.ShowScatterplot(this, bitmap, valueArea, bitmapArea);
            return newBitmap;
        }
    }

    public class Histogram: Plot
    {
        List<double> _values;
        public Histogram(List<double> values, string name, int intervalsAmount, List<Color>? colors = null, bool isGradient = true)
        {
            values = values.Order().ToList();
            _values = new List<double>(values);
            _name = name;

            List<PointF> points = new List<PointF>();
            double left = values.First(); int count = 0;
            double right = values.Last();
            double delta = (right - left) / intervalsAmount;

            for(int j = 0; (left<= right) && (j < values.Count());)
            {
                count = 0;
                while ((j < values.Count()) && (values[j] <= (left + delta)))
                {
                    count++;
                    j++;
                }
                points.Add(new PointF((float)(left), 0));
                points.Add(new PointF((float)(left), count));
                points.Add(new PointF((float)(left + delta), count));
                points.Add(new PointF((float)(left + delta), 0));
                left += delta;
            }
            _series = new Series(points);
        }

        public override RectangleF GetPlotArea()
        {
            List<PointF> pointsR = _series.GetRealPoints();
            RectangleF plotArea = new RectangleF(pointsR.First().X, 0, pointsR.Last().X, (float)_series.GetMaxY());
            return plotArea;
        }

        public List<int> GetCounts()
        {
            List<PointF> pointsR = _series.GetRealPoints();
            List<int> counts = new List<int>();
            for (int i = 0; i < pointsR.Count(); i += 4)
            {
                counts.Add((int)(pointsR[i + 1].Y));
            }
            return counts;
        }

        public override Bitmap ShowWith(Painter painter, Bitmap bitmap, RectangleF valueArea, Rectangle bitmapArea)
        {
            Bitmap newBitmap = painter.ShowHistogram(this, bitmap, valueArea, bitmapArea);
            return newBitmap;
        }
    }
    
}
