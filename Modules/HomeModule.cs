using Nancy;
using System.Collections.Generic;
using HangmanGame.Objects;

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
      Get["/human_hangman/{id}/{letter}"] = parameters =>
      {
        Hangman currentHangman = Hangman.FindGame(int.Parse(parameters.id));
        currentHangman.GuessLetter(parameters.letter);
        return View["hangman.cshtml", currentHangman];
      };
    }
  }
}
