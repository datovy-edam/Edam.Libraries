using Edam.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edam.Data.Dictionary.Api
{

   public class LookUpResultInfo
   {

      public DictionaryContext Context { get; set; } = null;
      public IResultsLog ResultsLog { get; set; } = new ResultLog();

      public ITermInfo CurrentTerm { get; set; } = null;
      public ITermInfo ProcessedTerm { get; set; } = null;

      public int Acknowleged { get; set; }
      public int NotAcknowledge { get; set; }

      public int Found { get; set; }
      public int NotFound { get; set; }

      public LookUpResultInfo()
      {
         Acknowleged = 0;
         NotAcknowledge = 0;
      }
   }

}
