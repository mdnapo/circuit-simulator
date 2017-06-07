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
	}
}
