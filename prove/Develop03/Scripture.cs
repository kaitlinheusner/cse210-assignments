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
        Random random = new Random();
        int count = random.Next(1, 3);
        int hidden = 0;

        while (hidden < count)
        {
            int index = random.Next(_words.Count());

            if (!_words[index].isHidden())
            {
                _words[index].Hide();
                hidden++;
            }
        }

         if (IsCompletelyHidden())
        {
            return;
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