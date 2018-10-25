using System;

namespace FlowControl
{
    public class PluginAttribute : Attribute
    {
        public string ImageUrl
        {
            get;
            set;
        }

        public string DataTemplatePath
        {
            get;
            set;
        }

        public PluginAttribute()
        {
        }
    }
}
