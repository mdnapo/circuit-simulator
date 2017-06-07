using System.Collections.Generic;

namespace Core.Output
{
	public class TextOutput : ITextOutput
	{
		private List<string> _output;
		public string Get { get { return GetOutput(); } }


		public TextOutput()
		{
			_output = new List<string>();
		}

		public void Add(string output)
		{
			_output.Add(output);
		}

		public void Reset()
		{
			_output = new List<string>();
		}

		private string GetOutput()
		{
			string output = "";

			foreach (string line in _output)
				output += $"{line}\r\n";

			return output;
		}
	}
}
