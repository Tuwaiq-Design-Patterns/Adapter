using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.Client
{
    public interface IComponent
    {
        public string Name { get; }
        public List<string> Children { get; }
    }
}
