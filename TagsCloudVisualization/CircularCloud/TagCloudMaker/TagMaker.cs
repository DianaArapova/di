using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TagsCloudVisualization.CircularCloud.CloudLayouter;

namespace TagsCloudVisualization.CircularCloud.TagCloudMaker
{
	public class TagMaker : ITagMaker
	{
		private readonly Func<ICircularCloudLayouter> cloudMakerFunc;
		private readonly string font;
		private readonly Size imageSize;
		private int maxSize = 80;
		private int minSize = 20;

		public TagMaker(Func<ICircularCloudLayouter> cloudMaker, Config config)
		{
			cloudMakerFunc = cloudMaker;
			font = config.TagFontName;
			imageSize = config.ImageSize;
		}

		public Dictionary<string, Rectangle> MakeCloud(Dictionary<string, int> tagsList)
		{
			var cloudMaker = cloudMakerFunc();
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
					})
				.Where(tag => tag.Value.IsSuccess)
				.ToDictionary(tag => tag.Key, tag => tag.Value.Value);
		}
	}
}