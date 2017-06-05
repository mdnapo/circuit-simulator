using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Contracts;

namespace Core.Models.V2
{
	public class OutputNode : NodeV2
	{
		public OutputNode(string key) : base(key)
		{
		}

		public override void Process(NodeV2 triggerSource)
		{
			base.Process(triggerSource);
			Value = Inputs.First().Value;
		}
	}
}
