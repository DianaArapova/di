using System.Drawing;

namespace TagsCloudVisualization
{
	public class Config
	{
		public Brush[] TagColor { get; }
		public Size ImageSize { get; }
		public Point Center { get; }
		public string TagFontName { get; }
		public int WordsCount { get; }
		public bool Noun { get; }
		public bool Adj { get; }
		public bool Verb { get; }
		public Config(Brush[] tagColor, Size imageSize, Point center, 
			string tagFontName, int wordsCount, bool noun, bool adj, bool verb)
		{
			TagColor = tagColor;
			ImageSize = imageSize;
			Center = center;
			TagFontName = tagFontName;
			WordsCount = wordsCount;
			Noun = noun;
			Adj = adj;
			Verb = verb;
		}
	}
}