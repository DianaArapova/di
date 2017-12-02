using System.Collections.Generic;

namespace TagsCloudVisualization.TagReader.TagFilter
{
	public class TagNotBoringFilter : ITagFilter
	{
		private readonly List<string> boringWords = new List<string>();
		public TagNotBoringFilter(List<string> boringWords=null)
		{
			if (!(boringWords is null))
				this.boringWords = boringWords;
		}
		public bool IsSuitableWorld(string word)
		{	
			return !boringWords.Contains(word) && word.Length > 3;
		}
	}
}