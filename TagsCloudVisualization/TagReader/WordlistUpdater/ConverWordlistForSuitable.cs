using System.Collections.Generic;
using System.Linq;
using TagsCloudVisualization.TagReader.TagFilter;

namespace TagsCloudVisualization.TagReader.WordlistUpdater
{
	public class ConverWordlistForSuitable : IWordListUpdater
	{
		private readonly ITagFilter tagFilter;
		private readonly IWordUpdater wordUpdater;
		public ConverWordlistForSuitable(ITagFilter tagFilter, IWordUpdater wordUpdater)
		{
			this.tagFilter = tagFilter;
			this.wordUpdater = wordUpdater;
		}
		public IEnumerable<string> UpdateWordList(IEnumerable<string> wordlist)
		{
			return wordlist.Where(word => tagFilter.IsSuitableWorld(word))
				.Select(word => wordUpdater.UpdateWord(word));
		}
	}
}