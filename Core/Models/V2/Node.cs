using System;
using System.Collections.Generic;
using System.ComponentModel;
using Core.Output;

namespace Core.Models.V2
{
	public abstract class Node
	{
		public string Key { get; private set; }
		public string Type { get; private set; }
		public bool Processed { get; set; }

        public bool ProcessedMoreThanOnce { get; set; }
		public ICollection<Node> Inputs { get; set; }
		public ICollection<Node> Outputs { get; set; }

		private int _value;
		public int Value
		{
			get { return _value; }
			set { _value = SetValue(value); }
		}

		private ITextOutput _output;

		public Node(string key, string type)
		{
			Key = key;
			Type = type;
			Processed = false;
            ProcessedMoreThanOnce = false;
			Inputs = new List<Node>();
			Outputs = new List<Node>();
		}

		public void AddInputNode(Node node)
		{
			Inputs.Add(node);
		}

		public void AddOutputNode(Node node)
		{
			Outputs.Add(node);
		}

		public void SetTextOutput(ITextOutput output)
		{
			_output = output;
		}

		public bool CanProcess()
		{
            if (Processed)
            {
                return false;
            }

            int processed = 0;

			foreach (Node node in Inputs)
			{
				if (node.Processed)
				{
					processed++;
				}
			}

			return processed == Inputs.Count;
		}

		public virtual void Process()
		{
                Processed = true;	
		}

		private string ToTextOutput(Node triggerSource)
		{
			return this is OutputNode ?
				$"({triggerSource.Key}) -> {triggerSource.Value} -> {Type} ({Key}) -> {triggerSource.Value}" :
				$"({triggerSource.Key}) -> {triggerSource.Value} -> {Type} ({Key})";
		}

		protected virtual void ProcessInput(Node triggerSource)
		{
			_output.Add(ToTextOutput(triggerSource));
			if (CanProcess())
			{
				Process();
			}
		}

		protected void TriggerOutputs()
		{
			foreach (Node output in Outputs)
			{
				output.ProcessInput(this);
			}
		}

		protected int SetValue(int value)
		{
			return value == 0 ? 0 : 1;
		}
	}
}
