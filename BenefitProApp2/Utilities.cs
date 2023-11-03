using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BenefitProApp2
{
    public class Utilities
    {
        public List<MethodInfo> GetAllTestMethodsFromTestProject()
        {
            Assembly[] assemblies= AppDomain.CurrentDomain.GetAssemblies(); 
            string dllpath = AppDomain.CurrentDomain.GetAssemblies().Where(a => a.ManifestModule.Name.Equals("BenefitPro1.dll")).FirstOrDefault().Location;
            Assembly assembly = Assembly.LoadFrom(dllpath);
            var types = assembly.GetTypes();
            List<MethodInfo> testMethods = new List<MethodInfo>();

            foreach (var t in types)
            {
                var typeAttr = t.GetCustomAttribute(typeof(TestClassAttribute));
                var methods = t.GetMethods();
                foreach (var m in methods)
                {
                    var methodAttr = m.GetCustomAttribute(typeof(TestMethodAttribute));
                    if (methodAttr != null)
                    {
                        testMethods.Add(m);
                    }
                }
            }
            return testMethods;
        }

    }
}
