using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingTree
{
  static class GetInput
  {
    public enum UserChoice
    {
      ConsoleInput = 1,
      FileInput,
      RandomInput,
      End
    }
    static public IInputData GetSomeInput(int choice)
    {
      IInputData someInput = null;
      if((UserChoice)choice == UserChoice.RandomInput)
      {
        someInput = new RandomInput();
      }
      if((UserChoice)choice == UserChoice.FileInput)
      {
        someInput = new FileInput();
      }
      if((UserChoice)choice == UserChoice.ConsoleInput)
      {
        someInput = null;
      }
      return someInput;
    }
  }
}
