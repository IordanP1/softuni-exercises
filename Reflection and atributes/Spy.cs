using System.Reflection;
using System.Text;
namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
        {
            Console.WriteLine($"Class under investigation: {investigatedClass}");

           var type = Type.GetType(investigatedClass);
            var fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic|BindingFlags.Public);
            var searchedFileds = fields.Where(f => requestedFields.Contains(f.Name))
                .ToList();

            var istance = Activator.CreateInstance(type);
            var result = new StringBuilder();

            foreach (var field in fields)
            {
                var value = field.GetValue(istance);
                result.AppendLine($"{field.Name} = {value}");

                
            }
            return result.ToString();
        }
        public string AnalyzeAccessModifiers(string className)
        {
            var type = Type.GetType(className);

            var result = new StringBuilder();

            var fields = type.GetFields();

            foreach (var field in fields)
            {
                result.AppendLine($"{field.Name} must be private!");
            }
            var properties = type.GetProperties(BindingFlags.Instance|BindingFlags.Public|BindingFlags.NonPublic);
            foreach (var property in properties)
            {
                var getMethod = property.GetGetMethod(true);
                if (getMethod != null && !getMethod.IsPublic)
                {
                   result.AppendLine($"{getMethod.Name} have to be public!");
                }
                var setMethod = property.GetSetMethod();

                if (setMethod!=null&&!setMethod.IsPrivate)
                { 
                    result.AppendLine($"{setMethod.Name} have to be private!");
                }
            }

            return result.ToString();

           
        }
        public string RevealPrivateMethods(string className)
        {
            Console.WriteLine($"All Private Methods of Class: {className}");

            var type = Type.GetType(className);
            Console.WriteLine($"Base Class: {type.BaseType.Name}");
            
             var privateMethod = type.GetMethods(BindingFlags.Instance |  BindingFlags.NonPublic | BindingFlags.Static);
            var result = new StringBuilder();
            foreach (var method in privateMethod)
            {
                result.AppendLine(method.Name);
            }
            return result.ToString();

        }
        public string CollectGettersAndSetters(string className)
        {
            var type = Type.GetType(className);
            var allMethods = type.GetMethods(BindingFlags.Instance |BindingFlags.Public| BindingFlags.NonPublic | BindingFlags.Static);
            var result = new StringBuilder();
            foreach (var method in allMethods)
            {
                if (method.Name.StartsWith("get"))
                {
                    result.AppendLine($"{method.Name} will return {method.ReturnType}");
                }
                else if (method.Name.StartsWith("set"))
                {
                    result.AppendLine($"{method.Name} will set field of {method.ReturnType}");
                }
            }
            return result.ToString();

        }
    }
   
}
