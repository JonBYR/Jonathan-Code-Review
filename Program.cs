using System;
using System.Collections.Generic;
using System.IO;

namespace GitDiff
{
    
    class Program
    {
        public static string FilePicker() //asks user to input the name of the file they want to use
        {
            Console.WriteLine("What is the file you would like to read? Please spell correctly");
            string answer = Console.ReadLine();
            answer.Trim(); //removes any whitespaces
            return answer;
        }
        public static string FileCompared(bool result, string file1, string file2) //compares if the two files are the same by taking in a boolean result
        {
            if (result == true)
            {
                return $"Files {file1} and {file2} are the same";
            }
            else
            {
                return $"Files {file1} and {file2} are different";
            }
        }
        public static string GitDiff()
        {
            string answer1 = FilePicker();
            string answer2 = FilePicker();
            while (answer1 == answer2) //if the same file is given twice then the user will be asked to give a different file to compare
            {
                Console.WriteLine("Please do not give the same file");
                answer2 = FilePicker();
            }
            string[] file1 = File.ReadAllLines(answer1); //reads in the first file the user typed in and stores it as a string array
            string[] file2 = File.ReadAllLines(answer2); //reads in the second file the user typed in and stores it as a string array
            int n1 = file1.Length; //get the length for both string arrays
            int n2 = file2.Length;
            bool filesEqual = true;
            if (n1 != n2) //if the array lengths are different then the files must not be the same, so the bool is changed to false
            {
                filesEqual = false;
            }
            else
            {
                int i = 0; //create to variables that will be used to incrament through both arrays
                int j = 0;

                while ((n1 > 0) || (n2 > 0))
                {

                    string a = file1[i];
                    string b = file2[j]; //variable that is overwritten each iteration
                    if (a != b) //if the element of both arrays are not the same at the same position, then the files must not have been the same, so the bool is false and we no longer need to check the files 
                    {
                        filesEqual = false;
                        break;
                    }
                    i++;
                    j++; //goes too the next element
                    n1--;
                    n2--; //reduction for the while loop to work
                }
            }
            return FileCompared(filesEqual, answer1, answer2); //return the result of the bool being true or false
        }

        static void Main(string[] args)
        {
            bool filesFound = false;
            while (filesFound == false) //exception handling will check if the files exist in the bin folder, and will continue to ask the user to give the correct files if the exception is raised
            {
                try
                {
                    Console.WriteLine(GitDiff());
                    filesFound = true;
                }
                catch (FileNotFoundException e)
                {
                    Console.WriteLine("File(s) does not exist, please try again");
                }
            }
            

        } 
            
            
        }
    }
