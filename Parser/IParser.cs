namespace Parser
{
	public interface IParser
	{
		ICircuitDescription Parse(string file = null);
	}
}
