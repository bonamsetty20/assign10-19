using System;
using System.IO;

public class DocumentManagementSystem
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Document Management System!");

        while (true)
        {
            Console.WriteLine("\n select an operation:");
            Console.WriteLine("1. Create a new file");
            Console.WriteLine("2. Read a file");
            Console.WriteLine("3. Append to a file");
            Console.WriteLine("4. Delete a file");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice from 1-5: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter the file name: ");
                    string createFileName = Console.ReadLine();
                    Console.Write("Enter the file content: ");
                    string createFileContent = Console.ReadLine();
                    CreateFile(createFileName, createFileContent);
                    Console.WriteLine("File created successfully!");
                    break;
                case "2":
                    Console.Write("Enter the file name: ");
                    string readFile = Console.ReadLine();
                    string fileContent = ReadFile(readFile);
                    Console.WriteLine("File content:");
                    Console.WriteLine(fileContent);
                    break;
                case "3":
                    Console.Write("Enter the file name: ");
                    string appendFileName = Console.ReadLine();
                    Console.Write("Enter the content to append: ");
                    string appendContent = Console.ReadLine();
                    AppendToFile(appendFileName, appendContent);
                    Console.WriteLine("Content appended to the file successfully!");
                    break;
                case "4":
                    Console.Write("Enter the file name: ");
                    string deleteFile = Console.ReadLine();
                    DeleteFile(deleteFile);
                    Console.WriteLine("File deleted successfully!");
                    break;
                case "5":
                    Console.WriteLine("Exiting the program...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private static void CreateFile(string fileName, string content)
    {
        string filePath = GetFilePath(fileName);

        // Write the content to the file
        using (StreamWriter writer = File.CreateText(filePath))
        {
            writer.Write(content);
        }
    }

    private static string ReadFile(string fileName)
    {
        string filePath = GetFilePath(fileName);

        // Read the content from the file
        using (StreamReader reader = File.OpenText(filePath))
        {
            return reader.ReadToEnd();
        }
    }

    private static void AppendToFile(string fileName, string content)
    {
        string filePath = GetFilePath(fileName);

        // Append the content to the file
        using (StreamWriter writer = File.AppendText(filePath))
        {
            writer.Write(content);
        }
    }

    private static void DeleteFile(string fileName)
    {
        string filePath = GetFilePath(fileName);

        // Delete the file if it exists
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
        else
        {
            throw new FileNotFoundException("File not found.", filePath);
        }
    }

    private static string GetFilePath(string fileName)
    {
        string directoryPath = Directory.GetCurrentDirectory();
        return Path.Combine(directoryPath, fileName);
    }
   
}
