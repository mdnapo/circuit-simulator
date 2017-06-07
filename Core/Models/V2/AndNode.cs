using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Output;

namespace Core.Models.V2
{
	public class AndNode : Node
	{
		public AndNode(string key, string type) : base(key, type)
		{

		}

		public override void Process()
		{
			base.Process();

			var a = Inputs.First().Value;
			var b = Inputs.Last().Value;
			Value = a == b ? a : 0;

			TriggerOutputs();
		}
	}
}
