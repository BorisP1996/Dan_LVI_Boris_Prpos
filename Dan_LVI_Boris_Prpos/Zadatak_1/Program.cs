using System;
using System.Net;
using System.IO;
using System.IO.Compression;



namespace Zadatak_1
{
    /// <summary>
    /// User enters link=>html code is downloaded into txt file
    /// //User enters zip=>folder with files is zipped
    /// </summary>
    class Program 
    {
        static void Main(string[] args)
        {
            //path where files will be created
            string originPath = @"..\..\HTML\HTML";
            //path where will be folder that will contain files
            string directory = @"..\..\HTML";
            while (true)
            {
                try
                {
                    Console.WriteLine("\nEnter web page link to download html code:\nEnter \"zip\" to zip all downloaded files:\nEnter \"x\" to exit the program:\n");
                    string input = Console.ReadLine();
                    //program stops
                    if (input == "x" || input == "X")
                    {
                        break;
                    }
                    //folder is getting zipped
                    else if (input == "zip")
                    {
                        //if zipped folder already exists=>delete it
                        File.Delete(@"..\..\ZIPPED.zip");
                        //zip folder from given path
                        ZipFile.CreateFromDirectory(@"..\..\HTML\", @"..\..\ZIPPED.zip");
                        //notify user
                        Console.WriteLine("\nFiles are zipped\n");
                    }
                    else
                    {
                        using (WebClient client = new WebClient())
                        {
                            //count how many files there is, in order to give them different names
                            int fileCount = Directory.GetFiles(directory, "*.*", SearchOption.TopDirectoryOnly).Length;
                            //create unique name for every file using fileCount number
                            string path = originPath + fileCount.ToString() + ".txt";
                            //download html code
                            string htmlCode = client.DownloadString(input);
                            //stream writer writes to file
                            StreamWriter sw = new StreamWriter(path, true);
                            sw.WriteLine(htmlCode);
                            sw.Close();
                            Console.WriteLine("\nHTML code is downloaded.\n");
                        }
                    }
                }
                catch (UriFormatException)
                {
                    Console.WriteLine("Invalid link. Please try again.");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }
        }
    }
}
