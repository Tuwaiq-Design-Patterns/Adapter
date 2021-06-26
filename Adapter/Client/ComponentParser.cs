using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.Client
{
    public class ComponentParser
    {
        private IComponent Component;
        public ComponentParser(IComponent component)
        {
            Component = component;
        }

        public void ComponentName()
        {
            Console.WriteLine(Component.Name);
        }
        public void ComponentChildrenCount()
        {
            Console.WriteLine(Component.Children.Count);
        }
    }
}
