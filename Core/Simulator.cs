using Core.Output;
using Core.Models.V2;

namespace Core
{
	public class Simulator
	{
		public ITextOutput Output { get; set; }

		private Circuit _circuit;
		public Circuit Circuit
		{
			get { return _circuit; }
			set
			{
				_circuit = value;
				_circuit.SetOutput(Output);
			}
		}

		public Simulator()
		{
			_circuit = new Circuit();
			Output = new TextOutput();
		}

		public void Run()
		{
			_circuit.Reset();
			Output.Reset();
			_circuit.Process();
		}

        public string IsCircuitValid()
        {
            foreach (var output in _circuit.Outputs)
            {
                if (!output.Processed)
                {
                    return $"Output {output.Key} has not been reached, invalid Circuit!";
                }
            }

            foreach ( var op in _circuit.Operators)
            {
                if (op.ProcessedMoreThanOnce)
                {
                    return $"Operator {op.Key} has been tried to process more than once, infinite loop makes an invalid circuit!";
                }
                if (!op.Processed || op.Outputs.Count == 0)
                {
                    return $"Operator {op.Key} has not been processed, invalid Circuit!";
                }
            }

            return "";
        }
	}
}
