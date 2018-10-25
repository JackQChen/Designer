using System.Windows;

namespace FlowControl
{
    public class NameLabel : System.Windows.Controls.Label
    {
        protected override void OnMouseDoubleClick(System.Windows.Input.MouseButtonEventArgs e)
        {
            var viewModel = new NameLabelViewModel();
            var data = this.DataContext as DesignerItemViewModelBase;
            viewModel.Label = data.Label;
            if (ApplicationServicesProvider.Instance.Provider.EditorService.ShowDialog(viewModel) == true)
            {
                data.Label = viewModel.Label;
            }
            base.OnMouseDoubleClick(e);
        }
    }
}
