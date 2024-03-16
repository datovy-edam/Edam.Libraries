using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Python.Runtime;

namespace Edam.Language.Python
{

   /// <summary>
   /// Helper to prepare Python parameters list.
   /// </summary>
   public class Parameters
   {
      private Dictionary<string, Object> m_Items = 
         new Dictionary<string, Object>();

      /// <summary>
      /// Add an string value.
      /// </summary>
      /// <param name="name">name of parameter</param>
      /// <param name="value">parameter value</param>
      public void Add(string name, string value)
      {
         m_Items.Add(name, value);
      }

      /// <summary>
      /// Add an integer value.
      /// </summary>
      /// <param name="name">name of parameter</param>
      /// <param name="value">parameter value</param>
      public void Add(string name, int value)
      {
         m_Items.Add(name, value);
      }

      /// <summary>
      /// Add an float value.
      /// </summary>
      /// <param name="name">name of parameter</param>
      /// <param name="value">parameter value</param>
      public void Add(string name, float value)
      {
         m_Items.Add(name, value);
      }

      /// <summary>
      /// Prepare a list of PyObjects that will be used as method parameters.
      /// </summary>
      /// <returns>PyObject array is returned</returns>
      public PyObject[] ToPyObjects()
      {
         PyObject[] result = new PyObject[m_Items.Count];
         int c = 0;
         foreach(object item in m_Items.Values)
         {
            var type = item.GetType();
            if (type.Name == "String")
            {
               result[c++] = new PyString((string) item);
            }
            else if (type.Name == "Int32")
            {
               result[c++] = new PyInt((int)item);
            }
            else if (type.Name == "Single")
            {
               result[c++] = new PyFloat((float)item);
            }
         }
         return result;
      }

   }

}
