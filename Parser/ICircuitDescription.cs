using System.Collections.Generic;

namespace Parser
{
	public interface ICircuitDescription
	{
		IDictionary<string, string> Nodes { get; }
		IDictionary<string, string[]> Edges { get; }
	}
}
