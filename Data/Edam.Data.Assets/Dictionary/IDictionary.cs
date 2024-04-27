using Edam.Data.Assets.Dictionary;
using Edam.Data.Dictionary;
using Edam.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edam.Data.Dictionary
{

   public interface IDictionary
   {

      ResultsLog<ITermInfo?> FindTerm(
         ITermInfo term, DictionaryType type = DictionaryType.Term);
      ResultsLog<ITermInfo?> AddTerm(ITermInfo term,
         DictionaryType type = DictionaryType.Term);
      ResultsLog<ITermInfo?> RemoveTerm(ITermInfo term,
         DictionaryType type = DictionaryType.Term);

      IResultsLog SaveChanges();

   }

}
