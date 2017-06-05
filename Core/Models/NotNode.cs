using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class NotNode : Node
    {
        public NotNode(string key) : base(key)
        {
        }

        public override void Process()
        {
            base.Process();

            int output = Inputs.First() == 1 ? 0 : 1;

            SetOutputValue(output);
            PassOutputToNextNodes();
        }
    }
}
