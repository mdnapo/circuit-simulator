using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class OrNode : Node
    {
        public OrNode(string key) : base(key)
        {
        }

        public override void Process()
        {
            base.Process();

            var A = Inputs.First();
            var B = Inputs.Last();
            var output = A != B ? 1 : B;

            SetOutputValue(output);
            PassOutputToNextNodes();
        }
    }
}
