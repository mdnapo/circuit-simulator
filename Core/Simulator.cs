using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Contracts;
using Core.Models.V2;

namespace Core
{
    public class Simulator : ITextView
    {
		private List<String> _results;
		public Circuit Circuit { private get; set; }

		public Simulator()
		{
			_results = new List<string>();
		}

		public void AddProcessingResult(string result)
		{
			_results.Add(result);
		}

		public string[] GetProcessingResults()
		{
			return _results.ToArray();
		}
    }
}
