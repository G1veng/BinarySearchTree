using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BuildingTree
{
  class File
  {
    static public void SaveInFile(Node binaryTree)
    {
      string path = "";
      do
      {
        Console.WriteLine("Please enter path to file");
        path = Console.ReadLine();
        FileInfo tempFile = new FileInfo(path);
        if (!tempFile.Exists)
        {
          try
          {
            StreamWriter newFile = new StreamWriter(path);
            newFile.Close();
          }
          catch
          {
            Console.WriteLine("Bad name for file, please try again");
            continue;
          }
        }
        if (tempFile.Exists)
        {
          if (tempFile.IsReadOnly)
          {
            Console.WriteLine("Something wrong with file. please try again");
            continue;
          }
          else
          {
            Console.WriteLine("Do you want to rewrite file?" + Environment.NewLine + "1 - Yes");
            if (Input.GetInt() != 1)
            {
              continue;
            }
          }
        }
        tempFile.Delete();
        break;
      }
      while (true);

      List<int> array = binaryTree.PreOrder();
      StreamWriter file = new StreamWriter(path);
      for (int i = 0; i < array.Count; i++)
      {
        file.WriteLine(array[i].ToString());
      }
      file.Close();
      Console.WriteLine("File saved");
    }
    static public Node GetDataFromFile()
    {
      Node binaryTree = new Node();
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
