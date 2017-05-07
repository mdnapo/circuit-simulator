using System;
using System.IO;

namespace Parser.Library
{
	internal class FileReader
	{
		public static string[] ReadFile(string file = null)
		{
			return File.ReadAllLines(file ?? PathFromDesktop("/circuit.txt"));
		}

		private static string PathFromDesktop(string path)
		{
			return Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + path;
		}
	}
}
