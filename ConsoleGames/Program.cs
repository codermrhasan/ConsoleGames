using System;
using NumberGuessing;

namespace ConsoleGames
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
            while (true)
            {
            Begin:
                int option;
                try
                {
                    Console.WriteLine("++++++++++++++++++ Hello Console Gamer! ++++++++++++++++++");
                    Console.WriteLine("Choose a game to play:\n" +
                        "1. Number Guessing Game");


                    option = Convert.ToInt32(Console.ReadLine());

                    if (option != 1)
                    {
                        throw new ArgumentOutOfRangeException("option", "choosen option must be in given options.");
                    }

                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("\nThere is an Error!\n" +
                        "Please choose the right option\n");
                    goto Begin;
                }
                catch (Exception)
                {
                    Console.WriteLine("\nThere is an Error!\n" +
                        "Please choose a valid number\n");
                    goto Begin;
                }

                if (option == 1)
                {
                    var choosenGame = new NumberGuessingGame();
                    choosenGame.Home();
                }
            }
        }
    }
}
