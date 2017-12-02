using System.Drawing;

namespace TagsCloudVisualization
{
	public class Config
	{
		public Brush TagColor { get; }
		public Size ImageSize { get; }
		public Point Center { get; }
		public string TagFontName { get; }
		public int WordsCount { get; }

		public Config(Brush tagColor, Size imageSize, Point center, 
			string tagFontName, int wordsCount)
		{
			TagColor = tagColor;
			ImageSize = imageSize;
			Center = center;
			TagFontName = tagFontName;
			WordsCount = wordsCount;
		}
	}
}