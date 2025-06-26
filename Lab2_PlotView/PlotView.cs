using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_PlotView
{
    public class PlotView : PictureBox
    {
        private Bitmap _fullBitmap;
        private RectangleF _valueArea;
        private Rectangle _plotArea;
        
        //private List<Plot> _plots;
        private List<Axis> _axes;

        private List<SimpleColorPainter> _scPainters;
        private List<GradientColorPainter> _gcPainters;
        private List<PaletteColorPainter> _pcPainters;
        private Dictionary<Plot, Painter> _plots;

        public int plotAreaPadding = 10;
        public int xAxisIntervals = 10;
        public int yAxisIntervals = 10;
        public PlotView()
        {
            _fullBitmap = new Bitmap(1,1);
            _plotArea = new Rectangle(0, 0, 1, 1);
            _valueArea = new RectangleF(0, 0, 0, 0);

            //_plots = new List<Plot>();
            _axes = new List<Axis>();

            _scPainters = new List<SimpleColorPainter>();
            _gcPainters = new List<GradientColorPainter>();
            _pcPainters = new List<PaletteColorPainter>();
            _plots = new Dictionary<Plot, Painter>();
        }

        public void Initialize()
        {
            _fullBitmap = new Bitmap(this.Width, this.Height);
            _plotArea = new Rectangle(plotAreaPadding * 3, plotAreaPadding * 3, this.Width - plotAreaPadding * 3, this.Height - plotAreaPadding * 3);

            Axis axis = new Axis(0, 0, 0, 0);
            _axes.Add(axis);
            axis = new Axis(0, 0, 0, 90);
            _axes.Add(axis);

            _fullBitmap.MakeTransparent();
            
            Graphics g = Graphics.FromImage(_fullBitmap);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.Flush();

            Image = (Image)_fullBitmap;
        }

        public void Clear()
        {
            _fullBitmap.Dispose();
            _fullBitmap = new Bitmap(1, 1);
            _plotArea = new Rectangle(0, 0, 1, 1);
            _valueArea = new RectangleF(0, 0, 0, 0);

            //_plots = new List<Plot>();
            _axes = new List<Axis>();

            _scPainters = new List<SimpleColorPainter>();
            _gcPainters = new List<GradientColorPainter>();
            _pcPainters = new List<PaletteColorPainter>();
            _plots = new Dictionary<Plot, Painter>();

            Initialize();
        }
        private void RefreshBitmap()
        {
            Graphics g = Graphics.FromImage(_fullBitmap);
            g.Clear(Color.Transparent);
            g.Flush();
            _fullBitmap.MakeTransparent();

            _axes[0] = new Axis(_valueArea.X, _valueArea.Width, xAxisIntervals, 0);
            _axes[1] = new Axis(_valueArea.Y, _valueArea.Height, yAxisIntervals, 90);
            foreach (Axis axis in _axes)
            {
                _fullBitmap = axis.Show(_fullBitmap, _valueArea, _plotArea);
            }

            foreach (var item in _plots)
            {
                _fullBitmap = ((Plot)(item.Key)).ShowWith((Painter)item.Value, _fullBitmap, _valueArea, _plotArea);
            }
            Image = (Image)_fullBitmap;
        }

        private bool AdjustArea(RectangleF newArea)
        {
            double minX, maxX, minY, maxY;
            minX = Math.Min(newArea.X, _valueArea.X); maxX = Math.Max(newArea.Width, _valueArea.Width);
            minY = Math.Min(newArea.Y, _valueArea.Y); maxY = Math.Max(newArea.Height, _valueArea.Height);

            if (minX != _valueArea.X || maxX != _valueArea.Width || minY != _valueArea.Y || maxY != _valueArea.Height)
            {
                _valueArea = new RectangleF((float)minX, (float)minY, (float)maxX, (float)maxY);
                RefreshBitmap();
                return true;
            }
            return false;
        }

        private bool AdjustArea(Series s)
        {
            double minX, maxX, minY, maxY;
            minX = Math.Min(s.GetMinX(), _valueArea.X); maxX = Math.Max(s.GetMaxX(), _valueArea.Width);
            minY = Math.Min(s.GetMinY(), _valueArea.Y); maxY = Math.Max(s.GetMaxY(), _valueArea.Height);

            if (minX != _valueArea.X || maxX != _valueArea.Width || minY != _valueArea.Y || maxY != _valueArea.Height)
            {
                _valueArea = new RectangleF((float)minX, (float)minY, (float)maxX, (float)maxY);
                RefreshBitmap();
                return true;
            }
            return false;
        }

        // this will not add new painters with styles that already exist
        private Painter CreatePainter(List<Color>? colors, bool isGradient)
        {
            if (colors == null || colors.Count == 0)
            {
                Color color = Color.Black;
                SimpleColorPainter? picasso = _scPainters.Find(x => x._color == color);
                if(picasso == null)
                { 
                    picasso = new SimpleColorPainter(color);
                }

                _scPainters.Add(picasso);
                return picasso;
            }
            else if(colors.Count == 1)
            {
                Color color = colors[0];
                SimpleColorPainter? picasso = _scPainters.Find(x => x._color == color);
                if (picasso == null)
                {
                    picasso = new SimpleColorPainter(color);
                }

                _scPainters.Add(picasso);
                return picasso;
            }
            else if (isGradient)
            {
                Color colorStart = colors.First();
                Color colorEnd = colors.Last();
                GradientColorPainter? dali = _gcPainters.Find(x => x._colorStart == colorStart && x._colorEnd == colorEnd);
                if(dali == null)
                {
                    dali = new GradientColorPainter(colorStart, colorEnd);
                }

                _gcPainters.Add(dali);
                return dali;
            }
            colors = colors.Distinct().ToList();
            PaletteColorPainter? monet = _pcPainters.Find(x => !x._colors.Except(colors).ToList().Any() && !colors.Except(x._colors).ToList().Any());
            if (monet == null)
            {
                monet = new PaletteColorPainter(colors);
            }
            
            _pcPainters.Add(monet);
            return monet;
        }

        public void PlotScatterplot(List<PointF> points, string name, List<Color>? colors = null, bool isGradient = true)
        {
            Series series = new Series(points);
            
            Scatterplot plot = new Scatterplot(series, name, colors, isGradient);
            Painter painter = CreatePainter(colors, isGradient);
            _plots.Add(plot, painter);

            if (!AdjustArea(series))
            {
                _fullBitmap = plot.ShowWith(painter, _fullBitmap, _valueArea, _plotArea);
                Image = (Image)_fullBitmap;
            }
        }

        public void PlotHistogram(List<double> values, string name, List<Color>? colors = null, bool isGradient = true)
        {
            int intervalsAmount = xAxisIntervals;

            Histogram plot = new Histogram(values, name, intervalsAmount, colors, isGradient);
            Painter painter = CreatePainter(colors, isGradient);
            _plots.Add(plot, painter);

            if (!AdjustArea(plot.GetPlotArea()))
            {
                _fullBitmap = plot.ShowWith(painter, _fullBitmap, _valueArea, _plotArea);
                Image = (Image)_fullBitmap;
            }
            //RefreshBitmap();
        }
    }
}
