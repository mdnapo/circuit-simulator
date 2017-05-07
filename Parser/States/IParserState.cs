using Parser.Library;

namespace Parser.States
{
	public interface IParserState
	{
		void Parse(IParserContext context);
	}
}
