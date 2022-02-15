using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingTree
{
  public class Node
  {
    public const int FirstNode = int.MaxValue;
    static public int nesting = 0;
    static public int maxNesting = 0;
    private int data;
    private Node parent;
    private Node left;
    private Node right;

    public Node()
    {
      parent = null;
      left = null;
      right = null;
      data = FirstNode;
    }
    public int GetData()
    {
      return data;
    }
    public void SetData(int newData)
    {
      data = newData;
    }
    public Node GetParent()
    {
      return parent;
    }
    public Node GetLeft()
    {
      return left;
    }
    public Node GetRight()
    {
      return right;
    }
    public void SetParent(Node newParent)
    {
      parent = newParent;
    }
    public void SetRight(Node newRight)
    {
      right = newRight;
    }
    public void SetLeft(Node newLeft)
    {
      left = newLeft;
    }
    public void Add(int data)
    {
      if (GetParent() == null && GetLeft() == null && GetRight() == null && GetData() == FirstNode)
      {
        SetData(data);
      }
      if (GetData() != FirstNode)
      {
        if (data < GetData())
        {
          if (GetLeft() != null)
          {
            GetLeft().Add(data);
          }
          if (GetLeft() == null)
          {
            SetLeft(new Node());
            GetLeft().SetData(data);
            GetLeft().SetParent(this);
          }
        }
        if (data > GetData())
        {
          if (GetRight() != null)
          {
            GetRight().Add(data);
          }
          if (GetRight() == null)
          {
            SetRight(new Node());
            GetRight().SetData(data);
            GetRight().SetParent(this);
          }
        }
      }
    }
    public void DeleteElement(int data)
    {
      if (GetData() != data)
      {
        if (GetLeft() != null)
        {
          GetLeft().DeleteElement(data);
        }
        if (GetRight() != null)
        {
          GetRight().DeleteElement(data);
        }
      }
      if (GetData() == data)
      {
        if (GetRight() == null && GetLeft() == null)
        {
          if (GetParent() != null)
          {
            if (GetParent().GetLeft() != null && GetParent().GetLeft().GetData() == data)
            {
              GetParent().SetLeft(null);
            }
            if (GetParent().GetRight() != null && GetParent().GetRight().GetData() == data)
            {
              GetParent().SetRight(null);
            }
          }
          if (GetParent() == null)
          {
            SetData(0);
          }
        }
        if (GetRight() == null && GetLeft() != null)
        {
          if (GetParent() != null)
          {
            if (GetParent().GetLeft() != null)
            {
              if (GetParent().GetLeft().GetData() == data)
              {
                GetParent().SetLeft(GetLeft());
                GetLeft().SetParent(GetParent());
              }
            }
            if (GetParent().GetRight() != null)
            {
              if (GetParent().GetRight().GetData() == data)
              {
                GetParent().SetRight(GetLeft());
                GetLeft().SetParent(GetParent());
              }
            }
          }
          if (GetParent() == null)
          {
            SetData(GetLeft().GetData());
            SetLeft(GetLeft().GetLeft());
            SetRight(GetLeft().GetRight());
          }
        }
        if (GetRight() != null && GetLeft() == null)
        {
          if (GetParent() != null)
          {
            if (GetParent().GetLeft() != null)
            {
              if (GetParent().GetLeft().GetData() == data)
              {
                GetParent().SetLeft(GetRight());
                GetRight().SetParent(GetParent());
              }
            }
            if (GetParent().GetRight() != null)
            {
              if (GetParent().GetRight().GetData() == data)
              {
                GetParent().SetRight(GetRight());
                GetRight().SetParent(GetParent());
              }
            }
          }
          if (GetParent() == null)
          {
            SetData(GetRight().GetData());
            SetLeft(GetRight().GetLeft());
            SetRight(GetRight().GetRight());
          }
        }
        if (GetRight() != null && GetLeft() != null)
        {
          if (GetParent() != null)
          {
            var lowestElement = FindNext();
            SetData(lowestElement.GetData());
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
          if (GetParent() == null)
          {
            var arrayList = PreOrder();
            arrayList.Remove(GetData());
            arrayList.Remove(GetRight().GetData());
            arrayList.Insert(0, GetRight().GetData());
            ClearTree();
            for (int i = 0; i < arrayList.Count; i++)
            {
              Add(arrayList[i]);
            }
          }
        }
      }
    }
    public List<int> PreOrder()
    {
      List<int> arrayList = new List<int>();
      PreOrderInner(arrayList);
      return arrayList;
    }
    public List<int> InOrder()
    {
      List<int> arrayList = new List<int>();
      InOrderInner(arrayList);
      return arrayList;
    }
    public List<int> PostOrder()
    {
      List<int> arrayList = new List<int>();
      PostOrderInner(arrayList);
      return arrayList;
    }
    private void PreOrderInner(List<int> listArray)
    {
      listArray.Add(GetData());
      if (GetLeft() != null)
      {
        GetLeft().PreOrderInner(listArray);
      }
      if (GetRight() != null)
      {
        GetRight().PreOrderInner(listArray);
      }
    }
    private void InOrderInner(List<int> listArray)
    {
      if (GetLeft() != null)
      {
        GetLeft().PreOrderInner(listArray);
      }
      listArray.Add(GetData());
      if (GetRight() != null)
      {
        GetRight().PreOrderInner(listArray);
      }
    }
    private void PostOrderInner(List<int> listArray)
    {
      if (GetLeft() != null)
      {
        GetLeft().PreOrderInner(listArray);
      }
      if (GetRight() != null)
      {
        GetRight().PreOrderInner(listArray);
      }
      listArray.Add(GetData());
    }
    public Node FindMinimum()
    {
      if (GetLeft() == null)
      {
        return this;
      }
      return GetLeft().FindMinimum();
    }
    public Node FindNext()
    {
      return GetRight().FindMinimum();
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
      ShowBinaryTreeInner(treeInString);
    }
    private void ShowBinaryTreeInner(string[] treeInString)
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
      treeInString[nesting] += GetData();
      if (GetLeft() != null)
      {
        nesting++;
        GetLeft().ShowBinaryTreeInner(treeInString);
        nesting--;
      }
      if (GetLeft() == null && nesting != maxNesting)
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
      if (GetRight() != null)
      {
        nesting++;
        GetRight().ShowBinaryTreeInner(treeInString);
        nesting--;
      }
      if (GetRight() == null && nesting != maxNesting)
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
      if (maxNesting < nesting)
      {
        maxNesting = nesting;
      }
      if (GetLeft() != null)
      {
        nesting++;
        GetLeft().DepthOfTree();
        nesting--;
      }
      if (GetRight() != null)
      {
        nesting++;
        GetRight().DepthOfTree();
        nesting--;
      }
    }
    public bool EmptyTree()
    {
      if (GetLeft() == null && GetRight() == null && GetData() == FirstNode)
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
      SetLeft(null);
      SetRight(null);
      SetData(FirstNode);
    }
  }
}
