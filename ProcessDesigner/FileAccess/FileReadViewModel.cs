using System.Windows.Input;
using ProcessControl;

namespace FileAccess
{
    [ImageUrl("/FileAccess;component/Images/File.png")]
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
            FileReadModel data = new FileReadModel();
            data.FilePath = "";
            if (this.ShowEditor(data))
            {
                this.model.FilePath = data.FilePath;
            }
        }
    }
}
