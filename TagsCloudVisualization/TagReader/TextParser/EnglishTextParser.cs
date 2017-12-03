using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using TagsCloudVisualization.TagReader.TagReader;

namespace TagsCloudVisualization.TagReader.TextParser
{
	public class EnglishTextParser : IParser
	{
		public IEnumerable<string> GetWordsFromLine(string line)
		{
			var regexForEnglishWord = new Regex(@"[A-Za-z']*");
			foreach (Match match in regexForEnglishWord.Matches(line))
				yield return match.Value;
		}

		public IEnumerable<string> Parse(IEnumerable<string> text)
		{
			foreach (var line in text)
			{
				foreach (var word in GetWordsFromLine(line))
				{
					yield return word;
				}
			}
		}
	}
}