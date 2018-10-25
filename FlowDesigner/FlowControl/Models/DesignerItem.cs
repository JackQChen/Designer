using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlowControl
{
    public abstract class DesignerItem : DesignerItemBase
    {
        public DesignerItem(int id, double left, double top)
            : base(id)
        {
            this.Left = left;
            this.Top = top;
        }

        public double Left { get; private set; }
        public double Top { get; private set; }

        public string Setting { get; set; }

    }
}
