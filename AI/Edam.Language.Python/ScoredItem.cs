using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edam.Language.Python
{

   public class ScoredItem
   {

      public string Text1 { get; set; }
      public string Text2 { get; set; }
      public int Index { get; set; }
      public float Score { get; set; }

      public ScoredItem(dynamic pythonObject)
      {
         Text1 = pythonObject.text1;
         Text2 = pythonObject.text2;
         Index = pythonObject.index;
         Score = pythonObject.score;
      }

   }

}
