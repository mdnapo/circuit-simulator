using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Contracts;

namespace Core.Models.V2
{
	public class OrNode : Node
	{
		public OrNode(string key, string type) : base(key, type)
		{

		}

		public override void Process(Node triggerSource)
		{
			base.Process(triggerSource);

			int a = Inputs.First().Value;
			int b = Inputs.Last().Value;
			Value = a != b ? 1 : b;

			TriggerOutputs();
		}
	}
}
