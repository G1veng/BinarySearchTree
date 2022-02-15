using BuildingTree;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BuildingTree
{
  public interface IInputData
  {
     Tree input();
  }

  public class RandomInput : IInputData
  {
    const int LowerLimit = 5;
    const int UpperLimit = 12;
    static Random rnd = new Random();
    public Tree input()
    {
      Tree binaryTree = new Tree();
      int countOfNUmbers = rnd.Next(LowerLimit, UpperLimit);
      int[] array = new int[countOfNUmbers];
      for (int i = 0; i < countOfNUmbers; i++)
      {
        array[i] = i + 1;
      }
      int n = countOfNUmbers;
      while (n > 1)
      {
        n--;
        int f = rnd.Next(n + 1);
        int value = array[f];
        array[f] = array[n];
        array[n] = value;
      }
      for (int i = 0; i < countOfNUmbers; i++)
      {
        binaryTree.Add(array[i]);
      }
      binaryTree.ShowBinaryTree();
      return binaryTree;
    }
  }

  public class FileInput : IInputData
  {
    public Tree input()
    {
      Tree binaryTree = new Tree();
      string path;
      do
      {
        List<string> tempArray = new List<string>();
        Console.WriteLine("Please enter path to file");
        path = Console.ReadLine();
        FileInfo tempFile = new FileInfo(path);
        if (!tempFile.Exists)
        {
          Console.WriteLine("File is not existing");
          continue;
        }
        StreamReader tempOpenedFile = new StreamReader(path);
        while (!tempOpenedFile.EndOfStream)
        {
          tempArray.Add(tempOpenedFile.ReadLine());
        }
        tempOpenedFile.Close();
        bool badData = false;
        for (int i = 0; i < tempArray.Count; i++)
        {
          if (!int.TryParse(tempArray[i], out int number))
          {
            Console.WriteLine("Bad data");
            badData = true;
          }
        }
        if (badData)
        {
          continue;
        }
        break;
      }
      while (true);
      StreamReader file = new StreamReader(path, false);
      List<int> array = new List<int>();
      while (!file.EndOfStream)
      {
        array.Add(Convert.ToInt32(file.ReadLine()));
      }
      file.Close();
      for (int i = 0; i < array.Count; i++)
      {
        binaryTree.Add(array[i]);
      }
      Console.WriteLine("Binary tree:" + Environment.NewLine);
      binaryTree.ShowBinaryTree();
      return binaryTree;
    }
  }
}
