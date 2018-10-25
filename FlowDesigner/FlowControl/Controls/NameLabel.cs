using System.Windows;

namespace FlowControl
{
    public class NameLabel : System.Windows.Controls.Label
    {
        protected override void OnMouseDoubleClick(System.Windows.Input.MouseButtonEventArgs e)
        {
            var model = new NameLabelModel();
            var data = this.DataContext as DesignerItemViewModelBase;
            model.Label = data.Label;
            if (ApplicationServicesProvider.Instance.Provider.EditorService.ShowDialog(model) == true)
            {
                data.Label = model.Label;
            }
            base.OnMouseDoubleClick(e);
        }
    }
}
