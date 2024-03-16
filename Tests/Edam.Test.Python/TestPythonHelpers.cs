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
         string scriptName = @"python_sample1";
         Parameters parameters = new Parameters();
         parameters.Add("something", "something");
         PythonHelper.RunScript(scriptName, "get_CurrentDirectory", parameters);
      }
   }
}
