using System.Collections.Generic;
using System.Linq;
using TagsCloudVisualization.TagReader.IdentifyPatrOfSpeech;

namespace TagsCloudVisualization.TagReader.TransformWords
{
	public class TransformForPOS : ITranfrormWord
	{
		private readonly Dictionary<string, bool> isNeedPOS;
		private readonly IDetermPOS determPos;
		private readonly ILogger logger;
		public TransformForPOS(Config config, IDetermPOS determPos, ILogger logger)
		{
			isNeedPOS = new Dictionary<string, bool>
			{
				{"N", config.Noun}, {"V", config.Verb}, {"J", config.Adj}
			};
			this.determPos = determPos;
			this.logger = logger;
		}

		private bool IsGoodPOS(string word)
		{
			var pos = determPos.GetPartOfSpeech(word);
			if (pos.IsSuccess)
				return isNeedPOS.ContainsKey(pos.Value) && isNeedPOS[pos.Value];
			logger.LogError(pos.Error);
			return false;
		}

		public IEnumerable<string> Transform(IEnumerable<string> wordlist)
		{
			return wordlist.Where(IsGoodPOS);
		}
	}
}