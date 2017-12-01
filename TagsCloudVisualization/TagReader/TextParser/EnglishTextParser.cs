using System.Collections.Generic;
using System.IO;

namespace TagsCloudVisualization.TagReader.TextParser
{
	public class EnglishTextParser : IParser
	{
		private readonly ITagReader tagReader;
		public EnglishTextParser(ITagReader tagReader)
		{
			this.tagReader = tagReader;
		}

		public IEnumerable<string> GetWordsFromLine(string line)
		{
			yield return line;
		}
		public IEnumerable<string> Parse(string path)
		{
			foreach (var line in tagReader.Read(path))
			{
				foreach (var word in GetWordsFromLine(line))
				{
					yield return word;
				}
			}
		}
	}
}