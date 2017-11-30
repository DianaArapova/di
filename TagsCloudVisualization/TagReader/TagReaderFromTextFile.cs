using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TagsCloudVisualization.TagReader
{
	public class TagReaderFromTextFile :ITagReader
	{
		public Dictionary<string, int> GetFrequency(IEnumerable<string> dict, int wordsCount)
		{
			return dict.Where(word => word.Length > 3)
				.Select(word => word.ToLower())
				.GroupBy(word => word)
				.OrderByDescending(wordList => wordList.Count())
				.Take(wordsCount)
				.ToDictionary(word => word.Key, wordList => wordList.Count());
		}

		public IEnumerable<string> Read(string path)
		{
			return File.ReadLines(path);
		}
	}
}