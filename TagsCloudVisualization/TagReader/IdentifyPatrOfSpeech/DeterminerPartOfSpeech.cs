using System;
using System.IO;
using SharpNL.POSTag;

namespace TagsCloudVisualization.TagReader.IdentifyPatrOfSpeech
{
	public class DeterminerPartOfSpeech : IDetermPOS
	{
		private const string fileName = "en-pos-maxent.bin";
		private readonly Result<POSTaggerME> posTaggerResult;

		private POSModel CreatePosModel()
		{
			using (var modelFile = new FileStream(fileName, FileMode.Open))
				return new POSModel(modelFile);
		}

		public DeterminerPartOfSpeech()
		{
			var posModel = Result.Of(CreatePosModel);
			if (posModel.IsSuccess)
			{
				posTaggerResult = Result.Ok(new POSTaggerME(posModel.Value));
				return;
			}
			posTaggerResult = Result.Fail<POSTaggerME>("File with setting for POS library " +
			                                           $"{fileName} doesn't exist");
		}

		public Result<string> GetPartOfSpeech(string word)
		{
			if (!posTaggerResult.IsSuccess)
				return Result.Fail<string>(posTaggerResult.Error);
			return Result.Ok(posTaggerResult.Value.Tag(new[] {word})[0][0].ToString());
		}
	}
}