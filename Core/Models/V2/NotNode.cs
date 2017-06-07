using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Output;

namespace Core.Models.V2
{
	public class NotNode : Node
	{
		public NotNode(string key, string type) : base(key, type)
		{
		}

		public override void Process()
		{
			base.Process();

			Value = Inputs.First().Value == 1 ? 0 : 1;

			TriggerOutputs();
		}
	}
}
