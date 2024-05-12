using Edam.Data.AssetReport;
namespace Edam.Test.AssetReports
{
   [TestClass]
   public class TestReportHeader
   {
      public const string REPORTS_PATH = "C:\\prjs\\Edam\\Edam.Consoles\\Edam.Studio\\Edam.Studio\\ApplicationData\\Edam.Studio\\Edam.App.Data\\Reports";
      [TestMethod]
      public void LoadHeader()
      {
         string reportFullPath = REPORTS_PATH + "/AssetReportHeaderStandard.json";
         AssetReportHeaderInfo headers = 
            AssetReportHeaderInfo.FromJson(reportFullPath);
         Assert.IsNotNull(headers);
      }
   }
}