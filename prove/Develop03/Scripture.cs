public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();
    private List<Word> _visibleWords = new List<Word>();

    public Scripture(Reference reference, string scriptureText)
    {
        _reference = reference;

        string[] parts = scriptureText.Split(" ");
        foreach (string word in parts)
        {
            _words.Add(new Word(word));
        }
    }

    public string GetRenderedText()
    {
        string scriptureBody = "";

        foreach (Word scriptureWord in _words)
        {
            scriptureBody += scriptureWord.GetRenderedText() + " ";
        }

        return $"{_reference.GetReference()} {scriptureBody}";
    }

    public void HideWords()
    {
        _visibleWords.Clear();

        foreach (Word word in _words)
        {
            if (word.Show())
            {
                _visibleWords.Add(word);
            }
        }

        Random random = new Random();
        int countToHide = random.Next(1, 4);

        if (countToHide > _visibleWords.Count)
        {
            countToHide = _visibleWords.Count;
        }

        for (int i = 0; i < countToHide; i++)
        {
            int index = random.Next(_visibleWords.Count);
            _visibleWords[index].Hide();
            _visibleWords.RemoveAt(index);
        }
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.isHidden())
            {
                return false;
            }
        }
        return true;
    }
}