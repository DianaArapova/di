using System;

namespace TagsCloudVisualization
{
	public class Logger : ILogger
	{
		public void LogError(string error)
		{
			Console.WriteLine(error);
			Console.WriteLine("\nPress ESC to exit");
			while (Console.ReadKey(true).Key != ConsoleKey.Escape)
			{
			}
			Environment.Exit(1);
		}
	}
}