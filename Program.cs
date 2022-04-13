using System;
using System.IO;

namespace filecodelab
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput = "";
            
            while(userInput != "4")
            {
                Console.WriteLine("Please choose an option below");
                DisplayMenu();
                userInput = Console.ReadLine();
                Route(userInput);
            } 
        }

        static void DisplayMenu()
        {
            Console.WriteLine("Type 1 to encode a file");
            Console.WriteLine("Type 2 to decode a file");
            Console.WriteLine("Type 3 for word count");
            Console.WriteLine("Type 4 exit the program");
        }
        static void Route(string userInput)
        {
            switch(userInput)
            {
                case "1":
                    Encode();
                    break;
                case "2":
                    Decode();
                    break;
                case "3":
                    WordCount();
                    break;
                case "4":
                    Console.WriteLine("Thank you for using the program");
                    break;
                default:
                    Console.WriteLine("Please enter a valid input");
                    break;
            }
            static void Encode()
            {
                Console.WriteLine("Please choose a file to be encoded");
                string inFileName = Console.ReadLine();
                Console.WriteLine("Please choose a file to save to");
                string outFileName = Console.ReadLine();

                FileCoder(inFileName, outFileName);

            }
            static void Decode()
            {
                Console.WriteLine("Please choose a file to be decoded");
                string inFileName = Console.ReadLine();
                Console.WriteLine("Please choose a file to save to");
                string outFileName = Console.ReadLine();

                FileCoder(inFileName, outFileName);
            }

            static void WordCount()
            {
                Console.WriteLine("Please choose a file that you want the word count for");
                string inFileName = Console.ReadLine();

                ShowWordCount(inFileName);
            }

            static void ShowWordCount(string inFileName)
            {
                StreamReader inFile = new StreamReader($"{inFileName}.txt");
                string line = inFile.ReadLine();
                int wordCount = 0;

                while(line != null)
                {
                    string[] temp = line.Split(" ");
                    wordCount += temp.Length;

                    line = inFile.ReadLine();
                }
                inFile.Close();

                System.Console.WriteLine($"The number of words in the file is {wordCount}");
            }
            static void FileCoder(string inFileName, string outFileName)
            {
                StreamReader inFile = new StreamReader($"{inFileName}.txt");
                StreamWriter outFile = new StreamWriter($"{outFileName}.txt");

                string line = inFile.ReadLine();
                while(line != null)
                {
                    string newLine = LineCoder(line);
                    outFile.WriteLine(newLine);

                    line = inFile.ReadLine();
                    
                }
                inFile.Close();
                outFile.Close();
            }
            static string LineCoder(string line)
            {
                string newLine = "";
                string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                line = line.ToUpper();

                for(int u = 0; u < line.Length; u++)
                {
                    int found = -1;
                    for(int j = 0; j < alphabet.Length; j++)
                    {
                        if(line[u] == alphabet[j])
                        {
                            found = j;
                        }

                    }
                    if(found != -1)
                    {
                        newLine += alphabet[(found + 13)%26];
                    }
                    else
                    {
                        newLine += line[u];
                    }
                }
                

                return newLine;
            }
        

        }
    }
}
