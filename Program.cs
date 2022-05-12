using System;
using System.IO;
using System.Text.Json;


namespace Cy5FileDemo
{
    class Movie
    {
        public int movid { get; set; }
        public int collection { get; set; }
        public string mname { get; set; }
        public string  mgenre { get; set; }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("File Demo");
             FileDemo();
            FolderDemo();
            FileJson();
        }

        //1.File exists - check
        //2.Create a new file - StreamWriter
        //3.Written to the file - WriteLine
        //4. Write All text - over write
        //5.Append text - add at the end
        //6.Read from File - Array 
        //7.Read from File - string
        static void FileDemo()
        {
            string fname = @"C:\Ezhil_Work\Work\Art_Training\csdemo.txt";
            //check
            if(File.Exists(fname))
            {
                Console.WriteLine("File found..");
            }
            else
            {
                Console.WriteLine("File not found..");
            }
            //create
            using (StreamWriter sw = File.CreateText(fname))
            {
                sw.WriteLine("Dot net fw consists of 16+ languages");
            }

            if (File.Exists(fname))
            {
                Console.WriteLine("File found..");
            }
            //write
            File.WriteAllText(fname, "Csharp is a popular dotnet language");
            File.AppendAllText(fname, "\nIt is part of dot net framework");

            //read
            Console.WriteLine();
            Console.WriteLine("Reading from File as Array");
            string[] filecontarr = File.ReadAllLines(fname);
            for (int i = 0; i < filecontarr.Length; i++)
            {
                Console.WriteLine(filecontarr[i]);
            }
            Console.WriteLine();
            Console.WriteLine("Reading from File as Text");
            string filetxt = File.ReadAllText(fname);
            Console.WriteLine(filetxt);


        }

        static void FolderDemo()
        {
            //string sourcefpath = @"C:\Ezhil_Work\Work\Art_Training\csdemo.txt";
            //string destfpath = @"C:\Ezhil_Work\Work\Art_Training\Portfolio\csdemo.txt";

            ////Copy

            //File.Copy(sourcefpath, destfpath,true);
            //Console.WriteLine("File copied..");

            //Move

            string sourcefp = @"C:\Ezhil_Work\Work\Art_Training\csdemomove.txt";
            
            string destfp = @"C:\Ezhil_Work\Work\Art_Training\Portfolio\csdemomove.txt";

            //Copy/Move
            
            Console.WriteLine(File.Exists(sourcefp));
            
            //File.Move(sourcefp, destfp);
            //Console.WriteLine("File Moved..");

            Console.WriteLine("List of Paintings");
            string folder = @"C:\Ezhil_Work\Work\Art_Training\Portfolio\";
            string[] filenames = Directory.GetFiles(folder);

            //for (int i = 0; i < filenames.Length; i++)
            //{
            //    Console.WriteLine(filenames[i]);
            //}

            Console.WriteLine("Display Subfolders");
            string[] subfolders = Directory.GetDirectories(folder);

            for (int i = 0; i < subfolders.Length; i++)
            {
                Console.WriteLine(subfolders[i]);
            }

            Console.WriteLine(Directory.GetParent(folder));
            Console.WriteLine(Directory.GetCreationTime(folder));
            Console.WriteLine(Directory.GetDirectoryRoot(folder));

            //delete
            File.Delete(destfp);
         
            Console.WriteLine("File successfully deleted..");

        }

        static void FileJson()
        {
            string jsonfile = @"C:\Users\Apple\source\repos\Cy5FileDemo\Movies.json";
            string jstxt = File.ReadAllText(jsonfile);
            Console.WriteLine(jstxt);

            Movie m1 = new Movie()
            {
                mname = "Wonderwoman",
                mgenre = "Action",
                movid = 1,
                collection = 364569
            };

            //Serialization - Conversion of obj -> json
            //Deserialization - Conversion of Json -> obj

            string js = JsonSerializer.Serialize(m1);
            Console.WriteLine(js);
        
            Movie m2 = JsonSerializer.Deserialize<Movie>(js);
            Console.WriteLine($"Movie Name is {m2.mname}  It is of {m2.mgenre}  And the collection is {m2.collection}");
            



        }
    }
}
