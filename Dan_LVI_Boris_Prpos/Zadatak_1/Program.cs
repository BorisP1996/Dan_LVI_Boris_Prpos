using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.IO.Compression;


namespace Zadatak_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string originPath = @"..\..\HTML\HTML";
            string directory = @"..\..\HTML";
            while (true)
            {
                Console.WriteLine("\nEnter web page link to download html code:\nEnter \"zip\" to zip all downloaded files:\nEnter \"x\" to exit the program:\n");

                string input = Console.ReadLine();

                if (input == "x" || input == "X")
                {
                    break;
                }

                else if (input == "zip")
                {
               
                    ZipFile.CreateFromDirectory(directory, @"..\..\Zipp_Folder");
                    ZipFile.ExtractToDirectory(@"..\..\Zipp_Folder", directory);

                    Console.WriteLine("\nFiles are zipped\n");
                   
                }

                else
                {
                    using (WebClient client = new WebClient())
                    {
                        int fileCount = Directory.GetFiles(directory, "*.*", SearchOption.TopDirectoryOnly).Length;
                        string path = originPath + fileCount.ToString() + ".txt";
                        string htmlCode = client.DownloadString(input);
                        StreamWriter sw = new StreamWriter(path, true);
                        sw.WriteLine(htmlCode);
                        sw.Close();
                        Console.WriteLine("\nHTML code is downloaded.\n");

                    }
                }

            }
        }
    }
}
