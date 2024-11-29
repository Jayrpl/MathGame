using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingProject
{
    public class MathGameLogic
    {
        public List<string> previousGames { get; set; } = new List<string>();

        public void BuildMenu()
        {
            Console.WriteLine("Please select an operation you would like to perform.");
            Console.WriteLine("1 - Addition");
            Console.WriteLine("2 - Subtraction");
            Console.WriteLine("3 - Multiplication");
            Console.WriteLine("4 - Division");
            Console.WriteLine("5 - Show History");
            Console.WriteLine("6 - Select Difficulty");
            Console.WriteLine("7 - Exit");
        }

        public int MathOperation(int firstNumber, int secondNumber, char operation)
        {
            switch (operation)
            {
                case '1':
                    {
                        previousGames.Add($"{firstNumber} + {secondNumber} = {firstNumber + secondNumber}");
                        return firstNumber + secondNumber;
                        break;
                    }
                case '2':
                    {
                        previousGames.Add($"{firstNumber} - {secondNumber} = {firstNumber - secondNumber}");
                        return firstNumber - secondNumber;
                        break;
                    }
                case '3':
                    {
                        previousGames.Add($"{firstNumber} x {secondNumber} = {firstNumber * secondNumber}");
                        return firstNumber * secondNumber;
                    }
                case '4':
                    while (firstNumber < 0 || firstNumber > 100)
                    {
                        try
                        {
                            Console.WriteLine("Please enter a number between 1 and 100");
                            firstNumber = Convert.ToInt32(Console.ReadLiine());
                        }
                }
            }
        }
    }
}
}