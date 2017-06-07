using Core.Builders;
using Parser;
using System;
using Core;

namespace BuilderTest
{
	class Program
	{
		static void Main(string[] args)
		{
			IParser parser = new FileParser();
			ICircuitDescription description = parser.Parse();
			Simulator simulator = new Simulator();

			CircuitBuilderV2 builder = new CircuitBuilderV2();
			simulator.Circuit = builder.GetCircuit(description);
			simulator.Run();

			Console.WriteLine(simulator.Output.Get);

			Console.Read();
		}
	}
}
