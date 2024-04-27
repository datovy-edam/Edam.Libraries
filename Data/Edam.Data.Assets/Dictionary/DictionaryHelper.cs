
using Edam.Language;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Edam.Application;
using Edam.Data.AssetSchema;
using Edam.Data.Dictionary.Api;

namespace Edam.Data.Dictionary
{

   public class DictionaryHelper
   {

      public static IDictionaryApi GetDictionaryApiInstance()
      {
         return AppAssembly.FetchInstance<IDictionaryApi>(
            AssetResourceHelper.ASSET_PYTHON_LANGUAGE);
      }

   }

}
