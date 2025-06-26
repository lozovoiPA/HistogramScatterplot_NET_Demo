using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_PlotView
{
    public class Series
    {
        private List<PointF> _pointsReal;
        private List<Point>? _pointsClient;

        public Series(List<PointF> points)
        {
            IEnumerable<PointF> e = points.OrderBy(p => p.X);
            _pointsReal = e.ToList();

            _pointsClient = null;
        }
        public Series(List<double> values)
        {
            _pointsReal = new List<PointF>();
            foreach (double value in values)
            {
                PointF newPoint = new PointF((float)value, 0);
                _pointsReal.Add(newPoint);
            }
            IEnumerable<PointF> e = _pointsReal.OrderBy(p => p.X);
            _pointsReal = e.ToList();

            _pointsClient = null;
        }

        // polar to cartesian transform
        // in this case values is an array of radius
        public Series(List<double> values, double angle)
        {
            _pointsReal = new List<PointF>();
            double cos = Math.Cos(angle), sin = Math.Sin(angle);
            foreach (double value in values)
            {
                PointF newPoint = new PointF((float)(value * cos), (float)(value * sin));
                _pointsReal.Add(newPoint);
            }
            IEnumerable<PointF> e = _pointsReal.OrderBy(p => p.X);
            _pointsReal = e.ToList();

            _pointsClient = null;
        }
        public void MapToClient(RectangleF realArea, Rectangle clientArea)
        {
            _pointsClient = PointsToClient(_pointsReal, realArea, clientArea);
        }
        public static List<Point> PointsToClient(List<PointF> points, RectangleF realArea, Rectangle clientArea)
        {
            List<Point> newPoints = new List<Point>();
            foreach (PointF point in points)
            {
                Point newPoint = PointToClient(point, realArea, clientArea);
                newPoints.Add(newPoint);
            }
            return newPoints;
        }

        public static Point PointToClient(PointF point, RectangleF realArea, Rectangle clientArea)
        {
            double deltaX = realArea.Width - realArea.X;
            double deltaY = realArea.Height - realArea.Y;

            Point newPoint = new Point(
                    (int)((clientArea.Width * (point.X - realArea.X) + clientArea.X * (realArea.Width - point.X)) / deltaX),
                    (int)((clientArea.Height * (realArea.Height - point.Y) + clientArea.Y * (point.Y - realArea.Y)) / deltaY)
                    );
            return newPoint;
        }

        public List<PointF> GetRealPoints()
        {
            List<PointF> pointsCopy = new List<PointF>(_pointsReal);
            return pointsCopy;
        }
        public List<Point> GetClientPoints()
        {
            List<Point> pointsCopy;
            if (_pointsClient == null)
            {
                pointsCopy = new List<Point>();
            }
            else
            {
                pointsCopy = new List<Point>(_pointsClient);
            }
            return pointsCopy;
        }
        public double GetMinX()
        {
            return _pointsReal[0].X;
        }
        public double GetMaxX()
        {
            return _pointsReal[_pointsReal.Count - 1].X;
        }
        public double GetMinY()
        {
            return _pointsReal.Min(p => p.Y);
        }
        public double GetMaxY()
        {
            return _pointsReal.Max(p => p.Y);
        }

    }
}
