namespace TagsCloudVisualization.TagReader.WordlistUpdater
{
	public class ConvertorWordToLowercase : IWordUpdater
	{
		public string UpdateWord(string word)
		{
			return word.ToLower();
		}
	}
}