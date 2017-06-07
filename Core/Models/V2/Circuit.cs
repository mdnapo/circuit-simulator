using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Output;

namespace Core.Models.V2
{
	public class Circuit
	{
		public ICollection<InputNode> Inputs { get; set; }
		public ICollection<Node> Operators { get; set; }
		public ICollection<OutputNode> Outputs { get; set; }

		public Circuit()
		{
			Inputs = new List<InputNode>();
			Operators = new List<Node>();
			Outputs = new List<OutputNode>();
		}

		public void SetOutput(ITextOutput _output)
		{
			((List<InputNode>)Inputs).
				ForEach(input => input.SetTextOutput(_output));
			((List<Node>)Operators).
				ForEach(operators => operators.SetTextOutput(_output));
			((List<OutputNode>)Outputs).
				ForEach(output => output.SetTextOutput(_output));
		}

		public void Reset()
		{
			((List<InputNode>)Inputs).
				ForEach(input => input.Processed = false);
			((List<Node>)Operators).
				ForEach(operators => operators.Processed = false);
			((List<OutputNode>)Outputs).
				ForEach(output => output.Processed = false);
		}

		public void Process()
		{
			foreach (var input in Inputs)
			{
				input.Process();
			}
		}
	}
}
