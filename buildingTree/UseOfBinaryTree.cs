using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingTree
{
  class UseOfBinaryTree
  {
    enum Interaction
    {
      AddElement = 1,
      ShowTree,
      DeleteElement,
      ClearTree,
      SaveData,
      GoBack
    }
    public static void Interact(Tree binaryTree)
    {
      Interaction choice;
      do
      {
        Console.WriteLine(Environment.NewLine + "1 - Add element" + Environment.NewLine + "2 - Show tree" +
          Environment.NewLine + "3 - Delete element" + Environment.NewLine + "4 - Clear tree "+ Environment.NewLine
          +"5 - Save data" + Environment.NewLine + "6 - Return");
        choice = (Interaction)Input.GetInt();
        if (choice == Interaction.AddElement)
        {
          int data = Input.GetInt();
          binaryTree.Add(data);
          Console.WriteLine(" ");
        }
        if (choice == Interaction.ShowTree)
        {
          if (!binaryTree.EmptyTree())
          {
            Console.WriteLine("Binary tree:" + Environment.NewLine);
            binaryTree.ShowBinaryTree();
          }
          else
          {
            Console.WriteLine("Tree is empty");
          }
        }
        if (choice == Interaction.DeleteElement)
        {
          if (!binaryTree.EmptyTree())
          {
            int data = Input.GetInt();
            binaryTree.DeleteElement(data);
          }
          else
          {
            Console.WriteLine("Tree is empty");
          }
        }
        if(choice == Interaction.ClearTree)
        {
          if (!binaryTree.EmptyTree())
          {
            binaryTree.ClearTree();
          }
          if (binaryTree.EmptyTree())
          {
            Console.WriteLine("Tree is empty");
          }
        }
        if (choice == Interaction.SaveData)
        {
          File.SaveInFile(binaryTree);
        }
        if (choice > Interaction.GoBack || choice < Interaction.AddElement)
        {
          Console.WriteLine("We have not these choice, plese try again");
        }
      } while (choice != Interaction.GoBack);
    }
  }
}
