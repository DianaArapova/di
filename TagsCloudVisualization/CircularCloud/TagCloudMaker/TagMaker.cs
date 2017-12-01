using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TagsCloudVisualization.CircularCloud.CloudLayouter;

namespace TagsCloudVisualization.CircularCloud.TagCloudMaker
{
	public class TagMaker : ITagMaker
	{
		private readonly ICircularCloudLayouter cloudMaker;
		private readonly Size imageSize;


		public TagMaker(ICircularCloudLayouter cloudMaker, Size imageSize)
		{
			this.cloudMaker = cloudMaker;
			this.imageSize = imageSize;
		}

		public Dictionary<string, Rectangle> MakeCloud(Dictionary<string, int> tagsList)
		{
			return tagsList
				.ToDictionary(tag => tag.Key,
					tag =>
					{
						var rectangleSize = new Size(tag.Key.Length * tag.Value * 15, 
							tag.Value * 30);
						return cloudMaker.PutNextRectangle(rectangleSize);
					});
		}
	}
}