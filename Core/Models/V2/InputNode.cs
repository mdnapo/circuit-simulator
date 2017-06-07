using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Output;

namespace Core.Models.V2
{
	public class InputNode : Node
	{
		public InputNode(string key, string type, int value) : base(key, type)
		{
			Value = value;
		}

		public override void Process()
		{
			base.Process();
			TriggerOutputs();
		}
	}
}
