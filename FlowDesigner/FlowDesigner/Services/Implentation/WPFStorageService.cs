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
        List<DiagramItem> listSave = new List<DiagramItem>();
        public int SaveDiagram(DiagramItem diagramItem)
        {
            listSave.Add(diagramItem);
            return listSave.Count - 1;
        }

        public int SaveDiagramItem(DiagramItemData diagramItemData)
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
            return listSave[itemId];
        }

        public Connection FetchConnection(int connectionId)
        {
            return null;
        }

        #endregion
    }
}
