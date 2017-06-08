using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.V2
{
    public class XorNode : Node
    {
        public XorNode(string key, string type) : base(key, type)
        {
        }

        public override void Process()
        {
            base.Process();

            var value1 = Inputs.First().Value;
            var value2 = Inputs.Last().Value;

            Value = value1 == value2 ? 0 : 1;

            TriggerOutputs();
        }
    }
}
