using Edam.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edam.Data.Lexicon.Semantics
{

   public class ITextSimilarityScore
   {
      IResultsLog Results { get; set; }
      string? Text1 { get; set; } = null;
      string? Text2 { get; set; } = null;
      int Index { get; set; } = -1;
      float Score { get; set; } = 0;
   }

}
