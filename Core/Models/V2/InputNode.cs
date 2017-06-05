using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Contracts;

namespace Core.Models.V2
{
	public class InputNode : NodeV2
	{
		public InputNode(string key, int value) : base(key)
		{
			Value = value;
		}

		public override void Process(NodeV2 triggerSource = null)
		{
			base.Process(this);
			TriggerOutputs();
		}
	}
}
