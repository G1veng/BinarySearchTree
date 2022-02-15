using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingTree
{
  public class Tree
  {
    private Node firstNode;
    static public int nesting = 0;
    static public int maxNesting = 0;
    public Tree()
    {
      firstNode = null;
    }
    public void Add(int data)
    {
      AddInner(data, firstNode);
    }
    private void AddInner(int data, Node currentNode)
    {
      if (currentNode == null)
      {
        this.firstNode = new Node();
        this.firstNode.SetData(data);
      }
      if (currentNode != null)
      {
        if (data < currentNode.GetData())
        {
          if (currentNode.GetLeft() != null)
          {
            AddInner(data, currentNode.GetLeft());
          }
          if (currentNode.GetLeft() == null)
          {
            currentNode.SetLeft(new Node());
            currentNode.GetLeft().SetData(data);
            currentNode.GetLeft().SetParent(currentNode);
          }
        }
        if (data > currentNode.GetData())
        {
          if (currentNode.GetRight() != null)
          {
            AddInner(data, currentNode.GetRight());
          }
          if (currentNode.GetRight() == null)
          {
            currentNode.SetRight(new Node());
            currentNode.GetRight().SetData(data);
            currentNode.GetRight().SetParent(currentNode);
          }
        }
      }
    }
    public void DeleteElement(int data)
    {
      DeleteElementInner(data, firstNode);
    }
    private void DeleteElementInner(int data, Node currentNode)
    {
      if (currentNode.GetData() != data)
      {
        if (currentNode.GetLeft() != null)
        {
          DeleteElementInner(data, currentNode.GetLeft());
        }
        if (currentNode.GetRight() != null)
        {
          DeleteElementInner(data, currentNode.GetRight());
        }
      }
      if (currentNode.GetData() == data)
      {
        if (currentNode.GetRight() == null && currentNode.GetLeft() == null)
        {
          if (firstNode != currentNode)
          {
            if (currentNode.GetParent().GetLeft() != null && currentNode.GetParent().GetLeft().GetData() == data)
            {
              currentNode.GetParent().SetLeft(null);
            }
            if (currentNode.GetParent().GetRight() != null && currentNode.GetParent().GetRight().GetData() == data)
            {
              currentNode.GetParent().SetRight(null);
            }
          }
          if (firstNode == currentNode)
          {
            firstNode.SetData(0);
          }
        }
        if (currentNode.GetRight() == null && currentNode.GetLeft() != null)
        {
          if (firstNode != currentNode)
          {
            if (currentNode.GetParent().GetLeft() != null)
            {
              if (currentNode.GetParent().GetLeft().GetData() == data)
              {
                currentNode.GetParent().SetLeft(currentNode.GetLeft());
                currentNode.GetLeft().SetParent(currentNode.GetParent());
              }
            }
            if (currentNode.GetParent().GetRight() != null)
            {
              if (currentNode.GetParent().GetRight().GetData() == data)
              {
                currentNode.GetParent().SetRight(currentNode.GetLeft());
                currentNode.GetLeft().SetParent(currentNode.GetParent());
              }
            }
          }
          if (firstNode == currentNode)
          {
            currentNode.SetData(currentNode.GetLeft().GetData());
            currentNode.SetRight(currentNode.GetLeft().GetRight());
            currentNode.SetLeft(currentNode.GetLeft().GetLeft());
          }
        }
        if (currentNode.GetRight() != null && currentNode.GetLeft() == null)
        {
          if (firstNode != currentNode)
          {
            if (currentNode.GetParent().GetLeft() != null)
            {
              if (currentNode.GetParent().GetLeft().GetData() == data)
              {
                currentNode.GetParent().SetLeft(currentNode.GetRight());
                currentNode.GetRight().SetParent(currentNode.GetParent());
              }
            }
            if (currentNode.GetParent().GetRight() != null)
            {
              if (currentNode.GetParent().GetRight().GetData() == data)
              {
                currentNode.GetParent().SetRight(currentNode.GetRight());
                currentNode.GetRight().SetParent(currentNode.GetParent());
              }
            }
          }
          if (firstNode == currentNode)
          {
            currentNode.SetData(currentNode.GetRight().GetData());
            currentNode.SetLeft(currentNode.GetRight().GetLeft());
            currentNode.SetRight(currentNode.GetRight().GetRight());
          }
        }
        if (currentNode.GetRight() != null && currentNode.GetLeft() != null)
        {
          if (currentNode != firstNode)
          {
            var lowestElement = FindNext(currentNode);
            currentNode.SetData(lowestElement.GetData());
            if (lowestElement.GetRight() == null)
            {
              if (lowestElement.GetParent().GetLeft() != null && lowestElement.GetParent().GetLeft().GetData() == lowestElement.GetData())
              {
                lowestElement.GetParent().SetLeft(null);
              }
              if (lowestElement.GetParent().GetRight() != null && lowestElement.GetParent().GetRight().GetData() == lowestElement.GetData())
              {
                lowestElement.GetParent().SetRight(null);
              }
            }
            if (lowestElement.GetRight() != null)
            {
              if (lowestElement.GetParent().GetLeft().GetData() == lowestElement.GetData())
              {
                lowestElement.GetParent().SetLeft(lowestElement.GetRight());
                lowestElement.GetRight().SetParent(lowestElement.GetParent());
              }
              if (lowestElement.GetParent().GetRight().GetData() == lowestElement.GetData())
              {
                lowestElement.GetParent().SetRight(lowestElement.GetRight());
                lowestElement.GetRight().SetParent(lowestElement.GetParent());
              }
            }
          }
          if (firstNode == currentNode)
          {
            var arrayList = PreOrder();
            arrayList.Remove(currentNode.GetData());
            arrayList.Remove(currentNode.GetRight().GetData());
            arrayList.Insert(0, currentNode.GetRight().GetData());
            ClearTree();
            for (int i = 0; i < arrayList.Count; i++)
            {
              Add(arrayList[i]);
            }
          }
        }
      }
      if(firstNode.GetRight() == null && firstNode.GetLeft() == null && firstNode.GetData() == 0)
      {
        ClearTree();
      }
    }
    public List<int> PreOrder()
    {
      List<int> arrayList = new List<int>();
      PreOrderInner(arrayList, firstNode);
      return arrayList;
    }
    public List<int> InOrder()
    {
      List<int> arrayList = new List<int>();
      InOrderInner(arrayList, firstNode);
      return arrayList;
    }
    public List<int> PostOrder()
    {
      List<int> arrayList = new List<int>();
      PostOrderInner(arrayList, firstNode);
      return arrayList;
    }
    private void PreOrderInner(List<int> listArray, Node currentNode)
    {
      listArray.Add(currentNode.GetData());
      if (currentNode.GetLeft() != null)
      {
        PreOrderInner(listArray, currentNode.GetLeft());
      }
      if (currentNode.GetRight() != null)
      {
        PreOrderInner(listArray, currentNode.GetRight());
      }
    }
    private void InOrderInner(List<int> listArray, Node currentNode)
    {
      if (currentNode.GetLeft() != null)
      {
        InOrderInner(listArray, currentNode.GetLeft()); 
      }
      listArray.Add(currentNode.GetData());
      if (currentNode.GetRight() != null)
      {
        InOrderInner(listArray, currentNode.GetRight());
      }
    }
    private void PostOrderInner(List<int> listArray, Node currentNode)
    {
      if (currentNode.GetLeft() != null)
      {
        PostOrderInner(listArray, currentNode.GetLeft());
      }
      if (currentNode.GetRight() != null)
      {
        PostOrderInner(listArray, currentNode.GetRight());
      }
      listArray.Add(currentNode.GetData());
    }
    public Node FindMinimum()
    {
      return FindMinimumInner(firstNode);
    }
    private Node FindMinimumInner(Node currentNode)
    {
      if (currentNode.GetLeft() == null)
      {
        return currentNode;
      }
      return FindMinimumInner(currentNode.GetLeft());
    }
    public Node FindNext(Node currentNode)
    {
      return FindNextInner(currentNode);
    }
    private Node FindNextInner(Node currentNode)
    {
      return FindMinimumInner(currentNode.GetRight());
    }
    public void ShowBinaryTree()
    {
      maxNesting = 0;
      DepthOfTree();
      string[] treeInString = new string[maxNesting + 1];
      for (int i = 0; i < maxNesting + 1; i++)
      {
        treeInString[i] = "";
      }
      ShowBinaryTreeInner(treeInString, firstNode);
    }
    private void ShowBinaryTreeInner(string[] treeInString, Node currentNode)
    {
      int countOfNumbersOnLastLayer = Convert.ToInt32(Math.Pow(2.0, Convert.ToDouble(maxNesting)));
      int countOfNumbersOnLayer = Convert.ToInt32(Math.Pow(2.0, Convert.ToDouble(nesting)));
      var count = countOfNumbersOnLastLayer / countOfNumbersOnLayer;
      if (treeInString[nesting] == "")
      {
        for (int i = 0; i < count - 1; i++)
        {
          treeInString[nesting] += " ";
        }
      }
      else
      {
        for (int i = 0; i < (count * 2) - 1; i++)
        {
          treeInString[nesting] += " ";
        }
      }
      treeInString[nesting] += currentNode.GetData();
      if (currentNode.GetLeft() != null)
      {
        nesting++;
        ShowBinaryTreeInner(treeInString, currentNode.GetLeft());
        nesting--;
      }
      if (currentNode.GetLeft() == null && nesting != maxNesting)
      {
        for (int i = nesting + 1; i < maxNesting + 1; i++)
        {
          int tempCountOfNumbersOnLayer = Convert.ToInt32(Math.Pow(2.0, Convert.ToDouble(i)));
          int newCount = countOfNumbersOnLastLayer / tempCountOfNumbersOnLayer;
          for (int j = 0; j < Convert.ToInt32(Math.Pow(2.0, Convert.ToDouble(i - (nesting + 1)))); j++)
          {
            if (treeInString[i] == "")
            {
              for (int k = 0; k < newCount - 1; k++)
              {
                treeInString[i] += " ";
              }
              treeInString[i] += ".";
            }
            else
            {
              for (int k = 0; k < (newCount * 2) - 1; k++)
              {
                treeInString[i] += " ";
              }
              treeInString[i] += ".";
            }
          }
        }
      }
      if (currentNode.GetRight() != null)
      {
        nesting++;
        ShowBinaryTreeInner(treeInString, currentNode.GetRight());
        nesting--;
      }
      if (currentNode.GetRight() == null && nesting != maxNesting)
      {
        for (int i = nesting + 1; i < maxNesting + 1; i++)
        {
          int tempCountOfNumbersOnLayer = Convert.ToInt32(Math.Pow(2.0, Convert.ToDouble(i)));
          int newCount = countOfNumbersOnLastLayer / tempCountOfNumbersOnLayer;
          for (int j = 0; j < Convert.ToInt32(Math.Pow(2.0, Convert.ToDouble(i - (nesting + 1)))); j++)
          {
            if (treeInString[i] == "")
            {
              for (int k = 0; k < newCount - 1; k++)
              {
                treeInString[i] += " ";
              }
              treeInString[i] += ".";
            }
            else
            {
              for (int k = 0; k < (newCount * 2) - 1; k++)
              {
                treeInString[i] += " ";
              }
              treeInString[i] += ".";
            }
          }
        }
      }
      if (nesting == 0)
      {
        for (int i = 0; i < maxNesting + 1; i++)
        {
          Console.WriteLine(treeInString[i]);
        }
      }
    }
    public void DepthOfTree()
    {
      DepthOfTreeInner(firstNode);
    }
    private void DepthOfTreeInner(Node currentNode)
    {
      if (maxNesting < nesting)
      {
        maxNesting = nesting;
      }
      if (currentNode.GetLeft() != null)
      {
        nesting++;
        DepthOfTreeInner(currentNode.GetLeft());
        nesting--;
      }
      if (currentNode.GetRight() != null)
      {
        nesting++;
        DepthOfTreeInner(currentNode.GetRight());
        nesting--;
      }
    }
    public bool EmptyTree()
    {
      if (firstNode == null)
      {
        return true;
      }
      else
      {
        return false;
      }
    }
    public void ClearTree()
    {
      firstNode = null;
    }
  }
}