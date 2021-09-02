using System;
using System.Text;
using System.Linq;

namespace hometask_4_1
{
  class Program
  {
    static void Main(string[] args)
    {
      // hometask
      var size = RequestInput();

      var numberArray = CreateNumberArray(size);

      Console.WriteLine(string.Join(" ", numberArray));
      Console.WriteLine();

      var evenArray = CreateEvenArray(numberArray);
      PrintArray(evenArray);

      var oddArray = CreateOddArray(numberArray);
      PrintArray(oddArray);
      Console.WriteLine();

      int evenUppercaseCounter = 0;
      var evenCharArray = CreateCharArray(evenArray, ref evenUppercaseCounter);
      PrintArray(evenCharArray);

      int oddUppercaseCounter = 0;
      var oddCharArray = CreateCharArray(oddArray, ref oddUppercaseCounter);
      PrintArray(oddCharArray);

      CompareResults(evenUppercaseCounter, oddUppercaseCounter);
    }

    private static int RequestInput()
    {
      int size = 0;

      Console.WriteLine("Please enter the capacity of your array: ");
      if (!int.TryParse(Console.ReadLine(), out size))
      {
        Console.WriteLine("numbers only");
        RequestInput();
      }

      return size;
    }

    private static int[] CreateNumberArray(int size)
    {
      int[] array = new int[size];
      Random rnd = new Random();


      for (int i = 0; i < array.Length; ++i)
      {
        array[i] = rnd.Next(1, 26);
      }
      return array;
    }

    private static int[] CreateOddArray(int[] array)
    {
      return array.Where(x => x % 2 != 0).ToArray();
    }

    private static int[] CreateEvenArray(int[] array)
    {
      return array.Where(x => x % 2 == 0).ToArray();
    }

    private static void PrintArray(int[] array)
    {
      Console.WriteLine(string.Join(" ", array));

    }

    private static void PrintArray(char[] array)
    {
      Console.WriteLine(string.Join(" ", array));

    }

    private static char[] CreateCharArray(int[] array, ref int uppercaseCount)
    {
      var uppercaseFilter = "a, e, i, d, h, j";

      var charArray = new char[array.Length];


      for (int i = 0; i < array.Length; i++)
      {
        var letter = (char)(array[i] + 96);
        if (uppercaseFilter.Contains(letter))
        {
          charArray[i] = char.ToUpper(letter);
          uppercaseCount++;
        }
        else
        {
          charArray[i] = letter;
        }
      }

      return charArray;
    }

    private static void CompareResults(int fromEven, int fromOdd)
    {
      var message = $"{(fromEven > fromOdd ? "Even" : "Odd")} contains most Uppercase letters";
      Console.WriteLine(message);

    }

  }
}

