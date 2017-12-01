using System.Drawing;
using Autofac;
using CommandLine;
using TagsCloudVisualization.CircularCloud.CloudLayouter;
using TagsCloudVisualization.CircularCloud.RectanglePlacer;
using TagsCloudVisualization.CircularCloud.TagCloudMaker;
using TagsCloudVisualization.CloudDrawer;
using TagsCloudVisualization.TagReader.PropertyForWordlist;
using TagsCloudVisualization.TagReader.TagFilter;
using TagsCloudVisualization.TagReader.TagReader;
using TagsCloudVisualization.TagReader.TextParser;

namespace TagsCloudVisualization
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var options = new Options();
			if (!Parser.Default.ParseArguments(args, options))
				return;

			var cloudCenter = new Point(500, 500);

			var container = new ContainerBuilder();

			container.RegisterType<CircularCloudLayouter>()
				.As<ICircularCloudLayouter>()
				.WithParameter("center", cloudCenter);
			container.RegisterType<DefaultRectanglePlacer>()
				.As<IRectanglePlacer>()
				.WithParameter("center", cloudCenter)
				.SingleInstance();
			container.RegisterType<TagMaker>()
				.As<ITagMaker>()
				.WithParameter("imageSize", new Size(options.Width, options.Height));
			container.RegisterType<CloudDrawer.CloudDrawer>()
				.As<ICloudDrawer>()
				.WithParameter("tagColor", Brushes.Black)
				.WithParameter("tagFontName", options.Font)
				.WithParameter("imageSize", new Size(options.Width, options.Height));
			container.RegisterType<GetterFrequency>()
				.As<IGetterIntegerProperty>()
				.WithParameter("wordsCount", options.Count);
			container.RegisterType<TagNotBoringFilter>()
				.As<ITagFilter>();
			container.RegisterType<TagReaderFromTextFile>()
				.As<ITagReader>();
			container.RegisterType<EnglishTextParser>()
				.As<IParser>();
			container.RegisterType<CloudCreatorFromText>().AsSelf();
			var build = container.Build();
			var cloudtagDrawer = build.Resolve<CloudCreatorFromText>();
			cloudtagDrawer.FromTextToImg(options.InputFile, options.OutputFile);
		}
	}
}
