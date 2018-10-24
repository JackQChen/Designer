using System.Windows.Input;
using ProcessControl;

namespace FileAccess
{
    [Plugin(ImageUrl = "Images/File.png", DataTemplatePath = "Styles/FileReadDataTemplate.xaml")]
    public class FileReadViewModel : DesignerItemViewModelBase
    {
        public FileReadModel model = new FileReadModel();

        public FileReadViewModel()
        {
            Init();
        }

        public FileReadViewModel(int id, DiagramViewModel parent, double left, double top, string setting1)
            : base(id, parent, left, top)
        {
            Init();
        }

        private void Init()
        {
            this.ShowConnectors = false;
        }

        public override void ExecuteShowEditorCommand(object parameter)
        {
            var param = parameter as FileReadViewModel;
            FileReadModel data = new FileReadModel();
            data.FilePath = param.model.FilePath;
            if (this.ShowEditor(data))
            {
                this.model.FilePath = data.FilePath;
            }
        }
    }
}
