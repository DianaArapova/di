using System.Collections.Generic;
using System.Drawing;
using Autofac;
using Autofac.Core;
using CommandLine;

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
			container.Register(_ => new Config(Brushes.Black, imageSize, 
				center, options.Font, options.Count)).SingleInstance();

			container.RegisterAssemblyTypes(typeof(Program).Assembly)
				.AsImplementedInterfaces()
				.SingleInstance();

			container
				.RegisterType<CloudCreatorFromText>()
				.AsSelf();
			var build = container.Build();

			var cloudtagDrawer = build.Resolve<CloudCreatorFromText>();
			cloudtagDrawer.FromTextToImg(options.InputFile, options.OutputFile, imageSize);
		}
	}
}
