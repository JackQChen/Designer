using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlowControl;

namespace FileAccess
{
    public class FileReadModel : INPCBase
    {
        private string filePath = "";
        public string FilePath
        {
            get
            {
                return filePath;
            }
            set
            {
                filePath = value;
                NotifyChanged("FilePath");
            }
        }
        public string Encoding { get; set; }
    }
}
