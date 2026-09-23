using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

     
        string[] splitWords = text.Split(' ');
        foreach (string wordText in splitWords)
        {
            _words.Add(new Word(wordText));
        }
    }

   
    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();

      
        List<int> unhiddenIndices = new List<int>();
        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].IsHidden())
            {
                unhiddenIndices.Add(i);
            }
        }

        int countToHide = Math.Min(numberToHide, unhiddenIndices.Count);
        for (int i = 0; i < countToHide; i++)
        {
            int randomIndex = random.Next(unhiddenIndices.Count);
            int wordIndexToHide = unhiddenIndices[randomIndex];

            _words[wordIndexToHide].Hide();
            unhiddenIndices.RemoveAt(randomIndex);
        }
    }

   
    public string GetDisplayText()
    {
        List<string> displayedWords = new List<string>();
        foreach (Word word in _words)
        {
            displayedWords.Add(word.GetDisplayText());
        }

        return $"{_reference.GetDisplayText()} - {string.Join(" ", displayedWords)}";
    }

    
    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}