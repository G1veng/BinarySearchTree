using System;
using System.Collections.Generic;
using System.IO;

namespace BuildingTree
{
  class Program
  {
    static void Main()
    {
      Tree binaryTree = new Tree();
      Console.WriteLine("Created by: Shishko Daniil Yrevich" + Environment.NewLine +
        "Option: 9" + Environment.NewLine + "Aim: Realize binary search tree, show features, realize function to" +
        " create, delete nodes and visualize tree. Also need manual, file and random enter." + Environment.NewLine +
        "Features: key in every node must be greater than keys in left brench and less than keys in right bench" + Environment.NewLine+ "Welcome.");
      do
      {
        Console.WriteLine(Environment.NewLine + Environment.NewLine +"1 - Console input" + Environment.NewLine
          + "2 - File input" + Environment.NewLine + "3 - Random input" + Environment.NewLine + "4 - End program");
        IInputData someInput = GetInput.GetSomeInput(Input.GetInt());
        if (someInput != null)
        {
          binaryTree = someInput.input();
        }
        UseOfBinaryTree.Interact(binaryTree);
      } while (true);
    }
  }
}