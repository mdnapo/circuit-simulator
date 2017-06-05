using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Contracts;

namespace Core.Models.V2
{
	public class CircuitV2
	{
		public ICollection<InputNode> Inputs { get; set; }
		public ICollection<NodeV2> Operators { get; set; }
		public ICollection<OutputNode> Outputs { get; set; }

		public CircuitV2()
		{
			Inputs = new List<InputNode>();
			Operators = new List<NodeV2>();
			Outputs = new List<OutputNode>();
		}

		public void SetSimulationContext(ISimulationContext context)
		{
			((List<InputNode>)Inputs).
				ForEach(input => input.SetSimulationContext(context));
			((List<NodeV2>)Operators).
				ForEach(operators => operators.SetSimulationContext(context));
			((List<OutputNode>)Outputs).
				ForEach(output => output.SetSimulationContext(context));
		}

		public void Process()
		{
			foreach (var input in Inputs)
			{
				input.Process(input);
			}
		}
	}
}
