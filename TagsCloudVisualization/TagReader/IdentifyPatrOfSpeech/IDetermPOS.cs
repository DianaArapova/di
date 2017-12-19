namespace TagsCloudVisualization.TagReader.IdentifyPatrOfSpeech
{
	public interface IDetermPOS
	{
		Result<string> GetPartOfSpeech(string word);
	}
}