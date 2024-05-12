using asset = Edam.Data.Asset;
using Edam.Data.AssetReport;
using Edam.Data.AssetSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edam.Text;

namespace Edam.Data.Assets.AssetReport
{

   public class ElementMapper
   {
      private const string TYPE_TYPE = "type";
      private const string TYPE_ROOT = "root";
      private const string ENUM = "enumerator";

      private const string TAG_PII = "PII";
      private const string TAG_PCI = "PCI";
      private const string TAG_SENSITIVE = "Sensitive";
      private const string TAG_CONFIDENTIAL = "Confidential";

      private IAssetElement _Element;
      private ITableRowHeader _Header;

      private Type _Type;

      public string Annotation
      {
         get { return AssetDataElement.GetAnnotattion(_Element); }
      }

      public string ItemStatus
      {
         get { return _Element.AssetStatus?.ToString(); }
      }

      public string Comments
      {
         get { return _Element.CommentText; }
      }

      public string DataType
      {
         get { return _Element.DataType ?? _Element.TypeName; }
      }

      public string EntityQualifiedNameText
      {
         get { return _Element.EntityQualifiedNameText; }
      }

      public string ElementQualifiedNameText
      {
         get { return (_Element.ElementType == asset.ElementType.attribute ?
            "@" : string.Empty) + _Element.ElementQualifiedNameText; }
      }

      public string Entity
      {
         get
         {
            return EntityQualifiedNameText;
         }
      }

      public string Element
      {
         get
         {
            return ElementQualifiedNameText;
         }
      }

      public string ElementNo
      {
         get { return _Element.ElementNo.ToString(); }
      }

      public string ElementType
      {
         get { return _Element.ElementType.ToString(); }
      }

      public string FullPath
      {
         get { return _Element.GetFullPath(); }
      }

      public string MaxLength
      {
         get { return _Element.Length.HasValue ?
            _Element.Length.Value.ToString() : string.Empty; }
      }

      public string LastUpdateDate
      {
         get { return _Element.LastUpdateDate?.ToString(); }
      }

      public string Occurrence
      {
         get { return _Element.Occurs.Replace(" ", ""); }
      }

      public string Precision
      {
         get
         {
            return _Element.Precision.HasValue ?
               _Element.Precision.Value.ToString() : String.Empty;
         }
      }

      public string Scale
      {
         get
         {
            return _Element.Scale.HasValue ?
               _Element.Scale.Value.ToString() : String.Empty;
         }
      }

      public string TagConfidential
      {
         get
         {
            return _Element.Tags.Contains(TAG_CONFIDENTIAL) ?
               TAG_CONFIDENTIAL : String.Empty;
         }
      }

      public string TagSensitive
      {
         get
         {
            return _Element.Tags.Contains(TAG_SENSITIVE) ?
               TAG_SENSITIVE : String.Empty;
         }
      }

      public string TagPII
      {
         get
         {
            return _Element.Tags.Contains(TAG_PII) ? TAG_PII : String.Empty;
         }
      }

      public string TagPCI
      {
         get
         {
            return _Element.Tags.Contains(TAG_PCI) ? TAG_PCI : String.Empty;
         }
      }

      public uint RowStyle
      {
         get
         {
            uint styleNo;
            string etype = ElementType.ToLower();
            if (etype == TYPE_TYPE || etype == TYPE_ROOT)
            {
               styleNo = (uint)TableRowStyle.Fill4Border1Font12;
            }
            else if (etype.ToLower() == ENUM)
            {
               styleNo = (uint)TableRowStyle.Fill1Border1Font12;
            }
            else
               styleNo = (uint)TableRowStyle.Fill1Font12;
            return styleNo;
         }
      }

      public string SampleValue
      {
         get { return _Element.SampleValue; }
      }

      public string URI
      {
         get { return _Element.Namespace; }
      }

      public string Value
      {
         get { return string.IsNullOrWhiteSpace(_Element.DefaultValue) ?
            string.Empty : _Element.DefaultValue;
         }
      }

      /// <summary>
      /// Initialize Mapper
      /// </summary>
      /// <param name="item"></param>
      /// <param name="header"></param>
      public ElementMapper(IAssetElement item, ITableRowHeader header)
      {
         _Element = item;
         _Header = header;
         _Type = this.GetType();
      }

      /// <summary>
      /// Get Text Value with given property name.
      /// </summary>
      /// <param name="propertyName">property name</param>
      /// <returns>text value is returned</returns>
      public string GetValueText(string propertyName)
      {
         return _Type.GetProperty(propertyName).GetValue(this, null).ToString();
      }

      /// <summary>
      /// Get Values.
      /// </summary>
      /// <remarks>if a value is specified in the header and none is found on
      /// the _Element then the header value is returned and assumed to be the
      /// default value</remarks>
      /// <returns>number of found values are returned</returns>
      public int GetValues()
      {
         int cnt = 0;
         foreach(var item in _Header.Items)
         {
            var value = GetValueText(item.ItemName);
            if (String.IsNullOrWhiteSpace(value))
            {
               value = String.IsNullOrWhiteSpace(item.Value == null ?
                  String.Empty : item.Value.ToString()) ?
                  String.Empty : item.Value.ToString();
            }
            item.Value = value;
            cnt++;
         }
         return cnt;
      }

   }

}
