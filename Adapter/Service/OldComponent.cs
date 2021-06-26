using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.Service
{
    public class OldComponent
    {
        private string name;
        public string[] children;

        public OldComponent(string name, string[] children)
        {
            this.name = name;
            this.children = children;
        }
        public string getName()
        {
            return name;
        }
    }
}
