
namespace ProcessControl
{
    public abstract class ConnectorInfoBase : INPCBase
    {
        private static double connectorWidth = 8;
        private static double connectorHeight = 8;

        public ConnectorInfoBase(ConnectorOrientation orientation)
        {
            this.Orientation = orientation;
        }

        public ConnectorOrientation Orientation { get; private set; }

        public static double ConnectorWidth
        {
            get { return connectorWidth; }
        }

        public static double ConnectorHeight
        {
            get { return connectorHeight; }
        }
    }
}
