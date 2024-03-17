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
         string scriptName = @"semanticTextSimilarity";
         Parameters parameters = new Parameters();
         parameters.Add("text1", "The person starved");
         parameters.Add("text2", "The man is starving");
         PythonHelper.RunScript(
            scriptName, "get_TextSimilarityScore", parameters);
      }
   }
}
