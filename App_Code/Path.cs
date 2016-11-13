using System;
using System.Collections.Generic;

public static class Path
{
	public static string GetFileName(string path)
	{
		int len = path.Split('\\','/').Length;
		return path.Split('\\','/')[len -1];
	}

	public static string GetFileExtension(string path)
	{
		int len = path.Split('.').Length;
		return path.Split('.')[len -1];
	}

	public static string AppendToFileNameNotExt(string path, string append)
	{
		string ext = "." + GetFileExtension(path);
		string[] dotSplit = path.Split('.');
		path = dotSplit[0];
		for (int i = 1; i < dotSplit.Length - 1; i++)
		{
			path += "." + dotSplit[i];
		}
		return path += append + ext;
	}
}
