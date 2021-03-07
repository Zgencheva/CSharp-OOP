using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace Stealer
{
    public class Spy
    {

        public string StealFieldInfo(string classToInvestigate, params string[] fieldsToInvestigate)
        {
            Type classType = Type.GetType(classToInvestigate);
            FieldInfo[] classFields = classType.GetFields(
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public
                );
            StringBuilder sb = new StringBuilder();

            Object classInstance = Activator.CreateInstance(classType, new object[] { });
            sb.AppendLine($"Class under investigation: {classToInvestigate}");

            foreach (FieldInfo field in classFields.Where(f => fieldsToInvestigate.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().Trim();

        }

        public string AnalyzeAcessModifiers(string classname)
        {
            Type classType = Type.GetType(classname);
            FieldInfo[] classFields = classType.GetFields(
                BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public
                );
            Object classInstance = Activator.CreateInstance(classType, new object[] { });
            MethodInfo[] publicMethods = classType.GetMethods(
                BindingFlags.Instance | BindingFlags.Public
                );
            MethodInfo[] nonPublicMethods = classType.GetMethods(
               BindingFlags.Instance | BindingFlags.NonPublic
               );
            StringBuilder sb = new StringBuilder();
            foreach (FieldInfo field in classFields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }
            foreach (MethodInfo method in nonPublicMethods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }
            foreach (MethodInfo method in publicMethods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }

            return sb.ToString().Trim();

        }

        public string RevealPrivateMethods(string className)
        {
            Type classType = Type.GetType(className);
            MethodInfo[] privateMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {classType.BaseType.Name}");
            foreach (MethodInfo method in privateMethods)
            {
                sb.AppendLine(method.Name);
            }
            return sb.ToString().Trim();
        }

        public string CollectGettersAndSetters(string className)
        {
            Type classType = Type.GetType(className);
            MethodInfo[] methods = classType.GetMethods(
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static
                );

            StringBuilder sb = new StringBuilder();
            
            foreach (MethodInfo method in methods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
            }

            foreach (MethodInfo method in methods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} will set field of {method.ReturnType}");
            }
            return sb.ToString().Trim();
        }

    }
}
