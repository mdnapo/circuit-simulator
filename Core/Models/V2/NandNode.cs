using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.V2
{
    public class NandNode : Node
    {
        public NandNode(string key, string type) : base(key, type)
        {

        }

        public override void Process()
        {
            base.Process();

            int a = Inputs.First().Value;
            int b = Inputs.Last().Value;
            if(a == 1 && b == 1)
            {
                Value = 0;
            }
            else
            {
                Value = 1;
            }

            TriggerOutputs();
        }
    }
}
