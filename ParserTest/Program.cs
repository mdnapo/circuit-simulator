using System;
using Parser;

namespace ParserTest
{
	class Program
	{
		static void Main(string[] args)
		{
			IParser parser = new FileParser();
			ICircuitDescription description = parser.Parse();

			Console.WriteLine("#Nodes");
			Console.WriteLine();

			foreach (string key in description.Nodes.Keys)
				Console.WriteLine(key + ":" + description.Nodes[key]);

			Console.WriteLine();
			Console.WriteLine("#Edges");
			Console.WriteLine();

			foreach (string key in description.Edges.Keys)
			{
				string targets = "";

				foreach (string target in description.Edges[key])
					targets += target + ", ";

				Console.WriteLine(key + ':' +targets);
			}

			Console.ReadKey();
		}
	}
}
