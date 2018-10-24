using System.Windows;

namespace ProcessControl
{
    public class NameLabel : System.Windows.Controls.Label
    {
        protected override void OnMouseDoubleClick(System.Windows.Input.MouseButtonEventArgs e)
        {
            var model = this.DataContext as DesignerItemViewModelBase;
            PopupWindow window = new PopupWindow();
            //window.Label = model.Label;
            window.Owner = Application.Current.MainWindow;
            if (window.ShowDialog() == true)
            {
                //model.Label = window.Label;
            }
            base.OnMouseDoubleClick(e);
        }
    }
}
