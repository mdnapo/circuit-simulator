﻿using Core.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parser;
using Core.Models.V2;

namespace Core.Builders
{
	public class CircuitBuilderV2
	{
		private NodeFactoryV2 _nodeFactory;
		private Circuit _circuit;
		private IDictionary<string, Node> _nodes;

		public CircuitBuilderV2()
		{
			_nodeFactory = new NodeFactoryV2();
		}

		public void AddNode(string key, string type)
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
			else
			{
				_circuit.Operators.Add(node);
			}
		}

		public void AddEdge(string source, string[] targets)
		{
			Node _source = _nodes[source];
			Node _target;

			foreach (string target in targets)
			{
				_target = _nodes[target];
				_source.AddOutputNode(_target);
				_target.AddInputNode(_source);
			}
		}

		public Circuit GetCircuit(ICircuitDescription description)
		{
			_circuit = new Circuit();
			_nodes = new Dictionary<string, Node>();

			foreach (string key in description.Nodes.Keys)
			{
				AddNode(key, description.Nodes[key]);
			}

			foreach (string key in description.Edges.Keys)
			{
				AddEdge(key, description.Edges[key]);
			}

			return _circuit;
		}
	}
}
