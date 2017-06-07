using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Output;

namespace Core.Models.V2
{
	public class OrNode : Node
	{
		public OrNode(string key, string type) : base(key, type)
		{

		}

		public override void Process()
		{
			base.Process();

			int a = Inputs.First().Value;
			int b = Inputs.Last().Value;
			Value = a != b ? 1 : b;

			TriggerOutputs();
		}
	}
}
