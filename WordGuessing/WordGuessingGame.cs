using System;


namespace WordGuessing
{
    public class WordGuessingGame
    {
        public static void Home()
        {



        Begin:
            Console.WriteLine(@"\/\/ \/\/ \/\/ WORD GUESSING GAME \/\/ \/\/ \/\/");
            Console.WriteLine("1. Play \t2. Rules");
            int option;
            try
            {
                option = Convert.ToInt32(Console.ReadLine());
                if (option<1 || option > 2)
                {
                    throw new ArgumentOutOfRangeException("option", "option should be in the given range of options");
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Please choose a valid option");
                goto Begin;
            }
            catch (Exception)
            {
                Console.WriteLine("Please enter a valid number");
                goto Begin;
            }

            /// Now we got a valid option
            

            if (option == 2)
            {
                Console.WriteLine(
                    "++++++++++++++ RULES ++++++++++++++\n" +
                    "Computer will show you 10 random\n" +
                    "words and it will pick a word \n" +
                    "randomly among those words. What \n" +
                    "you have to do is, make a right guess\n" +
                    "of word which was picked by computer.\n" +
                    "You have 5 chances to guess.\n");
                goto Begin;
            }
            else if (option == 1)
            {
                FileOps.CreateGameFile();
                string[] wordList = FileOps.ReadGameFile();
                Random rand = new Random();
                int luckyWordsIndex = rand.Next(10);
                int guessedIndex;

                for(int chance = 0; chance<5; chance++)
                {
                Guess:
                    try
                    {
                        Console.WriteLine("Guess which word has computer guessed? Enter that index number.");
                        for (int i = 0; i < 10; i++)
                        {
                            Console.Write($"{i + 1}. {wordList[i]}  ");
                        }
                        Console.WriteLine();

                        guessedIndex = Convert.ToInt32(Console.ReadLine());
                        if (guessedIndex < 1 || guessedIndex > 10)
                        {
                            throw new ArgumentOutOfRangeException("guessedIndex", "Guessed index should be from 1 to 10.");

                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("Guessed Index should be from 1 to 10.");
                        goto Guess;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Enter a valid number only");
                        goto Guess;
                        throw;
                    }

                    if (guessedIndex - 1 == luckyWordsIndex)
                    {
                        Console.WriteLine(
                            $"################## YOU WIN ##################\n" +
                            $"Your guess '{wordList[guessedIndex - 1]}' is correct.\n");
                        return;
                    }
                    else if (guessedIndex - 1 < luckyWordsIndex)
                    {
                        Console.WriteLine($"Your guess '{wordList[guessedIndex - 1]}' is lower than correct word\n");
                    }
                    else if (guessedIndex - 1 > luckyWordsIndex)
                    {
                        Console.WriteLine($"Your guess '{wordList[guessedIndex - 1]}' is higher than correct word\n");
                    }
                }
                Console.WriteLine("!!!!!!!!!!!!!!!!! You Are Looser !!!!!!!!!!!!!!!!!\n");
            
            }

        }

    }
}
