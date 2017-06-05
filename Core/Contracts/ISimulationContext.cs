using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Contracts
{
	public interface ISimulationContext
	{
		void AddProcessingResult(string result);
		string[] GetProcessingResults();
	}
}
