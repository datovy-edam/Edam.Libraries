using Edam.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edam.Language.Python
{

   public class ReturnResults
   {
      public bool Success { get; set; } = false;
      public dynamic? Results { get; set; } = null;

      public ReturnResults() 
      {
      }
      public ReturnResults(dynamic? results)
      {
         Results = results;
      }

   }

}
