using System.Collections.Generic;

namespace TagsCloudVisualization.TagReader.TagFilter
{
	public class TagNotBoringFilter : ITagFilter
	{
		private readonly List<string> boringWords;
		public TagNotBoringFilter(List<string> boringWords)
		{
			this.boringWords = boringWords;
		}
		public bool IsSuitableWorld(string word)
		{
			return !boringWords.Contains(word) && word.Length > 3;
		}
	}
}