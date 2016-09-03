//Author: Daniel Kawamoto

using System;
using System.IO;

class Program
{
	public static void checkFiles()
	{
		string srcDir = @"/Users/danielkawamoto/Documents/TTA/C Sharp/Drills/File_Transfer_Console_Drill/SourceFolder";
		string dstDir = @"/Users/danielkawamoto/Documents/TTA/C Sharp/Drills/File_Transfer_Console_Drill/DestinationFolder";
		string[] files = Directory.GetFiles(srcDir);
		DateTime twentyFourHours = DateTime.Now.AddHours(-24);

		int fileCount = 0;
		int oldFileCount = 0;
		int filesAlreadyCopied = 0;

		foreach (string file in files)
		{
			var fi = new FileInfo(file);
			if (fi.LastWriteTime > twentyFourHours) // Remember, now is technically a greater value of time than 24hrs ago...
			{
				fileCount += 1;
				string newFilePath = Path.Combine(dstDir, fi.Name);
				try
				{
					File.Copy(file, newFilePath, false);
				}
				catch (Exception)
				{
					filesAlreadyCopied += 1;
				}
			}
			else
			{
				oldFileCount += 1;
			}
		}

		// RESULTS
		Console.WriteLine("RESULTS:");
		Console.WriteLine("Files older than 24hrs: " + oldFileCount);
		if (filesAlreadyCopied > 0)
		{
			Console.WriteLine("Files already copied: " + filesAlreadyCopied);
		}
		else
		{
			Console.WriteLine("Files copied to new folder: " + fileCount);
		}
		Console.WriteLine();
		Console.WriteLine("SOURCE DIRECTORY: \n" + srcDir);
		Console.WriteLine("DESTINATION DIRECTORY: \n" + dstDir);
	}

	static void Main(string[] args)
	{
		checkFiles();
		Console.ReadKey();
	}
}
