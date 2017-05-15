using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class InputNode : Node
    {
        public InputNode(string key, int value) : base(key)
        {
            SetOutputValue(value);
        }

        public override void Process()
        {
            base.Process();
            PassOutputToNextNodes();
        }
    }
}
