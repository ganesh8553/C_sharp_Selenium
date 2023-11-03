

using NUnit.Framework;
using System.Reflection;

namespace WinFormsApp3
{
    public class Utilities
    {
        public List<MethodInfo> GetAllTestMethodsFromTestProject()
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            string dllpath = AppDomain.CurrentDomain.GetAssemblies().Where(a => a.ManifestModule.Name.Equals("BenefitPro.dll")).FirstOrDefault().Location;
            Assembly assembly = Assembly.LoadFrom(dllpath);
            var types = assembly.GetTypes();
            List<MethodInfo> testMethods = new List<MethodInfo>();

            foreach (var t in types)
            {
                var methodInfos = t.GetMethods().Where(m => m.GetCustomAttributes(typeof(TestAttribute), false).Length > 0);
                testMethods.AddRange(methodInfos);
            }
            
            return testMethods;
        }
    }
}
