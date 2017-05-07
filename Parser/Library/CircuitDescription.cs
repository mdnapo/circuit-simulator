using System.Collections.Generic;

namespace Parser.Library
{
	internal class CircuitDescription : ICircuitDescription
	{
		public IDictionary<string, string> Nodes { get; private set; }
		public IDictionary<string, string[]> Edges { get; private set; }

		public CircuitDescription(IDictionary<string, string> nodes, IDictionary<string, string[]>edges)
		{
			Nodes = nodes;
			Edges = edges;
		}
	}
}
