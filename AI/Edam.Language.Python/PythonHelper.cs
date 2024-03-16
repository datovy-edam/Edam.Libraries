using Python.Runtime;
using Edam.Application;

namespace Edam.Language.Python
{

   public class PythonHelper
   {
      
      public static string GetPythonDllPath()
      {
         return AppSettings.GetSectionString("PythonDllPath");
      }

      public static string GetPythonModulesPath()
      {
         return AppSettings.GetSectionString("PythonModulesPath");
      }

      /// <summary>
      /// Get Python Module Script Path.
      /// </summary>
      /// <param name="scriptName">script name</param>
      /// <param name="scriptPath">script path</param>
      /// <returns>script full path is returned</returns>
      public static string GetPythonModulePath(
         string scriptName, string? scriptPath = null)
      {
         string ppath = String.IsNullOrWhiteSpace(scriptPath) ? 
            String.Empty : "\\" + scriptPath;
         return GetPythonModulesPath() + ppath + scriptName;
      }

      public static void RunScript(
         string scriptName, string methodName, Parameters? parameters = null)
      {
         string mpath = GetPythonModulesPath() + scriptName;
         string ddlPath = GetPythonDllPath();

         Runtime.PythonDLL = ddlPath;

         PythonEngine.Initialize();

         // prepare results
         PyObject? results = null;

         // using Python Global Interpreter Lock
         using (Py.GIL())
         {
            // prepare resources to invoke python methods
            dynamic os = Py.Import("os");
            dynamic sys = Py.Import("sys");

            sys.path.append(os.path.dirname(os.path.expanduser(mpath)));
            var fromFile = Py.Import(Path.GetFileNameWithoutExtension(mpath));

            // any parameters?
            if (parameters != null)
            {
               // setup parameters
               var plist = parameters.ToPyObjects();

               // invoke methods and get results...
               results = fromFile.InvokeMethod(methodName, plist);
            }
            else
            {
               // invoke methods and get results...
               results = fromFile.InvokeMethod(methodName);
            }
            
         }
      }
   }

}
