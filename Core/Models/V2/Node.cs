using System;
using System.Collections.Generic;
using Core.Contracts;

namespace Core.Models.V2
{
	public abstract class Node
	{
		public string Key { get; private set; }
		public string Type { get; private set; }
		public bool Processed { get; set; }
		public ICollection<Node> Inputs { get; set; }
		public ICollection<Node> Outputs { get; set; }
		public int Value { get; set; }

		private ITextView _context;

		public Node(string key, string type)
		{
			Key = key;
			Type = type;
			Processed = false;
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

		public void SetTextView(ITextView context)
		{
			_context = context;
		}

		public bool CanProcess()
		{
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

		public virtual void Process(Node triggerSource)
		{
			if (Processed)
			{
				throw new Exception("There is an inifinite loop.");
			}

			Processed = true;
		}

		private string ToProcessingResult(Node triggerSource)
		{
			return this is OutputNode ?
				$"{triggerSource.Type} ({triggerSource.Key}) -> {triggerSource.Value} -> {Type} ({Key}) -> {triggerSource.Value}" :
				$"{triggerSource.Type} ({triggerSource.Key}) -> {triggerSource.Value} -> {Type} ({Key})";
		}

		protected virtual void ProcessInput(Node triggerSource)
		{
			_context.AddProcessingResult(ToProcessingResult(triggerSource));
			if (CanProcess())
			{
				Process(triggerSource);
			}
		}

		protected void TriggerOutputs()
		{
			foreach (Node output in Outputs)
			{
				output.ProcessInput(this);
			}
		}
	}
}
