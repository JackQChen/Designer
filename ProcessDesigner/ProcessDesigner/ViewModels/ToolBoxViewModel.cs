using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using ProcessControl.Helpers;
using ProcessControl;
using System.IO;
using System.Reflection;

namespace ProcessDesigner
{
    public class ToolBoxViewModel
    {
        private List<ToolBoxData> toolBoxItems = new List<ToolBoxData>();

        public ToolBoxViewModel()
        {
            var plugInDir = AppDomain.CurrentDomain.BaseDirectory + "PlugIn";
            if (!Directory.Exists(plugInDir))
                Directory.CreateDirectory(plugInDir);
            foreach (var fileName in Directory.GetFiles(plugInDir, "*.dll", SearchOption.AllDirectories))
            {
                var asm = Assembly.LoadFrom(fileName);
                foreach (var type in asm.GetTypes().Where(p => p.IsSubclassOf(typeof(DesignerItemViewModelBase))))
                {
                    var attrs = type.GetCustomAttributes(typeof(ImageUrlAttribute), true).ToArray();
                    if (attrs.Length > 0)
                        toolBoxItems.Add(new ToolBoxData(((ImageUrlAttribute)attrs[0]).ImageUrl, type));
                }
            }
        }

        public List<ToolBoxData> ToolBoxItems
        {
            get { return toolBoxItems; }
        }
    }
}
