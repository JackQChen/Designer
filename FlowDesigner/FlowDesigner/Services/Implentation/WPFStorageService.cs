using System.Collections.Generic;
using System.Linq;
using FlowControl;

namespace FlowDesigner
{
    public class WPFStorageService : IStorageService
    {
        #region IStorageService 成员

        public void DeleteConnection(int connectionId)
        {
        }

        public void DeleteDiagramItem(int diagramId)
        {
        }

        public int SaveConnection(Connection connection)
        {
            return 0;
        }

        public int SaveDiagram(DiagramItem diagramItem)
        {
            return 0;
        }

        public int SaveDiagramItem(DiagramItem diagramItem)
        {
            return 0;
        }

        public IEnumerable<DiagramItem> FetchAllDiagram()
        {
            List<DiagramItem> list = new List<DiagramItem>();
            return list.AsEnumerable<DiagramItem>();
        }

        public DiagramItem FetchDiagram(int itemId)
        {
            return null;
        }

        public Connection FetchConnection(int connectionId)
        {
            return null;
        }

        #endregion
    }
}
