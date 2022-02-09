using System;
using System.IO;
using System.Linq;
namespace ReversFile
{
    class Program
    {
        static void Main(string[] args)
        {
            SaveToNewFile("test.txt", "Я люблю програмування");

            bool completeExecution = false;
            while (!completeExecution) 
            { 
                Console.WriteLine("Enter path to file \n Example: test.txt ");
                string enteredPath = Console.ReadLine();
                string dataIn = string.Empty;
           
                try
                {
                    dataIn = LoadFile(enteredPath);
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("file not found");
                    continue;
                }

                Console.WriteLine($"Enter a name for the new file, if empty name new file: Revers{enteredPath}");
                string enteredNewPath = Console.ReadLine();
                if (enteredNewPath == string.Empty) enteredNewPath = "Revers" + enteredPath;
                string result = ReverseString(dataIn);
                SaveToNewFile(enteredNewPath, result);
                Console.WriteLine(dataIn + " =>\n" + result);


                Console.WriteLine("Continue the program?");
                if (Console.ReadLine() == "yes") continue;
                else completeExecution = true;
            }
        }

        static string ReverseString(string text)
        {
            return new string(text.ToCharArray().Reverse().ToArray());
        }
        static string LoadFile(string path)
        {
            try
            {
                TextReader tr = File.OpenText(path);
                string text = tr.ReadToEnd();
                tr.Close();
                return text;
            }
            catch (FileNotFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }

        }
        static void SaveToNewFile(string path, string text)
        {
            if (text == string.Empty)
                return;
            if (File.Exists(path))
                File.Delete(path);

            FileInfo f = new FileInfo(path);
            TextWriter tw = f.CreateText();
            tw.WriteAsync(text);
            tw.Close();
        }
    }
}
