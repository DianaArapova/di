using System.Drawing;
using System.Linq;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using TagsCloudVisualization.TagReader.IdentifyPatrOfSpeech;
using TagsCloudVisualization.TagReader.TransformWords;

namespace TagsCloudVisualization.Test
{
	public class TransformForPOS_Should
	{
		private Config config;
		private IDetermPOS determPos;
		private ITranfrormWord transformForPos;
		[SetUp]
		public void SetUp()
		{
			config = new Config(null, Size.Empty, Point.Empty, null, 100, false, false, true);
			var mockPos = new Mock<IDetermPOS>();
			var logger = new Mock<ILogger>();
			var goodWord = new[] { "grow", "die", "born" };
			var boringWord = new[] { "a", "the", "and" };

			foreach (var word in goodWord)
				mockPos.Setup(pt => pt.GetPartOfSpeech(word)).Returns("V");
			foreach (var word in boringWord)
				mockPos.Setup(pt => pt.GetPartOfSpeech(word)).Returns("P");
			determPos = mockPos.Object;
			transformForPos = new TransformForPOS(config, determPos, logger.Object);
		}

		[Test]
		public void TransformForPOS_GetsGoodWord_FromIEnumetableWithAllGoodWords()
		{
			var array = new[] {"grow", "die", "born"};
			transformForPos.Transform(array).Should().Equal(array);
		}

		[Test]
		public void TransformForPOS_GetsGoodWord_FromIEnumetableWithSomeBadWords()
		{
			var array = new[] { "grow", "die", "born" };
			var array1 = new[] {"grow", "a", "die", "born", "and"};
			transformForPos.Transform(array1).Should().Equal(array);
		}

		[Test]
		public void TransformForPOS_GetsGoodWord_FromIEnumetableWithAllBadWords()
		{
			var array = new[] { "a", "the", "and" };
			transformForPos.Transform(array).ToList().Should().BeEmpty();
		}
	}
}