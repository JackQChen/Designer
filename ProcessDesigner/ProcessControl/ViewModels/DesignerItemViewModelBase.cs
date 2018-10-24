using System.Collections.Generic;

namespace ProcessControl
{
    public abstract class DesignerItemViewModelBase : SelectableDesignerItemViewModelBase
    {
        private double left;
        private double top;
        private bool showConnectors = false;
        private string label = "步骤名称", imageUrl = "";
        private List<FullyCreatedConnectorInfo> connectors = new List<FullyCreatedConnectorInfo>();
        private IEditorService editorService;

        private static double itemWidth = 65;
        private static double itemHeight = 65;

        public DesignerItemViewModelBase(int id, IDiagramViewModel parent, double left, double top)
            : base(id, parent)
        {
            this.left = left;
            this.top = top;
            Init();
        }

        public DesignerItemViewModelBase()
            : base()
        {
            Init();
        }

        public FullyCreatedConnectorInfo LeftConnector
        {
            get { return connectors[0]; }
        }

        public FullyCreatedConnectorInfo RightConnector
        {
            get { return connectors[1]; }
        }

        public static double ItemWidth
        {
            get { return itemWidth; }
        }

        public static double ItemHeight
        {
            get { return itemHeight; }
        }

        public bool ShowConnectors
        {
            get
            {
                return showConnectors;
            }
            set
            {
                if (showConnectors != value)
                {
                    showConnectors = value;
                    RightConnector.ShowConnectors = value;
                    LeftConnector.ShowConnectors = value;
                    NotifyChanged("ShowConnectors");
                }
            }
        }

        public double Left
        {
            get
            {
                return left;
            }
            set
            {
                if (left != value)
                {
                    left = value;
                    NotifyChanged("Left");
                }
            }
        }

        public double Top
        {
            get
            {
                return top;
            }
            set
            {
                if (top != value)
                {
                    top = value;
                    NotifyChanged("Top");
                }
            }
        }

        public string Label
        {
            get
            {
                return label;
            }
            set
            {
                if (label != value)
                {
                    label = value;
                    NotifyChanged("Label");
                }
            }
        }

        public string ImageUrl
        {
            get
            {
                return imageUrl;
            }
        }

        public System.Windows.Input.ICommand ShowEditorCommand
        {
            get;
            private set;
        }

        private void Init()
        {
            connectors.Add(new FullyCreatedConnectorInfo(this, ConnectorOrientation.Left));
            connectors.Add(new FullyCreatedConnectorInfo(this, ConnectorOrientation.Right));
            var attributes = this.GetType().GetCustomAttributes(typeof(ImageUrlAttribute), true);
            if (attributes.Length > 0)
                imageUrl = ((ImageUrlAttribute)attributes[0]).ImageUrl;
            editorService = ApplicationServicesProvider.Instance.Provider.EditorService;
            ShowEditorCommand = new SimpleCommand(ExecuteShowEditorCommand);
            this.ShowConnectors = false;
        }

        public virtual void ExecuteShowEditorCommand(object parameter)
        {
        }

        public bool ShowEditor(object dataContextForPopup)
        {
            if (editorService.ShowDialog(dataContextForPopup) == true)
                return true;
            return false;
        }
    }
}
