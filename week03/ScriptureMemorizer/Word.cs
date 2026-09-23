using System;

public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        if (!_isHidden)
        {
            return _text;
        }

        char[] letters = _text.ToCharArray();
        for (int i = 0; i < letters.Length; i++)
        {
            
            if (char.IsLetterOrDigit(letters[i]))
            {
                letters[i] = '_';
            }
        }

        return new string(letters);
    }
}