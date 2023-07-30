using System;
using System.IO;

namespace ChadOS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"
⠀⠀⠀⠀⠀⠀⣠⠴⠒⠉⠉⠉⠉⠉⠓⠢⣄⠀⠀⠀
⠀⠀⠀⠀⠀⡞⠁⠀⢀⡀⠀⠀⠀⠀⡄⠀⠈⣆⠀⠀
⠀⠀⠀⠀⢸⠁⠀⠀⠀⣱⠀⠀⠀⠐⣣⠂⠀⢹⡀⠀
⠀⠀⠀⠀⢸⠀⠀⠀⠀⢇⢠⣤⣴⣕⢹⢶⣄⣠⠇⠀
⠀⠀⠀⠀⠈⢧⠀⠀⡰⠀⠋⢣⣽⠎⠈⣿⡟⢻⠀⠀
⠀⠀⠀⠀⠀⠀⠓⠦⡷⣄⣀⠀⣰⡀⠀⡇⢀⠞⠀⠀Booted to ChadOS
⠀⠀⠀⠀⠀⠀⠀⡸⠁⡇⠸⢰⠉⡩⢶⡹⡇⠀⠀⠀
⠀⣀⠤⠖⠒⡿⠹⠁⢰⠁⠀⠈⠈⢯⣭⠃⡇⠀⠀⠀
⣋⠀⠀⠀⢰⠁⠀⠀⠘⠦⣄⡀⠀⠈⠐⡆⢙⣆⠀⠀
⠉⠉⠳⣄⠀⢇⢠⡄⠀⠀⠀⠉⣳⠒⠒⡻⠉⠘⠓⢆
");
            Console.WriteLine("ChadOS - Type 'exit' to quit.");

            bool isRunning = true;

            while (isRunning)
            {
                Console.Write("> ");
                string input = Console.ReadLine();
                string[] cmdArgs = input.Split(' ');
                string command = cmdArgs[0];

                switch (command)
                {
                    case "exit":
                        isRunning = false;
                        break;

                    case "help":
                        Console.WriteLine("Available commands: help, dir, makefile, rmfile, run");
                        break;

                    case "dir":
                        ListDirectory();
                        break;

                    case "makefile":
                        if (cmdArgs.Length >= 2)
                            CreateFile(cmdArgs[1]);
                        else
                            Console.WriteLine("Usage: makefile <filename>");
                        break;

                    case "rm":
                        if (cmdArgs.Length >= 2)
                            DeleteFile(cmdArgs[1]);
                        else
                            Console.WriteLine("Usage: rm <filename>");
                        break;

                    case "run":
                        if (cmdArgs.Length >= 2)
                            RunFile(cmdArgs[1]);
                        else
                            Console.WriteLine("Usage: run <filename>");
                        break;

                    default:
                        Console.WriteLine("Command not found. Type 'help' for available commands.");
                        break;
                }
            }

            Console.WriteLine("Exiting ChadOS...");
        }

        static void ListDirectory()
        {
            string[] files = Directory.GetFiles(".");
            foreach (string file in files)
            {
                Console.WriteLine(Path.GetFileName(file));
            }
        }

        static void CreateFile(string filename)
        {
            try
            {
                File.Create(filename);
                Console.WriteLine($"File '{filename}' created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void DeleteFile(string filename)
        {
            try
            {
                File.Delete(filename);
                Console.WriteLine($"File '{filename}' deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void RunFile(string filename)
        {
            Console.WriteLine($"Running '{filename}'...");
        }
    }
}
