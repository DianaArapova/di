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

		public CloudCreatorFromText(ICloudDrawer cloudDrawer, ITagMaker tagMaker, 
			IParser parser, IPropertyForWordlist getterFrequancy,
			IWordListUpdater wordListUpdater, ITagReader tagReader)
		{
			this.cloudDrawer = cloudDrawer;
			this.getterFrequancy = getterFrequancy;
			this.parser = parser;
			this.tagMaker = tagMaker;
			this.wordListUpdater = wordListUpdater;
			this.tagReader = tagReader;
		}

		public void FromTextToImg(string inputPath, string imagePath, Size imageSize)
		{
			var text = tagReader.Read(inputPath);
			var englishWords = parser.Parse(text);
			var goodEnglishWords = wordListUpdater.UpdateWordList(englishWords);
			var tagsList = getterFrequancy.GetProperty(goodEnglishWords);
			var tagsRectanglesDict = tagMaker.MakeCloud(tagsList, imageSize);
			var bitmap = cloudDrawer.Draw(tagsRectanglesDict);
			bitmap.Save(imagePath);
		}
	}
}