using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adapter.Client;
using Adapter.Service;

namespace Adapter.Adapter
{
    public class ComponentParserAdapter : IComponent
    {
        public OldComponent Adaptee { get; }

        public string Name
        {
            get
            {
                return Adaptee.getName();
            }
        }
        public List<string> Children
        {
            get
            {
                return new List<string>(Adaptee.children);
            }
        }

        public ComponentParserAdapter(OldComponent component)
        {
            Adaptee = component;
        }
    }
}
