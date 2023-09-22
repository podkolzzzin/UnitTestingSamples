namespace ObsoleteFilesApp;

public class ObsoleteFilesDetector
{
  private readonly IDateProvider _dateProvider;
  private readonly IFileSystemProvider _fileSystemProvider;
  public ObsoleteFilesDetector(IDateProvider dateProvider, IFileSystemProvider fileSystemProvider)
  {
    _dateProvider = dateProvider;
    _fileSystemProvider = fileSystemProvider;
  }
  
  /// <summary>
  /// The method returns the list of files that were modified more than specified amount of days ago.
  /// </summary>
  /// <param name="path"></param>
  /// <param name="extension"></param>
  /// <param name="days"></param>
  /// <returns></returns>
  public string[] DetectObsoleteFiles(string path, string extension, int days)
  {
    return _fileSystemProvider.EnumerateFiles(path, extension)
      .Where(f => (_dateProvider.GetCurrentDateTime() - f.LastWriteTime).Days > days)
      .Select(f => f.Path)
      .ToArray();
  }
}

public interface IDateProvider
{
  DateTime GetCurrentDateTime();
}

public record File(string Path, DateTime LastWriteTime);

public interface IFileSystemProvider
{
  IEnumerable<File> EnumerateFiles(string path, string extension);
}