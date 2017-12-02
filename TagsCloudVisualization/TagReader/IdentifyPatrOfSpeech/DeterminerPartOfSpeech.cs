using System.IO;
using SharpNL.POSTag;

namespace TagsCloudVisualization.TagReader.IdentifyPatrOfSpeech
{
	public class DeterminerPartOfSpeech : IDetermPOS
	{
		private readonly POSTaggerME posTagger;

		public DeterminerPartOfSpeech()
		{
			POSModel posModel;
			using (var modelFile = new FileStream("en-pos-maxent.bin", FileMode.Open))
				posModel = new POSModel(modelFile);
			posTagger = new POSTaggerME(posModel);
		}

		public string GetPartOfSpeech(string word)
		{
			return posTagger.Tag(new[] {word})[0][0].ToString();
		}
	}
}