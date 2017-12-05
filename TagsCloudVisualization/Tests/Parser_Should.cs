using System.Linq;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using TagsCloudVisualization.TagReader.TagReader;
using TagsCloudVisualization.TagReader.TextParser;

namespace TagsCloudVisualization.Tests
{
	public class Parser_Should
	{
		private IParser parser;
		private Mock<ITagReader> reader;
		[SetUp]
		public void SetUp()
		{
			reader = new Mock<ITagReader>();
			parser = new EnglishTextParser(reader.Object);
		}

		[Test]
		public void ParserShouldCallRearerWithTheSamePath()
		{
			var a = parser.Parse("text.txt").ToList();
			reader.Verify(r => r.Read("text.txt"), Times.Once());
		}

		[Test]
		public void Parser_ShouldRightChooseEnglishWords()
		{
			var s = "abacaba";
			reader.Setup(a => a.Read("1.txt")).Returns(s.Split('\n'));
			parser = new EnglishTextParser(reader.Object);
			parser.Parse("1.txt").Should().Equal(s);
		}

		[Test]
		public void Parser_ShouldRightChooseEnglishWordsInSentance()
		{
			var s = "abacaba wrwarf 245 2 a'a";
			reader.Setup(a => a.Read("1.txt")).Returns(s.Split('\n'));
			parser = new EnglishTextParser(reader.Object);
			parser.Parse("1.txt").Should().Equal("abacaba", "wrwarf", "a'a");
		}
	}
}