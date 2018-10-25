using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlowControl
{
    public interface IStorageService
    {
        //delete methods
        void DeleteConnection(int connectionId);
        void DeleteDiagramItem(int diagramId);

        //save methods
        int SaveConnection(Connection connection);
        int SaveDiagram(DiagramItem diagramItem);
        int SaveDiagramItem(DiagramItem diagramItem);

        //fetch methods
        IEnumerable<DiagramItem> FetchAllDiagram();
        DiagramItem FetchDiagram(int itemId);
        Connection FetchConnection(int connectionId);
    }
}
