using System;
using Parser.Library;

namespace Parser.States
{
	public class ParseNodeState : KeyValueState, IParserState
	{
		public void Parse(IParserContext context)
		{
			context.State = new CommentState();
			context.State.Parse(context);

			while (!context.CurrentLineIsBlank)
			{
				context.AddNode(
					GetKey(context.CurrentLine),
					GetValue(context.CurrentLine)
				);
				context.NextLine();
			}
			context.NextLine();

			context.State = new ParseEdgeState();
			context.State.Parse(context);
		}
	}
}
