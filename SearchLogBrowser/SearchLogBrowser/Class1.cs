using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchLogBrowser
{
    class GenericKeyValue
    {
        public String Key { get; set; }
        public String Value { get; set; }
    }

    class ComboBoxItem: GenericKeyValue
    {
        public override string ToString()
        {
            return Key;
        }
    }
}
