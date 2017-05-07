using Parser.States;

namespace Parser.Library
{
	public interface IParserContext
	{
		IParserState State { get; set; }
		bool HasLines { get; }
		bool CurrentLineIsBlank { get; }
		string CurrentLine { get; }
		void NextLine();
		void AddNode(string name, string type);
		void AddEdge(string source, string[] targets);
	}
}
