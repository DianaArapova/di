using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using TagsCloudVisualization.CircularCloud.CloudLayouter;
using TagsCloudVisualization.CircularCloud.TagCloudMaker;

namespace TagsCloudVisualization.Test
{
	public class TagMaker_Should
	{
		private Mock<ICircularCloudLayouter> layouter;
		private Config config;

		private ITagMaker tagMaker;

		[SetUp]
		public void SetUp()
		{
			config = new Config(null, Size.Empty, Point.Empty, "Tahoma", 100, false, false, true);
			layouter = new Mock<ICircularCloudLayouter>();
			layouter
				.Setup(a => a
					.PutNextRectangle(It.IsAny<Size>()))
				.Returns<Size>(s=> new Rectangle(Point.Empty, s));
			tagMaker = new TagMaker(() => layouter.Object, config);
		}


		[Test]
		public void TagMaker_ShouldGetSizeInDescendingOrder()
		{
			var dict = new Dictionary<string, int> {{"asfe", 6}, { "ava", 2 }, { "sdfs", 1}};
			var dictRect = tagMaker.MakeCloud(dict, Size.Empty);
			dictRect.Select(rect => rect.Value.Height).Should().BeInDescendingOrder();
		}
	}
}