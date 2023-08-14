using System;
using System.IO;

namespace FolderSizeScanner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the directory path:");
            string directoryPath = Console.ReadLine();

            if (Directory.Exists(directoryPath))
            {
                Console.WriteLine($"Scanning directory: {directoryPath}");
                Console.WriteLine("Folder Name\tSize (Bytes)");

                CalculateFolderSizes(directoryPath);
            }
            else
            {
                Console.WriteLine("Directory not found.");
            }

            Console.ReadLine();
        }

        static void CalculateFolderSizes(string directoryPath)
        {
            string[] subDirectories = Directory.GetDirectories(directoryPath);

            foreach (string subDirectory in subDirectories)
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(subDirectory);
                long folderSize = GetDirectorySize(directoryInfo);

                
                Console.WriteLine($"{directoryInfo.Name}\t\t{folderSize}");
            }
        }

        static long GetDirectorySize(DirectoryInfo directoryInfo)
        {
            long size = 0;

            FileInfo[] files = directoryInfo.GetFiles();
            foreach (FileInfo file in files)
            {
                size += file.Length;
            }

            DirectoryInfo[] subDirectories = directoryInfo.GetDirectories();
            foreach (DirectoryInfo subDirectory in subDirectories)
            {
                size += GetDirectorySize(subDirectory);
            }

            return size;
        }
    }
}
