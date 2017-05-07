using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Parser.States;
using Parser.Library;

namespace Parser
{
	public class FileParser : IParserContext, IParser
	{
		public IParserState State { get; set; }
		public bool HasLines { get { return _lines.Length > 0; } }
		public string CurrentLine
		{
			get { return Regex.Replace(_lines[0], @"\s", ""); }
		}
		public bool CurrentLineIsBlank { get { return _lines[0].Length <= 0; } }

		private string[] _lines;
		private IDictionary<string, string> _nodes;
		private IDictionary<string, string[]> _edges;


		public void NextLine()
		{
			_lines = _lines.Skip(1).ToArray();
		}

		public ICircuitDescription Parse(string file = null)
		{
			_lines = FileReader.ReadFile(file);
			_nodes = new Dictionary<string, string>();
			_edges = new Dictionary<string, string[]>();

			State = new ParseNodeState();
			State.Parse(this);
			return new CircuitDescription(_nodes, _edges);
		}

		public void AddNode(string key, string type)
		{
			_nodes.Add(key, type);
		}

		public void AddEdge(string source, string[] targets)
		{
			_edges.Add(source, targets);
		}
	}
}
