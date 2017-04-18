using UnityEngine;
using UnityEditor;

using System.Collections.Generic;
using System.Diagnostics;


public class TablePostProcessor : AssetPostprocessor 
{
	//Edit this field
	//Root Path
	static string kRootPath = "/GameTable-Converter";
		
	static string kExcelFilesPath = kRootPath + "/Excel";
	static string kConverterPath = kRootPath + "/run.bat";

	private static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths) 
	{
		foreach (string filePath in importedAssets)
		{
			if (filePath.Contains (kExcelFilesPath) == false)
				continue;

			// Check is this Excel file
			if (filePath.EndsWith(".xlsx") == false)
				continue;
			
			// Check is this temp file
			if (filePath.StartsWith("~"))
				continue;

			Convert ();
		}
	}

	private static void Convert()
	{
		UnityEngine.Debug.Log("Excecute Convert");

		ConvertExcelToJson();

		AssetDatabase.Refresh();
	}

	private static void ConvertExcelToJson()
	{
		var info = new ProcessStartInfo ();
		info.FileName = Application.dataPath + kConverterPath;
		info.WorkingDirectory = Application.dataPath + kRootPath;
		Process.Start (info);
	}
}