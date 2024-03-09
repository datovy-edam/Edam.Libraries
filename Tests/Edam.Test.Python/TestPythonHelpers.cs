using Edam.Language.Python;
using System.Diagnostics;
using Edam.Test.Library.Application;

namespace Edam.Test.Python
{
   [TestClass]
   public class TestPythonHelpers
   {

      [TestInitialize]
      public void InitializeEnvironment()
      {
         ApplicationHelpers.InitializeApplication();
         Debug.Print("Initialized...");
      }

      [TestMethod]
      public void TestPythonModules()
      {
         PythonHelper.RunScript(@"python_sample1");
      }
   }
}