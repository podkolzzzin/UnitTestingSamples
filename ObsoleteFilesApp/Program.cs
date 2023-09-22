// See https://aka.ms/new-console-template for more information

// This app detects obsolete files on the specified path.

using ObsoleteFilesApp;

if (args.Length == 0)
{
  args = new[]
  {
    "C:\\Program Files (x86)\\Windows NT", // path to search old files 
    "*.dll", // extension of such files
    "10" // number of days
  };
}

var detector = new ObsoleteFilesDetector(new DateProvider(), new FileSystemProvider());

var files = detector.DetectObsoleteFiles(args[0], args[1], int.Parse(args[2]));

Console.WriteLine($"Found {files.Length} obsolete files:");
foreach (var file in files)
{
  Console.WriteLine("\t" + file);
}