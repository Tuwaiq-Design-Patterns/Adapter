using System;
using System.Collections.Generic;

using Adapter.Adapter;
using Adapter.Service;
using Adapter.Client;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            IComponent component = new ComponentParserAdapter(new OldComponent("MainComponent", new string[] { "Router", "Drawer", "Navbar", "CardList" }));
            ComponentParser cp = new ComponentParser(component);

            cp.ComponentName();
            cp.ComponentChildrenCount();
        }
    }
}
