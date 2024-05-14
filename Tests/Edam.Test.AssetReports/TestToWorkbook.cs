using Edam.Data.AssetReport;
using Edam.Text;
using Edam.Test.Library.Application;
using System.Diagnostics;
using Edam.Diagnostics;
using Edam.InOut;
using Edam.Test.Library.Project;
using Edam.Data.AssetConsole;
namespace Edam.Test.AssetReports
{
   [TestClass]
   public class TestToWorkbook
   {

      [TestInitialize]
      public void InitializeEnvironment()
      {
         ApplicationHelpers.InitializeApplication();
         Debug.Print("Initialized...");
      }

      [TestMethod]
      public void PrepareWorkbook()
      {
         ItemBaseInfo item = ProjectHelper.GetProjectItem(
            "Projects/Datovy.HC.CD/" +
            "Arguments/0002.HC.CD.Custom.ToDictionary.Args.json");
         ResultsLog<object> presults = ProjectHelper.ProcessItem(item);

         if (!presults.Success)
         {
            // TODO: put some assertions here...
            return;
         }

         // get arguments...
         AssetConsoleArgumentsInfo args = (AssetConsoleArgumentsInfo)
            presults.ResultValueObject;

         // preapre workbook
         AssetReportBuilder.ToWorkbookFile(args);
      }

   }
}