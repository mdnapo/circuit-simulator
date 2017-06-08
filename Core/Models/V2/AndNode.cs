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


            var firstvalue = Inputs.First().Value;
            var value = firstvalue;

            //can process more than 2 inputs
            for (int i = 1; i < Inputs.Count; i++)
            {
                if (!(firstvalue == Inputs.ElementAt(i).Value))
                {
                    value = 0;
                    continue;
                }
            }
            Value = value;

            //var a = Inputs.First().Value;
            //var b = Inputs.Last().Value;
            //Value = a == b ? a : 0;

            TriggerOutputs();
		}

        override public bool CanProcess()
        {
            if (Processed)
            {
                return false;
            }

            bool canProcess = false;

            foreach (Node node in Inputs)
            {
                if (node.Processed)
                {
                    if (node.Value == 0)
                    {
                        canProcess = true;
                    }
                }
            }

            return base.CanProcess() || canProcess;
        }
    }
}
