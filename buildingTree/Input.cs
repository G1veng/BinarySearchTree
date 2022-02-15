using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingTree
{
  class Input
  {
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
  }
}
