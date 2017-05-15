using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class OutputNode : Node
    {
        public OutputNode(string key) : base(key)
        {
        }

        public override void Process()
        {
            base.Process();

            SetOutputValue(Inputs.First());
        }
    }
}
