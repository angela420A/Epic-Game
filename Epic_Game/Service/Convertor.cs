using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Epic_Game.Service
{
    public class JsonToViewModel<T> where T : class
    {
        public T Obj { get; set; }
        public JsonToViewModel() { }
        public JsonToViewModel(T obj, string JsonString)
        {
            Obj = obj;
            string[] dic = processString(JsonString);
            foreach (var i in dic)
            {
                var KeyValue = i.Split(':');
                setProperty(KeyValue[1], KeyValue[0]);
            }
        }
        public string[] processString(string str)
        {
            str = str.Replace("\"", "");
            str = str.Substring(1, str.Length - 2);
            return str.Split(',');
        }
        public void setProperty(string Value, string PropertyName)
        {
            PropertyInfo Property = Obj.GetType().GetProperty(PropertyName);
            try
            {
                ParseAndSetProperty(Value, Property);
            }
            catch
            {
                throw new Exception("Property Name doesn't exsist.");
            }
        }
        public void ParseAndSetProperty(string Value, PropertyInfo Property)
        {
            switch (Property.PropertyType.Name)
            {
                case "Nullable`1":
                    Property.SetValue(Obj, Value.ToNullable());
                    break;
                case "Int32":
                    Property.SetValue(Obj, int.Parse(Value));
                    break;
                case "Decimal":
                    Property.SetValue(Obj, decimal.Parse(Value));
                    break;
                case "DateTime":
                    Property.SetValue(Obj, Value.ToDateTime());
                    break;
                default:
                    Property.SetValue(Obj, Value);
                    break;
            }
        }
    }
    public static class ConvertHelper { 
        public static DateTime ToDateTime(this string str)
        {
            var ymd = str.Split('.');
            List<int> list = new List<int>();
            foreach (var i in ymd) list.Add(int.Parse(i));
            return new DateTime(list[0], list[1], list[2]);
        }

        public static int? ToNullable(this string str)
        {
            int result;
            if (str.Equals("")) return null;
            else
            {
                var res = int.TryParse(str, out result);
                if (res) return result;
                else throw new Exception("string cannot be convert to Int32");
            }
        }
    }
        
}