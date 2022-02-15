using Microsoft.VisualStudio.TestTools.UnitTesting;
using BuildingTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingTree.Tests
{
  [TestClass()]
  public class NodeTests
  {
    [TestMethod()]
    public void DeleteElementTest()
    {
      Tree binaryTree = new Tree();
      int[] array = new int[] { 6, 4, 8, 3, 7, 9 };
      List<int> resultOfTestOne = new List<int> { 6, 4, 3, 8, 9 };
      List<int> resultOfTestTwo = new List<int> { 6, 4, 3, 9 };
      List<int> resultOfTestThree = new List<int> { 6, 3, 9 };
      List<int> resultOfTestFour = new List<int> { 9, 3 };
      List<int> resultOfTestFive = new List<int> { 9, 3 };
      List<int> toDelete = new List<int> { 7, 8, 4, 6, 10 };
      List<List<int>> results = new List<List<int>> { resultOfTestOne, resultOfTestTwo, resultOfTestThree, resultOfTestFour, resultOfTestFive };
      for (int i = 0; i < 6; i++)
      {
        binaryTree.Add(array[i]);
      }
      for(int i = 0; i < toDelete.Count; i++)
      {
        binaryTree.DeleteElement(toDelete[i]);
        var createdArray = binaryTree.PreOrder();
        for(int j = 0; j < createdArray.Count; j++)
        {
          Assert.AreEqual(createdArray[j], results[i][j]);
        }
      }
    }
    [TestMethod()]
    public void AddTest()
    {
      Tree binaryTree = new Tree();
      int[] array = new int[] { 6, 4, 8, 3, 7, 9, 6 };
      List<int> resultOfTestOne = new List<int> { 6 };
      List<int> resultOfTestTwo = new List<int> { 6, 4 };
      List<int> resultOfTestThree = new List<int> { 6, 4, 8 };
      List<int> resultOfTestFour = new List<int> { 6, 4, 3, 8 };
      List<int> resultOfTestFive = new List<int> { 6, 4, 3, 8, 7 };
      List<int> resultOfTestFSix = new List<int> { 6, 4, 3, 8, 7, 9 };
      List<int> resultOfTestFSeven = new List<int> { 6, 4, 3, 8, 7, 9 };
      List<List<int>> results = new List<List<int>> {resultOfTestOne, resultOfTestTwo, resultOfTestThree, resultOfTestFour, resultOfTestFive,
      resultOfTestFSix, resultOfTestFSeven};
      for (int i = 0; i < 6; i++)
      {
        binaryTree.Add(array[i]);
        var createdArray = binaryTree.PreOrder();
        for (int j = 0; j < createdArray.Count; j++)
        {
          Assert.AreEqual(createdArray[j], results[i][j]);
        }
      }
    }
  }
}