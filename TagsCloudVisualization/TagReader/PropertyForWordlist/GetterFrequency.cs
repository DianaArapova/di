using System.Collections.Generic;
using System.Linq;
using TagsCloudVisualization.TagReader.TagFilter;

namespace TagsCloudVisualization.TagReader.PropertyForWordlist
{
	public class GetterFrequency : IGetterIntegerProperty
	{
		private readonly int wordsCount;
		private readonly ITagFilter tagFilter;
		public GetterFrequency(ITagFilter tagFilter, int wordsCount = int.MaxValue)
		{
			this.wordsCount = wordsCount;
			this.tagFilter = tagFilter;
		}
		public Dictionary<string, int> GetProperty(IEnumerable<string> wordlist)
		{
			return wordlist.Where(word => tagFilter.IsSuitableWorld(word))
				.Select(word => word.ToLower())
				.GroupBy(word => word)
				.OrderByDescending(wordList => wordList.Count())
				.Take(wordsCount)
				.ToDictionary(word => word.Key, wordList => wordList.Count());
		}
	}
}