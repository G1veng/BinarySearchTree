using System;
using System.Collections.Generic;
using System.IO;

namespace BuildingTree
{
  class Program
  {
    enum UserChoice
    {
      ConsoleInput = 1,
      FileInput,
      RandomInput,
      End
    }
    static void Main()
    {
      Node binaryTree = new Node();
      Console.WriteLine("Created by: Shishko Daniil Yrevich" + Environment.NewLine +
        "Option: 9" + Environment.NewLine + "Aim: Realize binary search tree, show features, realize function to" +
        " create, delete nodes and visualize tree. Also need manual, file and random enter." + Environment.NewLine +
        "Features: key in every node must be greater than keys in left brench and less than keys in right bench" + Environment.NewLine+ "Welcome.");
      UserChoice choice;
      do
      {
        Console.WriteLine(Environment.NewLine + Environment.NewLine +"1 - Console input" + Environment.NewLine
          + "2 - File input" + Environment.NewLine + "3 - Random input" + Environment.NewLine + "4 - End program");
        choice = (UserChoice)Input.GetInt();
        if (choice == UserChoice.FileInput)
        {
          binaryTree = File.GetDataFromFile();
        }
        if (choice == UserChoice.RandomInput)
        {
          binaryTree = Input.RandomInput();
        }
        if (choice == UserChoice.End)
        {
          break;
        }
        if (choice > UserChoice.End || choice < UserChoice.ConsoleInput)
        {
          Console.WriteLine("We dont have these option, please try again");
          continue;
        }
        UseOfBinaryTree.Interact(binaryTree);
      } while (true);
    }
  }
}