using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models.V2;

namespace Core.Factories
{
	public class NodeFactoryV2
	{
        private Dictionary<string, Type> _types;

        public NodeFactoryV2()
        {
            _types = new Dictionary<string, Type>();
        }
        public void AddNodeType(string key, Type type)
        {
            _types[key] = type;
        }
        public Node Create(string key, string type)
        {
            Type t = _types[type.ToLower()];
            Node c = (Node)Activator.CreateInstance(t, key, type);
            return c;
        }
    }
}
