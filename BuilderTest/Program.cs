using Core.Builders;
using Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IParser parser = new FileParser();
            ICircuitDescription description = parser.Parse();

            CircuitBuilder builder = new CircuitBuilder();

            //add Nodes
            foreach (string key in description.Nodes.Keys)
            {
                builder.AddNode(key, description.Nodes[key]);
            }

            //add Edges
            foreach (string key in description.Edges.Keys)
            {
                foreach (string target in description.Edges[key])
                {
                    builder.AddEdge(key, target);
                }
            }

            var circuit = builder.GetCircuit();
            circuit.Process();

            //test if circuit is correct
            var nodes = builder.GetNodes();
            foreach (var node in nodes)
            {
                Console.WriteLine(node.Value.ToString());
            }

            Console.Read();
        }
    }
}
