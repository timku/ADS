using System;
using System.Collections.Generic;
using System.Text;

namespace ADSopdr3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Out.WriteLine("Welcome to ADS opdr3");
            CreateSom();

            while (true) // Loop indefinitely
            {
                Console.WriteLine("Waiting for user input..."); // Prompt
                Console.Write(": "); // Prompt
                string input = Console.ReadLine().Trim(); // Get string from user
                if (input == "exit" || input == "e") // Check string
                {
                    break;
                }
                else if (input == "skip" || input == "s")
                {
                    Console.Out.WriteLine("Skip question");
                    CreateSom();
                    continue;
                }
                else if (input == "eyeofra")
                {
                    debugmode = !debugmode;//toggle debug mode
                    Console.Out.WriteLine("????????????????????????");
                    CreateSom();
                    continue;
                }
                if (input.Length == (numbers.Length + operators.Length))
                {
                    Infix infix = new Infix(input);
                    String output = infix.toPostfix(); // do the translation
                    if (infix.calculate() == answer)
                    {
                        Console.Out.WriteLine("Given answer is CORRECT");
                        CreateSom();
                    }
                    else
                    {
                        Console.Out.WriteLine("Given answer is INCORRECT");
                    }
                }
            }
        }
        static bool debugmode = false;
        static int[] numbers;
        static char[] operators;
        static double answer=0;
        static void CreateSom()
        {
            Console.WriteLine("-------------------- (options: skip, exit)");
            numbers = new int[] { RandomNumber(1, 9), RandomNumber(1, 9), RandomNumber(1, 9), RandomNumber(1, 9) };
            operators = new char[] { '*', '+', '-' };
            operators = Shuffle(operators); // Randomize the order
            string mathexp = numbers[0] + "" + operators[0] + "" + numbers[1] + "" + operators[1] + "" + numbers[2] + operators[2] + "" + numbers[3];
            Infix infix = new Infix(mathexp);
            String postfix = infix.toPostfix(); // do the translation
            answer = infix.calculate(); // calculate the answer

            if (debugmode)
            {
                Console.WriteLine("Som: " + mathexp + " = " + answer + "     postfix(" + postfix + ")");
            }
            
            //sort the arrays
            Array.Sort(numbers);
            Array.Sort(operators);

            Console.WriteLine("Numbers: " + numbers[0] + " " + numbers[1] + " " + numbers[2] + " " + numbers[3]+"\r\n"+
            "Operators: " + operators[0] + " " + operators[1] + " " + operators[2] + "\r\n"+
            "Answer: " + answer);
        }
        private static Random random = new Random();
        public static int RandomNumber(int min, int max)
        {
            return random.Next(min, max);
        }
        public static char[] Shuffle(char[] input)
        {
            List<char> inputList = new List<char>(input);
            char[] output = new char[input.Length];
            int i = 0;
            while (inputList.Count > 0)
            {
                int index = random.Next(inputList.Count);
                output[i++] = inputList[index];
                inputList.RemoveAt(index);
            }
            return output;
        }
    }
}
