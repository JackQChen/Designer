using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ProcessControl
{
    [ValueConversion(typeof(List<Point>), typeof(PathSegmentCollection))]
    public class ConnectionPathConverter : IValueConverter
    {
        static ConnectionPathConverter()
        {
            Instance = new ConnectionPathConverter();
        }

        public static ConnectionPathConverter Instance
        {
            get;
            private set;
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            List<Point> points = (List<Point>)value;
            var pfc = new PathFigureCollection();
            var start = points[0];
            var end = points[1];
            var length = (start - end).Length;
            var _connectionExtensionLength = length / 2.0;
            var startextend = new Point(start.X + _connectionExtensionLength, start.Y);
            var endextend = new Point(end.X - _connectionExtensionLength - 30, end.Y);
            var figure = new PathFigure() { IsClosed = false, StartPoint = start };
            figure.Segments.Add(new BezierSegment(startextend, endextend, end, true));
            pfc.Add(figure);
            return new PathGeometry(pfc);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
