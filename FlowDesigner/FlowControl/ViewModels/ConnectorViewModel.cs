using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using FlowControl.Helpers;

namespace FlowControl
{
    public class ConnectorViewModel : SelectableDesignerItemViewModelBase
    {
        private FullyCreatedConnectorInfo sourceConnectorInfo;
        private ConnectorInfoBase sinkConnectorInfo;
        private Point sourceB;
        private Point sourceA;
        private List<Point> connectionPoints;
        private Point endPoint;
        private Rect area;


        public ConnectorViewModel(int id, IDiagramViewModel parent,
            FullyCreatedConnectorInfo sourceConnectorInfo, FullyCreatedConnectorInfo sinkConnectorInfo)
            : base(id, parent)
        {
            Init(sourceConnectorInfo, sinkConnectorInfo);
        }

        public ConnectorViewModel(FullyCreatedConnectorInfo sourceConnectorInfo, ConnectorInfoBase sinkConnectorInfo)
        {
            Init(sourceConnectorInfo, sinkConnectorInfo);
        }

        public bool IsFullConnection
        {
            get { return sinkConnectorInfo is FullyCreatedConnectorInfo; }
        }

        public Point SourceA
        {
            get
            {
                return sourceA;
            }
            set
            {
                if (sourceA != value)
                {
                    sourceA = value;
                    UpdateArea();
                    NotifyChanged("SourceA");
                }
            }
        }

        public Point SourceB
        {
            get
            {
                return sourceB;
            }
            set
            {
                if (sourceB != value)
                {
                    sourceB = value;
                    UpdateArea();
                    NotifyChanged("SourceB");
                }
            }
        }

        public List<Point> ConnectionPoints
        {
            get
            {
                return connectionPoints;
            }
            private set
            {
                if (connectionPoints != value)
                {
                    connectionPoints = value;
                    NotifyChanged("ConnectionPoints");
                }
            }
        }

        public Point EndPoint
        {
            get
            {
                return endPoint;
            }
            private set
            {
                if (endPoint != value)
                {
                    endPoint = value;
                    NotifyChanged("EndPoint");
                }
            }
        }

        public Rect Area
        {
            get
            {
                return area;
            }
            private set
            {
                if (area != value)
                {
                    area = value;
                    UpdateConnectionPoints();
                    NotifyChanged("Area");
                }
            }
        }

        public FullyCreatedConnectorInfo SourceConnectorInfo
        {
            get
            {
                return sourceConnectorInfo;
            }
            set
            {
                if (sourceConnectorInfo != value)
                {
                    sourceConnectorInfo = value;
                    SourceA = PointHelper.GetPointForConnector(this.SourceConnectorInfo);
                    NotifyChanged("SourceConnectorInfo");
                    (sourceConnectorInfo.DataItem as INotifyPropertyChanged).PropertyChanged += new WeakINPCEventHandler(ConnectorViewModel_PropertyChanged).Handler;
                }
            }
        }

        public ConnectorInfoBase SinkConnectorInfo
        {
            get
            {
                return sinkConnectorInfo;
            }
            set
            {
                if (sinkConnectorInfo != value)
                {
                    sinkConnectorInfo = value;
                    if (SinkConnectorInfo is FullyCreatedConnectorInfo)
                    {
                        SourceB = PointHelper.GetPointForConnector((FullyCreatedConnectorInfo)SinkConnectorInfo);
                        (((FullyCreatedConnectorInfo)sinkConnectorInfo).DataItem as INotifyPropertyChanged).PropertyChanged += new WeakINPCEventHandler(ConnectorViewModel_PropertyChanged).Handler;
                    }
                    else
                    {
                        SourceB = ((PartCreatedConnectionInfo)SinkConnectorInfo).CurrentLocation;
                    }
                    NotifyChanged("SinkConnectorInfo");
                }
            }
        }

        private void UpdateArea()
        {
            Area = new Rect(SourceA, SourceB);
        }

        private void UpdateConnectionPoints()
        {
            ConnectionPoints = new List<Point>()
                                   {
                                       new Point( SourceA.X  <  SourceB.X ? 0d : Area.Width, SourceA.Y  <  SourceB.Y ? 0d : Area.Height ), 
                                       new Point(SourceA.X  >  SourceB.X ? 0d : Area.Width, SourceA.Y  >  SourceB.Y ? 0d : Area.Height)
                                   };
            if (IsFullConnection)
                EndPoint = ConnectionPoints.Last();
            else
                EndPoint = new Point();
        }

        private void ConnectorViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Left":
                case "Top":
                    SourceA = PointHelper.GetPointForConnector(this.SourceConnectorInfo);
                    if (this.SinkConnectorInfo is FullyCreatedConnectorInfo)
                    {
                        SourceB = PointHelper.GetPointForConnector((FullyCreatedConnectorInfo)this.SinkConnectorInfo);
                    }
                    break;
            }
        }

        private void Init(FullyCreatedConnectorInfo sourceConnectorInfo, ConnectorInfoBase sinkConnectorInfo)
        {
            this.Parent = sourceConnectorInfo.DataItem.Parent;
            this.SourceConnectorInfo = sourceConnectorInfo;
            this.SinkConnectorInfo = sinkConnectorInfo;
        }

    }
}
