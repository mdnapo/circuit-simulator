using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Output
{
	public interface ITextOutput
	{
		string Get { get; }
		void Add(string output);
		void Reset();
	}
}
