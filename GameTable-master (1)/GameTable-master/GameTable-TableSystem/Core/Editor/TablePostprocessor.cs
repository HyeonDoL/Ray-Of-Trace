using UnityEngine;
using UnityEditor;

using System.Collections.Generic;
using System.Diagnostics;


public class TablePostProcessor : AssetPostprocessor 
{
	// Full path to the Asset
	static string FullPathToExcel = Application.dataPath + "/GameTable-AutomaticConverter/Editor/Excel/";

	// Excel file Improt path
	static string ExcelPath = null;

	// Python script path
	static string ConverterPath = Application.dataPath + "/GameTable-AutomaticConverter/Editor/Automatic Converter.lnk";

	static bool isInitialize = false;

	private static void Initialize()
	{
		string[] splitPath = FullPathToExcel.Split('/');

		// Assets/GameTable-AutomaticConverter/Editor/Excel/ - 4 form behind
		ExcelPath =	splitPath[splitPath.Length - 5] + "/" +
					splitPath[splitPath.Length - 4] + "/" +
					splitPath[splitPath.Length - 3] + "/" +
					splitPath[splitPath.Length - 2] + "/";

		isInitialize = true;
	}

	private static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths) 
	{
		if(isInitialize == false)
			Initialize();

		// Imported Asset
		foreach (string filePath in importedAssets)
		{
			// Check is this temp file
			if (filePath.StartsWith("~"))
				continue;

			// Check is this Excel file
			if (filePath.EndsWith(".xlsx") == false)
				continue;

			// Check is this in ExcelPath
			if (filePath.StartsWith(ExcelPath))
				Convert();
		}
	}

	private static void Convert()
	{
		// Logging
		UnityEngine.Debug.Log("Excecute Automatic Cconvert");

		// Convert
		ConvertExcelToJson();

		// Refresh Assets folder
		AssetDatabase.Refresh();
	}

	private static void ConvertExcelToJson()
	{
		Process.Start(ConverterPath, "").WaitForExit();
	}
}

