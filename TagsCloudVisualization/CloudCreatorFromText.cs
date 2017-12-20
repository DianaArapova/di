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
			var bitmapResult = tagReader.Read(inputPath)
				.Then(parser.Parse)
				.Then(wordListUpdater.UpdateWordList)
				.Then(getterFrequancy.GetProperty)
				.Then(tagMaker.MakeCloud)
				.Then(cloudDrawer.Draw)
				.Catch(logger.LogError);
			bitmapResult.Value.Save(imagePath);
		}
	}
}