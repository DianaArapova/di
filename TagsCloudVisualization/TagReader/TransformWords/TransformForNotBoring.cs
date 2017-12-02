using System.Collections.Generic;
using System.Linq;

namespace TagsCloudVisualization.TagReader.TransformWords
{
	public class TransformForNotBoring : ITranfrormWord
	{
		private readonly List<string> boringWords = new List<string>();
		public TransformForNotBoring(List<string> boringWords=null)
		{
			if (!(boringWords is null))
				this.boringWords = boringWords;
		}
		public bool IsSuitableWorld(string word)
		{	
			return !boringWords.Contains(word) && word.Length > 3;
		}

		public IEnumerable<string> Transform(IEnumerable<string> wordlist)
		{
			return wordlist.Where(IsSuitableWorld);
		}
	}
}