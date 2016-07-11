using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CustomAttributes;

namespace CodeExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            var holder = getAttributes(new AttributesTestClass());
            foreach(string val in holder)
            {
                Console.WriteLine(val);
            }
            var test = Console.Read();
        }

        static List<string> getAttributes(object target)
        {
            Type targetType = target.GetType();
            var properties = targetType.GetProperties();
            List<string> values = new List<string>();
            foreach(var pr in properties)
            {
                var attributes = pr.GetCustomAttributes();
                foreach(var a in attributes)
                {
                    var attributePropeties = a.GetType().GetProperties();
                    foreach(var atrpro in attributePropeties)
                    {
                        values.Add((atrpro.GetValue(a)).ToString());
                    }
                }
            }
            return values;
        }
    }
}
