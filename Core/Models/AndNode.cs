using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class AndNode : Node
    {
        public AndNode(string key) : base(key)
        {
        }

        public override void Process()
        {
            base.Process();

            var A = Inputs.First();
            var B = Inputs.Last();
            var output = A == B ? A : 0;

            SetOutputValue(output);
            PassOutputToNextNodes();
        }
    }
}
