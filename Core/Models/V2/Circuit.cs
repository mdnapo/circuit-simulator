using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Contracts;

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

		public void SetTextView(ITextView context)
		{
			((List<InputNode>)Inputs).
				ForEach(input => input.SetTextView(context));
			((List<Node>)Operators).
				ForEach(operators => operators.SetTextView(context));
			((List<OutputNode>)Outputs).
				ForEach(output => output.SetTextView(context));
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
