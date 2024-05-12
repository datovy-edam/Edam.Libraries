using Edam.Data.Assets.AssetReport;
using Edam.Serialization;
using Edam.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Edam.Data.AssetReport
{

   public class AssetReportHeaderInfo : ITableRowHeader
   {

      public const string DEFAULT_MAIN_HEADER = 
         "AssetNo,AssetStatus,LastUpdateDate," +
         "Entity,Element,Value,Type,ElementType,Length,Occurs,Comment," +
         "Annotation,Sample,Namespace,FullPath";

      public List<ITableHeaderItem> Items { get; set; } =
         new List<ITableHeaderItem>();

      /// <summary>
      /// Create a header given a comma delimited string of headers.
      /// </summary>
      /// <param name="commaDelimitedText">comma delimited string of headers. 
      /// if text is empty or null then the DEFAULT_MAIN_HEADER will be used
      /// instead</param>
      /// <returns>instance of list is returned</returns>
      public static List<ITableHeaderItem> GetItems(
         string commaDelimitedText = null)
      {
         if (String.IsNullOrWhiteSpace(commaDelimitedText))
         {
            commaDelimitedText = DEFAULT_MAIN_HEADER;
         }

         var l = commaDelimitedText.Split(',');
         var items = new List<ITableHeaderItem>();
         foreach (var item in l)
         {
            items.Add(new AssetReportItemInfo(name: item));
         }
         return items;
      }

      /// <summary>
      /// Get the headers as a comma delimited text string.
      /// </summary>
      /// <returns>text string is returned</returns>
      public string GetCommaDelimitedHeaders()
      {
         string csv = String.Empty;
         foreach(var item in Items)
         {
            csv += csv == String.Empty ?
               item.ElementName : ',' + item.ElementName;
         }
         return csv;
      }

      /// <summary>
      /// Get header items list from a JSON file.
      /// </summary>
      /// <param name="filePath">JSON file path</param>
      /// <returns>list of headers is returned</returns>
      public static AssetReportHeaderInfo FromJson(string filePath)
      {
         string jsonText = System.IO.File.ReadAllText(filePath);
         var results = 
            JsonSerializer.TryDeserialize<AssetReportHeaderInfo>(jsonText);
         if (results.Success)
         {
            foreach(var item in results.Data.Items)
            {
               item.Validate();
            }
         }
         return results.Success ? results.Data : null;
      }

   }

}
