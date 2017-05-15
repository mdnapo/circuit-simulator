using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Circuit
    {
        public ICollection<InputNode> Inputs { get; set; }

        public ICollection<OutputNode> Outputs { get; set; }

        public Circuit()
        {
            Inputs = new List<InputNode>();
            Outputs = new List<OutputNode>();
        }

        public void Process()
        {
            foreach (var input in Inputs)
            {
                input.Process();
            }
        }
    }
}
