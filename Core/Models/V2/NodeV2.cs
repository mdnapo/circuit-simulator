using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Contracts;

namespace Core.Models.V2
{
	public abstract class NodeV2
	{
		public string Key { get; private set; }
		public bool Processed { get; set; }
		public ICollection<NodeV2> Inputs { get; set; }
		public ICollection<NodeV2> Outputs { get; set; }
		public int Value { get; set; }

		private ISimulationContext _context;

		public NodeV2(string key)
		{
			Key = key;
			Processed = false;
			Inputs = new List<NodeV2>();
			Outputs = new List<NodeV2>();
		}

		public void AddInputNode(NodeV2 node)
		{
			Inputs.Add(node);
		}

		public void AddOutputNode(NodeV2 node)
		{
			Outputs.Add(node);
		}

		public void SetSimulationContext(ISimulationContext context)
		{
			_context = context;
		}

		public bool CanProcess()
		{
			int processed = 0;

			foreach (NodeV2 node in Inputs)
			{
				if (node.Processed)
				{
					processed++;
				}
			}

			return processed == Inputs.Count;
		}

		public virtual void Process(NodeV2 triggerSource)
		{
			if (Processed)
			{
				throw new Exception("There is an inifinite loop.");
			}

			Processed = true;
		}

		private string ToProcessingResult(NodeV2 triggerSource)
		{
			return this is OutputNode ?
				triggerSource.Key + " -> " + triggerSource.Value + " -> " + Key + " -> " + triggerSource.Value :
				triggerSource.Key + " -> " + triggerSource.Value + " -> " + Key;
		}

		protected virtual void ProcessInput(NodeV2 triggerSource)
		{
			_context.AddProcessingResult(ToProcessingResult(triggerSource));
			if (CanProcess())
			{
				Process(triggerSource);
			}
		}

		protected void TriggerOutputs()
		{
			foreach (NodeV2 output in Outputs)
			{
				output.ProcessInput(this);
			}
		}
	}
}
