using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Edam.Language;
using Edam.Diagnostics;

namespace Edam.Data.Lexicon.Semantics
{

   /// <summary>
   /// Helper class to get the semantic text similarities.
   /// </summary>
   public class TextSimilarity
   {
      public const string SEMANTIC_TEXT_SIMILARITY_INSTANCE = 
         "SEMANTIC_TEXT_SIMILARITY_INSTANCE";

      public const string SCRIPT_SEMANTIC_TEXT_SIMILARITY = 
         "semanticTextSimilarity";
      public const string METHOD_GET_TEXT_SIMILARITY_SCORE = 
         "get_TextSimilarityScore";

      private ITextSimilarity m_Instance;

      public TextSimilarity() 
      {
         m_Instance = LexiconHelper.GetTextSimilarityInstance();
      }

      /// <summary>
      /// Do a similarity test and return its score.
      /// </summary>
      /// <param name="text1">sentence / text 1</param>
      /// <param name="text2">sentence / text 2</param>
      /// <returns>similarity score is returned</returns>
      public ITextSimilarityScore Semilarity(string text1, string text2)
      {
         Parameters parameters = new Parameters();
         parameters.Add("text1", text1);
         parameters.Add("text2", text2);
         var results = m_Instance.ExecuteScript(
            SCRIPT_SEMANTIC_TEXT_SIMILARITY, METHOD_GET_TEXT_SIMILARITY_SCORE,
            parameters);
         dynamic? value = results.ResultValueObject as dynamic;

         return value as ITextSimilarityScore;
      }

      /// <summary>
      /// Do a similarity test and return its score.
      /// </summary>
      /// <param name="text1">sentence / text 1</param>
      /// <param name="text2">sentence / text 2</param>
      /// <returns>similarity score is returned</returns>
      public static ITextSimilarityScore GetSimilarityScore(
         string text1, string text2)
      {
         TextSimilarity textSimilarity = new TextSimilarity();
         return textSimilarity.Semilarity(text1, text2);
      }

   }

}
