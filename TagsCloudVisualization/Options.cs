using CommandLine;
using CommandLine.Text;

namespace TagsCloudVisualization
{
	public class Options
	{
		[Option('i', "input", Required = true, HelpText = "input file")]
		public string InputFile { get; set; }

		[Option('o', "output", Required = true, HelpText = "output file")]
		public string OutputFile { get; set; }

		[Option('w', "width", DefaultValue = 1000, HelpText = "width")]
		public int Width { get; set; }

		[Option('h', "height", DefaultValue = 1000, HelpText = "height")]
		public int Height { get; set; }

		[Option('c', "count", DefaultValue = 100, HelpText = "count of word in cloud")]
		public int Count { get; set; }

		[Option('f', "Font", DefaultValue = "Tahoma", HelpText = "Font Name")]
		public string Font { get; set; }

		[HelpOption]
		public string GetUsage()
		{
			return HelpText.AutoBuild(this);
		}
	}
}