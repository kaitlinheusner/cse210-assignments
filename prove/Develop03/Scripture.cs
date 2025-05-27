public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();

    public Scripture(Reference reference, string scriptureText)
    {
        _reference = reference;

        string[] words = scriptureText.Split(" ");
        foreach (string wordText in words)
        {
            _words.Add(new Word(wordText));
        }
    }

    public string GetRenderedText()
    {
        string scriptureBody = "";

        foreach (Word word in _words)
        {
            scriptureBody += word.GetRenderedText() + " ";
        }

        return $"{_reference.GetReference()} {scriptureBody}";
    }

    public void HideWords()
    {
        Random randomWord = new Random();
        bool wordHidden = false;

        while (!wordHidden)
        {
            int index = randomWord.Next(_words.Count());

            if (!_words[index].isHidden())
            {
                _words[index].Hide();
                wordHidden = true;
            }
            
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