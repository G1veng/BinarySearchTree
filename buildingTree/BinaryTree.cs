using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingTree
{
  public class Node
  {
    private int data;
    private Node parent;
    private Node left;
    private Node right;

    public Node()
    {
      parent = null;
      left = null;
      right = null;
      data = 0;
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
  }
}
