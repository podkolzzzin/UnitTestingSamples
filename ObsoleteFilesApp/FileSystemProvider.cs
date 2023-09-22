namespace ObsoleteFilesApp;

public class FileSystemProvider : IFileSystemProvider
{
  public IEnumerable<File> EnumerateFiles(string path, string extension)
  {
    return Directory.EnumerateFiles(path, extension, SearchOption.AllDirectories)
      .Select(x => new File(x, System.IO.File.GetLastWriteTime(x)));
  }
}