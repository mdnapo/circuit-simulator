using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Contracts;

namespace Core.Models.V2
{
	public class OrNode : NodeV2
	{
		public OrNode(string key) : base(key)
		{

		}

		public override void Process(NodeV2 triggerSource)
		{
			base.Process(triggerSource);

			int a = Inputs.First().Value;
			int b = Inputs.Last().Value;
			Value = a != b ? 1 : b;

			TriggerOutputs();
		}
	}
}
