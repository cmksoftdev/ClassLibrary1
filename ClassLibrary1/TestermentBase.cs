using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Testerment
{
    public class TestermentBase
    {
    }

    public class ViewModelTestHelper<T> where T : class
    {
        PropertyInfo[] properties;
        FieldInfo[] fields;
        MethodInfo[] methods;

        public ViewModelTestHelper()
        {
            properties = typeof(T).GetProperties();
            fields = typeof(T).GetFields();
            methods = typeof(T).GetMethods();
        }

        public void Test(string methodName, object[] parameters, dynamic expectedState, object[] args)
        {
            var sut = (T)Activator.CreateInstance(typeof(T), args);
        }

        public void Test(string methodName, object[] parameters, Dictionary<string, object> expectedState, T sut)
        {
            var method = methods.First(x => x.Name == methodName);
            var result = method.Invoke(sut, parameters);
            foreach (var p in expectedState)
            {
                if(fields.Any(x=>x.Name == p.Key))
                {
                    var field = fields.First(x => x.Name == p.Key).GetValue(sut);
                    if (field != p.Value)
                    {
                        throw new Exception($"The field {p.Key} is not equal to the expected value. Expected = {p.Value} ; Actual = {field}");
                    }
                }
                else if(properties.Any(x => x.Name == p.Key))
                {
                    var property = properties.First(x => x.Name == p.Key).GetValue(sut);
                    if (!property.Equals(p.Value))
                    {
                        throw new Exception($"The property {p.Key} is not equal to the expected value. Expected = {p.Value} ; Actual = {property}");
                    }
                }
                else
                {
                    throw new Exception($"Could not resolve {p.Key}");
                }
            }
        }
    }
}
