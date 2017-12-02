using System.Collections.Generic;
using System.Linq;

namespace TagsCloudVisualization.TagReader.TransformWords
{
	public class TransformForLowercase : ITranfrormWord
	{
		public string UpdateWord(string word)
		{
			return word.ToLower();
		}

		public IEnumerable<string> Transform(IEnumerable<string> wordlist)
		{
			return wordlist.Select(UpdateWord);
		}
	}
}