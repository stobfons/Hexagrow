using System;
using System.Collections.Generic;
using System.IO;

public class cs
{
    public static void Main(string[] args)
    {
        title = "error";
        BG = "000000";
        Path = "000000";
        BGEmpty = "000000";
        BGDeep = "000000";
        EStroke = "000000";

        Stone = new string[3];
        Stone[0] = "000000";
        Stone[1] = "000000";
        Stone[2] = "000000";

        Detail = new string[3];
        Detail[0] = "000000";
        Detail[1] = "000000";
        Detail[2] = "000000";

        StoneEmpty = new string[3];
        StoneEmpty[0] = "000000";
        StoneEmpty[1] = "000000";
        StoneEmpty[2] = "000000";

        DetailEmpty = new string[3];
        DetailEmpty[0] = "000000";
        DetailEmpty[1] = "000000";
        DetailEmpty[2] = "000000";

        StoneDeep = new string[3];
        StoneDeep[0] = "000000";
        StoneDeep[1] = "000000";
        StoneDeep[2] = "000000";

        DetailDeep = new string[3];
        DetailDeep[0] = "000000";
        DetailDeep[1] = "000000";
        DetailDeep[2] = "000000";

        Scanner loader = new Scanner(new File("svg.txt"));
        Console.WriteLine("Enter a search term:");
        string dT = Console.ReadLine();
        int l = 0;
        int i = 0;
        List<string> items = new List<string>();
        while (loader.HasNextLine())
        {
            items.Add(loader.NextLine());

            if (items[l].Contains(dT))
            {
                i = l;
            }
            l++;
        }

        title = items[i];
        BG = items[i + 1];
        Path = items[i + 2];
        BGEmpty = items[i + 3];
        BGDeep = items[i + 4];
        EStroke = items[i + 5];

        Stone[0] = items[i + 6];
        Stone[1] = items[i + 7];
        Stone[2] = items[i + 8];

        Detail[0] = items[i + 9];
        Detail[1] = items[i + 10];
        Detail[2] = items[i + 11];

        StoneEmpty[0] = items[i + 12];
        StoneEmpty[1] = items[i + 13];
        StoneEmpty[2] = items[i + 14];

        DetailEmpty[0] = items[i + 15];
        DetailEmpty[1] = items[i + 16];
        DetailEmpty[2] = items[i + 17];

        StoneDeep[0] = items[i + 18];
        StoneDeep[1] = items[i + 19];
        StoneDeep[2] = items[i + 20];

        DetailDeep[0] = items[i + 21];
        DetailDeep[1] = items[i + 22];
        DetailDeep[2] = items[i + 23];

        DirectoryInfo originPDir = new DirectoryInfo("..\\Assets\\0 Spielfeld\\Path\\classic");
        Directory.CreateDirectory(originPDir.FullName.Replace("classic", title));
        DirectoryInfo originTDir = new DirectoryInfo("..\\Assets\\0 Spielfeld\\Tiles\\classic");
        Directory.CreateDirectory(originTDir.FullName.Replace("classic", title));

        FileInfo[] originPaths = originPDir.GetFiles("*.svg");
        FileInfo[] originTiles = originTDir.GetFiles("Empty*.svg");
        FileInfo originBG = new FileInfo("..\\Assets\\0 Spielfeld\\Background\\classic.svg");
        FileInfo originBGDeep = new FileInfo("..\\Assets\\0 Spielfeld\\Background\\classicDeep.svg");

        Path(originPaths, title, BG, Path, Stone, Detail);
        //Empty(originTiles, title, BGEmpty, StoneEmpty, DetailEmpty, EStroke);
        //BG(originBG, title, BGDeep, StoneDeep, DetailDeep);
        //BG(originBGDeep, title, BGDeep, StoneDeep, DetailDeep);
    }
    }

    public static void Path(FileInfo[] files, string title, string BG, string Path, string[] Stone, string[] Detail)
    {
        string sub = "";
        string newPath = "";
        StreamWriter newFile;

        try
        {
            for (int i = 0; i < files.Length; i++)
            {
                newPath = files[i].FullName.Replace("classic", title);
                //Console.WriteLine(files[i]);
                StreamReader reader = new StreamReader(files[i].FullName);
                try
                {
                    newFile = new StreamWriter(newPath);
                    while (!reader.EndOfStream)
                    {
                        string text = reader.ReadLine();
                        if (text.Contains("#"))
                        {
                            int start = text.IndexOf('#') + 1;
                            if (start >= 0)
                            {
                                sub = text.Substring(start, start + 6);
                            }
                        }
                        //Background
                        text = text.Replace("#" + sub + ";stroke:#000000;stroke-width:2;", "#" + BG + ";stroke:#000000;stroke-width:2;");
                        //Path
                        text = text.Replace("#" + sub + ";stroke:#000000;stroke-miterlimit:10;", "#" + Path + ";stroke:#000000;stroke-miterlimit:10;");
                        //Stones
                        text = text.Replace("#" + sub + ";stroke:#000000;stroke-width:0.5;", "#" + Stone[(int)Math.Floor(new Random().NextDouble() * 3)] + ";stroke:#000000;stroke-width:0.5;");
                        //Details
                        text = text.Replace("#" + sub + ";stroke:#000000;stroke-width:0.25;", "#" + Detail[(int)Math.Floor(new Random().NextDouble() * 3)] + ";stroke:#000000;stroke-width:0.25;");

                        newFile.WriteLine(text);
                        newFile.Flush();
                    }

                    newFile.Close();
                }
                catch (IOException e)
                {
                    Console.WriteLine("Error");
                    Console.WriteLine(e.StackTrace);
                } // Ends Try Catch Writer
                reader.Close();
            }
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine("An error occurred.");
            Console.WriteLine(e.StackTrace);
        }
    }
    public static void Empty(FileInfo[] files, string title, string BG, string[] Stone, string[] Detail, string Stroke)
    {
        string sub = "";
        string newPath = "";
        StreamWriter newFile;
        Console.WriteLine(files[0]);
        try
        {
            for (int i = 0; i < files.Length; i++)
            {
                newPath = files[i].FullName.Replace("classic", title);
                Console.WriteLine(files[i]);
                StreamReader reader = new StreamReader(files[i].FullName);
                try
                {
                    newFile = new StreamWriter(newPath);
                    while (!reader.EndOfStream)
                    {
                        string text = reader.ReadLine();
                        if (text.Contains("#"))
                        {
                            int start = text.IndexOf('#') + 1;
                            if (start >= 0)
                            {
                                sub = text.Substring(start, start + 6);
                            }
                        }
                        //Background
                        text = text.Replace("#" + sub + ";stroke:#000000;stroke-width:2;", "#" + BG + ";stroke:#" + Stroke + ";stroke-width:2;");
                        //Stones
                        text = text.Replace("#" + sub + ";stroke:#000000;stroke-width:0.5;", "#" + Stone[(int)Math.Floor(new Random().NextDouble() * 3)] + ";stroke:#" + Stroke + ";stroke-width:0.5;");
                        //Details
                        text = text.Replace("#" + sub + ";stroke:#000000;stroke-width:0.25;", "#" + Detail[(int)Math.Floor(new Random().NextDouble() * 3)] + ";stroke:#000000;stroke-width:0.25;");

                        newFile.WriteLine(text);
                        newFile.Flush();
                    }

                    newFile.Close();
                }
                catch (IOException e)
                {
                    Console.WriteLine("Error");
                    Console.WriteLine(e.StackTrace);
                } // Ends Try Catch Writer
                reader.Close();
            }

        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine("An error occurred.");
            Console.WriteLine(e.StackTrace);
        }
    }

    public static void BG(FileInfo file, string title, string BG, string[] Stone, string[] Detail)
    {
        string sub = "";
        StreamWriter newFile = null;
        try
        {
            newFile = new StreamWriter(file.FullName.Replace("classic", title));
        }
        catch (IOException e)
        {
            Console.WriteLine("Error");
            Console.WriteLine(e.StackTrace);
        }
        try
        {
            using (StreamReader reader = new StreamReader(file.FullName))
            {
                while (!reader.EndOfStream)
                {
                    string text = reader.ReadLine();

                    if (text.Contains("#"))
                    {
                        int start = text.IndexOf('#') + 1;

                        if (start >= 0)
                        {
                            sub = text.Substring(start, start + 6);
                        }
                    }
                    //Background
                    text = text.Replace("#" + sub + ";stroke:#000000;stroke-width:6;", "#" + BG + ";stroke:#000000;stroke-width:6;"); //approved
                    //Stones
                    text = text.Replace("#" + sub + ";stroke:#000000;stroke-miterlimit:10;", "#" + Stone[(int)Math.Floor(new Random().NextDouble() * 3)] + ";stroke:#000000;stroke-miterlimit:10;");
                    //Details
                    text = text.Replace("#" + sub + ";stroke:#000000;stroke-width:0.5;", "#" + Detail[(int)Math.Floor(new Random().NextDouble() * 3)] + ";stroke:#000000;stroke-width:0.5;");

                    newFile.WriteLine(text);
                    newFile.Flush();
                }
            }
        }
        catch (IOException e1)
        {
            Console.WriteLine("Error");
            Console.WriteLine(e1.StackTrace);
        }
    }
}

