using System.Collections.Generic;

namespace TagsCloudVisualization.TagReader.WordlistUpdater
{
	public interface IWordListUpdater
	{
		IEnumerable<string> UpdateWordList(IEnumerable<string> wordlist);
	}
}