using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TagsCloudVisualization.CircularCloud.CloudLayouter;

namespace TagsCloudVisualization.CircularCloud.TagCloudMaker
{
	public class TagMaker : ITagMaker
	{
		private readonly ICircularCloudLayouter cloudMaker;


		public TagMaker(ICircularCloudLayouter cloudMaker)
		{
			this.cloudMaker = cloudMaker;
		}

		public Dictionary<string, Rectangle> MakeCloud(Dictionary<string, int> tagsList, Size imageSize)
		{
			return tagsList
				.ToDictionary(tag => tag.Key,
					tag =>
					{
						var rectangleSize = new Size(tag.Key.Length * tag.Value * 10, 
							tag.Value * 20);
						return cloudMaker.PutNextRectangle(rectangleSize);
					});
		}
	}
}