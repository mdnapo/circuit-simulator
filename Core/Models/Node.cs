using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public abstract class Node
    {
        private string _key;
        private int _outputValue;
        private int _totalNrOfInputs;
        private bool _isProcessed;
        public ICollection<int> Inputs { get; set; }
        public ICollection<Node> Outputs { get; set; }

        public Node(string key)
        {
            _totalNrOfInputs = 0;
            _key = key;
            Inputs = new List<int>();
            Outputs = new List<Node>();
        }

        public string GetKey()
        {
            return _key;
        }

        public int GetOutputValue()
        {
            return _outputValue;
        }

        public void SetOutputValue(int value)
        {
            _outputValue = value;
        }

        public void AddInputValue(int value)
        {
            Inputs.Add(value);
            if (CanProcess())
            {
                Process();
            }
        }

        public void AddInput()
        {
            _totalNrOfInputs++;
        }

        public void AddOutputNode(Node node)
        {
            Outputs.Add(node);
            node.AddInput();
        }

        public bool CanProcess()
        {
            return (Inputs.Count == _totalNrOfInputs && !_isProcessed);
        }

        private bool isProcessed()
        {
            return _isProcessed;
        }

        public void PassOutputToNextNodes()
        {
            foreach (var output in Outputs)
            {
                output.AddInputValue(_outputValue);
            }
        }
        
        public virtual void Process()
        {
            _isProcessed = true;
        }

        override public string ToString()
        {
            var strb = new StringBuilder();
            strb.Append($"#NODE \n");
            strb.Append($"\t key: {_key} \n");
            strb.Append($"\t value: {_outputValue} \n");
            strb.Append($"\t inputs: {_totalNrOfInputs} \n");

            strb.Append($"\t edges: ");
            foreach (var node in Outputs)
            {
                strb.Append($"{node.GetKey()}, ");
            }

            strb.Append($"\n \t processed: {_isProcessed} \n");

            return strb.ToString();
        }
    }
}
