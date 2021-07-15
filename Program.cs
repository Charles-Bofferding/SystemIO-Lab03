using System;
using System.IO;

namespace SystemIO_Lab03
{
    class Program
    {
        static void Main(string[] args)
        {

            //Challenge 1
            //Challenges written by me have more than just the method call to try and keep
            //Auto testing best practices going
            Console.WriteLine("Finding what three numbers multiplied together are:");
            Console.WriteLine("Please enter 3 numbers in a single line seperated by spaces and hit enter:");
            string input1 = Console.ReadLine();
            int response1 = ReturnSum(input1);

            //Challenge 2, put all the user inputs in he method
            int response2 = ReturnAverage();

            //Challenge 3
            Console.WriteLine("\nHere have a cool diamond design");
            PrintDesign();

            //Challenge 4
            int[] c4Arr = { 1, 4, 3, 6, 1, 1, 4, 4, 4, 4 };
            Console.WriteLine("\nFinding the number with the greatest frequency in the following array:");
            Console.WriteLine(c4Arr);
            Console.WriteLine("The most common cvalue is:");
            ChallengeFour(c4Arr);

            //Challenge 5
            int[] c5Arr = { 5, 7, 8, 2, 5, 90, 11, 1 };
            Console.WriteLine("\nFinding the largest number within the following array:");
            Console.WriteLine(c5Arr);
            Console.WriteLine("\nThe largest cvalue is:");
            Challenge5(c5Arr);

            //Challenge 6
            Console.WriteLine("\nNow to add a word onto a text file:");
            Console.WriteLine("Please enter a word and hit enter:");
            string wordIn = Console.ReadLine();
            string path = "../../../Test.txt";
            WriteWordToFile(wordIn, path);

            //Challenge 7
            Console.WriteLine("\nAnd now to look at the contents of that file:");
            ReadFileContents(path);

            //Challenge 8
            Console.WriteLine("\nAnd now to remove the first word of that file:");
            RemoveFirstWord(path);

            //Challenge 9
            Console.WriteLine("\nAnd finally to analyze a sentence:");
            ProcessSentence();


        }

        //Challenge 1
        public static int ReturnSum(string input) 
        {

            int sum = 1;

            //split string using split method
            string[] stringArray = input.Split(' ');
            int length = stringArray.Length;
            int[] numArray = new int[length];
            for (int i = 0; i < length; i++)
            {
                numArray[i] = Convert.ToInt32(stringArray[i]);
                //Console.WriteLine(stringArray[i]);
            }

            //less than 3 numbers returns 0
            if (length < 3)
            {
                Console.WriteLine("You did not enter enough numbers and get 0 as a return.");
                return 0;
            }
            else
            {
                //more than 3 only multiply the first 3 
                for (int i = 0; i < 3; i++)
                {
                    sum = sum * numArray[i];
                }
                Console.WriteLine($"The product of these 3 values is: {sum}");
                return sum;
            }

        }

        //Challenge 2
        public static int ReturnAverage()
        {
            Console.WriteLine("\nPlease enter a number between 2 and 10.");
            int userNumber = Convert.ToInt32(Console.ReadLine());
            int[] numberArr = new int[userNumber];
            int sum = 0;
            int length = numberArr.Length;
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine($"Please enter a number: {i} of {length}");
                numberArr[i] = Convert.ToInt32(Console.ReadLine());
                sum += numberArr[i];
            }

            int average = sum / numberArr.Length;

            Console.WriteLine($"The average of these {length} numbers is: {average}");

            return average;
        }

        //Challenge 3
        public static void PrintDesign()
        {
            //The brute force way
            //Console.WriteLine("    *");
            //Console.WriteLine("   ***");
            //Console.WriteLine("  *****");
            //Console.WriteLine(" *******");
            //Console.WriteLine("*********");
            //Console.WriteLine(" *******"); //line 6 1 space 7*
            //Console.WriteLine("  *****");   //line 7 2 space 5*
            //Console.WriteLine("   ***");    //line 8 3 space 3*
            //Console.WriteLine("    *");

            //Algorithm Way
            for (int i = 0; i < 9; i++) 
            {
                string output = "";
                //Ascending edge
                if (i < 5)
                {
                    //add 4-i spaces
                    for (int j = 0; j < 4 - i; j++)
                    {
                        output = output + " ";
                    }
                    //add 2i+1 *
                    for (int j = 0; j < (2 * i) + 1; j++)
                    {
                        output = output + "*";
                    }
                }
                //Descending edge
                else
                {
                    //spaces equal to i-5
                    for (int j = 0; j < i-4; j++)
                    {
                        output = output + " ";
                    }
                    //* equal to 9-(i-5) * 2
                    for (int j = 0; j < 9 - (i-4) *2; j++)
                    {
                        output = output + "*";
                    }
                }
                Console.WriteLine(output);
            }

        }

        //Challenge 4
        static int ChallengeFour(int[] array)
        {
            Array.Sort(array);
            int mostCommon = array[0];
            int mostCommonCount = 0;
            int nextNumber = array[1];
            int nextNumberCount = 0;
            for (int i = 0; i < array.Length; i++)
            {
                //Decide if the next number in the array is the current max, the next target,
                //Or else the next next target
                if (array[i] == mostCommon)
                {
                    mostCommonCount++;
                }
                else if (array[i] == nextNumber)
                {
                    nextNumberCount++;
                }
                else
                {
                    nextNumber = array[i];
                    nextNumberCount = 1;
                }

                //After looking at the number decide which of the 2 stored values it should go on
                if (mostCommonCount < nextNumberCount)
                {
                    mostCommonCount = nextNumberCount;
                    mostCommon = nextNumber;
                    if (i < array.Length - 1)
                    {
                        nextNumber = array[i + 1];
                        nextNumberCount = 0;
                    }
                }
            }
            Console.WriteLine($"{mostCommon}");
            return mostCommon;
        }


        //Challenge 5
        public static int Challenge5(int[] arr)
        {
            int ans = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > arr[i - 1])
                {
                    ans = arr[i];
                }
            }
            Console.WriteLine(ans);
            return ans;
        }

        //Challenge 6
        public static void WriteWordToFile(string word, string path)
        {

            //add on the word as a string, after putting in a character return
            File.AppendAllText(path, "\n");
            File.AppendAllText(path, word);

        }

        //Challenge 7
        public static void ReadFileContents(string path)
        {
            //console write to prove we have everything made
            string feedback = File.ReadAllText(path);
            Console.WriteLine(feedback);
        }

        //Challenge 8
        public static void RemoveFirstWord(string path)
        {
            //Read the info in
            string feedback = File.ReadAllText(path);
            string[] stringArr = feedback.Split("\n");
            string[] newArray = new string[stringArr.Length - 1];
            for (int i = 1; i < stringArr.Length; i++)
            {
                newArray[i - 1] = stringArr[i];
            }
            string joined = String.Join("\n", newArray);
            File.WriteAllText(path, joined);
            Console.WriteLine(String.Join("\n", newArray));
        }

        //Challenge 9
        public static string[] ProcessSentence()
        {
            Console.WriteLine("Give me words.");
            string wordsDemanded = Console.ReadLine();
            string[] eachWord = wordsDemanded.Split(" ");
            string[] answers = new string[wordsDemanded.Length];
            for (int i = 0; i < eachWord.Length; i++)
            {
                answers[i] = $"{eachWord[i]}: {eachWord[i].Length}";
            }
            for (int i = 0; i < answers.Length; i++)
            {
                Console.WriteLine(answers[i]);
            }
            return answers;
        }
    }
}
