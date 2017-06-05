using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Contracts;

namespace Core.Models.V2
{
	public class AndNode : NodeV2
	{
		public AndNode(string key) : base(key)
		{

		}

		public override void Process(NodeV2 triggerSource)
		{
			base.Process(triggerSource);

			var a = Inputs.First().Value;
			var b = Inputs.Last().Value;
			Value = a == b ? a : 0;

			TriggerOutputs();
		}
	}
}
