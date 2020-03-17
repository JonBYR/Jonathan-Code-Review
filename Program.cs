using System;
using System.Collections.Generic;
using System.IO;

namespace GitDiff
{
    
    class Program
    {
        public static string FilePicker()
        {
            Console.WriteLine("What is the file you would like to read? Please spell correctly");
            string answer = Console.ReadLine();
            answer.Trim();
            return answer;
        }
        public static string FileCompared(bool result, string file1, string file2)
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
            while (answer1 == answer2)
            {
                answer1 = FilePicker();
                answer2 = FilePicker();
            }
            string[] file1 = File.ReadAllLines(answer1);
            string[] file2 = File.ReadAllLines(answer2);
            int n1 = file1.Length;
            int n2 = file2.Length;
            bool filesEqual = true;
            if (n1 != n2)
            {
                filesEqual = false;
            }
            else
            {
                int i = 0;
                int j = 0;

                while ((n1 > 0) || (n2 > 0))
                {

                    string a = file1[i].ToLower();
                    string b = file2[j].ToLower();
                    if (a != b)
                    {
                        filesEqual = false;
                        break;
                    }
                    i++;
                    j++;
                    n1--;
                    n2--;
                }
            }
            return FileCompared(filesEqual, answer1, answer2);
        }

        static void Main(string[] args)
        {
            bool filesFound = false;
            while (filesFound == false)
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
