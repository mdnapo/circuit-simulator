namespace Parser.States
{
	public abstract class KeyValueState
	{
		protected string GetKey(string line)
		{
			return line.Substring(0, line.IndexOf(':'));
		}

		protected string GetValue(string line)
		{
			int start = line.IndexOf(':') + 1;
			int end = line.IndexOf(';') - line.IndexOf(':') - 1;
			return line.Substring(start, end);
		}
	}
}
