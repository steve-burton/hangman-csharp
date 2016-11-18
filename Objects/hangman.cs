using System.Collections.Generic;

namespace HangmanGame.Objects
{
  public class Hangman
  {
    private string _word;
    private List<string> _hiddenWord = new List<string> {};
    private string _guess;
    private int _id;
    private bool _gameOver = false;
    private static List<Hangman> _allGames = new List<Hangman> {};
    private List<string> _incorrectGuesses = new List<string> {};
    private List<string> _remainingLetters = new List<string> {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};

    public Hangman(string word)
    {
      _word = word;
      _allGames.Add(this);
      _id = _allGames.Count;
      for (int count = 0; count < _word.Length; count++)
      {
        _hiddenWord.Add("_");
      }
    }

    public static Hangman FindGame(int searchID)
    {
      return _allGames[searchID-1];
    }

    public List<string> GetIncorrectGuesses()
    {
      return _incorrectGuesses;
    }

    public List<string> GetRemainingLetters()
    {
      return _remainingLetters;
    }

    public string GetGuess()
    {
      return _guess;
    }

    public bool GetGameOver()
    {
      return _gameOver;
    }

    public int GetAmountIncorrectGuesses()
    {
      return _incorrectGuesses.Count;
    }

    public int GetID()
    {
      return _id;
    }

    public List<string> GetRevealedLetters()
    {
      return _hiddenWord;
    }

    public void GuessLetter(string letter)
    {
      bool correctGuess = false;
      for (int index = 0; index < _word.Length; index++)
      {
        if (letter == _word[index].ToString())
        {
          _guess = "You guessed correctly!";
          correctGuess = true;
          _hiddenWord[index] = letter;
        }
      }
      if (!correctGuess && !(_incorrectGuesses.Contains(letter)))
      {
        _guess = "You guessed incorrectly!";
        _incorrectGuesses.Add(letter);
      }
      _remainingLetters.Remove(letter);
      if (!(_hiddenWord.Contains("_")))
      {
        _gameOver = true;
        _guess = "You Win!";
      }
      if (_incorrectGuesses.Count > 5)
      {
        _gameOver = true;
        _guess = "You Lose!";
      }
    }
  }
}
