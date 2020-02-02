using System;

namespace NumberGuessing
{
    class GamePlay
    {
        
        public static void Game()
        {
            /// This is the main game
        Beginning:
            int startNumber;
            int endNumber;
            int chances;
            
            try
            {
                Console.WriteLine("Choose a Start number");
                startNumber = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Choose a End number");
                endNumber = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("How many times you want to guess the number?");
                chances = Convert.ToInt32(Console.ReadLine());

                if (startNumber >= endNumber)
                {
                    throw new ArgumentException($"{startNumber} is not less than {endNumber}");
                }
            }
            catch(ArgumentException)
            {
                Console.WriteLine("\nThere is an Error!\n" +
                    "Start number must be less than End number.\n");
                goto Beginning;
            }
            catch (Exception)
            {
                Console.WriteLine("\nThere is an Error!\n" +
                    "Please choose a valid number\n");
                goto Beginning;
            }

            var rand = new Random();
            int randomNumber = rand.Next(startNumber, endNumber);

            for(int i = chances; i>0; i--)
            {
            Guess:
                int guessNumber;
                try
                {
                    Console.WriteLine("Make a guess");
                    guessNumber = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("\nThere is and Error!\n" +
                        "Please enter a valid number.\n");
                    goto Guess;
                }

                if(randomNumber == guessNumber)
                {
                    Console.WriteLine("\nYou Win! You make a Right guess.\n\n");
                    return;
                }
                else if(randomNumber > guessNumber)
                {
                    Console.WriteLine("\nYour guess is too Low.");
                }
                else if(randomNumber < guessNumber)
                {
                    Console.WriteLine("\nYour guess is too High");
                }
                Console.WriteLine($"You have only --> {i-1} <-- chance('s) left to make a right guess.\n");

            }
            Console.WriteLine("You Lose! You cann't make a right guess.\n");
        }
    }
}
