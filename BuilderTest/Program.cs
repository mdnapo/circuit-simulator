using Core.Builders;
using Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models.V2;
using Core.Contracts;
using Core;

namespace BuilderTest
{
	class Program
	{
		static void Main(string[] args)
		{
			IParser parser = new FileParser();
			ICircuitDescription description = parser.Parse();
			ITextView context = new Simulator();

			CircuitBuilderV2 builder = new CircuitBuilderV2();
			var c = builder.GetCircuit(description);
			c.SetTextView(context);
			c.Process();

			//foreach (NodeV2 node in c.Inputs)
			//	foreach (NodeV2 output in node.Outputs)
			//		Console.WriteLine(output.Key);

			//foreach (NodeV2 node in c.Operators)
			//	Console.WriteLine(node.ToString());

			//foreach (NodeV2 node in c.Outputs)
			//	Console.WriteLine(node.ToString());

			foreach (string r in context.GetProcessingResults())
				Console.WriteLine(r);

			Console.Read();
		}
	}
}
