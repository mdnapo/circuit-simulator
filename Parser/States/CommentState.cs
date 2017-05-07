using Parser.Library;

namespace Parser.States
{
	public class CommentState : IParserState
	{
		public void Parse(IParserContext context)
		{
			while (context.CurrentLine[0] == '#')
			{
				context.NextLine();
			}
		}
	}
}
