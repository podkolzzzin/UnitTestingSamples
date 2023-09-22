namespace UnitTestingSamples;

public static class MathOps
{
  public static int Sum(IHistoryWriter writer, int a, int b)
  {
    writer.Write($"{a}+{b}", a+b);
    return a + b;
  }
}
