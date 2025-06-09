<Query Kind="Program" />

void Main()
{
	// Define the paths to the two folders containing assembly files
	string folder1 = @"";
	string folder2 = @"";

	var folder1Dlls = Directory.GetFiles(folder1, "*.dll");
	var folder2Dlls = Directory.GetFiles(folder2, "*.dll");

	Console.WriteLine($"Folder1: {folder1}");
	Console.WriteLine($"Folder2: {folder2}");

	foreach (var dll1 in folder1Dlls)
	{
		string dllName = Path.GetFileName(dll1);
		string dll2Path = Path.Combine(folder2, dllName);

		if (File.Exists(dll2Path))
		{
			var version1 = AssemblyName.GetAssemblyName(dll1).Version;
			var version2 = AssemblyName.GetAssemblyName(dll2Path).Version;

			// Compare versions and report mismatches
			if (version1 != version2)
			{
				Console.WriteLine($"{dllName} version mismatch:");
				Console.WriteLine($" - Folder1: {version1}");
				Console.WriteLine($" - Folder2: {version2}");
			}
		}
		else
		{
			Console.WriteLine($"{dll2Path} file missing.");
		}
	}
}

