using System.Collections.Generic;
using System.Linq;
using TagsCloudVisualization.TagReader.IdentifyPatrOfSpeech;

namespace TagsCloudVisualization.TagReader.TransformWords
{
	public class TransformForPOS : ITranfrormWord
	{
		private readonly Dictionary<string, bool> isNeedPOS;
		private readonly IDetermPOS determPos;
		public TransformForPOS(Config config, IDetermPOS determPos)
		{
			isNeedPOS = new Dictionary<string, bool>
			{
				{"N", config.Noun}, {"V", config.Verb}, {"J", config.Adj}
			};
			this.determPos = determPos;
		}

		private bool IsGoodPOS(string word)
		{
			var pos = determPos.GetPartOfSpeech(word);
			return isNeedPOS.ContainsKey(pos) && isNeedPOS[pos];
		}

		public IEnumerable<string> Transform(IEnumerable<string> wordlist)
		{
			return wordlist.Where(IsGoodPOS);
		}
	}
}