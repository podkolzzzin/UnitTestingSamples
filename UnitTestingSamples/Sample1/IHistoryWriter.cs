namespace UnitTestingSamples;

public interface IHistoryWriter
{
  void Write(string operation, int result);
}

//
// public class Program
// {
//   public static void Main(string[] args)
//   {
//     var writer = new FileHistoryWriter("history.txt");
//     var x = MathOps.Sum(writer, 10, 30);
//     Console.WriteLine(x);
//   }
// }