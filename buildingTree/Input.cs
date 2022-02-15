using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingTree
{
  class Input
  {
    const int LowerLimit = 5;
    const int UpperLimit = 12;
    static public int GetInt()
    {
      int number = 0;
      while (true)
      {
        Console.Write("Please enter integer: ");
        string text = Console.ReadLine();
        if (int.TryParse(text, out number))
        {
          break;
        }
        Console.WriteLine("This is not a integer, try again");
      }
      return number;
    }

    static Random rnd = new Random();

    static public Node RandomInput()
    {
      Node binaryTree = new Node();
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
}
