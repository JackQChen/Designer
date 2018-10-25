using System.Windows;
using System.Windows.Controls;

namespace FlowControl
{
    /// <summary>
    /// Interaction logic for DiagramControl.xaml
    /// </summary>
    public partial class DiagramControl : UserControl
    {
        public DiagramControl()
        {
            InitializeComponent();
        }


        private void DesignerCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            DesignerCanvas myDesignerCanvas = sender as DesignerCanvas;
            zoomBox.DesignerCanvas = myDesignerCanvas;
        }

    }
}
