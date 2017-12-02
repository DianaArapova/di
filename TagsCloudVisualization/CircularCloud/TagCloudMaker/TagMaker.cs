using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TagsCloudVisualization.CircularCloud.CloudLayouter;

namespace TagsCloudVisualization.CircularCloud.TagCloudMaker
{
	public class TagMaker : ITagMaker
	{
		private readonly ICircularCloudLayouter cloudMaker;
		private readonly string font;
		private int maxSize = 80;
		private int minSize = 20;

		public TagMaker(ICircularCloudLayouter cloudMaker, Config config)
		{
			this.cloudMaker = cloudMaker;
			font = config.TagFontName;
		}

		public Dictionary<string, Rectangle> MakeCloud(Dictionary<string, int> tagsList, Size imageSize)
		{
			return tagsList
				.ToDictionary(tag => tag.Key,
					tag =>
					{
						var tagSize = (int) ((double) tag.Value / tagsList.Values.Max() 
						* (maxSize - minSize) + minSize);
						var rectangleSize = TextRenderer.MeasureText(tag.Key,
							new Font(new FontFamily(this.font), tagSize,
							FontStyle.Regular, GraphicsUnit.Pixel));
						
						return cloudMaker.PutNextRectangle(rectangleSize);
					});
		}
	}
}