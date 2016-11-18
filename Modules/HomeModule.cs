using Nancy;
using System.Collections.Generic;
using HangmanGame.Objects;
using System;

namespace HangmanGame
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ =>
      {
        return View["/index.cshtml"];
      };
      Get["/two_player"] = _ =>
      {
        return View["two_player.cshtml"];
      };
      Post["/human_hangman"] = _ =>
      {
        string word = Request.Form["new-word"];
        Hangman newHangman = new Hangman(word.ToUpper());
        return View["hangman.cshtml", newHangman];
      };
      Get["/computer_hangman"] = _ =>
      {
        List<string> computerWords = new List<string> {"PROGRAMMING", "RABBIT", "HOUSE", "BARNYARD", "ELEPHANT", "LUMBERJACK"};
        Random picker = new Random();
        int pickerIndex = picker.Next(0, computerWords.Count - 1);
        Hangman newHangman = new Hangman(computerWords[pickerIndex]);
        return View["hangman.cshtml", newHangman];
      };
      Get["/hangman/{id}/{letter}"] = parameters =>
      {
        Hangman currentHangman = Hangman.FindGame(int.Parse(parameters.id));
        currentHangman.GuessLetter(parameters.letter);
        return View["hangman.cshtml", currentHangman];
      };
    }
  }
}
