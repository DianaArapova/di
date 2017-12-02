using System.Collections.Generic;
using System.Linq;

namespace TagsCloudVisualization.TagReader.PropertyForWordlist
{
	public class Frequency : IPropertyForWordlist
	{
		private readonly int wordsCount;
		public Frequency(Config config)
		{
			wordsCount = config.WordsCount;
		}
		public Dictionary<string, int> GetProperty(IEnumerable<string> wordlist)
		{
			return wordlist
				.GroupBy(word => word)
				.OrderByDescending(wordList => wordList.Count())
				.Take(wordsCount)
				.ToDictionary(word => word.Key, wordList => wordList.Count());
		}
	}
}