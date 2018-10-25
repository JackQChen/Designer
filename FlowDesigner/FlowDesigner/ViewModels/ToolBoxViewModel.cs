using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using FlowControl;
using FlowControl.Helpers;

namespace FlowDesigner
{
    public class ToolBoxViewModel
    {
        private List<ToolBoxData> toolBoxItems = new List<ToolBoxData>();

        public ToolBoxViewModel()
        {
            var pluginDir = AppDomain.CurrentDomain.BaseDirectory + "Plugin";
            if (!Directory.Exists(pluginDir))
                Directory.CreateDirectory(pluginDir);
            foreach (var filePath in Directory.GetFiles(pluginDir, "*.dll", SearchOption.AllDirectories))
            {
                var asm = Assembly.LoadFrom(filePath);
                foreach (var type in asm.GetTypes().Where(p => p.IsSubclassOf(typeof(DesignerItemViewModelBase))))
                {
                    var attrs = type.GetCustomAttributes(typeof(PluginAttribute), true).ToArray();
                    if (attrs.Length > 0)
                    {
                        var plugin = attrs[0] as PluginAttribute;
                        var strPath = "/{0};component/{1}";
                        var fileName = Path.GetFileNameWithoutExtension(filePath);
                        var imgUrl = string.Format(strPath, fileName, plugin.ImageUrl);
                        DesignerItemViewModelBase.dicImageUrl.Add(type, imgUrl);
                        toolBoxItems.Add(new ToolBoxData(imgUrl, type));
                        var uri = new Uri(string.Format(strPath, fileName, plugin.DataTemplatePath), UriKind.Relative);
                        var res = (ResourceDictionary)Application.LoadComponent(uri);
                        Application.Current.Resources.MergedDictionaries.Add(res);
                    }
                }
            }
        }

        public List<ToolBoxData> ToolBoxItems
        {
            get { return toolBoxItems; }
        }
    }
}
