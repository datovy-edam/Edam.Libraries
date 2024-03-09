using Python.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// -----------------------------------------------------------------------------
// https://pythonnet.github.io/pythonnet/dotnet.html

namespace Edam.Language.Python
{

   /// <summary>
   /// Encapsulate the Python Intepreter.
   /// </summary>
   public class Interpreter : IDisposable
   {

      /// <summary>
      /// Global Interpreter Lock.
      /// </summary>
      private Py.GILState? _GIL = null;

      private dynamic? _os = null;
      private dynamic? _sys = null;

      public Interpreter()
      {
         Runtime.PythonDLL = PythonHelper.GetPythonDllPath();
         PythonEngine.Initialize();
      }

      /// <summary>
      /// Get Global Interpter Lock.
      /// </summary>
      /// <returns></returns>
      public Py.GILState GetLock()
      {
         _GIL = _GIL ?? Py.GIL();
         return _GIL;
      }

      /// <summary>
      /// Release Global Interpreter Lock by disposing it.
      /// </summary>
      public void ReleaseLock()
      {
         Dispose();
      }

      /// <summary>
      /// Get Script with given 
      /// </summary>
      /// <param name="scriptName">script / module name</param>
      /// <param name="scriptPath">script path (optional)</param>
      /// <returns></returns>
      public PyObject? GetScript(string scriptName, string? scriptPath = null)
      {
         string mpath =
            PythonHelper.GetPythonModulePath(scriptName, scriptPath);

         _os = _os ?? Py.Import("os");
         _sys = _sys ?? Py.Import("sys");

         _sys.path.append(_os.path.dirname(_os.path.expanduser(mpath)));
         return Py.Import(Path.GetFileNameWithoutExtension(mpath));
      }

      /// <summary>
      /// Run Script.
      /// </summary>
      /// <param name="scriptName">script name</param>
      /// <param name="scriptPath">script path (optional)</param>
      /// <returns></returns>
      public PyObject? RunScript(
         string scriptName, string? scriptPath = null)
      {
         GetLock();
         PyObject? script = GetScript(scriptName, scriptPath);
         return script.InvokeMethod(script);
      }

      /// <summary>
      /// Dispose / release interpreter lock resources.
      /// </summary>
      public void Dispose()
      {
         if (_GIL != null)
         {
            _GIL.Dispose();
            _GIL = null;
         }
      }

   }

}
