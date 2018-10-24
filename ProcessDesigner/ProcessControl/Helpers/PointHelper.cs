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
    public class PointHelper
    {
        public static Point GetPointForConnector(FullyCreatedConnectorInfo connector)
        {
            Point point = new Point();

            switch (connector.Orientation)
            {
                case ConnectorOrientation.Left:
                    point = new Point(connector.DataItem.Left - ConnectorInfoBase.ConnectorWidth, connector.DataItem.Top + (DesignerItemViewModelBase.ItemHeight / 2));
                    break;
                case ConnectorOrientation.Right:
                    point = new Point(connector.DataItem.Left + DesignerItemViewModelBase.ItemWidth + (ConnectorInfoBase.ConnectorWidth), connector.DataItem.Top + (DesignerItemViewModelBase.ItemHeight / 2));
                    break;
            }
            return point;
        }
    }
}
