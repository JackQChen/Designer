using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlowControl
{
    public interface IEditorService
    {
        bool? ShowDialog(object dataContextForPopup);
    }
}
