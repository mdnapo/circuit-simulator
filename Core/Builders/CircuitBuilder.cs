using Core.Factories;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parser;

namespace Core.Builders
{
    public class CircuitBuilder
    {
        private NodeFactory _nodeFactory;
        private Circuit _circuit;
        private IDictionary<string, Node> _nodes;

        public CircuitBuilder()
        {
            _nodeFactory = new NodeFactory();
            _circuit = new Circuit();
            _nodes = new Dictionary<string, Node>();
        }

        public CircuitBuilder AddNode(string key, string type)
        {
            var node = _nodeFactory.Create(key, type);
            _nodes.Add(key, node);

            if (type == "INPUT_LOW" || type == "INPUT_HIGH")
            {
                _circuit.Inputs.Add((InputNode)node);
            }
            else if (type == "PROBE")
            {
                _circuit.Outputs.Add((OutputNode)node);
            }

            return this;
        }

        public CircuitBuilder AddEdge(string source, string target)
        {
            _nodes[source].AddOutputNode(_nodes[target]);
            return this;
        }

        //method for testing
        public IDictionary<string, Node> GetNodes()
        {
            return _nodes;
        }

        public Circuit GetCircuit()
        {
            var circuit = _circuit;

			return circuit;
        }
    }
}
