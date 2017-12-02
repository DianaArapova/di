using System.Collections.Generic;
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
			var goodForWordlist = wordlist;
			foreach (var tranfrorm in tagFilter)
			{
				goodForWordlist = tranfrorm.Transform(goodForWordlist);
			}
			return goodForWordlist;
		}
	}
}