using Edam.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Edam.Data.Assets.AssetReport
{

   public class AssetReportItemInfo : ITableHeaderItem
   {

      public string ItemName { get; set; }
      public string ElementName { get; set; }
      public string Name { get; set; }
      public string Description { get; set; }
      public string Format { get; set; }
      public object Value { get; set; }

      public AssetReportItemInfo()
      {
      }

      public AssetReportItemInfo(
         string elementName = null, string name = null, 
         string description = null, string format = null)
      {
         ElementName = elementName;
         Name = name;
         Description = description;
         Format = format;
      }

      /// <summary>
      /// Validate and setup properties as needed.
      /// </summary>
      public void Validate()
      {
         if (String.IsNullOrWhiteSpace(ElementName))
         {
            ElementName = Name;
         }
         else if (String.IsNullOrWhiteSpace(Name))
         {
            Name = ElementName;
         }
         if (String.IsNullOrWhiteSpace(Description))
         {
            Description = Name;
         }
      }

   }

}
