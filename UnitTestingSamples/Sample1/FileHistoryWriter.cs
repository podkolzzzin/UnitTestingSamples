namespace UnitTestingSamples;

public class FileHistoryWriter : IHistoryWriter
{
  private readonly string _path;
  public FileHistoryWriter(string path)
  {
    _path = path;
  }

  public void Write(string operation, int result)
  {
    File.AppendAllText(_path, $"{operation} = {result}");
  }
}