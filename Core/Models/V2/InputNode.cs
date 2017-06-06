using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Contracts;

namespace Core.Models.V2
{
	public class InputNode : Node
	{
		public InputNode(string key, string type, int value) : base(key, type)
		{
			Value = value;
		}

		public override void Process(Node triggerSource = null)
		{
			base.Process(this);
			TriggerOutputs();
		}
	}
}
