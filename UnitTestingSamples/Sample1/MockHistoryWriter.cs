namespace UnitTestingSamples;

public class MockHistoryWriter : IHistoryWriter
{
  public string Operation { get; private set; }
  public int Result { get; private set; }
  public void Write(string operation, int result)
  {
    Operation = operation;
    Result = result;
  }
}