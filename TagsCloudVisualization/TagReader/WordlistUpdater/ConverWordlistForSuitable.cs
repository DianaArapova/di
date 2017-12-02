using System.Collections.Generic;
using System.Linq;
using TagsCloudVisualization.TagReader.TransformWords;

namespace TagsCloudVisualization.TagReader.WordlistUpdater
{
	public class ConverWordlistForSuitable : IWordListUpdater
	{
		private readonly List<ITranfrormWord> tagFilter;
		public ConverWordlistForSuitable(List<ITranfrormWord> tagFilter)
		{
			this.tagFilter = tagFilter;
		}
		public IEnumerable<string> UpdateWordList(IEnumerable<string> wordlist)
		{
			return tagFilter.Aggregate(wordlist, 
				(current, tranfrorm) => tranfrorm.Transform(current));
		}
	}
}