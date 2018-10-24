using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ProcessControl
{
    public class Connector : Control
    {
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DesignerCanvas canvas = GetDesignerCanvas(this);
            if (canvas != null)
            {
                canvas.SourceConnector = this;
            }
        }

        public ConnectorOrientation Orientation { get; set; }

        private DesignerCanvas GetDesignerCanvas(DependencyObject element)
        {
            while (element != null && !(element is DesignerCanvas))
                element = VisualTreeHelper.GetParent(element);
            return element as DesignerCanvas;
        }
    }


    public enum ConnectorOrientation
    {
        None = 0,
        Left = 1,
        Right = 2
    }
}
