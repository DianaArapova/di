using TagsCloudVisualization.CircularCloud.TagCloudMaker;
using TagsCloudVisualization.CloudDrawer;
using TagsCloudVisualization.TagReader.PropertyForWordlist;
using TagsCloudVisualization.TagReader.TextParser;

namespace TagsCloudVisualization
{
	public class CloudCreatorFromText
	{
		private readonly ICloudDrawer cloudDrawer;
		private readonly ITagMaker tagMaker;
		private readonly IParser parser;
		private readonly IGetterIntegerProperty getterFrequancy;

		public CloudCreatorFromText(ICloudDrawer cloudDrawer, ITagMaker tagMaker, 
			IParser parser, IGetterIntegerProperty getterFrequancy)
		{
			this.cloudDrawer = cloudDrawer;
			this.getterFrequancy = getterFrequancy;
			this.parser = parser;
			this.tagMaker = tagMaker;
		}

		public void FromTextToImg(string inputPath, string imagePath)
		{
			var englishWords = parser.Parse(inputPath);
			var tagsList = getterFrequancy.GetProperty(englishWords);
			var tagsRectanglesDict = tagMaker.MakeCloud(tagsList);
			var bitmap = cloudDrawer.Draw(tagsRectanglesDict);
			bitmap.Save(imagePath);
		}
	}
}