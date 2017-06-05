using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Contracts;

namespace Core.Models.V2
{
	public class NotNode : NodeV2
	{
		public NotNode(string key) : base(key)
		{
		}

		public override void Process(NodeV2 triggerSource)
		{
			base.Process(triggerSource);

			Value = Inputs.First().Value == 1 ? 0 : 1;

			TriggerOutputs();
		}
	}
}
