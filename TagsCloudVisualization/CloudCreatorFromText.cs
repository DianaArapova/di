using System.Drawing;
using TagsCloudVisualization.CircularCloud.TagCloudMaker;
using TagsCloudVisualization.CloudDrawer;
using TagsCloudVisualization.TagReader.PropertyForWordlist;
using TagsCloudVisualization.TagReader.TagReader;
using TagsCloudVisualization.TagReader.TextParser;
using TagsCloudVisualization.TagReader.WordlistUpdater;

namespace TagsCloudVisualization
{
	public class CloudCreatorFromText
	{
		private readonly ICloudDrawer cloudDrawer;
		private readonly ITagMaker tagMaker;
		private readonly IWordListUpdater wordListUpdater;
		private readonly IParser parser;
		private readonly IPropertyForWordlist getterFrequancy;
		private readonly ITagReader tagReader;
		private readonly ILogger logger;

		public CloudCreatorFromText(ICloudDrawer cloudDrawer, ITagMaker tagMaker, 
			IParser parser, IPropertyForWordlist getterFrequancy,
			IWordListUpdater wordListUpdater, ITagReader tagReader, ILogger logger)
		{
			this.cloudDrawer = cloudDrawer;
			this.getterFrequancy = getterFrequancy;
			this.parser = parser;
			this.tagMaker = tagMaker;
			this.wordListUpdater = wordListUpdater;
			this.tagReader = tagReader;
			this.logger = logger;
		}

		public void FromTextToImg(string inputPath, string imagePath, Size imageSize)
		{
			var textResult = tagReader.Read(inputPath);
			if (!textResult.IsSuccess)
				logger.LogError(textResult.Error);
			var englishWords = parser.Parse(textResult.Value);
			var goodEnglishWords = wordListUpdater.UpdateWordList(englishWords);
			var tagsList = getterFrequancy.GetProperty(goodEnglishWords);
			var tagsRectanglesDict = tagMaker.MakeCloud(tagsList, imageSize);
			var bitmapResult = cloudDrawer.Draw(tagsRectanglesDict);
			if (!bitmapResult.IsSuccess)
				logger.LogError(bitmapResult.Error);
			bitmapResult.Value.Save(imagePath);
		}
	}
}