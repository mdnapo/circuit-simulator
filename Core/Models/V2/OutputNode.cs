using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Contracts;

namespace Core.Models.V2
{
	public class OutputNode : Node
	{
		public OutputNode(string key, string type) : base(key, type)
		{
		}

		public override void Process(Node triggerSource)
		{
			base.Process(triggerSource);
			Value = Inputs.First().Value;
		}
	}
}
