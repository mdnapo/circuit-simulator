using Parser.Library;

namespace Parser.States
{
	public class ParseEdgeState : KeyValueState, IParserState
	{
		public void Parse(IParserContext context)
		{
			context.State = new CommentState();
			context.State.Parse(context);

			while (context.HasLines)
			{
				context.AddEdge(
					GetKey(context.CurrentLine),
					GetValue(context.CurrentLine).Split(',')
				);
				context.NextLine();
			}
		}
	}
}
