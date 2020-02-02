using System;

namespace NumberGuessing
{
    public class NumberGuessingGame
    {
        public void Home()
        {
            /// This Function is like Main Function of this game
         Beginning:
            Console.WriteLine("Choose an option");
            Console.WriteLine("1. Play \t 2. Rules");

            int option;

            try
            {
                option = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("\nThere is an Error!");
                Console.WriteLine("Please enter a valid number!\n");
                goto Beginning;
            }
            
            try
            {
                if ((option < 1) || (option > 2))
                {
                    throw new ArgumentOutOfRangeException("option", "option should be in the given range of options");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nThere is an Error!");
                Console.WriteLine("Please choose a number in between given options\n");
                goto Beginning;
            }
            

            /// Now we got a valid option 
            
            if (option is 2)
            {
                /// If user choose an option for game rules
                Console.WriteLine(
                    "\n+++++++++++++++++++++++ RULES +++++++++++++++++++++++\n" +
                    "First you have to set the 'Start' and 'End' numbers.\n" +
                    "Then you have to set how many times you want to\n" +
                    "make a guess. Then game machine will randomly select\n" +
                    "a number between your 'Start' and 'End' numbers.\n" +
                    "Then it will ask you to guess the number. For every\n" +
                    "response it will tell you \"You Win! Your guess is \n" +
                    "correct\" or \"Your guess is too high\" or \"Your \n" +
                    "guess is too low\" or \"You Lose! You can't make a \n" +
                    "right guess\". And remember, it will  ask you for\n" +
                    "making a guess exactly that times, which you set\n" +
                    "perviously. If you want to win, make a guess before \n" +
                    "finishing all the chances.\n" +
                    "\tAll The Best\n"
                    );
                goto Beginning;
            }
            else if (option is 1)
            {
                /// If user choose an option for play this game
                GamePlay.Game();
            }
        }
    }
}
