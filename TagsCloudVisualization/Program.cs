using System;
using System.Drawing;
using Autofac;
using Autofac.Core;
using CommandLine;
using TagsCloudVisualization.CircularCloud.CloudLayouter;
using TagsCloudVisualization.CircularCloud.RectanglePlacer;

namespace TagsCloudVisualization
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var options = new Options();
			if (!Parser.Default.ParseArguments(args, options))
				return;

			var imageSize = new Size(options.Width, options.Height);
			var container = new ContainerBuilder();
			var center = new Point(imageSize.Width / 2, imageSize.Height / 2);
			var brush = new[] {Brushes.Blue, Brushes.Black, Brushes.Red};
			container.Register(_ => new Config(brush, imageSize, center, 
				options.Font, options.Count, options.Noun, options.Adjective, options.Verb))
			.SingleInstance();

			container.RegisterAssemblyTypes(typeof(Program).Assembly)
				.AsImplementedInterfaces().SingleInstance();

			container
				.RegisterType<CloudCreatorFromText>()
				.AsSelf();
			var build = container.Build();
			build.Resolve<Func<ICircularCloudLayouter>>();
			var cloudtagDrawer = build.Resolve<CloudCreatorFromText>();
			cloudtagDrawer.FromTextToImg(options.InputFile, options.OutputFile, imageSize);
		}
	}
}
